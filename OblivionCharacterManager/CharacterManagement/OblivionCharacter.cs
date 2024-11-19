using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OblivionCharacterManager.CharacterManagement
{
    /// <summary>
    /// Represents an Oblivion character and its associated saves.
    /// </summary>
    [Serializable]
    public class OblivionCharacter : IXmlSerializable
    {
        /// <summary>
        /// The minimum difficulty level for character. This field is read-only.
        /// </summary>
        public static readonly int MinimumDifficulty = 0;

        /// <summary>
        /// The maximum difficulty level for a character. This field is read-only.
        /// </summary>
        public static readonly int MaximumDifficulty = 100;

        /// <summary>
        /// The default difficulty level for a character. This field is read-only.
        /// </summary>
        public static readonly int DefaultDifficulty = 50;

        private string m_Name;
        private int m_Difficulty = DefaultDifficulty;
        private bool m_ShowCrosshair = true;
        private bool m_SaveOnInteriorExteriorSwitch = true;
        private bool m_SaveOnRest = true;
        private bool m_SaveOnTravel = true;
        private bool m_SaveOnWait = true;
        private string m_Notes;
        [NonSerialized]
        private List<OblivionSave> m_Saves = new List<OblivionSave>();

        /// <summary>
        /// Gets the name of the character.
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// Gets or sets the difficulty level for this character (between 0 and 100 inclusive).
        /// </summary>
        public int Difficulty
        {
            get
            {
                return m_Difficulty;
            }
            set
            {
                if (value >= MinimumDifficulty || value <= MaximumDifficulty)
                {
                    m_Difficulty = value;
                }
                else
                {
                    string message = string.Format("The difficulty level must be between {0} and {1} inclusive.",
                                                   MinimumDifficulty, MaximumDifficulty);
                    throw new ArgumentOutOfRangeException(message, (Exception)null);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the crosshair will be shown ingame.
        /// </summary>
        public bool ShowCrosshair
        {
            get
            {
                return m_ShowCrosshair;
            }
            set
            {
                m_ShowCrosshair = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the game should be autosaved when the character goes from an interior cell to an exterior cell or vice versa.
        /// </summary>
        public bool SaveOnInteriorExteriorSwitch
        {
            get
            {
                return m_SaveOnInteriorExteriorSwitch;
            }
            set
            {
                m_SaveOnInteriorExteriorSwitch = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the game should be autosaved when the character rests.
        /// </summary>
        public bool SaveOnRest
        {
            get
            {
                return m_SaveOnRest;
            }
            set
            {
                m_SaveOnRest = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the game should be autosaved when the character fast travels.
        /// </summary>
        public bool SaveOnTravel
        {
            get
            {
                return m_SaveOnTravel;
            }
            set
            {
                m_SaveOnTravel = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the game should be autosaved when the character waits.
        /// </summary>
        public bool SaveOnWait
        {
            get
            {
                return m_SaveOnWait;
            }
            set
            {
                m_SaveOnWait = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes for the current character.
        /// </summary>
        public string Notes
        {
            get
            {
                return m_Notes;
            }
            set
            {
                m_Notes = value;
            }
        }

        /// <summary>
        /// Gets an array of <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> objects for the current instance.
        /// </summary>
        public OblivionSave[] Saves
        {
            get
            {
                if (m_Saves == null)
                {
                    m_Saves = new List<OblivionSave>();
                }

                return m_Saves.ToArray();
            }
        }

        /// <summary>
        /// Gets a delegate for matching characters according to their names.
        /// </summary>
        public Predicate<OblivionCharacter> NamePredicate
        {
            get
            {
                return character => character.Name == Name;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/> instance.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        public OblivionCharacter(string name)
        {
            m_Name = name;
        }

        /// <summary>
        /// Loads the saves for the current <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/>.
        /// </summary>
        public void LoadSaves()
        {
            if (m_Saves == null)
            {
                m_Saves = new List<OblivionSave>();
            }
            else
            {
                m_Saves.Clear();
            }

            // Get the character's save files.
            FileInfo[] saveFiles = SaveManager.GetSaveFiles(m_Name);

            // Load save data and create array of saves and unique character names.
            foreach (FileInfo saveFile in saveFiles)
            {
                try
                {
                    OblivionSave save = OblivionSave.LoadFromFile(saveFile.FullName);

                    if (save.CharacterName == m_Name)
                    {
                        m_Saves.Add(save);
                    }
                }
                catch (InvalidSaveFileException exception)
                {
                    // Ignore save file.
                    Program.HandleException(exception);
                }
            }
        }

        /// <summary>
        /// Applies the character's settings.
        /// </summary>
        public void ApplySettings()
        {
            Common.OblivionIni["Gameplay", "fDifficulty"] = string.Format("{0:F4}", ((double)m_Difficulty / 50D) - 1);
            Common.OblivionIni["Gameplay", "bCrossHair"] = m_ShowCrosshair ? "1" : "0";
            Common.OblivionIni["Gameplay", "bSaveOnInteriorExteriorSwitch"] = m_SaveOnInteriorExteriorSwitch ? "1" : "0";
            Common.OblivionIni["Gameplay", "bSaveOnRest"] = m_SaveOnRest ? "1" : "0";
            Common.OblivionIni["Gameplay", "bSaveOnTravel"] = m_SaveOnTravel ? "1" : "0";
            Common.OblivionIni["Gameplay", "bSaveOnWait"] = m_SaveOnWait ? "1" : "0";
        }

        /// <summary>
        /// Loads the character's settings from Oblivion.ini in its current state.
        /// </summary>
        private void LoadSettings()
        {
            double difficulty;
            bool difficultyValid = Double.TryParse(Common.OblivionIni["Gameplay", "fDifficulty"], out difficulty);
            if (difficultyValid)
            {
                m_Difficulty = (int)(difficulty + 1) * 50;
            }
            else
            {
                Debug.Fail("Invalid initialization file setting: fDifficulty.");
            }

            string showCrossHair = Common.OblivionIni["Gameplay", "bCrossHair"];
            if (showCrossHair == "1")
            {
                m_ShowCrosshair = true;
            }
            else if (showCrossHair == "0")
            {
                m_ShowCrosshair = false;
            }

            string saveOnInteriorExteriorSwitch = Common.OblivionIni["Gameplay", "bSaveOnInteriorExteriorSwitch"];
            if (saveOnInteriorExteriorSwitch == "1")
            {
                m_SaveOnInteriorExteriorSwitch = true;
            }
            else if (saveOnInteriorExteriorSwitch == "0")
            {
                m_SaveOnInteriorExteriorSwitch = false;
            }
            else
            {
                Debug.Fail("Invalid initialization file setting: bSaveOnInteriorExteriorSwitch.");
            }

            string saveOnRest = Common.OblivionIni["Gameplay", "bSaveOnRest"];
            if (saveOnRest == "1")
            {
                m_SaveOnRest = true;
            }
            else if (saveOnRest == "0")
            {
                m_SaveOnRest = false;
            }
            else
            {
                Debug.Fail("Invalid initialization file setting: bSaveOnRest.");
            }

            string saveOnTravel = Common.OblivionIni["Gameplay", "bSaveOnTravel"];
            if (saveOnTravel == "1")
            {
                m_SaveOnTravel = true;
            }
            else if (saveOnTravel == "0")
            {
                m_SaveOnTravel = false;
            }
            else
            {
                Debug.Fail("Invalid initialization file setting: bSaveOnTravel.");
            }

            string saveOnWait = Common.OblivionIni["Gameplay", "bSaveOnWait"];
            if (saveOnWait == "1")
            {
                m_SaveOnWait = true;
            }
            else if (saveOnWait == "0")
            {
                m_SaveOnWait = false;
            }
            else
            {
                Debug.Fail("Invalid initialization file setting: bSaveOnWait.");
            }
        }

        /// <summary>
        /// Gets a string representation of the current <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/>.
        /// </summary>
        /// <returns>A string represtnation of the current <see cref="OblivionCharacterManager.CharacterManagement.OblivionCharacter"/>.</returns>
        public override string ToString()
        {
            return m_Name;
        }

        #region IXmlSerializable Members

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (reader.NodeType == XmlNodeType.Element && reader.LocalName == GetType().Name)
            {
                reader.Read();
            }
            reader.ReadStartElement("character");

            m_Name = reader.ReadElementContentAsString("name", string.Empty);
            m_Difficulty = reader.ReadElementContentAsInt("difficulty", string.Empty);
            m_ShowCrosshair = reader.ReadElementContentAsBoolean("showCrosshair", string.Empty);
            m_SaveOnInteriorExteriorSwitch = reader.ReadElementContentAsBoolean(
                                                 "saveOnInteriorExteriorSwitch",
                                                 string.Empty);
            m_SaveOnRest = reader.ReadElementContentAsBoolean("saveOnRest", string.Empty);
            m_SaveOnTravel = reader.ReadElementContentAsBoolean("saveOnTravel", string.Empty);
            m_SaveOnWait = reader.ReadElementContentAsBoolean("saveOnWait", string.Empty);
            m_Notes = reader.ReadElementString("notes");

            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("character");

            writer.WriteElementString("name", m_Name);
            writer.WriteElementString("difficulty", m_Difficulty.ToString());
            writer.WriteElementString("showCrosshair", m_ShowCrosshair.ToString());
            writer.WriteElementString("saveOnInteriorExteriorSwitch",
                                      m_SaveOnInteriorExteriorSwitch.ToString());
            writer.WriteElementString("saveOnRest", m_SaveOnRest.ToString());
            writer.WriteElementString("saveOnTravel", m_SaveOnTravel.ToString());
            writer.WriteElementString("saveOnWait", m_SaveOnWait.ToString());
            writer.WriteElementString("notes", m_Notes);

            writer.WriteEndElement();
        }

        #endregion
    }
}