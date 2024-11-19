namespace OblivionCharacterManager
{
    /// <summary>
    /// Specifies the possible ways of sorting a save list.
    /// </summary>
    public enum SaveSortType
    {
        /// <summary>
        /// Specifies that the saves should be sorted by file name.
        /// </summary>
        FileName,

        /// <summary>
        /// Specifies that the saves should be sorted by activeCharacter name.
        /// </summary>
        CharacterName,

        /// <summary>
        /// Specifies that the saves should be sorted by activeCharacter level.
        /// </summary>
        CharacterLevel,

        /// <summary>
        /// Specifies that the saves should be sorted by activeCharacter location.
        /// </summary>
        CharacterLocation,

        /// <summary>
        /// Specifies that the saves should be sorted by game time.
        /// </summary>
        GameTime,

        /// <summary>
        /// Specifies that the saves should be sorted by play time.
        /// </summary>
        PlayTime,

        /// <summary>
        /// Specifies that the saves should be sorted by last save time.
        /// </summary>
        LastSaveTime,

        /// <summary>
        /// Specifies that the saves should be sorted by the version of Oblivion under which they were saved.
        /// </summary>
        OblivionVersion
    }
}