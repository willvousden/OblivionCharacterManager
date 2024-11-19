using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.CharacterManagement;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Displays information about an Oblivion save.
    /// </summary>
    [FormPersistence(FormStateAspects.All)]
    public partial class ViewSaveForm : BaseForm
    {
        private OblivionSave m_Save = null;

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.ViewSaveForm"/> instance.
        /// </summary>
        public ViewSaveForm(OblivionSave save)
        {
            if (save == null)
            {
                throw new ArgumentNullException("Save object must not be null.", "save");
            }

            InitializeComponent();

            m_Save = save;
            LoadSave();
        }

        /// <summary>
        /// Loads a save and displays its information on the form.
        /// </summary>
        private void LoadSave()
        {
            screenshotPictureBox.Image = m_Save.Screenshot;
            saveFileNameValueLabel.Text = m_Save.FileName;
            characterNameValueLabel.Text = m_Save.CharacterName;
            characterLevelValueLabel.Text = m_Save.CharacterLevel.ToString();
            characterLocationValueLabel.Text = m_Save.CharacterLocation;
            gameTimeValueLabel.Text = string.Format("Day {0}, {1:D2}:{2:D2}:{3:D2}",
                                                    m_Save.GameTime.Days, m_Save.GameTime.Hours,
                                                    m_Save.GameTime.Minutes,
                                                    m_Save.GameTime.Seconds);
            lastSaveValueLabel.Text = m_Save.LastSave.ToString("U", Common.DateTimeFormatInfo);
            oblivionSaveVersionValueLabel.Text = m_Save.OblivionVersion.ToString(2);

            // Set play time label (requires fiddling around with plural words etc.)
            int totalHours = m_Save.PlayTime.Days * 24 + m_Save.PlayTime.Hours;
            string hours = totalHours + (totalHours == 1 ? " hour" : " hours");
            string minutes = m_Save.PlayTime.Minutes + (m_Save.PlayTime.Minutes == 1 ? " minute" :
                             " minutes");
            string seconds = m_Save.PlayTime.Seconds + (m_Save.PlayTime.Seconds == 1 ? " second" :
                             " seconds");
            playTimeValueLabel.Text = string.Empty;

            if (m_Save.PlayTime.Hours > 0)
            {
                playTimeValueLabel.Text = hours;
            }

            if (m_Save.PlayTime.Minutes > 0)
            {
                if (playTimeValueLabel.Text.Length > 0)
                {
                    playTimeValueLabel.Text += ", " + minutes;
                }
                else
                {
                    playTimeValueLabel.Text = minutes;
                }
            }

            if (m_Save.PlayTime.Seconds > 0)
            {
                if (playTimeValueLabel.Text.Length > 0)
                {
                    playTimeValueLabel.Text += ", " + seconds;
                }
                else
                {
                    playTimeValueLabel.Text = seconds;
                }
            }

            DisplayPlugins();
        }

        /// <summary>
        /// Displays the plugins for the current save and their status.
        /// </summary>
        private void DisplayPlugins()
        {
            string[] plugins = OblivionSave.GetPluginLoadOrder();
            pluginListView.BeginUpdate();
            pluginListView.Items.Clear();
            foreach (string pluginFileName in m_Save.PluginFileNames)
            {
                ListViewItem newItem = new ListViewItem(pluginFileName);
                string enabledText;
                bool fileExists = File.Exists(Common.OblivionDataPath + Path.DirectorySeparatorChar + pluginFileName);
                if (!fileExists)
                {
                    // Plugin was not found.
                    enabledText = "Not found";
                    newItem.ForeColor = Color.Red;
                }
                else
                {
                    int index = Array.IndexOf(plugins, pluginFileName);
                    if (index >= 0)
                    {
                        // Plugin was found in order list.
                        enabledText = "Enabled";
                    }
                    else
                    {
                        // Plugin was not found in order list.
                        enabledText = "Disabled";
                        newItem.ForeColor = Color.Red;
                    }
                }

                newItem.SubItems.Add(enabledText);
                pluginListView.Items.Add(newItem);
            }
            pluginListView.EndUpdate();
        }

        #region Event handlers

        private void openContainingDirectoryToolStripButton_Click(object sender, EventArgs e)
        {
            if (m_Save != null)
            {
                string directoryPath = Path.GetDirectoryName(m_Save.FilePath);
                bool directoryExists = Directory.Exists(directoryPath);
                if (directoryExists)
                {
                    try
                    {
                        Process.Start(directoryPath);
                    }
                    catch
                    {
                        string text = "Could not open containing directory.";
                        Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void openDataDirectoryToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Common.OblivionDataPath);
            }
            catch
            {
                string text = "Could not open containing directory.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveDuplicateToolStripButton_Click(object sender, EventArgs e)
        {
            bool fileExists = m_Save != null && File.Exists(m_Save.FilePath);
            if (fileExists)
            {
                saveDuplicateSaveFileDialog.FileName = m_Save.FileName;
                DialogResult result = saveDuplicateSaveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(m_Save.FilePath, saveDuplicateSaveFileDialog.FileName);
                    }
                    catch
                    {
                        string text = "Could not copy save file.";
                        Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                string text = "Could not find the save file.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}