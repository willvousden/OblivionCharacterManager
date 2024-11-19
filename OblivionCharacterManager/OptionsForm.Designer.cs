namespace OblivionCharacterManager
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox generalGroupBox;
            this.rememberFormStatesCheckBox = new System.Windows.Forms.CheckBox();
            this.checkUpdatesOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.loadObseCheckBox = new System.Windows.Forms.CheckBox();
            this.oblivionLaunchCommandLineTextBox = new System.Windows.Forms.TextBox();
            this.oblivionLaunchCommandLineLabel = new System.Windows.Forms.Label();
            this.checkUpdatesNowButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.rootSaveDirectoryLabel = new System.Windows.Forms.Label();
            this.rootSaveDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.oblivionInstallDirectoryFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.oblivionInstallDirectoryBrowseButton = new System.Windows.Forms.Button();
            this.oblivionInstallDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.oblivionInstallDirectoryLabel = new System.Windows.Forms.Label();
            this.autodetectButton = new System.Windows.Forms.Button();
            this.directoriesGroupBox = new System.Windows.Forms.GroupBox();
            generalGroupBox = new System.Windows.Forms.GroupBox();
            generalGroupBox.SuspendLayout();
            this.directoriesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroupBox
            // 
            generalGroupBox.Controls.Add(this.rememberFormStatesCheckBox);
            generalGroupBox.Controls.Add(this.checkUpdatesOnStartupCheckBox);
            generalGroupBox.Controls.Add(this.loadObseCheckBox);
            generalGroupBox.Controls.Add(this.oblivionLaunchCommandLineTextBox);
            generalGroupBox.Controls.Add(this.oblivionLaunchCommandLineLabel);
            generalGroupBox.Controls.Add(this.checkUpdatesNowButton);
            generalGroupBox.Location = new System.Drawing.Point(12, 12);
            generalGroupBox.Name = "generalGroupBox";
            generalGroupBox.Size = new System.Drawing.Size(446, 114);
            generalGroupBox.TabIndex = 0;
            generalGroupBox.TabStop = false;
            generalGroupBox.Text = "General";
            // 
            // rememberFormStatesCheckBox
            // 
            this.rememberFormStatesCheckBox.AutoSize = true;
            this.rememberFormStatesCheckBox.Location = new System.Drawing.Point(9, 91);
            this.rememberFormStatesCheckBox.Name = "rememberFormStatesCheckBox";
            this.rememberFormStatesCheckBox.Size = new System.Drawing.Size(208, 17);
            this.rememberFormStatesCheckBox.TabIndex = 6;
            this.rememberFormStatesCheckBox.Text = "Remember window locations and sizes";
            this.rememberFormStatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkUpdatesOnStartupCheckBox
            // 
            this.checkUpdatesOnStartupCheckBox.AutoSize = true;
            this.checkUpdatesOnStartupCheckBox.Location = new System.Drawing.Point(9, 68);
            this.checkUpdatesOnStartupCheckBox.Name = "checkUpdatesOnStartupCheckBox";
            this.checkUpdatesOnStartupCheckBox.Size = new System.Drawing.Size(306, 17);
            this.checkUpdatesOnStartupCheckBox.TabIndex = 3;
            this.checkUpdatesOnStartupCheckBox.Text = "Check for updates when the program starts (in background)";
            this.checkUpdatesOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadObseCheckBox
            // 
            this.loadObseCheckBox.AutoSize = true;
            this.loadObseCheckBox.Location = new System.Drawing.Point(9, 45);
            this.loadObseCheckBox.Name = "loadObseCheckBox";
            this.loadObseCheckBox.Size = new System.Drawing.Size(285, 17);
            this.loadObseCheckBox.TabIndex = 2;
            this.loadObseCheckBox.Text = "Load Oblivion Script Extender when launching Oblivion";
            this.loadObseCheckBox.UseVisualStyleBackColor = true;
            this.loadObseCheckBox.CheckedChanged += new System.EventHandler(this.loadObseCheckBox_CheckedChanged);
            // 
            // oblivionLaunchCommandLineTextBox
            // 
            this.oblivionLaunchCommandLineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oblivionLaunchCommandLineTextBox.Location = new System.Drawing.Point(160, 19);
            this.oblivionLaunchCommandLineTextBox.Name = "oblivionLaunchCommandLineTextBox";
            this.oblivionLaunchCommandLineTextBox.Size = new System.Drawing.Size(280, 20);
            this.oblivionLaunchCommandLineTextBox.TabIndex = 1;
            // 
            // oblivionLaunchCommandLineLabel
            // 
            this.oblivionLaunchCommandLineLabel.AutoSize = true;
            this.oblivionLaunchCommandLineLabel.Location = new System.Drawing.Point(6, 22);
            this.oblivionLaunchCommandLineLabel.Name = "oblivionLaunchCommandLineLabel";
            this.oblivionLaunchCommandLineLabel.Size = new System.Drawing.Size(148, 13);
            this.oblivionLaunchCommandLineLabel.TabIndex = 0;
            this.oblivionLaunchCommandLineLabel.Text = "Oblivion launch command line";
            // 
            // checkUpdatesNowButton
            // 
            this.checkUpdatesNowButton.Location = new System.Drawing.Point(365, 64);
            this.checkUpdatesNowButton.Name = "checkUpdatesNowButton";
            this.checkUpdatesNowButton.Size = new System.Drawing.Size(75, 23);
            this.checkUpdatesNowButton.TabIndex = 4;
            this.checkUpdatesNowButton.Text = "Check now";
            this.checkUpdatesNowButton.UseVisualStyleBackColor = true;
            this.checkUpdatesNowButton.Click += new System.EventHandler(this.checkUpdatesNowButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(383, 238);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(302, 238);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // rootSaveDirectoryLabel
            // 
            this.rootSaveDirectoryLabel.AutoSize = true;
            this.rootSaveDirectoryLabel.Location = new System.Drawing.Point(6, 22);
            this.rootSaveDirectoryLabel.Name = "rootSaveDirectoryLabel";
            this.rootSaveDirectoryLabel.Size = new System.Drawing.Size(99, 13);
            this.rootSaveDirectoryLabel.TabIndex = 0;
            this.rootSaveDirectoryLabel.Text = "Root save directory";
            // 
            // rootSaveDirectoryTextBox
            // 
            this.rootSaveDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rootSaveDirectoryTextBox.Location = new System.Drawing.Point(129, 19);
            this.rootSaveDirectoryTextBox.Name = "rootSaveDirectoryTextBox";
            this.rootSaveDirectoryTextBox.Size = new System.Drawing.Size(311, 20);
            this.rootSaveDirectoryTextBox.TabIndex = 1;
            // 
            // oblivionInstallDirectoryFolderBrowserDialog
            // 
            this.oblivionInstallDirectoryFolderBrowserDialog.Description = "Please select the install directory for Oblivion.";
            this.oblivionInstallDirectoryFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.oblivionInstallDirectoryFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // oblivionInstallDirectoryBrowseButton
            // 
            this.oblivionInstallDirectoryBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oblivionInstallDirectoryBrowseButton.Location = new System.Drawing.Point(284, 71);
            this.oblivionInstallDirectoryBrowseButton.Name = "oblivionInstallDirectoryBrowseButton";
            this.oblivionInstallDirectoryBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.oblivionInstallDirectoryBrowseButton.TabIndex = 4;
            this.oblivionInstallDirectoryBrowseButton.Text = "Browse";
            this.oblivionInstallDirectoryBrowseButton.UseVisualStyleBackColor = true;
            this.oblivionInstallDirectoryBrowseButton.Click += new System.EventHandler(this.oblivionInstallDirectoryBrowseButton_Click);
            // 
            // oblivionInstallDirectoryTextBox
            // 
            this.oblivionInstallDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oblivionInstallDirectoryTextBox.Location = new System.Drawing.Point(129, 45);
            this.oblivionInstallDirectoryTextBox.Name = "oblivionInstallDirectoryTextBox";
            this.oblivionInstallDirectoryTextBox.Size = new System.Drawing.Size(311, 20);
            this.oblivionInstallDirectoryTextBox.TabIndex = 3;
            // 
            // oblivionInstallDirectoryLabel
            // 
            this.oblivionInstallDirectoryLabel.AutoSize = true;
            this.oblivionInstallDirectoryLabel.Location = new System.Drawing.Point(6, 48);
            this.oblivionInstallDirectoryLabel.Name = "oblivionInstallDirectoryLabel";
            this.oblivionInstallDirectoryLabel.Size = new System.Drawing.Size(117, 13);
            this.oblivionInstallDirectoryLabel.TabIndex = 2;
            this.oblivionInstallDirectoryLabel.Text = "Oblivion install directory";
            // 
            // autodetectButton
            // 
            this.autodetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autodetectButton.Location = new System.Drawing.Point(365, 71);
            this.autodetectButton.Name = "autodetectButton";
            this.autodetectButton.Size = new System.Drawing.Size(75, 23);
            this.autodetectButton.TabIndex = 5;
            this.autodetectButton.Text = "Autodetect";
            this.autodetectButton.UseVisualStyleBackColor = true;
            this.autodetectButton.Click += new System.EventHandler(this.autodetectButton_Click);
            // 
            // directoriesGroupBox
            // 
            this.directoriesGroupBox.Controls.Add(this.autodetectButton);
            this.directoriesGroupBox.Controls.Add(this.rootSaveDirectoryLabel);
            this.directoriesGroupBox.Controls.Add(this.rootSaveDirectoryTextBox);
            this.directoriesGroupBox.Controls.Add(this.oblivionInstallDirectoryBrowseButton);
            this.directoriesGroupBox.Controls.Add(this.oblivionInstallDirectoryTextBox);
            this.directoriesGroupBox.Controls.Add(this.oblivionInstallDirectoryLabel);
            this.directoriesGroupBox.Location = new System.Drawing.Point(12, 132);
            this.directoriesGroupBox.Name = "directoriesGroupBox";
            this.directoriesGroupBox.Size = new System.Drawing.Size(446, 100);
            this.directoriesGroupBox.TabIndex = 1;
            this.directoriesGroupBox.TabStop = false;
            this.directoriesGroupBox.Text = "Directories";
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(470, 273);
            this.Controls.Add(generalGroupBox);
            this.Controls.Add(this.directoriesGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            generalGroupBox.ResumeLayout(false);
            generalGroupBox.PerformLayout();
            this.directoriesGroupBox.ResumeLayout(false);
            this.directoriesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label oblivionLaunchCommandLineLabel;
        private System.Windows.Forms.TextBox oblivionLaunchCommandLineTextBox;
        private System.Windows.Forms.Label rootSaveDirectoryLabel;
        private System.Windows.Forms.TextBox rootSaveDirectoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog oblivionInstallDirectoryFolderBrowserDialog;
        private System.Windows.Forms.Button oblivionInstallDirectoryBrowseButton;
        private System.Windows.Forms.TextBox oblivionInstallDirectoryTextBox;
        private System.Windows.Forms.Label oblivionInstallDirectoryLabel;
        private System.Windows.Forms.Button autodetectButton;
        private System.Windows.Forms.GroupBox directoriesGroupBox;
        private System.Windows.Forms.CheckBox loadObseCheckBox;
        private System.Windows.Forms.Button checkUpdatesNowButton;
        private System.Windows.Forms.CheckBox checkUpdatesOnStartupCheckBox;
        private System.Windows.Forms.CheckBox rememberFormStatesCheckBox;
    }
}