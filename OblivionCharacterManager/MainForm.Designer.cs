namespace OblivionCharacterManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStrip toolStrip;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ColumnHeader SaveFileNameColumnHeader;
            System.Windows.Forms.ColumnHeader levelColumnHeader;
            System.Windows.Forms.ColumnHeader locationColumnHeader;
            System.Windows.Forms.Label characterLabel;
            System.Windows.Forms.StatusStrip statusStrip;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.viewSaveButton = new System.Windows.Forms.Button();
            this.characterOptionsButton = new System.Windows.Forms.Button();
            this.tidySaveDirectoryButton = new System.Windows.Forms.Button();
            this.showInGroupsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveListView = new System.Windows.Forms.ListView();
            this.lastSaveTimeColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.saveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tidySaveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSaveButton = new System.Windows.Forms.Button();
            this.deleteCharacterButton = new System.Windows.Forms.Button();
            this.setAsActiveCharacterButton = new System.Windows.Forms.Button();
            this.characterComboBox = new System.Windows.Forms.ComboBox();
            this.checkUpdatesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.openContainingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchOblivionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.launchObmmToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openSaveDirectoryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addCharacterToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.optionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStrip = new System.Windows.Forms.ToolStrip();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            SaveFileNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            levelColumnHeader = new System.Windows.Forms.ColumnHeader();
            locationColumnHeader = new System.Windows.Forms.ColumnHeader();
            characterLabel = new System.Windows.Forms.Label();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.saveContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchOblivionToolStripButton,
            this.launchObmmToolStripButton,
            this.openSaveDirectoryToolStripButton,
            toolStripSeparator1,
            this.addCharacterToolStripButton,
            toolStripSeparator2,
            this.optionsToolStripButton,
            this.aboutToolStripButton});
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(733, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveFileNameColumnHeader
            // 
            SaveFileNameColumnHeader.Text = "Save file name";
            SaveFileNameColumnHeader.Width = 386;
            // 
            // levelColumnHeader
            // 
            levelColumnHeader.Text = "Level";
            levelColumnHeader.Width = 45;
            // 
            // locationColumnHeader
            // 
            locationColumnHeader.Text = "Location";
            locationColumnHeader.Width = 132;
            // 
            // characterLabel
            // 
            characterLabel.AutoSize = true;
            characterLabel.Location = new System.Drawing.Point(12, 33);
            characterLabel.Name = "characterLabel";
            characterLabel.Size = new System.Drawing.Size(53, 13);
            characterLabel.TabIndex = 1;
            characterLabel.Text = "Character";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            statusStrip.Location = new System.Drawing.Point(0, 494);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(733, 22);
            statusStrip.TabIndex = 11;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Filter = "*";
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)));
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            // 
            // viewSaveButton
            // 
            this.viewSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewSaveButton.Enabled = false;
            this.viewSaveButton.Location = new System.Drawing.Point(394, 468);
            this.viewSaveButton.Name = "viewSaveButton";
            this.viewSaveButton.Size = new System.Drawing.Size(91, 23);
            this.viewSaveButton.TabIndex = 8;
            this.viewSaveButton.Text = "View Save";
            this.viewSaveButton.UseVisualStyleBackColor = true;
            this.viewSaveButton.Click += new System.EventHandler(this.viewSaveButton_Click);
            // 
            // characterOptionsButton
            // 
            this.characterOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.characterOptionsButton.Location = new System.Drawing.Point(586, 28);
            this.characterOptionsButton.Name = "characterOptionsButton";
            this.characterOptionsButton.Size = new System.Drawing.Size(75, 23);
            this.characterOptionsButton.TabIndex = 4;
            this.characterOptionsButton.Text = "Options";
            this.characterOptionsButton.UseVisualStyleBackColor = true;
            this.characterOptionsButton.Click += new System.EventHandler(this.characterOptionsButton_Click);
            // 
            // tidySaveDirectoryButton
            // 
            this.tidySaveDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tidySaveDirectoryButton.Location = new System.Drawing.Point(588, 468);
            this.tidySaveDirectoryButton.Name = "tidySaveDirectoryButton";
            this.tidySaveDirectoryButton.Size = new System.Drawing.Size(133, 23);
            this.tidySaveDirectoryButton.TabIndex = 10;
            this.tidySaveDirectoryButton.Text = "Tidy Save Directory";
            this.tidySaveDirectoryButton.UseVisualStyleBackColor = true;
            this.tidySaveDirectoryButton.Click += new System.EventHandler(this.tidySaveDirectoryButton_Click);
            // 
            // showInGroupsCheckBox
            // 
            this.showInGroupsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showInGroupsCheckBox.AutoSize = true;
            this.showInGroupsCheckBox.Checked = true;
            this.showInGroupsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInGroupsCheckBox.Location = new System.Drawing.Point(12, 472);
            this.showInGroupsCheckBox.Name = "showInGroupsCheckBox";
            this.showInGroupsCheckBox.Size = new System.Drawing.Size(99, 17);
            this.showInGroupsCheckBox.TabIndex = 7;
            this.showInGroupsCheckBox.Text = "Show in groups";
            this.showInGroupsCheckBox.UseVisualStyleBackColor = true;
            this.showInGroupsCheckBox.CheckedChanged += new System.EventHandler(this.showInGroupsCheckBox_CheckedChanged);
            // 
            // saveListView
            // 
            this.saveListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            SaveFileNameColumnHeader,
            levelColumnHeader,
            locationColumnHeader,
            this.lastSaveTimeColumnHeader});
            this.saveListView.ContextMenuStrip = this.saveContextMenuStrip;
            this.saveListView.FullRowSelect = true;
            this.saveListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.saveListView.HideSelection = false;
            this.saveListView.LabelEdit = true;
            this.saveListView.LabelWrap = false;
            this.saveListView.Location = new System.Drawing.Point(12, 57);
            this.saveListView.Name = "saveListView";
            this.saveListView.ShowItemToolTips = true;
            this.saveListView.Size = new System.Drawing.Size(709, 405);
            this.saveListView.TabIndex = 6;
            this.saveListView.UseCompatibleStateImageBehavior = false;
            this.saveListView.View = System.Windows.Forms.View.Details;
            this.saveListView.ItemActivate += new System.EventHandler(this.saveListView_ItemActivate);
            this.saveListView.SelectedIndexChanged += new System.EventHandler(this.saveListView_SelectedIndexChanged);
            this.saveListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saveListView_KeyDown);
            this.saveListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.saveListView_ColumnClick);
            this.saveListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.saveListView_AfterLabelEdit);
            // 
            // lastSaveTimeColumnHeader
            // 
            this.lastSaveTimeColumnHeader.Text = "Last Save Time";
            this.lastSaveTimeColumnHeader.Width = 129;
            // 
            // saveContextMenuStrip
            // 
            this.saveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.openContainingDirectoryToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            toolStripSeparator3,
            this.tidySaveDirectoryToolStripMenuItem});
            this.saveContextMenuStrip.Name = "saveContextMenuStrip";
            this.saveContextMenuStrip.Size = new System.Drawing.Size(202, 142);
            this.saveContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.saveContextMenuStrip_Opening);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // tidySaveDirectoryToolStripMenuItem
            // 
            this.tidySaveDirectoryToolStripMenuItem.Name = "tidySaveDirectoryToolStripMenuItem";
            this.tidySaveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.tidySaveDirectoryToolStripMenuItem.Text = "Tidy Save Directory";
            this.tidySaveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.tidySaveDirectoryToolStripMenuItem_Click);
            // 
            // deleteSaveButton
            // 
            this.deleteSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSaveButton.Enabled = false;
            this.deleteSaveButton.Location = new System.Drawing.Point(491, 468);
            this.deleteSaveButton.Name = "deleteSaveButton";
            this.deleteSaveButton.Size = new System.Drawing.Size(91, 23);
            this.deleteSaveButton.TabIndex = 9;
            this.deleteSaveButton.Text = "Delete Save";
            this.deleteSaveButton.UseVisualStyleBackColor = true;
            this.deleteSaveButton.Click += new System.EventHandler(this.deleteSaveButton_Click);
            // 
            // deleteCharacterButton
            // 
            this.deleteCharacterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteCharacterButton.Enabled = false;
            this.deleteCharacterButton.Location = new System.Drawing.Point(667, 28);
            this.deleteCharacterButton.Name = "deleteCharacterButton";
            this.deleteCharacterButton.Size = new System.Drawing.Size(54, 23);
            this.deleteCharacterButton.TabIndex = 5;
            this.deleteCharacterButton.Text = "Delete";
            this.deleteCharacterButton.UseVisualStyleBackColor = true;
            this.deleteCharacterButton.Click += new System.EventHandler(this.deleteCharacterButton_Click);
            // 
            // setAsActiveCharacterButton
            // 
            this.setAsActiveCharacterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setAsActiveCharacterButton.Enabled = false;
            this.setAsActiveCharacterButton.Location = new System.Drawing.Point(489, 28);
            this.setAsActiveCharacterButton.Name = "setAsActiveCharacterButton";
            this.setAsActiveCharacterButton.Size = new System.Drawing.Size(91, 23);
            this.setAsActiveCharacterButton.TabIndex = 3;
            this.setAsActiveCharacterButton.Text = "Set As Active";
            this.setAsActiveCharacterButton.UseVisualStyleBackColor = true;
            this.setAsActiveCharacterButton.Click += new System.EventHandler(this.setAsActiveCharacterButton_Click);
            // 
            // characterComboBox
            // 
            this.characterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.characterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterComboBox.FormattingEnabled = true;
            this.characterComboBox.Items.AddRange(new object[] {
            "[all characters]"});
            this.characterComboBox.Location = new System.Drawing.Point(71, 30);
            this.characterComboBox.Name = "characterComboBox";
            this.characterComboBox.Size = new System.Drawing.Size(412, 21);
            this.characterComboBox.TabIndex = 2;
            this.characterComboBox.SelectedIndexChanged += new System.EventHandler(this.characterComboBox_SelectedIndexChanged);
            // 
            // checkUpdatesBackgroundWorker
            // 
            this.checkUpdatesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkUpdatesBackgroundWorker_DoWork);
            this.checkUpdatesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkUpdatesBackgroundWorker_RunWorkerCompleted);
            // 
            // openContainingDirectoryToolStripMenuItem
            // 
            this.openContainingDirectoryToolStripMenuItem.Image = global::OblivionCharacterManager.Properties.Resources.Open;
            this.openContainingDirectoryToolStripMenuItem.Name = "openContainingDirectoryToolStripMenuItem";
            this.openContainingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openContainingDirectoryToolStripMenuItem.Text = "Open Containing Directory";
            this.openContainingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::OblivionCharacterManager.Properties.Resources.Rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::OblivionCharacterManager.Properties.Resources.Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // launchOblivionToolStripButton
            // 
            this.launchOblivionToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Oblivion;
            this.launchOblivionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.launchOblivionToolStripButton.Name = "launchOblivionToolStripButton";
            this.launchOblivionToolStripButton.Size = new System.Drawing.Size(102, 22);
            this.launchOblivionToolStripButton.Text = "Launch Oblivion";
            this.launchOblivionToolStripButton.Click += new System.EventHandler(this.launchOblivionToolStripButton_Click);
            // 
            // launchObmmToolStripButton
            // 
            this.launchObmmToolStripButton.Enabled = false;
            this.launchObmmToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Obmm;
            this.launchObmmToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.launchObmmToolStripButton.Name = "launchObmmToolStripButton";
            this.launchObmmToolStripButton.Size = new System.Drawing.Size(94, 22);
            this.launchObmmToolStripButton.Text = "Launch OBMM";
            this.launchObmmToolStripButton.Click += new System.EventHandler(this.launchObmmToolStripButton_Click);
            // 
            // openSaveDirectoryToolStripButton
            // 
            this.openSaveDirectoryToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Open;
            this.openSaveDirectoryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openSaveDirectoryToolStripButton.Name = "openSaveDirectoryToolStripButton";
            this.openSaveDirectoryToolStripButton.Size = new System.Drawing.Size(127, 22);
            this.openSaveDirectoryToolStripButton.Text = "Open Save Directory";
            this.openSaveDirectoryToolStripButton.Click += new System.EventHandler(this.openSaveDirectoryToolStripButton_Click);
            // 
            // addCharacterToolStripButton
            // 
            this.addCharacterToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.NewDocument;
            this.addCharacterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCharacterToolStripButton.Name = "addCharacterToolStripButton";
            this.addCharacterToolStripButton.Size = new System.Drawing.Size(97, 22);
            this.addCharacterToolStripButton.Text = "Add Character";
            this.addCharacterToolStripButton.Click += new System.EventHandler(this.addCharacterToolStripButton_Click);
            // 
            // optionsToolStripButton
            // 
            this.optionsToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.Options;
            this.optionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsToolStripButton.Name = "optionsToolStripButton";
            this.optionsToolStripButton.Size = new System.Drawing.Size(64, 22);
            this.optionsToolStripButton.Text = "Options";
            this.optionsToolStripButton.Click += new System.EventHandler(this.optionsToolStripButton_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Image = global::OblivionCharacterManager.Properties.Resources.About;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(56, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 516);
            this.Controls.Add(statusStrip);
            this.Controls.Add(this.tidySaveDirectoryButton);
            this.Controls.Add(this.showInGroupsCheckBox);
            this.Controls.Add(this.viewSaveButton);
            this.Controls.Add(this.characterOptionsButton);
            this.Controls.Add(this.saveListView);
            this.Controls.Add(this.deleteCharacterButton);
            this.Controls.Add(this.deleteSaveButton);
            this.Controls.Add(characterLabel);
            this.Controls.Add(this.characterComboBox);
            this.Controls.Add(toolStrip);
            this.Controls.Add(this.setAsActiveCharacterButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(741, 292);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oblivion Character Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.saveContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton launchOblivionToolStripButton;
        private System.Windows.Forms.ToolStripButton optionsToolStripButton;
        private System.Windows.Forms.ToolStripButton launchObmmToolStripButton;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.ToolStripButton openSaveDirectoryToolStripButton;
        private System.Windows.Forms.Button viewSaveButton;
        private System.Windows.Forms.Button characterOptionsButton;
        private System.Windows.Forms.Button tidySaveDirectoryButton;
        private System.Windows.Forms.CheckBox showInGroupsCheckBox;
        private System.Windows.Forms.ListView saveListView;
        private System.Windows.Forms.Button deleteSaveButton;
        private System.Windows.Forms.Button deleteCharacterButton;
        private System.Windows.Forms.Button setAsActiveCharacterButton;
        private System.Windows.Forms.ComboBox characterComboBox;
        private System.Windows.Forms.ColumnHeader lastSaveTimeColumnHeader;
        private System.Windows.Forms.ContextMenuStrip saveContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openContainingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tidySaveDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton addCharacterToolStripButton;
        private System.ComponentModel.BackgroundWorker checkUpdatesBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;

    }
}

