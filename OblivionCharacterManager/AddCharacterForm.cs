using System;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.CharacterManagement;

namespace OblivionCharacterManager
{
    /// <summary>
    /// A form through which a user can add a activeCharacter.
    /// </summary>
    public partial class AddCharacterForm : BaseForm
    {
        private Predicate<string> m_NameExistsMatch = null;

        /// <summary>
        /// Gets or sets a delegate to use when checking whether or not the given name is already in use.
        /// </summary>
        public Predicate<string> NameExistsMatch
        {
            get
            {
                return m_NameExistsMatch;
            }
            set
            {
                m_NameExistsMatch = value;
            }
        }

        /// <summary>
        /// Gets or sets the activeCharacter name displayed on the form.
        /// </summary>
        public string CharacterName
        {
            get
            {
                return characterNameTextBox.Text;
            }
            set
            {
                characterNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.AddCharacterForm"/> instance.
        /// </summary>
        public AddCharacterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates the currently present user input.
        /// </summary>
        /// <returns><c>true</c> if all intput is valid; <c>false</c> otherwise.</returns>
        private bool ValidateInput()
        {
            bool nameValid = SaveManager.IsValidCharacterName(characterNameTextBox.Text);
            if (!nameValid)
            {
                string text = "The provided character name is not valid.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool nameExists = Array.Exists(SaveManager.Characters, character => character.Name.ToLower() == characterNameTextBox.Text.ToLower());
            if (nameExists)
            {
                string text = "The provided character name is already in use.";
                Common.ShowMessageBox(this, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #region Event handlers

        private void characterNameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(characterNameTextBox.Text);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateInput();
            if (isValid)
            {
                DialogResult = DialogResult.OK;
            }
        }

        #endregion
    }
}