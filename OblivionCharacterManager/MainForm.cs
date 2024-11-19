using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.CharacterManagement;
using OblivionCharacterManager.Properties;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Represents a method that delegates a yes/no decision to a user.
    /// </summary>
    /// <param name="message">The message to display to the user.</param>
    /// <returns>The response of the user.</returns>
    public delegate bool UserResponse(string message);

    /// <summary>
    /// The main form for the application.
    /// </summary>
    [FormPersistence(FormStateAspects.All)]
    public partial class MainForm : BaseForm
    {
        /// <summary>
        /// Gets a method that displays a message box to the user asking for a response.
        /// </summary>
        public static UserResponse MessageBoxUserReponse
        {
            get
            {
                return delegate(string message)
                       {
                           string text = message;
                           DialogResult result = Common.ShowMessageBox(message, MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question,
                                                                       MessageBoxDefaultButton.Button2);
                           return result == DialogResult.Yes;
                       };
            }
        }

#if DEBUG
        private int m_ResetSettingsHotKeyId;
#endif
        private List<OblivionCharacter> m_Characters = new List<OblivionCharacter>();
        private OblivionCharacter m_ActiveCharacter;
        private OptionsForm m_OptionsForm = new OptionsForm();
        private AddCharacterForm m_AddCharacterForm = new AddCharacterForm();
        private ManualResetEvent m_MovingSavesFinished = new ManualResetEvent(true);
        private ManualResetEvent m_TidyingSavesFinished = new ManualResetEvent(true);

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.MainForm"/> instance.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Text = Common.ApplicationName;
            m_ActiveCharacter = SaveManager.GetActiveCharacter();

            bool savesDirectoryExists = Directory.Exists(Common.RootSaveDirectoryAbsolute);
            if (!savesDirectoryExists)
            {
                Directory.CreateDirectory(Common.RootSaveDirectoryAbsolute);
            }
            fileSystemWatcher.Path = Common.RootSaveDirectoryAbsolute;

            if (Settings.Default.SaveListSorter != null)
            {
                saveListView.ListViewItemSorter = Settings.Default.SaveListSorter;
            }
            else
            {
                saveListView.ListViewItemSorter = Settings.Default.SaveListSorter = new SaveListSorter();
            }

#if DEBUG
            Text += " [debug configuration]";
#endif

            RegisterHotKeys();
        }

        /// <summary>
        /// Sets up hot key bindings.
        /// </summary>
        private void RegisterHotKeys()
        {
            HotKeyPressed += MainForm_HotKeyPressed;

#if DEBUG
            HotKey resetHotKey = new HotKey(Keys.R, KeyModifiers.Control | KeyModifiers.Shift);
            RegisterHotKey(resetHotKey, out m_ResetSettingsHotKeyId);
#endif
        }

        /// <summary>
        /// Asks the user for confirmation before resetting the application's settings.
        /// </summary>
        private void ResetSettings()
        {
            string text = "Are you sure you want to reset the application's settings?";
            DialogResult result = Common.ShowMessageBox(this, text, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Settings.Default.Reset();
                Settings.Default.Save();

                text = "The application's settings have been reset.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Updates and refreshes the current cache of characters.
        /// </summary>
        private void RefreshCharacterCache()
        {
            SaveManager.LoadCharacters();
            m_Characters = new List<OblivionCharacter>(SaveManager.Characters);
        }

        /// <summary>
        /// Sets the status of the save display.
        /// </summary>
        private void SetSaveDisplayDisable(bool disabled)
        {
            if (disabled)
            {
                UseWaitCursor = true;
                tidySaveDirectoryButton.Enabled = false;
                saveListView.ItemActivate -= saveListView_ItemActivate;
            }
            else
            {
                UseWaitCursor = false;
                tidySaveDirectoryButton.Enabled = true;
                saveListView.ItemActivate += saveListView_ItemActivate;
            }
        }

        /// <summary>
        /// Updates the saves and characters on the form.
        /// </summary>
        private void DisplayCharacters()
        {
            DisplayCharacters(false);
        }

        /// <summary>
        /// Updates the saves and characters on the form.
        /// </summary>
        /// <param name="textOnly">A value specifying whether the saves list should only have each item's text updated, rather than all items refreshed.</param>
        private void DisplayCharacters(bool textOnly)
        {
            characterComboBox.BeginUpdate();
            m_ActiveCharacter = SaveManager.GetActiveCharacter();
            if (!textOnly)
            {
                // Update the character list.
                RefreshCharacterCache();
                characterComboBox.Items.Clear();
                characterComboBox.Items.Add("[all characters]");
                for (int i = 0; i < m_Characters.Count; i++)
                {
                    string text;
                    if (m_ActiveCharacter != null && m_ActiveCharacter.Name == m_Characters[i].Name)
                    {
                        text = m_Characters[i].Name + " [active]";
                    }
                    else
                    {
                        text = m_Characters[i].Name;
                    }

                    characterComboBox.Items.Insert(i + 1, text);
                }

                characterComboBox.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < m_Characters.Count && i < (characterComboBox.Items.Count - 1); i++)
                {
                    string text;
                    if (m_ActiveCharacter != null && m_ActiveCharacter.Name == m_Characters[i].Name)
                    {
                        text = m_Characters[i].Name + " [active]";
                    }
                    else
                    {
                        text = m_Characters[i].Name;
                    }

                    characterComboBox.Items[i + 1] = text;
                }
            }
            characterComboBox.EndUpdate();
        }

        /// <summary>
        /// Updates the saves list.
        /// </summary>
        private void DisplaySaves()
        {
            DisplaySaves(false);
        }

        /// <summary>
        /// Updates the saves list.
        /// </summary>
        /// <param name="useCurrentSaveData">A value specifying whether or not current save data should be used, rather than reloading the
        /// saves.</param>
        private void DisplaySaves(bool useCurrentSaveData)
        {
            if (m_Characters == null || m_Characters.Count == 0)
            {
                return;
            }

            saveListView.BeginUpdate();
            saveListView.Groups.Clear();
            saveListView.Items.Clear();
            List<OblivionSave> currentSaves = new List<OblivionSave>();
            if (characterComboBox.SelectedIndex == 0)
            {
                // Load all saves.
                foreach (OblivionCharacter character in m_Characters)
                {
                    if (!useCurrentSaveData)
                    {
                        // Reload saves.
                        character.LoadSaves();
                    }
                    saveListView.Groups.Add(character.Name, character.Name);
                    currentSaves.AddRange(character.Saves);
                }
            }
            else
            {
                // Add groups.
                foreach (OblivionCharacter character in m_Characters)
                {
                    saveListView.Groups.Add(character.Name, character.Name);
                }

                OblivionCharacter selectedCharacter = m_Characters[characterComboBox.SelectedIndex - 1];
                if (selectedCharacter != null)
                {
                    // Load individual character's saves.
                    if (!useCurrentSaveData)
                    {
                        // Reload saves.
                        selectedCharacter.LoadSaves();
                    }
                    currentSaves.AddRange(selectedCharacter.Saves);
                }
                else
                {
                    // Selected character isn't valid for some reason.
                    setAsActiveCharacterButton.Enabled = false;
                    deleteCharacterButton.Enabled = false;
                    saveListView.EndUpdate();
                    return;
                }
            }

            // Add items to list view.
            foreach (OblivionSave save in currentSaves)
            {
                ListViewItem newItem = new ListViewItem(save.FileName);
                newItem.SubItems.Add(save.CharacterLevel.ToString());
                newItem.SubItems.Add(save.CharacterLocation);
                newItem.SubItems.Add(save.LastSave.ToString());
                newItem.Tag = save;
                newItem.Group = saveListView.Groups[save.CharacterName];
                saveListView.Items.Add(newItem);
            }

            deleteSaveButton.Enabled = saveListView.SelectedItems.Count >= 1;
            viewSaveButton.Enabled = saveListView.SelectedItems.Count == 1;
            saveListView.Sort();
            saveListView.EndUpdate();
        }

        /// <summary>
        /// Attempts to move the save files.
        /// </summary>
        /// <param name="destination">The destination for the save files.</param>
        private void MoveSaves(string destination)
        {
            // Wait for any pending move/tidy operations to finish.
            m_MovingSavesFinished.WaitOne();
            m_TidyingSavesFinished.WaitOne();

            MethodInvoker task = () =>
                                 {
                                     m_MovingSavesFinished.Reset();
                                     SaveManager.TidySaveFiles(MessageBoxUserReponse);
                                     SaveManager.MoveSaveFiles(destination, MessageBoxUserReponse);
                                     fileSystemWatcher.Path = Common.OblivionMyGamesPath + Path.DirectorySeparatorChar + destination;
                                     m_MovingSavesFinished.Set();
                                 };
            using (BusyForm busyForm = new BusyForm(false))
            {
                busyForm.PerformTask(task, "Moving save directory.");
            }
        }

        /// <summary>
        /// Tidies the current save directory.
        /// </summary>
        private void TidySaves()
        {
            TidySaves(false);
        }

        /// <summary>
        /// Tidies the current save directory.
        /// </summary>
        /// <param name="suppressOutput"><c>true</c> to have error messages and confirmations suppressed; <c>false</c> otherwise.</param>
        private void TidySaves(bool suppressOutput)
        {
            bool alreadyTidying = !m_TidyingSavesFinished.WaitOne(0, false);
            if (alreadyTidying)
            {
                if (!suppressOutput)
                {
                    string text = "Could not tidy save files; they are already being tidied.";
                    Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            UserResponse response;
            if (suppressOutput)
            {
                response = delegate(string message)
                {
                    return false;
                };
            }
            else
            {
                response = MessageBoxUserReponse;
            }

            // TODO: tidy this up.
            BusyForm busyForm = null;
            MethodInvoker task = delegate()
                                 {
                                     // Wait for any pending move/tidy operations to finish.
                                     busyForm.Message = "Waiting for move operation to complete.";
                                     m_MovingSavesFinished.WaitOne();
                                      
                                     // Tidy the save directory.
                                     busyForm.Message = "Tidying save directory.";
                                     m_TidyingSavesFinished.Reset();
                                     SaveManager.TidySaveFiles(response);
                                     m_TidyingSavesFinished.Set();
                                 };
            using (busyForm = new BusyForm(false))
            {
                busyForm.PerformTask(task, "Tidying save directory.");
                DisplaySaves();
            }
        }

        /// <summary>
        /// Displays information about a save.
        /// </summary>
        private void DisplaySave(OblivionSave save)
        {
            using (ViewSaveForm form = new ViewSaveForm(save))
            {
                form.ShowDialog();
            }
        }

        #region Event handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            launchObmmToolStripButton.Enabled = Common.IsObmmInstalled;
            showInGroupsCheckBox.Checked = Settings.Default.ShowSavesInGroups;
            DisplayCharacters();

            if (Settings.Default.CheckUpdatesOnStartup)
            {
                toolStripStatusLabel.Text = "Checking for updates";
                checkUpdatesBackgroundWorker.RunWorkerAsync();
            }
        }

        private void MainForm_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
#if DEBUG
            if (e.HotKeyId == m_ResetSettingsHotKeyId)
            {
                ResetSettings();
            }
#endif
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            // Something's been deleted – refresh characters and saves to reflect changes.
            TidySaves(true);
        }

        private void launchOblivionToolStripButton_Click(object sender, EventArgs e)
        {
            bool launch = true;
            if (m_ActiveCharacter == null)
            {
                string text = "There is currently no active character. Are you sure you want to " +
                              "start Oblivion?";
                DialogResult result = Common.ShowMessageBox(this, text, MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                launch = result == DialogResult.Yes;
            }

            if (launch)
            {
                Close();
                Program.LaunchOblivion();
            }
        }

        private void launchObmmToolStripButton_Click(object sender, EventArgs e)
        {
            Program.LaunchObmm();
        }

        private void openSaveDirectoryToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Common.RootSaveDirectoryAbsolute);
            }
            catch (Exception exception)
            {
                string text = "Could not p[en save directory.";
                Common.ShowMessageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Program.HandleException(exception);
            }
        }

        private void addCharacterToolStripButton_Click(object sender, EventArgs e)
        {
            Predicate<string> nameExistsMatch = delegate(string name)
                                                {
                                                    name = name.ToLower();
                                                    return m_Characters.Exists(character => character.Name.ToLower() == name);
                                                };
            m_AddCharacterForm.NameExistsMatch = nameExistsMatch;
            DialogResult result = m_AddCharacterForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool isValid = SaveManager.IsValidCharacterName(m_AddCharacterForm.CharacterName);
                bool characterExists = nameExistsMatch(m_AddCharacterForm.CharacterName);
                if (!isValid)
                {
                    string text = "The provided character name is not valid.";
                    Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (characterExists)
                {
                    string text = "The provided character name is already in use.";
                    Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SaveManager.CreateCharacter(m_AddCharacterForm.CharacterName);
                    SaveManager.SaveCharacters();
                    DisplayCharacters();
                }
            }
        }

        private void optionsToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult result = m_OptionsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (m_OptionsForm.RootSaveDirectory != Common.RootSaveDirectoryRelative)
                {
                    string text = "Any files with conflicting names in the new location will be overwritten.  Are you sure you want to move the save files?";
                    result = Common.ShowMessageBox(this, text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        MoveSaves(m_OptionsForm.RootSaveDirectory);

                        m_OptionsForm.ApplySettings(false);
                    }
                    else
                    {
                        m_OptionsForm.ApplySettings(false);
                    }
                }
                else
                {
                    m_OptionsForm.ApplySettings(false);
                }
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            using (AboutForm form = new AboutForm())
            {
                form.ShowDialog();
            }
        }

        private void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySaves();

            bool characterButtonsEnabled = characterComboBox.SelectedIndex > 0 &&
                                           characterComboBox.SelectedIndex <= m_Characters.Count &&
                                           m_Characters[characterComboBox.SelectedIndex - 1] != null;
            deleteCharacterButton.Enabled = characterButtonsEnabled;
            setAsActiveCharacterButton.Enabled = characterButtonsEnabled &&
                                                 (m_ActiveCharacter == null ||
                                                 m_Characters[characterComboBox.SelectedIndex - 1].Name != m_ActiveCharacter.Name);
            characterOptionsButton.Enabled = characterButtonsEnabled;
        }

        private void setAsActiveCharacterButton_Click(object sender, EventArgs e)
        {
            if (characterComboBox.SelectedIndex > 0)
            {
                SaveManager.SetActiveCharacter(m_Characters[characterComboBox.SelectedIndex - 1]);
                setAsActiveCharacterButton.Enabled = false;
                DisplayCharacters(true);
            }
        }

        private void characterOptionsButton_Click(object sender, EventArgs e)
        {
            if (characterComboBox.SelectedIndex > 0 && characterComboBox.SelectedIndex <= m_Characters.Count)
            {
                OblivionCharacter selectedCharacter = m_Characters[characterComboBox.SelectedIndex - 1];
                if (selectedCharacter != null)
                {
                    using (CharacterOptionsForm form = new CharacterOptionsForm(selectedCharacter))
                    {
                        DialogResult result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            SaveManager.SaveCharacters();
                        }
                    }
                }
            }
        }

        private void deleteCharacterButton_Click(object sender, EventArgs e)
        {
            if (characterComboBox.SelectedIndex > 0)
            {
                OblivionCharacter character = m_Characters[characterComboBox.SelectedIndex - 1];

                // Prompt user for confirmation.
                string text = "All save files will be deleted permanently.  Are you sure you " +
                              "want to delete this character?";
                DialogResult result = Common.ShowMessageBox(this, text, MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning,
                                                            MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    fileSystemWatcher.EnableRaisingEvents = false;
                    SaveManager.DeleteCharacter(character);
                    fileSystemWatcher.EnableRaisingEvents = true;
                    DisplayCharacters();
                }
            }
        }

        private void saveListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SaveListSorter sorter = saveListView.ListViewItemSorter as SaveListSorter;
            if (sorter != null)
            {
                SaveSortType previousSortType = sorter.Type;
                switch (e.Column)
                {
                    default:
                    case 0:
                        sorter.Type = SaveSortType.FileName;
                        break;
                    case 1:
                        sorter.Type = SaveSortType.CharacterLevel;
                        break;
                    case 2:
                        sorter.Type = SaveSortType.CharacterLocation;
                        break;
                    case 3:
                        sorter.Type = SaveSortType.LastSaveTime;
                        break;
                }

                if (previousSortType == sorter.Type)
                {
                    if (sorter.Order == SortOrder.Ascending)
                    {
                        sorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        sorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }

                saveListView.Sort();
            }
        }

        private void saveListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                deleteSaveButton.Text = "Delete save";
                OblivionSave selectedSave = saveListView.SelectedItems[0].Tag as OblivionSave;
                if (selectedSave != null)
                {
                    viewSaveButton.Enabled = true;
                    deleteSaveButton.Enabled = true;
                }
                else
                {
                    viewSaveButton.Enabled = false;
                    deleteSaveButton.Enabled = false;
                }
            }
            else if (saveListView.SelectedItems.Count > 1)
            {
                viewSaveButton.Enabled = false;
                deleteSaveButton.Enabled = true;
                deleteSaveButton.Text = "Delete saves";
            }
            else
            {
                viewSaveButton.Enabled = false;
                deleteSaveButton.Enabled = false;
                deleteSaveButton.Text = "Delete save";
            }
        }

        private void saveListView_ItemActivate(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                OblivionSave selectedSave = saveListView.SelectedItems[0].Tag as OblivionSave;
                if (selectedSave != null)
                {
                    DisplaySave(selectedSave);
                }
            }
        }

        private void saveListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && saveListView.SelectedItems.Count == 1)
            {
                saveListView.SelectedItems[0].BeginEdit();
            }
        }

        private void saveListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                return;
            }

            List<char> invalidCharacters = new List<char>(Path.GetInvalidFileNameChars());
            string fileName = e.Label;
            bool containsInvalidCharacters = false;
            foreach (char character in fileName)
            {
                bool isInvalid = invalidCharacters.Contains(character);
                if (isInvalid)
                {
                    containsInvalidCharacters = true;
                    break;
                }
            }

            if (containsInvalidCharacters)
            {
                string text = "The file name contains invalid characters.";
                Common.ShowMessageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
            else
            {
                OblivionSave save = saveListView.Items[e.Item].Tag as OblivionSave;
                string filePath = Path.GetDirectoryName(save.FilePath) + Path.DirectorySeparatorChar + fileName;
                if (save != null)
                {
                    File.Move(save.FilePath, Path.GetFullPath(filePath));
                    save.FilePath = filePath;
                }
            }
        }

        private void showInGroupsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowSavesInGroups = saveListView.ShowGroups = showInGroupsCheckBox.Checked;
            if (showInGroupsCheckBox.Checked)
            {
                saveListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            }
            else
            {
                saveListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            }
            DisplaySaves(true);
        }

        private void viewSaveButton_Click(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                OblivionSave selectedSave = saveListView.SelectedItems[0].Tag as OblivionSave;
                if (selectedSave != null)
                {
                    DisplaySave(selectedSave);
                }
            }
        }

        private void deleteSaveButton_Click(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count > 0)
            {
                // Prompt user for confirmation.
                string text = "Are you sure you want to delete these save file(s)?";
                DialogResult result = Common.ShowMessageBox(this, text, MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning,
                                                            MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in saveListView.SelectedItems)
                    {
                        OblivionSave save = item.Tag as OblivionSave;
                        bool fileExists = save != null && File.Exists(save.FilePath);
                        if (fileExists)
                        {
                            try
                            {
                                fileSystemWatcher.EnableRaisingEvents = false;
                                File.Delete(save.FilePath);
                                fileSystemWatcher.EnableRaisingEvents = true;
                                saveListView.Items.Remove(item);
                            }
                            catch (Exception exception)
                            {
                                Common.ShowMessageBox(this, exception.Message, MessageBoxButtons.OK,
                                                      MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            saveListView.Items.Remove(item);
                        }
                    }
                }
            }
        }

        private void tidySaveDirectoryButton_Click(object sender, EventArgs e)
        {
            TidySaves();
        }

        private void saveContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = saveListView.SelectedItems[0];
                OblivionSave selectedSave = selectedItem.Tag as OblivionSave;
                if (selectedSave != null)
                {
                    viewToolStripMenuItem.Enabled = true;
                    openContainingDirectoryToolStripMenuItem.Enabled = true;
                    renameToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                }
                else
                {
                    viewToolStripMenuItem.Enabled = false;
                    openContainingDirectoryToolStripMenuItem.Enabled = false;
                    renameToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
            }
            else if (saveListView.SelectedItems.Count >= 1)
            {
                viewToolStripMenuItem.Enabled = false;
                openContainingDirectoryToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                viewToolStripMenuItem.Enabled = false;
                openContainingDirectoryToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                OblivionSave selectedSave = saveListView.SelectedItems[0].Tag as OblivionSave;
                if (selectedSave != null)
                {
                    DisplaySave(selectedSave);
                }
            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                OblivionSave selectedSave = saveListView.SelectedItems[0].Tag as OblivionSave;
                if (selectedSave != null)
                {
                    string directoryPath = Path.GetDirectoryName(selectedSave.FilePath);
                    bool directoryExists = Directory.Exists(directoryPath);
                    if (directoryExists)
                    {
                        Process.Start(directoryPath);
                    }
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveListView.SelectedItems.Count == 1)
            {
                saveListView.SelectedItems[0].BeginEdit();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSaveButton_Click(sender, e);
        }

        private void tidySaveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tidySaveDirectoryButton_Click(sender, e);
        }

        private void checkUpdatesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = UpdateInfo.GetUpdateInfo();
            }
            catch (Exception exception)
            {
                e.Result = null;

                Program.HandleException(exception);
            }
        }

        private void checkUpdatesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInfo updateInfo = e.Result as UpdateInfo;
            if (updateInfo != null)
            {
                if (updateInfo.LatestVersion > Common.ApplicationVersion)
                {
                    toolStripStatusLabel.Text = "Update available";
                    using (UpdateForm form = new UpdateForm(updateInfo))
                    {
                        form.ShowDialog();
                    }
                }
            }
            else
            {
                toolStripStatusLabel.Text = "Couldn't get update info";
                return;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveListSorter sorter = saveListView.ListViewItemSorter as SaveListSorter;
            if (sorter != null)
            {
                Settings.Default.SaveListSorter = sorter;
            }

            m_OptionsForm.Dispose();
            m_AddCharacterForm.Dispose();
        }

        #endregion
    }
}