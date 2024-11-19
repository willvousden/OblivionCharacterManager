using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using OblivionCharacterManager.Properties;
using UtilityLibrary;

namespace OblivionCharacterManager.CharacterManagement
{
    /// <summary>
    /// Manages save characters' save files.
    /// </summary>
    internal static class SaveManager
    {
        private static readonly string[] m_SaveFileExtensions = { ".ess", ".bak" };
        private static List<string> m_SaveFileNames = new List<string>();
        private static List<OblivionCharacter> m_Characters = new List<OblivionCharacter>();

        /// <summary>
        /// Gets a comparison delegate that compares the names of the two specified characters.
        /// </summary>
        private static Comparison<OblivionCharacter> NameComparison
        {
            get
            {
                return (character1, character2) => string.Compare(character1.Name, character2.Name);
            }
        }

        /// <summary>
        /// Gets a case-insensitive predicate delegate that compares the name of a character to another name.
        /// </summary>
        /// <param name="name">The name that the character should be checked against by the delegate.</param>
        /// <returns>A predicate.</returns>
        private static Predicate<OblivionCharacter> GetNamePredicate(string name)
        {
            return GetNamePredicate(name, false);
        }

        /// <summary>
        /// Gets a predicate delegate that compares the name of a character to another name.
        /// </summary>
        /// <param name="name">The name that the character should be checked against by the delegate.</param>
        /// <param name="caseSensitive"><c>true</c> if the comparison should be case-sensitive; <c>false</c> otherwise.</param>
        /// <returns>A predicate.</returns>
        private static Predicate<OblivionCharacter> GetNamePredicate(string name, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return delegate(OblivionCharacter character)
                       {
                           return character.Name == name;
                       };
            }
            else
            {
                return delegate(OblivionCharacter character)
                       {
                           return character.Name.ToLower() == name.ToLower();
                       };
            }
        }

        /// <summary>
        /// Gets the currently loaded list of characters.
        /// </summary>
        public static OblivionCharacter[] Characters
        {
            get
            {
                return m_Characters.ToArray();
            }
        }

        /// <summary>
        /// Gets the currently active character.
        /// </summary>
        /// <returns>A <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/> object  representing the currently active character, or <c>null</c> if there is none.</returns>
        public static OblivionCharacter GetActiveCharacter()
        {
            if (m_Characters == null)
            {
                LoadCharacters();
            }

            string activeCharacterName = Settings.Default.ActiveCharacterName;
            bool isNullOrEmpty = string.IsNullOrEmpty(activeCharacterName);
            if (!isNullOrEmpty)
            {
                OblivionCharacter activeCharacter = m_Characters.Find(character => character.Name == activeCharacterName);
                if (activeCharacter != null)
                {
                    Common.SetLocalSavePath(Common.RootSaveDirectoryRelative + Path.DirectorySeparatorChar + activeCharacter.Name + Path.DirectorySeparatorChar);
                    return activeCharacter;
                }
                else
                {
                    // No active character found.
                    Common.SetLocalSavePath(Common.RootSaveDirectoryRelative + Path.DirectorySeparatorChar);
                    return null;
                }
            }
            else
            {
                // No active character found.
                Common.SetLocalSavePath(Common.RootSaveDirectoryRelative + Path.DirectorySeparatorChar);
                return null;
            }
        }

