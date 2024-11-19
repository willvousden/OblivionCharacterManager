using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.CharacterManagement;
using OblivionCharacterManager.Properties;
using UtilityLibrary;
using Utility = UtilityLibrary.Utility;

namespace OblivionCharacterManager
{
    /// <summary>
    /// The main program class.
    /// </summary>
    internal static class Program
    {
        private static MainForm m_MainForm;
        private static InstanceManager m_InstanceManager;

        /// <summary>
        /// Handles an unexpected exception, logging it and informing the user if necessary.
        /// </summary>
        /// <param name="exception">The exception to be handled.</param>
        public static void HandleException(Exception exception)
        {
            HandleException(exception, null);
        }

        /// <summary>
        /// Handles an unexpected exception, logging it and informing the user if necessary.
        /// </summary>
        /// <param name="exception">The exception to be handled.</param>
        /// <param name="stateMessage">An additional message to be saved describing the circumstances under which the exception occured.</param>
        public static void HandleException(Exception exception, string stateMessage)
        {
            Debug.Fail(stateMessage ?? "An unexpected exception was caught.", exception.Message);
        }

        /// <summary>
        /// Checks a given path for essential files/subdirectories in order to determine whether or not Oblivion is installed in
        /// the directory.  Note that it is not fool proof.
        /// </summary>
        /// <param name="path">The path to check.</param>
        public static bool CheckInstallDirectory(string path)
        {
            if (path == null)
            {
                return false;
            }

            bool filesPresent = Directory.Exists(path)
                                && Directory.Exists(path + Path.DirectorySeparatorChar + "Data")
                                && File.Exists(path + Path.DirectorySeparatorChar + "Oblivion_default.ini")
                                && File.Exists(path + Path.DirectorySeparatorChar + "Oblivion.exe");
            if (!filesPresent)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main(string[] args)
        {
            bool exceptionCaught = false;
            try
            {
                bool initialisedSuccess = Initialise(args);
                if (!initialisedSuccess)
                {
                    // Could not initialise application - bail out here and signal failure to the OS.
                    return 1;
                }

                // Organise saves.
                SaveManager.TidySaveFiles(MainForm.MessageBoxUserReponse);

                // Show main form.
                using (m_MainForm = new MainForm())
                {
                    Application.Run(m_MainForm);
                }

                return 0;
            }
            catch (Exception exception)
            {
                HandleFatalException(exception);
                exceptionCaught = true;

                return 1;
            }
            finally
            {
                if (!exceptionCaught)
                {
                    Finalise();
                }
            }
        }

        /// <summary>
        /// Checks that essential files and directories are present.
        /// </summary>
        /// <returns>A value indicating whether or not the check was successful.</returns>
        private static bool Initialise(string[] args)
        {
            Environment.CurrentDirectory = Common.ApplicationInstallPath;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            // Set error log directory for easy access while debugging.
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Common.LogDirectory = myDocuments + Path.DirectorySeparatorChar + @"Logs" + Path.DirectorySeparatorChar + Common.ApplicationName;
#else
            // Application has been installed and is running in release configuration, so run from
            // the install directory.
            Environment.CurrentDirectory = Common.ApplicationInstallPath;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            // Determine whether an insatnce of the program is already running.
            m_InstanceManager = new InstanceManager(Common.ApplicationName);
            if (!m_InstanceManager.IsOnlyInstance)
            {
                // Another instance is already running.
                m_InstanceManager.Signal();
                return false;
            }
            else
            {
                // Register handler to be called when the user attempts to start another instance.
                m_InstanceManager.Signalled += delegate(object sender, EventArgs e)
                                               {
                                                   if (m_MainForm != null)
                                                   {
                                                       m_MainForm.BringForward(!Debugger.IsAttached); // The debugger doesn't seem to like flashing windows :(
                                                   }
                                               };
            }
#endif

            if (Common.OblivionInstallPath == null)
            {
                // Attempt to autodetect install path.
                Common.OblivionInstallPath = Common.GetOblivionInstallPathFromRegistry();
            }

            // Check validity of path.
            bool isPathValid = Common.OblivionInstallPath != null &&
                               CheckInstallDirectory(Common.OblivionInstallPath);
            if (!isPathValid)
            {
                DialogResult result;
                {
                    string text = "Could not find the Oblivion install directory.  Do you want to locate it yourself?";
                    result = Common.ShowMessageBox(text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }

                if (result == DialogResult.Yes)
                {
                    // Prompt user to locate directory.
                    using (FolderBrowserDialog installPathFolderBrowserDialogue = new FolderBrowserDialog())
                    {
                        installPathFolderBrowserDialogue.ShowNewFolderButton = false;
                        installPathFolderBrowserDialogue.Description = "Please locate the Oblivion install directory.";
                        while (!isPathValid)
                        {
                            result = installPathFolderBrowserDialogue.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                isPathValid = CheckInstallDirectory(installPathFolderBrowserDialogue.SelectedPath);
                                if (!isPathValid)
                                {
                                    {
                                        string text = "Could not find Oblivion install files in specified folder.";
                                        result = Common.ShowMessageBox(text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                    }

                                    if (result != DialogResult.Retry)
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            // Check that Oblivion.ini is present.
            bool userIniPresent = File.Exists(Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + "Oblivion.ini");
            if (!userIniPresent)
            {
                bool directoryExists = Directory.Exists(Common.OblivionMyGamesPath);
                if (!directoryExists)
                {
                    Directory.CreateDirectory(Common.OblivionMyGamesPath);
                }

                // Not present—copy the default .ini file.
                File.Copy(Common.OblivionInstallPath + Path.DirectorySeparatorChar + "Oblivion_default.ini", Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + "Oblivion.ini");
            }

            if (Settings.Default.FormSettings == null)
            {
                Settings.Default.FormSettings = new FormSettings(true);
            }
            BaseForm.FormSettings = Settings.Default.FormSettings;

            // Check completed successfully.
            return true;
        }

        /// <summary>
        /// Performs cleanup operations before the process terminates.
        /// </summary>
        private static void Finalise()
        {
            try
            {
                Settings.Default.Save();
            }
            finally
            {
                if (m_InstanceManager != null)
                {
                    m_InstanceManager.Dispose();
                }
            }
        }

        /// <summary>
        /// Launches Oblivion.
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded; <c>false</c> otherwise.</returns>
        internal static bool LaunchOblivion()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Common.OblivionInstallPath;

            // Try and launch via a custom command line if there is one.
            bool commandLineSpecified = !string.IsNullOrEmpty(Settings.Default.OblivionLaunchCommandLine);
            if (commandLineSpecified)
            {
                string commandLine = Settings.Default.OblivionLaunchCommandLine;
                bool commandLineIsNullOrEmpty = string.IsNullOrEmpty(commandLine);
                if (!commandLineIsNullOrEmpty)
                {
                    try
                    {
                        startInfo.FileName = commandLine;
                        Process.Start(startInfo);
                    }
                    catch (Win32Exception exception)
                    {
                        // Command line was invalid.
                        string text = "Invalid command line specified:" + Environment.NewLine +
                                      commandLine;
                        Common.ShowMessageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        LogException(exception, "Execution of custom command line failed when launching Oblivion.");

                        return false;
                    }
                }
            }
            else if (Settings.Default.LoadObseOnOblivionLaunch)
            {
                if (Common.IsObseInstalled)
                {
                    startInfo.FileName = Common.ObseLoaderPath;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                startInfo.FileName = Common.OblivionExecutablePath;
            }

            Process.Start(startInfo);
            return true;
        }

        /// <summary>
        /// Launches Oblivion Mod Manager.
        /// </summary>
        internal static void LaunchObmm()
        {
            // Double check that the executable exists.
            bool isObmmInstalled = File.Exists(Common.ObmmPath);
            if (isObmmInstalled)
            {
                try
                {
                    Process.Start(Common.ObmmPath);
                }
                catch (Win32Exception exception)
                {
                    HandleException(exception, "Could not launch OBMM.");
                }
            }
        }

        /// <summary>
        /// Handles the logging and/or displaying of an unhandled <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> to handle.</param>
        private static void HandleFatalException(Exception exception)
        {
            HandleFatalException(exception, null);
        }

        /// <summary>
        /// Handles the logging and/or displaying of an unhandled <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> to handle.</param>
        /// <param name="stateMessage">An additional message to be saved describing the circumstances under which the exception occured.</param>
        private static void HandleFatalException(Exception exception, string stateMessage)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            
            if (exception != null)
            {
                // Log the exception and display it on screen.
                string fileName;
                LogException(exception, stateMessage, out fileName);
                DisplayFatalException(exception, fileName);
            }
            else
            {
                DisplayFatalException(null);
            }
        }

        /// <summary>
        /// Displays information about a <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> whose information to display.</param>
        private static void DisplayFatalException(Exception exception)
        {
            DisplayFatalException(exception, null);
        }

        /// <summary>
        /// Displays information about a <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> whose information to display.</param>
        /// <param name="logFileName">The name of the file to which a log of the error was saved. <c>null</c>
        /// can be specified for none.</param>
        private static void DisplayFatalException(Exception exception, string logFileName)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            
            if (exception == null)
            {
                // Can't display an exception if it's null; just close the application.
                string text = "A fatal error has occurred and the program must close.";
                Common.ShowMessageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Display error normally.
                // TODO: abandon logging!
                using (ErrorForm errorForm = new ErrorForm(exception))
                {
                    //errorForm.ResetSettings += OnResetSettings;
                    errorForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Logs a <see cref="System.Exception"/> to a file with a randomly generated name.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> to log.</param>
        /// <param name="stateMessage">An additional message to be saved describing the circumstances under which the exception occured.</param>
        private static void LogException(Exception exception, string stateMessage)
        {
            string fileName;
            LogException(exception, stateMessage, out fileName);
        }

        /// <summary>
        /// Logs a <see cref="System.Exception"/> to a file with a randomly generated name.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> to log.</param>
        /// <param name="fileName">The name of the file to which the log was saved.</param>
        /// <param name="stateMessage">An additional message to be saved describing the circumstances under which the exception occured.</param>
        private static void LogException(Exception exception, string stateMessage, out string fileName)
        {
            Common.CheckLogDirectory();
            fileName = GenerateErrorLogFileName();
            LogException(exception, stateMessage, fileName);
        }

        /// <summary>
        /// Logs a <see cref="System.Exception"/> to a file with a randomly generated name.
        /// </summary>
        /// <param name="exception">The <see cref="System.Exception"/> to log.</param>
        /// <param name="fileName">The name of the file to which to save the log.</param>
        /// <param name="stateMessage">An additional message to be saved describing the circumstances under which the exception occured.</param>
        private static void LogException(Exception exception, string stateMessage, string fileName)
        {
            Common.CheckLogDirectory();

            // Set directory for log file.
            bool isPathRooted = Path.IsPathRooted(fileName);
            if (!isPathRooted)
            {
                fileName = Path.GetFullPath(Common.LogDirectory) + Path.DirectorySeparatorChar + fileName;
            }

            // Make sure directory exists.
            string directoryPath = Path.GetDirectoryName(fileName);
            bool directoryExists = Directory.Exists(directoryPath);
            if (!directoryExists)
            {
                Directory.CreateDirectory(directoryPath);
            }

            Utility.LogException(exception, fileName, stateMessage);
        }

        /// <summary>
        /// Resets all of the applications settings and clears any stored data.
        /// </summary>
        private static void ResetSettings()
        {
            SaveManager.DeleteCharactersFile();
            Settings.Default.Reset();
            Settings.Default.Save();
        }

        /// <summary>
        /// Generates a file name for an error log.
        /// </summary>
        /// <returns>An unused log file name for an error log.</returns>
        private static string GenerateErrorLogFileName()
        {
            string nameTemplate = "errorlog {0}{1}.txt";
            DateTime now = DateTime.Now;
            string year = now.Year.ToString();
            string timeStamp = string.Format("{0:D2}.{1:D2}.{2:D2}", now.Day, now.Month, year.Substring(year.Length - 2));

            bool exists;
            string fileName;
            int i = 1;
            do
            {
                fileName = Common.LogDirectory + Path.DirectorySeparatorChar;
                if (i == 1)
                {
                    fileName += string.Format(nameTemplate, timeStamp, string.Empty);
                }
                else
                {
                    fileName += string.Format(nameTemplate, timeStamp, " (" + i + ")");
                }
                exists = File.Exists(fileName);

                if (exists)
                {
                    i++;
                }
            } while (exists);

            return fileName;
        }

        #region Event handlers

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                HandleFatalException(e.ExceptionObject as Exception);
            }
            finally
            {
                Finalise();
            }
        }

        private static void OnResetSettings(object sender, CancelEventArgs e)
        {
            DialogResult result;
            {
                // Warn user and ask for confirmation of reset.
                string text = "This will clear all your application's settings and stored data " +
                              "and revert it to its original state.  You should only try this " +
                              "if the error has occured more than once." +
                              Environment.NewLine + Environment.NewLine +
                              "Are you sure you want to continue?";
                result = Common.ShowMessageBox(text, MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2);
            }

            if (result == DialogResult.Yes)
            {
                // User confirmed – reset settings.
                ResetSettings();

                string text = "All settings and stored data have been reset.";
                Common.ShowMessageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Cancel = false;
            }
            else
            {
                // User cancelled.
                e.Cancel = true;
            }
        }

        #endregion
    }
}