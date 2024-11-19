using System;
using System.Windows.Forms;
using FormsLibrary;
using OblivionCharacterManager.CharacterManagement;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Allows the user to view and modify options for an Oblivion activeCharacter.
    /// </summary>
    public partial class CharacterOptionsForm : BaseForm
    {
        OblivionCharacter m_Character;

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterOptionsForm"/> instance.
        /// </summary>
        public CharacterOptionsForm(OblivionCharacter character)
        {
            InitializeComponent();

            m_Character = character;
        }

        /// <summary>
        /// Loads the charater's information and displays it on the form.
        /// </summary>
        private void LoadSettings()
        {
            difficultyNumericUpDown.Value = m_Character.Difficulty;
            showCrosshairCheckBox.Checked = m_Character.ShowCrosshair;
            saveOnInteriorExteriorSwitchCheckBox.Checked = m_Character.SaveOnInteriorExteriorSwitch;
            saveOnRestCheckBox.Checked = m_Character.SaveOnRest;
            saveOnTravelCheckBox.Checked = m_Character.SaveOnTravel;
            saveOnWaitCheckBox.Checked = m_Character.SaveOnWait;
        }

        /// <summary>
        /// Applies the currently present details to the character.
        /// </summary>
        private void Commit()
        {
            m_Character.Difficulty = (int)difficultyNumericUpDown.Value;
            m_Character.ShowCrosshair = showCrosshairCheckBox.Checked;
            m_Character.SaveOnInteriorExteriorSwitch = saveOnInteriorExteriorSwitchCheckBox.Checked;
            m_Character.SaveOnRest = saveOnRestCheckBox.Checked;
            m_Character.SaveOnTravel = saveOnTravelCheckBox.Checked;
            m_Character.SaveOnWait = saveOnWaitCheckBox.Checked;
        }

        #region Component event handlers

        private void CharacterOptionsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Commit();
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}