        /// <summary>
        /// Determines whether or not the given character name is valid.
        /// </summary>
        /// <param name="name">The character name to validate.</param>
        /// <returns><c>true</c> if the name is valid; <c>false</c> otherwise.</returns>
        public static bool IsValidCharacterName(string name)
        {
            bool isNullOrEmpty = string.IsNullOrEmpty(name);
            if (isNullOrEmpty)
            {
                return false;
            }

            // Check that name does not contain invalid characters.
            char[] invalidCharacters = Path.GetInvalidFileNameChars();
            foreach (char invalidCharacter in invalidCharacters)
            {
                bool contained = name.Contains(invalidCharacter.ToString());
                if (contained)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sets a character as the active character.
        /// </summary>
        /// <param name="character">A <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/> representing the character to set as active.</param>
        public static void SetActiveCharacter(OblivionCharacter character)
        {
            // Check that the character is exists.
            bool characterExists = m_Characters.Exists(character.NamePredicate);
            if (!characterExists)
            {
                throw new ArgumentException("Character not found.", "character");
            }

            Settings.Default.ActiveCharacterName = character.Name;
            Settings.Default.Save();
            character.ApplySettings();
        }

        /// <summary>
        /// Creates and adds a new <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/>.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        public static void CreateCharacter(string name)
        {
            // Make sure the name is not already in use.
            bool characterExists = m_Characters.Exists(GetNamePredicate(name));
            if (characterExists)
            {
                throw new ArgumentException("Name already in use.", "name");
            }

            m_Characters.Add(new OblivionCharacter(name));
        }

        /// <summary>
        /// Deletes a character.
        /// </summary>
        /// <param name="character">An <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/>
        /// object representing the character to delete.</param>
        public static void DeleteCharacter(OblivionCharacter character)
        {
            // Make sure the character exists.
            bool characterExists = m_Characters.Exists(character.NamePredicate);
            if (!characterExists)
            {
                throw new ArgumentException("Character does not exist.", "character");
            }

            if (Settings.Default.ActiveCharacterName == character.Name)
            {
                // Unset the active character.
                Settings.Default.ActiveCharacterName = string.Empty;
            }

            // Remove character and its directory.
            character.LoadSaves();
            foreach (OblivionSave save in character.Saves)
            {
                bool fileExists = File.Exists(save.FilePath);
                if (fileExists)
                {
                    File.Delete(save.FilePath);
                }
            }
            string directoryPath = Common.RootSaveDirectoryAbsolute + Path.DirectorySeparatorChar + character.Name;
            bool directoryExists = Directory.Exists(directoryPath);
            bool isDirectoryEmpty = Directory.GetFileSystemEntries(directoryPath).Length == 0;
            if (directoryExists && isDirectoryEmpty)
            {
                Directory.Delete(directoryPath);
            }

            // Remove from list and save.
            m_Characters.RemoveAll(character.NamePredicate);
            SaveCharacters();
        }

        /// <summary>
        /// Tidies the saves folder and makes sure all characters have been added.
        /// </summary>
        /// <param name="userReponse">A callback method that will be called in the event of a file name conflict.</param>
        public static void TidySaveFiles(UserResponse userReponse)
        {
            // Load all saves.
            FileInfo[] saveFiles = GetSaveFiles();

            // Load saved character names.
            LoadCharacters();

            // Load each save and build a list of character names.
            m_SaveFileNames = new List<string>();
            List<OblivionSave> saves = new List<OblivionSave>();
            foreach (FileInfo saveFile in saveFiles)
            {
                try
                {
                    OblivionSave save = OblivionSave.LoadFromFile(saveFile.FullName);
                    saves.Add(save);
                    m_SaveFileNames.Add(save.FilePath);

                    bool characterExists = m_Characters.Exists(GetNamePredicate(save.CharacterName));
                    if (!characterExists)
                    {
                        m_Characters.Add(new OblivionCharacter(save.CharacterName));
                    }
                }
                catch (InvalidSaveFileException exception)
                {
                    // Ignore save file.
                    Program.HandleException(exception);
                }
            }

            // Make sure that stored active character is in the character list.
            bool activeCharacterExists = m_Characters.Exists(GetNamePredicate(Settings.Default.ActiveCharacterName));
            if (!activeCharacterExists)
            {
                // Unset.
                Settings.Default.ActiveCharacterName = string.Empty;
                Settings.Default.Save();
            }

            // Sort the characters and save them (thus creating their directories).
            m_Characters.Sort(NameComparison);
            SaveCharacters();

            // Make sure each save file is in the correct folder.
            foreach (OblivionSave save in saves)
            {
                string destination = Common.RootSaveDirectoryAbsolute +
                                     Path.DirectorySeparatorChar + save.CharacterName +
                                     Path.DirectorySeparatorChar + save.FileName;
                if (destination == save.FilePath)
                {
                    continue;
                }

                bool alreadyExists = File.Exists(destination);
                if (alreadyExists && save.FilePath != destination)
                {
                    // File conflict - allow user to decide.
                    bool overwrite = userReponse("A file name conflict occurred while " +
                                                 "attempting to move the file " +
                                                 save.FilePath + " to " + destination + "." +
                                                 "Overwrite conflicting file?");
                    if (overwrite)
                    {
                        File.Delete(destination);
                        alreadyExists = false;
                    }
                }

                if (!alreadyExists && save.FilePath != destination)
                {
                    // Check that directory exists.
                    string directoryPath = Path.GetDirectoryName(destination);
                    bool directoryExists = Directory.Exists(directoryPath);
                    if (!directoryExists)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    File.Move(save.FilePath, destination);
                }
            }
        }

        /// <summary>
        /// Moves all saves to the given location.
        /// </summary>
        /// <param name="destinationRoot">The path to which to move the directory.</param>
        /// <param name="overwrite">A value specifying whether or not to overwrite existing files in that location.</param>
        public static void MoveSaveFiles(string destinationRoot, bool overwrite)
        {
            MoveSaveFiles(destinationRoot, message => overwrite);
        }

        /// <summary>
        /// Moves all saves to the given location.
        /// </summary>
        /// <param name="destinationRoot">The path to which to move the directory.</param>
        /// <param name="overwriteUserResonse">A method that delegates the decision of whether or not to overwrite existing files to the user.</param>
        public static void MoveSaveFiles(string destinationRoot, UserResponse overwriteUserResonse)
        {
            bool isPathOk = !Path.IsPathRooted(destinationRoot);
            if (!isPathOk)
            {
                throw new ArgumentException("Path must be relative.", "destinationRoot");
            }

            if (overwriteUserResonse == null)
            {
                throw new ArgumentNullException("overwriteUserResponse", "User reponse delegate must not be null.");
            }

            // Copy contents of directory.
            DirectoryInfo currentDirectory = new DirectoryInfo(Common.RootSaveDirectoryAbsolute);
            FileInfo[] files = currentDirectory.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                // Check that the file exists in the right place (should do, but you never know).
                bool isValid = file.DirectoryName.StartsWith(Common.RootSaveDirectoryAbsolute);
                if (isValid)
                {
                    string relativePath = file.DirectoryName.Substring(Common.RootSaveDirectoryAbsolute.Length);
                    string newDirectoryPath = Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + destinationRoot + Path.DirectorySeparatorChar + relativePath;

                    // Check that destination directory exists.
                    bool newDirectoryExists = Directory.Exists(newDirectoryPath);
                    if (!newDirectoryExists)
                    {
                        Directory.CreateDirectory(newDirectoryPath);
                    }

                    string destinationFileName = newDirectoryPath + Path.DirectorySeparatorChar + file.Name;
                    bool destinationExists = File.Exists(destinationFileName);
                    if (destinationExists)
                    {
                        // Query supplied delegate for overwrite confirmation.
                        string message = destinationFileName + " already exists.  Do you want to overwrite it?";
                        file.CopyTo(destinationFileName, overwriteUserResonse(message));
                    }
                    else
                    {
                        file.CopyTo(destinationFileName);
                    }
                }
            }

            // Make sure all directories exist.
            DirectoryInfo[] directories = currentDirectory.GetDirectories("*", SearchOption.AllDirectories);
            foreach (DirectoryInfo directory in directories)
            {
                // Get new path.
                string relativePath = directory.FullName.Substring(Common.RootSaveDirectoryAbsolute.Length);
                string newPath = Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + destinationRoot + Path.DirectorySeparatorChar + relativePath;

                // Check that directory exists.
                bool directoryExists = Directory.Exists(newPath);
                if (!directoryExists)
                {
                    Directory.CreateDirectory(newPath);
                }
            }

            // Make sure all characters' directories exist.
            if (m_Characters == null)
            {
                m_Characters = new List<OblivionCharacter>();
            }
            foreach (OblivionCharacter character in m_Characters)
            {
                // Check that directory exists.
                string directoryPath = Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + destinationRoot + Path.DirectorySeparatorChar + character.Name;
                bool directoryExists = Directory.Exists(directoryPath);
                if (!directoryExists)
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Adjust save file locations.
                if (character.Saves != null)
                {
                    foreach (OblivionSave save in character.Saves)
                    {
                        save.FilePath = Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + destinationRoot + Path.DirectorySeparatorChar + character.Name + Path.DirectorySeparatorChar + save.FileName;
                    }
                }
            }

            // Delete old files - this is done separately so that a failure willnot result in some
            // files being in the new directory and some in the old one.
            currentDirectory.Delete(true);

            // Success – set new save directory.
            Common.RootSaveDirectoryRelative = destinationRoot;
        }

        /// <summary>
        /// Loads the saved characters from file.
        /// </summary>
        public static void LoadCharacters()
        {
            bool fileExists = File.Exists(Common.CharactersFileName);
            if (fileExists)
            {
                using (FileStream stream = File.OpenRead(Common.CharactersFileName))
                {
                    LoadCharacterData(stream);
                }
            }
            else
            {
                // Character file does not exist.
                m_Characters = new List<OblivionCharacter>();
            }
        }

        /// <summary>
        /// Saves the currently cached characters to file.
        /// </summary>
        public static void SaveCharacters()
        {
            if (m_Characters == null)
            {
                m_Characters = new List<OblivionCharacter>();
            }

            m_Characters.Sort(NameComparison);

            // Check that OCM main directory exists.
            string directoryPath = Path.GetDirectoryName(Path.GetFullPath(Common.CharactersFileName));
            bool directoryExists = Directory.Exists(directoryPath);
            if (!directoryExists)
            {
                // Create directory.
                Directory.CreateDirectory(directoryPath);
            }

            // Check that characters' individual subdirectories exist.
            foreach (OblivionCharacter character in m_Characters)
            {
                directoryPath = Common.RootSaveDirectoryAbsolute + Path.DirectorySeparatorChar + character.Name;
                directoryExists = Directory.Exists(directoryPath);
                if (!directoryExists)
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }

            // Get active character and apply its settings.
            OblivionCharacter activeCharacter = GetActiveCharacter();
            if (activeCharacter != null)
            {
                activeCharacter.ApplySettings();
            }

            // Serialise characters.
            using (Stream stream = File.Create(Common.CharactersFileName))
            {
                WriteCharacterData(stream);
            }
        }

        /// <summary>
        /// Deletes the file in which character information is kept.
        /// </summary>
        public static void DeleteCharactersFile()
        {
            bool fileExists = File.Exists(Common.CharactersFileName);
            if (fileExists)
            {
                File.Delete(Common.CharactersFileName);
            }
        }

        /// <summary>
        /// Gets all save files in the root save directory and any subdirectories.
        /// </summary>
        /// <returns>An array of <see cref="System.IO.FileInfo"/> objects representing the save files.</returns>
        public static FileInfo[] GetSaveFiles()
        {
            return GetSaveFiles(string.Empty);
        }

        /// <summary>
        /// Gets all save files in the specified subdirectory.
        /// </summary>
        /// <param name="subDirectory">The subdirectory of the root save directory in which to search.</param>
        /// <returns>An array of <see cref="System.IO.FileInfo"/> objects representing the save files.</returns>
        public static FileInfo[] GetSaveFiles(string subDirectory)
        {
            DirectoryInfo saveDirectory = new DirectoryInfo(Common.RootSaveDirectoryAbsolute + Path.DirectorySeparatorChar + subDirectory);
            if (saveDirectory.Exists)
            {
                FileInfo[][] saveFiles = new FileInfo[m_SaveFileExtensions.Length][];
                for (int i = 0; i < m_SaveFileExtensions.Length; i++)
                {
                    string extension = m_SaveFileExtensions[i];
                    saveFiles[i] = saveDirectory.GetFiles("*" + extension, SearchOption.AllDirectories);
                }

                return Utility.ConcatenateArrays(saveFiles);
            }
            else
            {
                return new FileInfo[0];
            }
        }

        /// <summary>
        /// Writes current character data to a stream.
        /// </summary>
        /// <param name="stream">The stream to which to write the character data.</param>
        private static void WriteCharacterData(Stream stream)
        {
            if (m_Characters == null)
            {
                m_Characters = new List<OblivionCharacter>();
            }

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, m_Characters);
        }

        /// <summary>
        /// Loads character data from a stream.
        /// </summary>
        /// <param name="stream">The stream from which to load the character data.</param>
        private static void LoadCharacterData(Stream stream)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<OblivionCharacter> characters = formatter.Deserialize(stream) as List<OblivionCharacter>;
                if (characters != null)
                {
                    m_Characters = characters;
                    m_Characters.Sort(NameComparison);
                }
                else
                {
                    // Character file is not valid.
                    m_Characters = new List<OblivionCharacter>();
                }
            }
            catch (SerializationException exception)
            {
                throw new InvalidDataException("Invalid character data encountered.", exception);
            }
        }
    }
}