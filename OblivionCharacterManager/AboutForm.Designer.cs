namespace OblivionCharacterManager
{
    partial class AboutForm
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            System.Windows.Forms.PictureBox logoPictureBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.applicationNameLabel = new System.Windows.Forms.Label();
            this.applicationVersionLabel = new System.Windows.Forms.Label();
            this.applicationCopyrightLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            logoPictureBox = new System.Windows.Forms.PictureBox();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(this.applicationNameLabel, 1, 0);
            tableLayoutPanel.Controls.Add(this.applicationVersionLabel, 1, 1);
            tableLayoutPanel.Controls.Add(this.applicationCopyrightLabel, 1, 2);
            tableLayoutPanel.Controls.Add(this.descriptionLabel, 1, 3);
            tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(348, 327);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = global::OblivionCharacterManager.Properties.Resources.OblivionCharacterManager48;
            logoPictureBox.Location = new System.Drawing.Point(3, 3);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 3);
            logoPictureBox.Size = new System.Drawing.Size(54, 54);
            logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // applicationNameLabel
            // 
            this.applicationNameLabel.AutoSize = true;
            this.applicationNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.applicationNameLabel.Location = new System.Drawing.Point(63, 0);
            this.applicationNameLabel.Name = "applicationNameLabel";
            this.applicationNameLabel.Size = new System.Drawing.Size(99, 20);
            this.applicationNameLabel.TabIndex = 0;
            this.applicationNameLabel.Text = "<application name>";
            this.applicationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // applicationVersionLabel
            // 
            this.applicationVersionLabel.AutoSize = true;
            this.applicationVersionLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.applicationVersionLabel.Location = new System.Drawing.Point(63, 20);
            this.applicationVersionLabel.Name = "applicationVersionLabel";
            this.applicationVersionLabel.Size = new System.Drawing.Size(107, 20);
            this.applicationVersionLabel.TabIndex = 1;
            this.applicationVersionLabel.Text = "<application version>";
            this.applicationVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // applicationCopyrightLabel
            // 
            this.applicationCopyrightLabel.AutoSize = true;
            this.applicationCopyrightLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.applicationCopyrightLabel.Location = new System.Drawing.Point(63, 40);
            this.applicationCopyrightLabel.Name = "applicationCopyrightLabel";
            this.applicationCopyrightLabel.Size = new System.Drawing.Size(116, 20);
            this.applicationCopyrightLabel.TabIndex = 2;
            this.applicationCopyrightLabel.Text = "<application copyright>";
            this.applicationCopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(this.descriptionLabel, 2);
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Padding = new System.Windows.Forms.Padding(3);
            this.descriptionLabel.Size = new System.Drawing.Size(342, 267);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = resources.GetString("descriptionLabel.Text");
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(285, 345);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(372, 374);
            this.Controls.Add(this.okButton);
            this.Controls.Add(tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label applicationNameLabel;
        private System.Windows.Forms.Label applicationVersionLabel;
        private System.Windows.Forms.Label applicationCopyrightLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label descriptionLabel;
    }
}