using System;
using FormsLibrary;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Displays information about the application.
    /// </summary>
    public partial class AboutForm : BaseForm
    {
        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.AboutForm"/> instance.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        #region Event handlers

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Text = "About " + Common.ApplicationName;
            applicationNameLabel.Text = Common.ApplicationName;
            applicationVersionLabel.Text = "Version " + Common.ApplicationVersion.ToString(3);
            applicationCopyrightLabel.Text = Common.ApplicationCopyright;
        }

        #endregion
    }
}