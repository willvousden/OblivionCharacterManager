namespace OblivionCharacterManager
{
    partial class CharacterOptionsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.autosaveGroupBox = new System.Windows.Forms.GroupBox();
            this.saveOnWaitCheckBox = new System.Windows.Forms.CheckBox();
            this.saveOnTravelCheckBox = new System.Windows.Forms.CheckBox();
            this.saveOnRestCheckBox = new System.Windows.Forms.CheckBox();
            this.saveOnInteriorExteriorSwitchCheckBox = new System.Windows.Forms.CheckBox();
            this.miscellaneousGroupBox = new System.Windows.Forms.GroupBox();
            this.showCrosshairCheckBox = new System.Windows.Forms.CheckBox();
            this.difficultyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.difficultylLabel = new System.Windows.Forms.Label();
            this.autosaveGroupBox.SuspendLayout();
            this.miscellaneousGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(240, 205);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(159, 205);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // autosaveGroupBox
            // 
            this.autosaveGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autosaveGroupBox.Controls.Add(this.saveOnWaitCheckBox);
            this.autosaveGroupBox.Controls.Add(this.saveOnTravelCheckBox);
            this.autosaveGroupBox.Controls.Add(this.saveOnRestCheckBox);
            this.autosaveGroupBox.Controls.Add(this.saveOnInteriorExteriorSwitchCheckBox);
            this.autosaveGroupBox.Location = new System.Drawing.Point(12, 86);
            this.autosaveGroupBox.Name = "autosaveGroupBox";
            this.autosaveGroupBox.Size = new System.Drawing.Size(303, 113);
            this.autosaveGroupBox.TabIndex = 1;
            this.autosaveGroupBox.TabStop = false;
            this.autosaveGroupBox.Text = "Autosave";
            // 
            // saveOnWaitCheckBox
            // 
            this.saveOnWaitCheckBox.AutoSize = true;
            this.saveOnWaitCheckBox.Location = new System.Drawing.Point(6, 88);
            this.saveOnWaitCheckBox.Name = "saveOnWaitCheckBox";
            this.saveOnWaitCheckBox.Size = new System.Drawing.Size(88, 17);
            this.saveOnWaitCheckBox.TabIndex = 3;
            this.saveOnWaitCheckBox.Text = "Save on wait";
            this.saveOnWaitCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveOnTravelCheckBox
            // 
            this.saveOnTravelCheckBox.AutoSize = true;
            this.saveOnTravelCheckBox.Location = new System.Drawing.Point(6, 65);
            this.saveOnTravelCheckBox.Name = "saveOnTravelCheckBox";
            this.saveOnTravelCheckBox.Size = new System.Drawing.Size(95, 17);
            this.saveOnTravelCheckBox.TabIndex = 2;
            this.saveOnTravelCheckBox.Text = "Save on travel";
            this.saveOnTravelCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveOnRestCheckBox
            // 
            this.saveOnRestCheckBox.AutoSize = true;
            this.saveOnRestCheckBox.Location = new System.Drawing.Point(6, 42);
            this.saveOnRestCheckBox.Name = "saveOnRestCheckBox";
            this.saveOnRestCheckBox.Size = new System.Drawing.Size(86, 17);
            this.saveOnRestCheckBox.TabIndex = 1;
            this.saveOnRestCheckBox.Text = "Save on rest";
            this.saveOnRestCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveOnInteriorExteriorSwitchCheckBox
            // 
            this.saveOnInteriorExteriorSwitchCheckBox.AutoSize = true;
            this.saveOnInteriorExteriorSwitchCheckBox.Location = new System.Drawing.Point(6, 19);
            this.saveOnInteriorExteriorSwitchCheckBox.Name = "saveOnInteriorExteriorSwitchCheckBox";
            this.saveOnInteriorExteriorSwitchCheckBox.Size = new System.Drawing.Size(172, 17);
            this.saveOnInteriorExteriorSwitchCheckBox.TabIndex = 0;
            this.saveOnInteriorExteriorSwitchCheckBox.Text = "Save on interior/exterior switch";
            this.saveOnInteriorExteriorSwitchCheckBox.UseVisualStyleBackColor = true;
            // 
            // miscellaneousGroupBox
            // 
            this.miscellaneousGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.miscellaneousGroupBox.Controls.Add(this.showCrosshairCheckBox);
            this.miscellaneousGroupBox.Controls.Add(this.difficultyNumericUpDown);
            this.miscellaneousGroupBox.Controls.Add(this.difficultylLabel);
            this.miscellaneousGroupBox.Location = new System.Drawing.Point(12, 12);
            this.miscellaneousGroupBox.Name = "miscellaneousGroupBox";
            this.miscellaneousGroupBox.Size = new System.Drawing.Size(303, 68);
            this.miscellaneousGroupBox.TabIndex = 0;
            this.miscellaneousGroupBox.TabStop = false;
            this.miscellaneousGroupBox.Text = "Miscellaneous";
            // 
            // showCrosshairCheckBox
            // 
            this.showCrosshairCheckBox.AutoSize = true;
            this.showCrosshairCheckBox.Location = new System.Drawing.Point(6, 45);
            this.showCrosshairCheckBox.Name = "showCrosshairCheckBox";
            this.showCrosshairCheckBox.Size = new System.Drawing.Size(98, 17);
            this.showCrosshairCheckBox.TabIndex = 2;
            this.showCrosshairCheckBox.Text = "Show crosshair";
            this.showCrosshairCheckBox.UseVisualStyleBackColor = true;
            // 
            // difficultyNumericUpDown
            // 
            this.difficultyNumericUpDown.Location = new System.Drawing.Point(59, 19);
            this.difficultyNumericUpDown.Name = "difficultyNumericUpDown";
            this.difficultyNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.difficultyNumericUpDown.TabIndex = 1;
            this.difficultyNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // difficultylLabel
            // 
            this.difficultylLabel.AutoSize = true;
            this.difficultylLabel.Location = new System.Drawing.Point(6, 21);
            this.difficultylLabel.Name = "difficultylLabel";
            this.difficultylLabel.Size = new System.Drawing.Size(47, 13);
            this.difficultylLabel.TabIndex = 0;
            this.difficultylLabel.Text = "Difficulty";
            // 
            // CharacterOptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(327, 237);
            this.Controls.Add(this.autosaveGroupBox);
            this.Controls.Add(this.miscellaneousGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Options";
            this.Load += new System.EventHandler(this.CharacterOptionsForm_Load);
            this.autosaveGroupBox.ResumeLayout(false);
            this.autosaveGroupBox.PerformLayout();
            this.miscellaneousGroupBox.ResumeLayout(false);
            this.miscellaneousGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox autosaveGroupBox;
        private System.Windows.Forms.CheckBox saveOnWaitCheckBox;
        private System.Windows.Forms.CheckBox saveOnTravelCheckBox;
        private System.Windows.Forms.CheckBox saveOnRestCheckBox;
        private System.Windows.Forms.CheckBox saveOnInteriorExteriorSwitchCheckBox;
        private System.Windows.Forms.GroupBox miscellaneousGroupBox;
        private System.Windows.Forms.CheckBox showCrosshairCheckBox;
        private System.Windows.Forms.NumericUpDown difficultyNumericUpDown;
        private System.Windows.Forms.Label difficultylLabel;
    }
}