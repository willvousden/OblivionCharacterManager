using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using OblivionCharacterManager.Properties;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Represents information about a version of the application.
    /// </summary>
    public class UpdateInfo
    {
        private static readonly string m_UserAgent = "OCM Updater";
        private static readonly string m_ContentType = "application/octet-stream";
        private static int m_DefaultTimeout = Settings.Default.UpdateTimeout;

        /// <summary>
        /// Attempts to query the server for update information, using the default timeout period.
        /// </summary>
        /// <returns>An <see cref="OblivionCharacterManager.UpdateInfo"/> object containing information about the latest update from the server.</returns>
        /// <exception cref="WebException">Thrown if the request times out or the server cannot be contacted for any other reason.</exception>
        /// <exception cref="InvalidDataException">Thrown when the server provides an invalid response.</exception>
        public static UpdateInfo GetUpdateInfo()
        {
            return GetUpdateInfo(m_DefaultTimeout);
        }

        /// <summary>
        /// Attempts to query the server for update information, using the specified timeout period.
        /// </summary>
        /// <param name="timeout">The length of time, in milliseconds, before the request times out.</param>
        /// <returns>An <see cref="OblivionCharacterManager.UpdateInfo"/> object containing information about the latest update from the server.</returns>
        /// <exception cref="WebException">Thrown if the request times out, or the server cannot be contacted for any other reason.</exception>
        /// <exception cref="InvalidDataException">Thrown when the server provides an invalid response.</exception>
        public static UpdateInfo GetUpdateInfo(int timeout)
        {
            // Send request to server.
            string versionQuery = "?version=" + Common.ApplicationVersion.ToString(3);
            WebRequest request = HttpWebRequest.Create(Settings.Default.UpdateCheckUri +
                                                       versionQuery);
            Debug.Assert(request is HttpWebRequest);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).UserAgent = m_UserAgent;
            }
            request.Timeout = timeout;
            WebResponse response = request.GetResponse();

            Debug.Assert(response != null);
            if (response.ContentLength >= 4 && response.ContentType == m_ContentType)
            {
                try
                {
                    // Get latest version info from server.
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        BinaryReader reader = new BinaryReader(responseStream);
                        return GetUpdateInfo(reader);
                    }
                }
                catch (EndOfStreamException exception)
                {
                    // Indicated length of a string was incorrect.
                    throw new InvalidDataException("The data provided by the server " +
                                                   "were not in the correct format.",
                                                   exception);
                }
            }
            else
            {
                // Content type was incorrect.
                throw new InvalidDataException("The data provided by the server " +
                                               "were not in the correct format.");
            }
        }

        /// <summary>
        /// Creates and populates a new <see cref="OblivionCharacterManager.UpdateInfo"/> instance from its binary representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.IO.BinaryReader"/> from which to read binary data.</param>
        /// <returns>The populated object.</returns>
        /// <exception cref="InvalidDataException">Thrown when the binary data are incorrect.</exception>
        private static UpdateInfo GetUpdateInfo(BinaryReader reader)
        {
            UpdateInfo updateInfo = new UpdateInfo();

            // Get version and download URI.
            updateInfo.LatestVersion = new Version(reader.ReadByte(),
                                                   reader.ReadByte(),
                                                   reader.ReadByte());
            updateInfo.DownloadUri = reader.ReadString();

            // Get changes.
            int changeCount = reader.ReadByte();
            try
            {
                updateInfo.Changes = new string[changeCount];
                for (int i = 0; i < changeCount; i++)
                {
                    updateInfo.Changes[i] = reader.ReadString();
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // Tried to write past end of array – change count was incorrect.
                throw new InvalidDataException("The data provided by the server " +
                                               "were not in the correct format.",
                                               exception);
            }

            // Get notes.
            updateInfo.Notes = reader.ReadString();

            return updateInfo;
        }

        private Version m_LatestVersion = null;
        private string m_DownloadUri = null;
        private string[] m_Changes = null;
        private string m_Notes = null;

        /// <summary>
        /// Gets or sets the version number of the update.
        /// </summary>
        public Version LatestVersion
        {
            get
            {
                return m_LatestVersion;
            }
            set
            {
                m_LatestVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the download URI for the update.
        /// </summary>
        public string DownloadUri
        {
            get
            {
                return m_DownloadUri;
            }
            set
            {
                m_DownloadUri = value;
            }
        }

        /// <summary>
        /// Gets or sets the changes for the update.
        /// </summary>
        public string[] Changes
        {
            get
            {
                return m_Changes;
            }
            set
            {
                m_Changes = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes for the update.
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
        /// Initialises a new <see cref="OblivionCharacterManager.UpdateInfo"/> instance.
        /// </summary>
        private UpdateInfo()
        {
        }
    }
}