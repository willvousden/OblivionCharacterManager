using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using OblivionCharacterManager.CharacterManagement;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Sorts a list of <see cref="OblivionCharacterManager.CharacterManagement.OblivionSave"/> objects.
    /// </summary>
    public class SaveListSorter : IComparer, IComparer<OblivionSave>, IXmlSerializable
    {
        private SaveSortType m_Type = SaveSortType.FileName;
        private SortOrder m_Order = SortOrder.Ascending;

        /// <summary>
        /// Gets or sets the sort type to be used while sorting.
        /// </summary>
        public SaveSortType Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        /// <summary>
        /// Get or sets the order in which to sort items.
        /// </summary>
        public SortOrder Order
        {
            get
            {
                return m_Order;
            }
            set
            {
                m_Order = value;
            }
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.SaveListSorter"/> instance.
        /// </summary>
        public SaveListSorter()
        {
        }

        /// <summary>
        /// Compares two <see cref="System.Windows.Forms.ListViewItem"/> objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="object1">The first item to compare.</param>
        /// <param name="object2">The second item to compare.</param>
        /// <returns>A value less than zero if <c>object1</c> is less than <c>object2</c>, equal to zero if <c>object1</c> is equal to <c>object2</c>, or greater than zero if <c>object1</c> is
        /// greater than <c>object2</c>.</returns>
        public int Compare(object object1, object object2)
        {
            ListViewItem item1 = object1 as ListViewItem;
            ListViewItem item2 = object2 as ListViewItem;
            if (item1 != null && item2 != null)
            {
                OblivionSave save1 = item1.Tag as OblivionSave;
                OblivionSave save2 = item2.Tag as OblivionSave;
                return Compare(save1, save2);
            }
            else
            {
                throw new ArgumentException("Invalid save.");
            }
        }

        /// <summary>
        /// Compares two <see cref="System.Windows.Forms.ListViewItem"/> objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="save1">The first save to compare.</param>
        /// <param name="save2">The second save to compare.</param>
        /// <returns>A value less than zero if <c>save1</c> is less than <c>save2</c>, equal to zero if <c>save1</c> is equal to <c>save2</c>, or greater than zero if <c>save1</c> is
        /// greater than <c>save2</c>.</returns>
        public int Compare(OblivionSave save1, OblivionSave save2)
        {
            if (save1 != null && save2 != null)
            {
                if (m_Order == SortOrder.None)
                {
                    return 0;
                }

                int returnValue;
                switch (m_Type)
                {
                    case SaveSortType.FileName:
                        returnValue = string.Compare(save1.FileName, save2.FileName);
                        break;
                    case SaveSortType.CharacterName:
                        returnValue = string.Compare(save1.CharacterName, save2.CharacterName);
                        break;
                    case SaveSortType.CharacterLevel:
                        if (save1.CharacterLevel > save2.CharacterLevel)
                        {
                            returnValue = -1;
                        }
                        else if (save1.CharacterLevel == save2.CharacterLevel)
                        {
                            returnValue = 0;
                        }
                        else
                        {
                            returnValue = 1;
                        }
                        break;
                    case SaveSortType.CharacterLocation:
                        returnValue = string.Compare(save1.CharacterLocation, save2.CharacterLocation);
                        break;
                    case SaveSortType.GameTime:
                        returnValue = TimeSpan.Compare(save1.GameTime, save2.GameTime);
                        break;
                    case SaveSortType.PlayTime:
                        returnValue = TimeSpan.Compare(save1.PlayTime, save2.PlayTime);
                        break;
                    case SaveSortType.LastSaveTime:
                        returnValue = DateTime.Compare(save1.LastSave, save2.LastSave);
                        break;
                    case SaveSortType.OblivionVersion:
                        if (save1.OblivionVersion > save2.OblivionVersion)
                        {
                            returnValue = -1;
                        }
                        else if (save1.OblivionVersion == save2.OblivionVersion)
                        {
                            return 0;
                        }
                        else
                        {
                            returnValue = 1;
                        }
                        break;
                    default:
                        Debug.Fail("Unrecognised enumeration member.");
                        returnValue = 0;
                        break;
                }

                if (m_Order == SortOrder.Ascending)
                {
                    return returnValue;
                }
                else
                {
                    return -returnValue;
                }
            }
            else
            {
                throw new ArgumentException("Invalid save.");
            }
        }

        #region IXmlSerializable members

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
            reader.ReadStartElement("formSettings");

            string typeString = reader.ReadElementString("type");
            m_Type = (SaveSortType)Enum.Parse(typeof(SaveSortType), typeString);

            string orderString = reader.ReadElementString("order");
            m_Order = (SortOrder)Enum.Parse(typeof(SortOrder), orderString);

            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("formSettings");

            writer.WriteElementString("type", m_Type.ToString());
            writer.WriteElementString("order", m_Order.ToString());

            writer.WriteEndElement();
        }

        #endregion
    }
}