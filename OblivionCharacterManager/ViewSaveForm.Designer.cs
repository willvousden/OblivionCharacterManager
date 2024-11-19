namespace OblivionCharacterManager
{
    partial class ViewSaveForm
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
            System.Windows.Forms.GroupBox saveInfoGroupBox;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label saveFileNameLabel;
            System.Windows.Forms.Label characterNameLabel;
            System.Windows.Forms.Label playTimeLabel;
            System.Windows.Forms.Label characterLevelLabel;
            System.Windows.Forms.Label characterLocationLabel;
            System.Windows.Forms.Label gameTimeLabel;
            System.Windows.Forms.Label oblivionSaveVersionLabel;
            System.Windows.Forms.Label lastSaveLabel;
            System.Windows.Forms.Label pluginDependenciesLabel;
            System.Windows.Forms.Label screenshotLabel;
            System.Windows.Forms.ColumnHeader pluginFileNameColumnHeader;
            System.Windows.Forms.ColumnHeader pluginStatusColumnHeader;
            this.playTimeValueLabel = new System.Windows.Forms.Label();
            this.oblivionSaveVersionValueLabel = new System.Windows.Forms.Label();
            this.saveFileNameValueLabel = new System.Windows.Forms.Label();
            this.lastSaveValueLabel = new System.Windows.Forms.Label();
            this.gameTimeValueLabel = new System.Windows.Forms.Label();
            this.characterNameValueLabel = new System.Windows.Forms.Label();
            this.characterLocationValueLabel = new System.Windows.Forms.Label();
            this.characterLevelValueLabel = new System.Windows.Forms.Label();
            this.pluginListView = new System.Windows.Forms.ListView();
            this.screenshotPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveDuplicateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openContainingDirectoryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openDataDirectoryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveDuplicateSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveInfoGroupBox = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            saveFileNameLabel = new System.Windows.Forms.Label();
            characterNameLabel = new System.Windows.Forms.Label();
            playTimeLabel = new System.Windows.Forms.Label();
            characterLevelLabel = new System.Windows.Forms.Label();
            characterLocationLabel = new System.Windows.Forms.Label();
            gameTimeLabel = new System.Windows.Forms.Label();
            oblivionSaveVersionLabel = new System.Windows.Forms.Label();
            lastSaveLabel = new System.Windows.Forms.Label();
            pluginDependenciesLabel = new System.Windows.Forms.Label();
            screenshotLabel = new System.Windows.Forms.Label();
            pluginFileNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            pluginStatusColumnHeader = new System.Windows.Forms.ColumnHeader();
            saveInfoGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenshotPictureBox)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveInfoGroupBox
            // 
            saveInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            saveInfoGroupBox.Controls.Add(tableLayoutPanel1);
            saveInfoGroupBox.Controls.Add(pluginDependenciesLabel);
            saveInfoGroupBox.Controls.Add(screenshotLabel);
            saveInfoGroupBox.Controls.Add(this.pluginListView);
            saveInfoGroupBox.Controls.Add(this.screenshotPictureBox);
            saveInfoGroupBox.Location = new System.Drawing.Point(12, 28);
            saveInfoGroupBox.Name = "saveInfoGroupBox";
            saveInfoGroupBox.Size = new System.Drawing.Size(658, 357);
            saveInfoGroupBox.TabIndex = 1;
            saveInfoGroupBox.TabStop = false;
            saveInfoGroupBox.Text = "Save info";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(saveFileNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(this.playTimeValueLabel, 1, 6);
            tableLayoutPanel1.Controls.Add(characterNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(this.oblivionSaveVersionValueLabel, 1, 7);
            tableLayoutPanel1.Controls.Add(playTimeLabel, 0, 6);
            tableLayoutPanel1.Controls.Add(characterLevelLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(this.saveFileNameValueLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(this.lastSaveValueLabel, 1, 5);
            tableLayoutPanel1.Controls.Add(characterLocationLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(this.gameTimeValueLabel, 1, 4);
            tableLayoutPanel1.Controls.Add(gameTimeLabel, 0, 4);
            tableLayoutPanel1.Controls.Add(oblivionSaveVersionLabel, 0, 7);
            tableLayoutPanel1.Controls.Add(lastSaveLabel, 0, 5);
            tableLayoutPanel1.Controls.Add(this.characterNameValueLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(this.characterLocationValueLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(this.characterLevelValueLabel, 1, 2);
            tableLayoutPanel1.Location = new System.Drawing.Point(6, 242);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(646, 105);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // saveFileNameLabel
            // 
            saveFileNameLabel.AutoSize = true;
            saveFileNameLabel.Location = new System.Drawing.Point(3, 0);
            saveFileNameLabel.Name = "saveFileNameLabel";
            saveFileNameLabel.Size = new System.Drawing.Size(80, 13);
            saveFileNameLabel.TabIndex = 0;
            saveFileNameLabel.Text = "Save file name:";
            // 
            // playTimeValueLabel
            // 
            this.playTimeValueLabel.AutoSize = true;
            this.playTimeValueLabel.Location = new System.Drawing.Point(105, 78);
            this.playTimeValueLabel.Name = "playTimeValueLabel";
            this.playTimeValueLabel.Size = new System.Drawing.Size(102, 13);
            this.playTimeValueLabel.TabIndex = 13;
            this.playTimeValueLabel.Text = "playTimeValueLabel";
            // 
            // characterNameLabel
            // 
            characterNameLabel.AutoSize = true;
            characterNameLabel.Location = new System.Drawing.Point(3, 13);
            characterNameLabel.Name = "characterNameLabel";
            characterNameLabel.Size = new System.Drawing.Size(85, 13);
            characterNameLabel.TabIndex = 2;
            characterNameLabel.Text = "Character name:";
            // 
            // oblivionSaveVersionValueLabel
            // 
            this.oblivionSaveVersionValueLabel.AutoSize = true;
            this.oblivionSaveVersionValueLabel.Location = new System.Drawing.Point(105, 91);
            this.oblivionSaveVersionValueLabel.Name = "oblivionSaveVersionValueLabel";
            this.oblivionSaveVersionValueLabel.Size = new System.Drawing.Size(131, 13);
            this.oblivionSaveVersionValueLabel.TabIndex = 15;
            this.oblivionSaveVersionValueLabel.Text = "oblivionVersionValueLabel";
            // 
            // playTimeLabel
            // 
            playTimeLabel.AutoSize = true;
            playTimeLabel.Location = new System.Drawing.Point(3, 78);
            playTimeLabel.Name = "playTimeLabel";
            playTimeLabel.Size = new System.Drawing.Size(52, 13);
            playTimeLabel.TabIndex = 12;
            playTimeLabel.Text = "Play time:";
            // 
            // characterLevelLabel
            // 
            characterLevelLabel.AutoSize = true;
            characterLevelLabel.Location = new System.Drawing.Point(3, 26);
            characterLevelLabel.Name = "characterLevelLabel";
            characterLevelLabel.Size = new System.Drawing.Size(81, 13);
            characterLevelLabel.TabIndex = 4;
            characterLevelLabel.Text = "Character level:";
            // 
            // saveFileNameValueLabel
            // 
            this.saveFileNameValueLabel.AutoSize = true;
            this.saveFileNameValueLabel.Location = new System.Drawing.Point(105, 0);
            this.saveFileNameValueLabel.Name = "saveFileNameValueLabel";
            this.saveFileNameValueLabel.Size = new System.Drawing.Size(127, 13);
            this.saveFileNameValueLabel.TabIndex = 1;
            this.saveFileNameValueLabel.Text = "saveFileNameValueLabel";
            // 
            // lastSaveValueLabel
            // 
            this.lastSaveValueLabel.AutoSize = true;
            this.lastSaveValueLabel.Location = new System.Drawing.Point(105, 65);
            this.lastSaveValueLabel.Name = "lastSaveValueLabel";
            this.lastSaveValueLabel.Size = new System.Drawing.Size(101, 13);
            this.lastSaveValueLabel.TabIndex = 11;
            this.lastSaveValueLabel.Text = "lastSaveValueLabel";
            // 
            // characterLocationLabel
            // 
            characterLocationLabel.AutoSize = true;
            characterLocationLabel.Location = new System.Drawing.Point(3, 39);
            characterLocationLabel.Name = "characterLocationLabel";
            characterLocationLabel.Size = new System.Drawing.Size(96, 13);
            characterLocationLabel.TabIndex = 6;
            characterLocationLabel.Text = "Character location:";
            // 
            // gameTimeValueLabel
            // 
            this.gameTimeValueLabel.AutoSize = true;
            this.gameTimeValueLabel.Location = new System.Drawing.Point(105, 52);
            this.gameTimeValueLabel.Name = "gameTimeValueLabel";
            this.gameTimeValueLabel.Size = new System.Drawing.Size(109, 13);
            this.gameTimeValueLabel.TabIndex = 9;
            this.gameTimeValueLabel.Text = "gameTimeValueLabel";
            // 
            // gameTimeLabel
            // 
            gameTimeLabel.AutoSize = true;
            gameTimeLabel.Location = new System.Drawing.Point(3, 52);
            gameTimeLabel.Name = "gameTimeLabel";
            gameTimeLabel.Size = new System.Drawing.Size(60, 13);
            gameTimeLabel.TabIndex = 8;
            gameTimeLabel.Text = "Game time:";
            // 
            // oblivionSaveVersionLabel
            // 
            oblivionSaveVersionLabel.AutoSize = true;
            oblivionSaveVersionLabel.Location = new System.Drawing.Point(3, 91);
            oblivionSaveVersionLabel.Name = "oblivionSaveVersionLabel";
            oblivionSaveVersionLabel.Size = new System.Drawing.Size(85, 13);
            oblivionSaveVersionLabel.TabIndex = 14;
            oblivionSaveVersionLabel.Text = "Oblivion version:";
            // 
            // lastSaveLabel
            // 
            lastSaveLabel.AutoSize = true;
            lastSaveLabel.Location = new System.Drawing.Point(3, 65);
            lastSaveLabel.Name = "lastSaveLabel";
            lastSaveLabel.Size = new System.Drawing.Size(56, 13);
            lastSaveLabel.TabIndex = 10;
            lastSaveLabel.Text = "Last save:";
            // 
            // characterNameValueLabel
            // 
            this.characterNameValueLabel.AutoSize = true;
            this.characterNameValueLabel.Location = new System.Drawing.Point(105, 13);
            this.characterNameValueLabel.Name = "characterNameValueLabel";
            this.characterNameValueLabel.Size = new System.Drawing.Size(133, 13);
            this.characterNameValueLabel.TabIndex = 3;
            this.characterNameValueLabel.Text = "characterNameValueLabel";
            // 
            // characterLocationValueLabel
            // 
            this.characterLocationValueLabel.AutoSize = true;
            this.characterLocationValueLabel.Location = new System.Drawing.Point(105, 39);
            this.characterLocationValueLabel.Name = "characterLocationValueLabel";
            this.characterLocationValueLabel.Size = new System.Drawing.Size(146, 13);
            this.characterLocationValueLabel.TabIndex = 7;
            this.characterLocationValueLabel.Text = "characterLocationValueLabel";
            // 
            // characterLevelValueLabel
            // 
            this.characterLevelValueLabel.AutoSize = true;
            this.characterLevelValueLabel.Location = new System.Drawing.Point(105, 26);
            this.characterLevelValueLabel.Name = "characterLevelValueLabel";
            this.characterLevelValueLabel.Size = new System.Drawing.Size(131, 13);
            this.characterLevelValueLabel.TabIndex = 5;
            this.characterLevelValueLabel.Text = "characterLeveValuelLabel";
            // 
            // pluginDependenciesLabel
            // 
            pluginDependenciesLabel.AutoSize = true;
            pluginDependenciesLabel.Location = new System.Drawing.Point(265, 16);
            pluginDependenciesLabel.Name = "pluginDependenciesLabel";
            pluginDependenciesLabel.Size = new System.Drawing.Size(106, 13);
            pluginDependenciesLabel.TabIndex = 1;
            pluginDependenciesLabel.Text = "Plugin dependencies";
            // 
            // screenshotLabel
            // 
            screenshotLabel.AutoSize = true;
            screenshotLabel.Location = new System.Drawing.Point(3, 16);
            screenshotLabel.Name = "screenshotLabel";
            screenshotLabel.Size = new System.Drawing.Size(61, 13);
            screenshotLabel.TabIndex = 0;
            screenshotLabel.Text = "Screenshot";
            // 
            // pluginListView
            // 
            this.pluginListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            pluginFileNameColumnHeader,
            pluginStatusColumnHeader});
            this.pluginListView.FullRowSelect = true;
            this.pluginListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pluginListView.Location = new System.Drawing.Point(268, 32);
            this.pluginListView.MultiSelect = false;
            this.pluginListView.Name = "pluginListView";
            this.pluginListView.Size = new System.Drawing.Size(384, 204);
            this.pluginListView.TabIndex = 2;
            this.pluginListView.UseCompatibleStateImageBehavior = false;
            this.pluginListView.View = System.Windows.Forms.View.Details;
            // 
            // pluginFileNameColumnHeader
            // 
            pluginFileNameColumnHeader.Text = "Plugin file name";
            pluginFileNameColumnHeader.Width = 274;
            // 
            // pluginStatusColumnHeader
            // 
            pluginStatusColumnHeader.Text = "Status";
            pluginStatusColumnHeader.Width = 93;
            // 
            // screenshotPictureBox
            // 
            this.screenshotPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.screenshotPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.screenshotPictureBox.Location = new System.Drawing.Point(6, 32);
            this.screenshotPictureBox.Name = "screenshotPictureBox";
            this.screenshotPictureBox.Size = new System.Drawing.Size(256, 204);
            this.screenshotPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenshotPictureBox.TabIndex = 13;
            this.screenshotPictureBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(593, 391);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDuplicateToolStripButton,
            this.toolStripSeparator1,
            this.openContainingDirectoryToolStripButton,
            this.openDataDirectoryToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(680, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // saveDuplicateToolStripButton
            // 
            this.saveDuplicateToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Save;
            this.saveDuplicateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDuplicateToolStripButton.Name = "saveDuplicateToolStripButton";
            this.saveDuplicateToolStripButton.Size = new System.Drawing.Size(98, 22);
            this.saveDuplicateToolStripButton.Text = "Save Duplicate";
            this.saveDuplicateToolStripButton.Click += new System.EventHandler(this.saveDuplicateToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openContainingDirectoryToolStripButton
            // 
            this.openContainingDirectoryToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Open;
            this.openContainingDirectoryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openContainingDirectoryToolStripButton.Name = "openContainingDirectoryToolStripButton";
            this.openContainingDirectoryToolStripButton.Size = new System.Drawing.Size(154, 22);
            this.openContainingDirectoryToolStripButton.Text = "Open Containing Directory";
            this.openContainingDirectoryToolStripButton.Click += new System.EventHandler(this.openContainingDirectoryToolStripButton_Click);
            // 
            // openDataDirectoryToolStripButton
            // 
            this.openDataDirectoryToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Open;
            this.openDataDirectoryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openDataDirectoryToolStripButton.Name = "openDataDirectoryToolStripButton";
            this.openDataDirectoryToolStripButton.Size = new System.Drawing.Size(126, 22);
            this.openDataDirectoryToolStripButton.Text = "Open Data Directory";
            this.openDataDirectoryToolStripButton.Click += new System.EventHandler(this.openDataDirectoryToolStripButton_Click);
            // 
            // saveDuplicateSaveFileDialog
            // 
            this.saveDuplicateSaveFileDialog.Filter = "Oblivion save files (*.ess)|*.ess";
            this.saveDuplicateSaveFileDialog.Title = "Save Duplicate";
            // 
            // ViewSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(680, 426);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(saveInfoGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSaveForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Save";
            saveInfoGroupBox.ResumeLayout(false);
            saveInfoGroupBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenshotPictureBox)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playTimeValueLabel;
        private System.Windows.Forms.Label oblivionSaveVersionValueLabel;
        private System.Windows.Forms.Label saveFileNameValueLabel;
        private System.Windows.Forms.Label lastSaveValueLabel;
        private System.Windows.Forms.Label gameTimeValueLabel;
        private System.Windows.Forms.Label characterNameValueLabel;
        private System.Windows.Forms.Label characterLocationValueLabel;
        private System.Windows.Forms.Label characterLevelValueLabel;
        private System.Windows.Forms.ListView pluginListView;
        private System.Windows.Forms.PictureBox screenshotPictureBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveDuplicateToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openContainingDirectoryToolStripButton;
        private System.Windows.Forms.ToolStripButton openDataDirectoryToolStripButton;
        private System.Windows.Forms.SaveFileDialog saveDuplicateSaveFileDialog;
    }
}