namespace OblivionCharacterManager
{
    partial class UpdateForm
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
            this.checkUpdatesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.latestVersionLabel = new System.Windows.Forms.Label();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.currentVersionValueLabel = new System.Windows.Forms.Label();
            this.latestVersionValueLabel = new System.Windows.Forms.Label();
            this.informationTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.downloadLinkLabel = new System.Windows.Forms.LinkLabel();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.updateReadoutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkUpdatesBackgroundWorker
            // 
            this.checkUpdatesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkUpdatesBackgroundWorker_DoWork);
            this.checkUpdatesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkUpdatesBackgroundWorker_RunWorkerCompleted);
            // 
            // latestVersionLabel
            // 
            this.latestVersionLabel.AutoSize = true;
            this.latestVersionLabel.Location = new System.Drawing.Point(12, 22);
            this.latestVersionLabel.Name = "latestVersionLabel";
            this.latestVersionLabel.Size = new System.Drawing.Size(76, 13);
            this.latestVersionLabel.TabIndex = 2;
            this.latestVersionLabel.Text = "Latest version:";
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AutoSize = true;
            this.currentVersionLabel.Location = new System.Drawing.Point(12, 9);
            this.currentVersionLabel.Name = "currentVersionLabel";
            this.currentVersionLabel.Size = new System.Drawing.Size(81, 13);
            this.currentVersionLabel.TabIndex = 0;
            this.currentVersionLabel.Text = "Current version:";
            // 
            // currentVersionValueLabel
            // 
            this.currentVersionValueLabel.AutoSize = true;
            this.currentVersionValueLabel.Location = new System.Drawing.Point(99, 9);
            this.currentVersionValueLabel.Name = "currentVersionValueLabel";
            this.currentVersionValueLabel.Size = new System.Drawing.Size(89, 13);
            this.currentVersionValueLabel.TabIndex = 1;
            this.currentVersionValueLabel.Text = "<current version>";
            // 
            // latestVersionValueLabel
            // 
            this.latestVersionValueLabel.AutoSize = true;
            this.latestVersionValueLabel.Location = new System.Drawing.Point(99, 22);
            this.latestVersionValueLabel.Name = "latestVersionValueLabel";
            this.latestVersionValueLabel.Size = new System.Drawing.Size(81, 13);
            this.latestVersionValueLabel.TabIndex = 3;
            this.latestVersionValueLabel.Text = "<latest version>";
            // 
            // informationTextBox
            // 
            this.informationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.informationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.informationTextBox.Location = new System.Drawing.Point(12, 51);
            this.informationTextBox.Multiline = true;
            this.informationTextBox.Name = "informationTextBox";
            this.informationTextBox.ReadOnly = true;
            this.informationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.informationTextBox.Size = new System.Drawing.Size(355, 167);
            this.informationTextBox.TabIndex = 6;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(292, 224);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // downloadLinkLabel
            // 
            this.downloadLinkLabel.AutoSize = true;
            this.downloadLinkLabel.Location = new System.Drawing.Point(99, 35);
            this.downloadLinkLabel.Name = "downloadLinkLabel";
            this.downloadLinkLabel.Size = new System.Drawing.Size(79, 13);
            this.downloadLinkLabel.TabIndex = 5;
            this.downloadLinkLabel.TabStop = true;
            this.downloadLinkLabel.Text = "<download uri>";
            this.downloadLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.downloadLinkLabel_LinkClicked);
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(12, 35);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(58, 13);
            this.downloadLabel.TabIndex = 4;
            this.downloadLabel.Text = "Download:";
            // 
            // updateReadoutLabel
            // 
            this.updateReadoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateReadoutLabel.AutoSize = true;
            this.updateReadoutLabel.Location = new System.Drawing.Point(12, 229);
            this.updateReadoutLabel.Name = "updateReadoutLabel";
            this.updateReadoutLabel.Size = new System.Drawing.Size(91, 13);
            this.updateReadoutLabel.TabIndex = 7;
            this.updateReadoutLabel.Text = "<update readout>";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 259);
            this.Controls.Add(this.updateReadoutLabel);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.downloadLinkLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.informationTextBox);
            this.Controls.Add(this.latestVersionValueLabel);
            this.Controls.Add(this.currentVersionValueLabel);
            this.Controls.Add(this.currentVersionLabel);
            this.Controls.Add(this.latestVersionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_FormClosed);
            this.Load += new System.EventHandler(this.CheckUpdatesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker checkUpdatesBackgroundWorker;
        private System.Windows.Forms.Label latestVersionLabel;
        private System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.Label currentVersionValueLabel;
        private System.Windows.Forms.Label latestVersionValueLabel;
        private System.Windows.Forms.TextBox informationTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.LinkLabel downloadLinkLabel;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label updateReadoutLabel;
    }
}