using System;

namespace OblivionCharacterManager.CharacterManagement
{
    /// <summary>
    /// Represents an error that occurs as a result of an invalidly formatted save file being loaded.
    /// </summary>
    public class InvalidSaveFileException : Exception
    {
        private string m_FilePath;

        /// <summary>
        /// Gets or sets the path to the file that caused the error.
        /// </summary>
        public string FilePath
        {
            get
            {
                return m_FilePath;
            }
            set
            {
                m_FilePath = value;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException"/> instance.
        /// </summary>
        internal InvalidSaveFileException()
            : this(null)
        {
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException"/> instance.
        /// </summary>
        /// <param name="filePath">The path to the invalidly formatted file.</param>
        internal InvalidSaveFileException(string filePath)
            : base()
        {
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException"/> instance.
        /// </summary>
        /// <param name="filePath">The path to the file that caused the error.</param>
        /// <param name="message">A message that describes the error.</param>
        internal InvalidSaveFileException(string filePath, string message)
            : base(message)
        {
            m_FilePath = filePath;
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException"/> instance.
        /// </summary>
        /// <param name="filePath">The path to the ifile that caused the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        internal InvalidSaveFileException(string filePath, Exception innerException)
            : this(filePath, null, innerException)
        {
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.CharacterManagement.InvalidSaveFileException"/> instance.
        /// </summary>
        /// <param name="filePath">The path to the file that caused the error.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        internal InvalidSaveFileException(string filePath, string message, Exception innerException)
            : base(message, innerException)
        {
            m_FilePath = filePath;
        }
    }
}