using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using OblivionCharacterManager.CharacterManagement;
using OblivionCharacterManager.Properties;
using UtilityLibrary;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Contains members whose use is common to the entire assembly.
    /// </summary>
    internal static class Common
    {
        private static string m_CharactersFileName = "Characters.dat";
        private static InitializationFileInfo m_OblivionIni;
        private static Encoding m_Encoding = Encoding.UTF8;
        private static DateTimeFormatInfo m_DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
        private static string m_LogDirectory = "Logs";
        private static string m_ApplicationInstallPath = Environment.CurrentDirectory.TrimEnd('\\');

        /// <summary>
        /// Attempts to get the application's install path from the registry. If this fails, the current directory will be returned.
        /// </summary>
        internal static string ApplicationInstallPath
        {
            get
            {
                return m_ApplicationInstallPath;
            }
            set
            {
                m_ApplicationInstallPath = value;
            }
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        internal static string ApplicationName
        {
            get
            {
                return Utility.GetAssemblyName();
            }
        }

        /// <summary>
        /// Gets the version of the application.
        /// </summary>
        internal static Version ApplicationVersion
        {
            get
            {
                return Utility.GetAssemblyVersion();
            }
        }

        /// <summary>
        /// Gets the copyright information of the application.
        /// </summary>
        internal static string ApplicationCopyright
        {
            get
            {
                return Utility.GetAssemblyCopyright();
            }
        }

        /// <summary>
        /// Gets a <see cref="UtilityLibrary.InitializationFileInfo"/> object representing the Oblivion.ini file.
        /// </summary>
        internal static InitializationFileInfo OblivionIni
        {
            get
            {
                return m_OblivionIni;
            }
        }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        internal static Encoding Encoding
        {
            get
            {
                return m_Encoding;
            }
            set
            {
                m_Encoding = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Globalization.DateTimeFormatInfo"/> object used for formatting <see cref="System.DateTime"/> objects.
        /// </summary>
        internal static DateTimeFormatInfo DateTimeFormatInfo
        {
            get
            {
                return m_DateTimeFormatInfo;
            }
            set
            {
                m_DateTimeFormatInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the directory to which errors are logged.
        /// </summary>
        internal static string LogDirectory
        {
            get
            {
                return m_LogDirectory;
            }
            set
            {
                m_LogDirectory = value;
            }
        }

        /// <summary>
        /// Gets the stored install path for Oblivion.
        /// </summary>
        internal static string OblivionInstallPath
        {
            get
            {
                bool isNullOrEmpty = string.IsNullOrEmpty(Settings.Default.OblivionInstallPath);
                if (!isNullOrEmpty)
                {
                    return Settings.Default.OblivionInstallPath;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Settings.Default.OblivionInstallPath = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets the path to Oblivion's local application data directory.
        /// </summary>
        internal static string OblivionAppDataPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Oblivion";
            }
        }

        /// <summary>
        /// Gets the path to Oblivion's 'My Games' directory.
        /// </summary>
        internal static string OblivionMyGamesPath
        {
            get
            {
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                if (myDocuments[myDocuments.Length - 1] != Path.DirectorySeparatorChar)
                {
                    myDocuments += Path.DirectorySeparatorChar;
                }

                return  myDocuments + "My Games" + Path.DirectorySeparatorChar + "Oblivion";
            }
        }

        /// <summary>
        /// Gets the path to Oblivion's Data directory.
        /// </summary>
        internal static string OblivionDataPath
        {
            get
            {
                return OblivionInstallPath + Path.DirectorySeparatorChar + "Data";
            }
        }

        /// <summary>
        /// Gets or sets the relative path to the subdirectory of Oblivion's My Games directory in which saves are kept.
        /// </summary>
        internal static string RootSaveDirectoryRelative
        {
            get
            {
                return Settings.Default.RootSaveDirectory;
            }
            set
            {
                Settings.Default.RootSaveDirectory = value;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets the absolute path to the subdirectory of  Oblivion's My Games directory in which saves are kept.
        /// </summary>
        internal static string RootSaveDirectoryAbsolute
        {
            get
            {
                return OblivionMyGamesPath + Path.DirectorySeparatorChar + Settings.Default.RootSaveDirectory;
            }
        }

        /// <summary>
        /// Gets the path to the Oblivion.exe executable.
        /// </summary>
        internal static string OblivionExecutablePath
        {
            get
            {
                if (OblivionInstallPath != null)
                {
                    return OblivionInstallPath + Path.DirectorySeparatorChar + "Oblivion.exe";
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the path to the Oblivion Mod Manager exectutable.
        /// </summary>
        internal static string ObmmPath
        {
            get
            {
                return OblivionInstallPath + Path.DirectorySeparatorChar + "OblivionModManager.exe";
            }
        }

        /// <summary>
        /// Gets the path to to the OBSE
        /// </summary>
        internal static string ObseLoaderPath
        {
            get
            {
                return OblivionInstallPath + Path.DirectorySeparatorChar + "obse_loader.exe";
            }
        }

        /// <summary>
        /// Gets a value indicating whether or Oblivion Mod Manager is installed.
        /// </summary>
        internal static bool IsObmmInstalled
        {
            get
            {
                return File.Exists(ObmmPath);
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not Oblivion Script Extender is installed.
        /// </summary>
        internal static bool IsObseInstalled
        {
            get
            {
                return File.Exists(ObseLoaderPath);
            }
        }

        /// <summary>
        /// Gets the path to the Plugins.txt file used by Oblivion to store the plugin load order.
        /// </summary>
        internal static string OblivionPluginsTxtPath
        {
            get
            {
                return OblivionAppDataPath + Path.DirectorySeparatorChar + "Plugins.txt";
            }
        }

        /// <summary>
        /// Gets the name of the file containing activeCharacter information.
        /// </summary>
        public static string CharactersFileName
        {
            get
            {
                return m_CharactersFileName;
            }
            set
            {
                m_CharactersFileName = value;
            }
        }

        /// <summary>
        /// Initialises static members.
        /// </summary>
        static Common()
        {
            string installPath = GetApplicationInstallPath();
            if (installPath != null)
            {
                m_ApplicationInstallPath = installPath;
            }

            m_OblivionIni = new InitializationFileInfo(OblivionMyGamesPath + Path.DirectorySeparatorChar + "Oblivion.ini");
        }

        /// <summary>
        /// Checks that the application log directory exists and creates it if it doesn't.
        /// </summary>
        /// <exception cref="System.IO.DirectoryNotFoundException">The log directory's parent directory was not found (for example, it is in an unmapped drive).</exception>
        internal static void CheckLogDirectory()
        {
            bool exists = Directory.Exists(LogDirectory);
            if (!exists)
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        /// <summary>
        /// Obtains the Oblivion install path from the registry
        /// </summary>
        /// <returns>The Oblivion install path as indicated by the registry, or <c>null</c> if it cannot be found.</returns>
        internal static string GetOblivionInstallPathFromRegistry()
        {
            RegistryKey oblivionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Bethesda Softworks\Oblivion");
            if (oblivionKey != null)
            {
                object installPathValue = oblivionKey.GetValue("Installed Path");
                if (installPathValue != null)
                {
                    return installPathValue.ToString().TrimEnd('\\');
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the path used by Oblivion to store save files.
        /// </summary>
        /// <returns>The local save path, relative to Oblivion's 'My Games' directory.</returns>
        internal static string GetLocalSavePath()
        {
            return m_OblivionIni["General", "SLocalSavePath"];
        }

        /// <summary>
        /// Sets the path used by Oblivion to store save files.
        /// </summary>
        /// <param name="path">The local save path, relative to Oblivion's 'My Games' directory. Must be of the form directory\subdirectory\, i.e. one trailing backslash and none preceeding.</param>
        internal static void SetLocalSavePath(string path)
        {
            // Attempt to create a DirectoryInfo object - this will throw an exception for us if
            // the path is invalid.
            DirectoryInfo pathInfo = new DirectoryInfo(path);

            // Validate path.
            bool isNullOrEmpty = string.IsNullOrEmpty(path);
            bool isRooted = Path.IsPathRooted(path);
            string directoryName = Path.GetDirectoryName(path);
            char[] invalidCharacters = Path.GetInvalidPathChars();
            bool containsInvalidCharacters = false;
            path = path.Trim('\\') + '\\';
            foreach (char invalidCharacter in invalidCharacters)
            {
                int index = Array.IndexOf<char>(path.ToCharArray(), invalidCharacter);
                if (index >= 0)
                {
                    containsInvalidCharacters = true;
                    break;
                }
            }

            if (isNullOrEmpty)
            {
                throw new ArgumentException("Path cannot be null or empty.", "path");
            }
            else if (containsInvalidCharacters)
            {
                throw new ArgumentException("Path contains invalid characters.", "path");
            }
            else if (isRooted)
            {
                throw new ArgumentException("Path must be relative.", "path");
            }
            else if (directoryName + '\\' != path)
            {
                throw new ArgumentException("Path must be to a directory.", "path");
            }

            // Completed validation, hopefully it's ok!
            m_OblivionIni["General", "SLocalSavePath"] = path;
        }

        /// <summary>
        /// Displays a message box with the default caption.
        /// </summary>
        /// <param name="text">The text to be displayed in the message box.</param>
        /// <param name="buttons">The buttons to display on the message box.</param>
        /// <param name="icon">The icons to display on the message box.</param>
        internal static DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, ApplicationName, buttons, icon);
        }

        /// <summary>
        /// Displays a message box with the default caption.
        /// </summary>
        /// <param name="owner">The window under which to show the message box.</param>
        /// <param name="text">The text to be displayed in the message box.</param>
        /// <param name="buttons">The buttons to display on the message box.</param>
        /// <param name="icon">The icons to display on the message box.</param>
        internal static DialogResult ShowMessageBox(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(owner, text, ApplicationName, buttons, icon);
        }

        /// <summary>
        /// Displays a message box with the default caption.
        /// </summary>
        /// <param name="text">The text to be displayed in the message box.</param>
        /// <param name="buttons">The buttons to display on the message box.</param>
        /// <param name="icon">The icons to display on the message box.</param>
        /// <param name="defaultButton">The button that will initially have focus when the message box is shown.</param>
        internal static DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(text, ApplicationName, buttons, icon, defaultButton);
        }

        /// <summary>
        /// Displays a message box with the default caption.
        /// </summary>
        /// <param name="owner">The window under which to show the message box.</param>
        /// <param name="text">The text to be displayed in the message box.</param>
        /// <param name="buttons">The buttons to display on the message box.</param>
        /// <param name="icon">The icons to display on the message box.</param>
        /// <param name="defaultButton">The button that will initially have focus when the message box is shown.</param>
        internal static DialogResult ShowMessageBox(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(owner, text, ApplicationName, buttons, icon, defaultButton);
        }

        /// <summary>
        /// Gets the application's install path from the registry.
        /// </summary>
        /// <returns>The fully qualified install path of the application as stored in the registry, or <c>null</c> if it cannot be found.</returns>
        private static string GetApplicationInstallPath()
        {
            // Get registry info.
            string installPath;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + ApplicationName);
            if (key != null)
            {
                object installPathValue = key.GetValue("InstallPath");
                bool isEmpty = installPathValue == null || String.IsNullOrEmpty(installPathValue.ToString());
                if (!isEmpty)
                {
                    installPath = installPathValue.ToString();
                    bool exists = Directory.Exists(installPath);
                    if (!exists)
                    {
                        // Indicated path does not exist.
                        installPath = Environment.CurrentDirectory;
                    }
                }
                else
                {
                    // Value was empty.
                    installPath = Environment.CurrentDirectory;
                }
            }
            else
            {
                // No key found.
                installPath = Environment.CurrentDirectory;
            }

            return installPath.TrimEnd('\\');
        }
    }
}