using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using FormsLibrary;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Displays information about application updates to the user.
    /// </summary>
    public partial class UpdateForm : BaseForm
    {
        private UpdateInfo m_UpdateInfo = null;

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.UpdateForm"/> instance.
        /// </summary>
        public UpdateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.UpdateForm"/> instance.
        /// </summary>
        /// <param name="updateInfo">The update info that should be displayed on the form.</param>
        public UpdateForm(UpdateInfo updateInfo)
            : this()
        {
            m_UpdateInfo = updateInfo;
        }

        /// <summary>
        /// Displays the currently loaded <see cref="OblivionCharacterManager.UpdateInfo"/> object on the form.
        /// </summary>
        private void DisplayUpdateInfo()
        {
            Debug.Assert(m_UpdateInfo != null, "m_UpdateInfo is null.");
            if (m_UpdateInfo != null)
            {
                latestVersionValueLabel.Text = m_UpdateInfo.LatestVersion.ToString(3);
                downloadLinkLabel.Text = m_UpdateInfo.DownloadUri;

                // Write list of changes.
                informationTextBox.Text = "Changes:" + Environment.NewLine;
                Debug.Assert(m_UpdateInfo.Changes != null);
                if (m_UpdateInfo.Changes.Length > 0)
                {
                    foreach (string change in m_UpdateInfo.Changes)
                    {
                        informationTextBox.AppendText("> " + change + Environment.NewLine);
                    }
                }
                else
                {
                    informationTextBox.AppendText("o changes.");
                }

                // Write notes.
                Debug.Assert(m_UpdateInfo.Notes != null);
                if (m_UpdateInfo.Notes != string.Empty)
                {
                    informationTextBox.AppendText(Environment.NewLine + "Notes:");
                    informationTextBox.AppendText(Environment.NewLine + m_UpdateInfo.Notes);
                }

                if (m_UpdateInfo.LatestVersion > Common.ApplicationVersion)
                {
                    updateReadoutLabel.Text = "An newer version is available.";
                }
                else
                {
                    updateReadoutLabel.Text = "There are no updates currently available.";
                }
            }
            else
            {
                updateReadoutLabel.Text = "There are no updates currently available.";
                latestVersionValueLabel.Text = string.Empty;
                informationTextBox.Clear();
                downloadLinkLabel.Text = string.Empty;
            }
        }

        /// <summary>
        /// Clears the form's display.
        /// </summary>
        private void ClearDisplay()
        {
            updateReadoutLabel.Text = string.Empty;
            latestVersionValueLabel.Text = string.Empty;
            informationTextBox.Clear();
            downloadLinkLabel.Text = string.Empty;
        }

        #region Event handlers

        private void CheckUpdatesForm_Load(object sender, EventArgs e)
        {
            currentVersionValueLabel.Text = Common.ApplicationVersion.ToString(3);
            downloadLinkLabel.Text = string.Empty;
            if (m_UpdateInfo == null)
            {
                if (!checkUpdatesBackgroundWorker.IsBusy)
                {
                    ClearDisplay();
                    updateReadoutLabel.Text = "Getting update info...";
                    checkUpdatesBackgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                DisplayUpdateInfo();
            }
        }

        private void downloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(downloadLinkLabel.Text);
            }
            catch (Win32Exception exception)
            {
                Program.HandleException(exception);
            }
        }

        private void checkUpdatesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                m_UpdateInfo = UpdateInfo.GetUpdateInfo();
                e.Result = (bool?)true;
            }
            catch (WebException exception)
            {
                Program.HandleException(exception);
                m_UpdateInfo = null;
                e.Result = (bool?)false;
            }
            catch (InvalidDataException exception)
            {
                Program.HandleException(exception);
                m_UpdateInfo = null;
                e.Result = (bool?)false;
            }
        }

        private void checkUpdatesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool? checkSuccess = e.Result as bool?;
            if (checkSuccess ?? false)
            {
                DisplayUpdateInfo();
            }
            else
            {
                m_UpdateInfo = null;
                DisplayUpdateInfo();
                string text = "Could not query server for latest version information.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_UpdateInfo = null;
        }

        #endregion
    }
}