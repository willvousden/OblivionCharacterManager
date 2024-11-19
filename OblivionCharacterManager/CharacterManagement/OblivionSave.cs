using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OblivionCharacterManager.CharacterManagement
{
    /// <summary>
    /// Represents an Oblivion save file.
    /// </summary>
    [Serializable]
    public class OblivionSave
    {
        private const int HoursInDay = 24;
        private const int MinutesInHour = 60;
        private const int SecondsInMinute = 60;
        private const string SaveFileIdentifier = "TES4SAVEGAME";
        private static readonly Encoding FileEncoding = Encoding.ASCII;

        /// <summary>
        /// Loads save information from a file.
        /// </summary>
        /// <param name="filePath">The path to the file to load.</param>
        /// <returns>A <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> containing the file's save information.</returns>
        /// <exception cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException">The file is not a valid save file.</exception>
        public static OblivionSave LoadFromFile(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            OblivionSave save = new OblivionSave();
            save.m_FilePath = filePath;
            save.LoadFile();

            return save;
        }

        /// <summary>
        /// Gets the current plugin load order used by Oblivion.
        /// </summary>
        /// <returns>An array of s containing plugin file names in the order in which they are loaded by Oblivion.</returns>
        public static string[] GetPluginLoadOrder()
        {
            bool fileExists = File.Exists(Common.OblivionPluginsTxtPath);
            List<string> pluginFileNames = new List<string>();
            if (fileExists)
            {
                using (StreamReader reader = File.OpenText(Common.OblivionPluginsTxtPath))
                {
                    while (!reader.EndOfStream)
                    {
                        // Read line and check that it has content and is not a comment.
                        string line = reader.ReadLine().Trim();
                        if (line != string.Empty && line[0] != '#')
                        {
                            pluginFileNames.Add(line);
                        }
                    }
                }
            }

            return pluginFileNames.ToArray();
        }

        /// <summary>
        /// Gets a list of all plugin files in the Oblivion data directory.
        /// </summary>
        /// <returns>An array of <see cref="System.String"/>s containing the plugins found.</returns>
        public static string[] GetPlugins()
        {
            string[] pluginPaths = Directory.GetFiles(Common.OblivionDataPath, "*.esp");
            for (int i = 0; i < pluginPaths.Length; i++)
            {
                pluginPaths[i] = Path.GetFileName(pluginPaths[i]);
            }
            return pluginPaths;
        }

        /// <summary>
        /// Reads a zero terminated string that is prefixed with a byte containing its length.
        /// </summary>
        /// <param name="stream">The stream from which to read the string.</param>
        /// <returns>The string that was read.</returns>
        /// <exception cref="EndOfStreamException">Thrown if there are not enough data present in the stream to read the complete string.</exception>
        /// <exception cref="InvalidDataException">Thrown if the stream does not contain a valid bzstring.</exception>
        private static string ReadBzstring(Stream stream)
        {
            // For this, we can simply treat it as a bstring and cut the final character off
            // (after checking that it is a null character).
            string bzstring = ReadBstring(stream);
            if (bzstring[bzstring.Length - 1] == '\0')
            {
                return bzstring.Substring(0, bzstring.Length - 1);
            }
            else
            {
                // No terminator activeCharacter found.
                throw new InvalidDataException("Could not read a correctly formatted bzstring from the given stream.");
            }
        }

        /// <summary>
        /// Reads a string that is prefixed with a byte containing its length.
        /// </summary>
        /// <param name="stream">The stream from which to read the string.</param>
        /// <returns>The string that was read.</returns>
        /// <exception cref="EndOfStreamException">Thrown if there is not enough datapresent in the stream to read the complete string.</exception>
        private static string ReadBstring(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream, FileEncoding);
            byte stringLength = reader.ReadByte();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < stringLength; i++)
            {
                stringBuilder.Append(reader.ReadChar());
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Reads a zero terminated string.
        /// </summary>
        /// <param name="stream">The stream from which to read the string.</param>
        /// <returns>The string that was read.</returns>
        /// <exception cref="EndOfStreamException">Thrown if there is not enough data present in the stream to read the complete string.</exception>
        private static string ReadZstring(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream, FileEncoding);
            char currentCharacter;
            StringBuilder stringBuilder = new StringBuilder();
            while ((currentCharacter = reader.ReadChar()) != '\0')
            {
                stringBuilder.Append(currentCharacter);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Reads a UTC systemtime structure and converts it to a <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="stream">The stream from which to read the systemtime structure.</param>
        /// <returns>A <see cref="System.DateTime"/> object representing the time contained in the systemtime structure.</returns>
        private static DateTime ReadSystemtime(Stream stream)
        {
            // Read systemtime components.
            BinaryReader reader = new BinaryReader(stream, FileEncoding);
            ushort year = reader.ReadUInt16();
            ushort month = reader.ReadUInt16();
            ushort dayOfWeek = reader.ReadUInt16();
            ushort day = reader.ReadUInt16();
            ushort hour = reader.ReadUInt16();
            ushort minute = reader.ReadUInt16();
            ushort second = reader.ReadUInt16();
            ushort millisecond = reader.ReadUInt16();

            // Convert to DateTime.
            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Constructs a bitmap stored as a raw bitmap.
        /// </summary>
        /// <param name="stream">The stream from which to read the bitmap.</param>
        /// <returns>The constructed bitmap bitmap.</returns>
        /// <exception cref="EndOfStreamException">Thrown if there is not enough data present in the stream to read the complete string.</exception>
        private static Bitmap ReadBitmap(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream, FileEncoding);

            // Get size of remaining bitmap data.
            uint size = reader.ReadUInt32();

            // Read dimensions.
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();

            // Calculate length of image data.
            int length = (int)size - 2 * sizeof(int);
            if (length != width * height * 3)
            {
                throw new InvalidDataException("Incorrect size field in save screenshot data.");
            }

            // Read data from stream prior to writing.
            byte[] pixelData;
            try
            {
                pixelData = reader.ReadBytes((int)size - 2 * sizeof(int));
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new EndOfStreamException(null, exception);
            }

            // Lock bitmap data into memory.
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Rectangle lockArea = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(lockArea, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Flip red and blue channels.
            int pixelSize = 3;
            int stride = bitmapData.Stride;
            for (int y = 0; y < height; y++)
            {
                int rowIndex = y * stride;
                for (int x = 0; x < width; x++)
                {
                    int scanOffset = x * pixelSize;
                    byte placeHolder = pixelData[rowIndex + scanOffset];
                    pixelData[rowIndex + scanOffset] = pixelData[rowIndex + scanOffset + 2];
                    pixelData[rowIndex + scanOffset + 2] = placeHolder;
                }
            }

            // Write to image data in memory.
            Marshal.Copy(pixelData, 0, bitmapData.Scan0, pixelData.Length);

            // Unlock bitmap data and return built image.
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }

        private string m_FilePath;
        private Version m_OblivionVersion;
        private DateTime? m_SaveTime;
        private long m_SaveNumber;
        private string m_CharacterName;
        private int m_CharacterLevel;
        private string m_CharacterLocation;
        private TimeSpan m_GameTime;
        private TimeSpan m_PlayTime;
        private DateTime m_LastSave;
        private Image m_Screenshot;
        private string[] m_PluginFileNames;

        /// <summary>
        /// Gets or sets the path to the save file.
        /// </summary>
        public string FilePath
        {
            get
            {
                return m_FilePath;
            }
            set
            {
                m_FilePath = value;
            }
        }

        /// <summary>
        /// Gets the name of the save file.
        /// </summary>
        public string FileName
        {
            get
            {
                return Path.GetFileName(m_FilePath);
            }
        }

        /// <summary>
        /// Gets the Oblivion version of the save.
        /// </summary>
        public Version OblivionVersion
        {
            get
            {
                return m_OblivionVersion;
            }
        }

        /// <summary>
        /// Gets the time that the save file was created. <c>null</c> if the version is less than 0.82.
        /// </summary>
        public DateTime? SaveTime
        {
            get
            {
                return m_SaveTime;
            }
        }

        /// <summary>
        /// Gets the save number of the file.
        /// </summary>
        public long SaveNumber
        {
            get
            {
                return m_SaveNumber;
            }
        }

        /// <summary>
        /// Gets the ccharacter's name.
        /// </summary>
        public string CharacterName
        {
            get
            {
                return m_CharacterName;
            }
        }

        /// <summary>
        /// Gets the activeCharacter's level.
        /// </summary>
        public int CharacterLevel
        {
            get
            {
                return m_CharacterLevel;
            }
        }

        /// <summary>
        /// Gets the activeCharacter's location.
        /// </summary>
        public string CharacterLocation
        {
            get
            {
                return m_CharacterLocation;
            }
        }

        /// <summary>
        /// Gets the total elapsed game time (starts at 1 day, 1 hour).
        /// </summary>
        public TimeSpan GameTime
        {
            get
            {
                return m_GameTime;
            }
        }

        /// <summary>
        /// Gets the total play time for the save file.
        /// </summary>
        public TimeSpan PlayTime
        {
            get
            {
                return m_PlayTime;
            }
        }

        /// <summary>
        /// Gets the time of the last save to the file.
        /// </summary>
        public DateTime LastSave
        {
            get
            {
                return m_LastSave;
            }
        }

        /// <summary>
        /// Gets the screenshot of the save.
        /// </summary>
        public Image Screenshot
        {
            get
            {
                return m_Screenshot;
            }
        }

        /// <summary>
        /// Gets a list of all plugins file names (with extensions) used by the save.
        /// </summary>
        public string[] PluginFileNames
        {
            get
            {
                return m_PluginFileNames;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> instance.
        /// </summary>
        private OblivionSave()
        {
        }

        /// <summary>
        /// Attempts to load the save file.
        /// </summary>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if the file cannot be found.</exception>
        /// <exception cref="System.IO.IOException">Thrown if the file cannot be accessed.</exception>
        /// <exception cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException">Thrown if the file is not an valid save file.</exception>
        public void LoadFile()
        {
            using (FileStream stream = new FileStream(m_FilePath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(stream, FileEncoding);

                try
                {
                    #region Process file header

                    // Read and confirm fileId string.
                    string fileId = FileEncoding.GetString(reader.ReadBytes(SaveFileIdentifier.Length));
                    if (fileId != SaveFileIdentifier)
                    {
                        throw new InvalidSaveFileException(m_FilePath);
                    }

                    // Read version.
                    m_OblivionVersion = new Version(reader.ReadByte(), reader.ReadByte());

                    if (m_OblivionVersion.Minor > 82)
                    {
                        // Read save time.
                        m_SaveTime = ReadSystemtime(stream);
                    }
                    else
                    {
                        // Save time not present in this version.
                        m_SaveTime = null;
                    }

                    // Skip over the ulong represntation of the minor version.
                    reader.ReadBytes(4);

                    #endregion

                    #region Process save header

                    // Determine ensuing header size.
                    uint headerSize = reader.ReadUInt32();

                    // Read save number (don't know what this is based on).
                    m_SaveNumber = reader.ReadUInt32();

                    // Read character details.
                    m_CharacterName = ReadBzstring(stream);
                    m_CharacterLevel = reader.ReadUInt16();
                    m_CharacterLocation = ReadBzstring(stream);

                    // Determine elapsed game time.
                    double totalGameDays = reader.ReadSingle();
                    double totalGameHours = totalGameDays * (double)HoursInDay;
                    double totalGameMinutes = totalGameHours * (double)MinutesInHour;
                    double totalGameSeconds = totalGameMinutes * (double)SecondsInMinute;
                    int gameDays = (int)totalGameDays;
                    int gameHours = (int)(totalGameHours - Math.Round(totalGameDays, 0) * (double)HoursInDay);
                    int gameMinutes = (int)(totalGameMinutes - Math.Round(totalGameHours, 0) * (double)MinutesInHour);
                    int gameSeconds = (int)(totalGameSeconds - Math.Round(totalGameMinutes, 0) * (double)SecondsInMinute);
                    m_GameTime = new TimeSpan(gameDays, gameHours, gameMinutes, gameSeconds);

                    // Read the number of elapsed ticks (milliseconds) - note that since it is
                    // stored as a 32-bit integer, its value will wrap to zero after around 49.7
                    // days.
                    uint ticks = reader.ReadUInt32();
                    m_PlayTime = new TimeSpan((long)ticks * 10000);

                    // Read last save time.
                    m_LastSave = ReadSystemtime(stream);

                    // Read screenshot data.
                    m_Screenshot = ReadBitmap(stream);

                    #endregion

                    #region Process plugin list

                    // Read the number of plugins.
                    byte pluginCount = reader.ReadByte();

                    // Read plugin file names.
                    m_PluginFileNames = new string[pluginCount];
                    for (int i = 0; i < pluginCount; i++)
                    {
                        m_PluginFileNames[i] = ReadBstring(stream);
                    }

                    #endregion
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    // Not enough data present.
                    throw new InvalidSaveFileException(m_FilePath, exception);
                }
                catch (EndOfStreamException exception)
                {
                    // Not enough data present.
                    throw new InvalidSaveFileException(m_FilePath, exception);
                }
            }
        }

        /// <summary>
        /// Gets a string representation of the current <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> object.
        /// </summary>
        /// <returns>A string representation of the current <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> object.</returns>
        public override string ToString()
        {
            return FileName;
        }
    }
}