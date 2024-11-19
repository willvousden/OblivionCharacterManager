using System;
using System.IO;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.Properties;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Allows the user to view and modify options for the application.
    /// </summary>
    public partial class OptionsForm : BaseForm
    {
        /// <summary>
        /// Gets or sets the command line arguments for Oblivion displayed on the form.
        /// </summary>
        public string OblivionCommandLine
        {
            get
            {
                return oblivionLaunchCommandLineLabel.Text;
            }
            set
            {
                oblivionLaunchCommandLineLabel.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the root save directory displayed on the form.
        /// </summary>
        public string RootSaveDirectory
        {
            get
            {
                return rootSaveDirectoryTextBox.Text;
            }
            set
            {
                rootSaveDirectoryTextBox.Text = value;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.OptionsForm"/> instance.
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Commits the currently present settings to persistent storage.
        /// </summary>
        public void Commit()
        {
            ApplySettings(true);
        }

        /// <summary>
        /// Commits the currently present settings to persistent storage.
        /// </summary>
        /// <param name="saveRootSaveDirectory">A value specifying whether to include the root save directory.</param>
        public void ApplySettings(bool saveRootSaveDirectory)
        {
            Settings.Default.OblivionLaunchCommandLine = oblivionLaunchCommandLineTextBox.Text;
            Settings.Default.LoadObseOnOblivionLaunch = loadObseCheckBox.Checked && Common.IsObseInstalled;
            Settings.Default.CheckUpdatesOnStartup = checkUpdatesOnStartupCheckBox.Checked;
            Settings.Default.FormSettings.RememberFormStates = rememberFormStatesCheckBox.Checked;

            Settings.Default.OblivionInstallPath = oblivionInstallDirectoryTextBox.Text;
            if (saveRootSaveDirectory)
            {
                Settings.Default.RootSaveDirectory = rootSaveDirectoryTextBox.Text;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Loads current settings to be displayed on the form.
        /// </summary>
        public void LoadSettings()
        {
            oblivionLaunchCommandLineTextBox.Text = Settings.Default.OblivionLaunchCommandLine;
            loadObseCheckBox.Enabled = Common.IsObseInstalled;
            loadObseCheckBox.Checked = Settings.Default.LoadObseOnOblivionLaunch && Common.IsObseInstalled;
            checkUpdatesOnStartupCheckBox.Checked = Settings.Default.CheckUpdatesOnStartup;
            rememberFormStatesCheckBox.Checked = Settings.Default.FormSettings.RememberFormStates;

            oblivionLaunchCommandLineTextBox.Enabled = !loadObseCheckBox.Checked;
            oblivionInstallDirectoryTextBox.Text = Settings.Default.OblivionInstallPath;
            rootSaveDirectoryTextBox.Text = Settings.Default.RootSaveDirectory;
        }

        /// <summary>
        /// Validates the currently given root save directory on the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateRootSaveDirectory()
        {
            try
            {
                DirectoryInfo rootSaveDirectoryInfo = new DirectoryInfo(rootSaveDirectoryTextBox.Text);
                return !Path.IsPathRooted(rootSaveDirectoryTextBox.Text);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        #region Event handlers

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void loadObseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oblivionLaunchCommandLineTextBox.Enabled = !loadObseCheckBox.Checked;
        }

        private void checkUpdatesNowButton_Click(object sender, EventArgs e)
        {
            using (UpdateForm form = new UpdateForm())
            {
                form.ShowDialog();
            }
        }

        private void oblivionInstallDirectoryBrowseButton_Click(object sender, EventArgs e)
        {
            oblivionInstallDirectoryFolderBrowserDialog.SelectedPath = oblivionInstallDirectoryTextBox.Text;
            DialogResult result = oblivionInstallDirectoryFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                oblivionInstallDirectoryTextBox.Text = oblivionInstallDirectoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void autodetectButton_Click(object sender, EventArgs e)
        {
            string registryPath =Common.GetOblivionInstallPathFromRegistry();
            if (registryPath != null)
            {
                oblivionInstallDirectoryTextBox.Text = registryPath;
            }
            else
            {
                string text = "Could not identify Oblivion's install path.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool rootSaveDirectoryOk = ValidateRootSaveDirectory();
            if (!rootSaveDirectoryOk)
            {
                string text = "Invalid root save directory given.  The path must be relative.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool installDirectoryOk = Program.CheckInstallDirectory(oblivionInstallDirectoryTextBox.Text);
            if (!installDirectoryOk)
            {
                string text = "Invalid install directory given; directory or necessary files not found.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}