// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="XmlNodeTextReader.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Xml;

namespace Zeroit.Framework.Utilities.Xml
{
    /// <summary>
    /// XmlNodeTextReader is Simple Only XmlNode Reader this is usefull when you have
    /// the xmlnode as string and you need to read it as fast is possible
    /// </summary>
    public class XmlNodeTextReader
	{
        /// <summary>
        /// Class XmlAttribute.
        /// </summary>
        public class XmlAttribute
		{
            /// <summary>
            /// The name
            /// </summary>
            public string Name;
            /// <summary>
            /// The value
            /// </summary>
            public string Value;

            /// <summary>
            /// Initializes a new instance of the <see cref="XmlAttribute"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="value">The value.</param>
            internal XmlAttribute(string name,string value)
			{
				this.Name = name;
				this.Value = value;
			}
		}

        /// <summary>
        /// The m attributes names
        /// </summary>
        ArrayList m_AttributesNames = null;
        /// <summary>
        /// The m attributes values
        /// </summary>
        ArrayList m_AttributesValues = null;
        /// <summary>
        /// The m value
        /// </summary>
        string m_Value = null;
        /// <summary>
        /// The m XML node
        /// </summary>
        string m_XmlNode = null;
        /// <summary>
        /// The m local name
        /// </summary>
        string m_LocalName = null;

        /// <summary>
        /// The m has child
        /// </summary>
        bool m_HasChild = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlNodeTextReader"/> class.
        /// </summary>
        /// <param name="xmlnode">The xmlnode.</param>
        public XmlNodeTextReader(string xmlnode)
		{
			m_AttributesNames = new ArrayList();
			m_AttributesValues = new ArrayList();
			m_XmlNode = "<nodes>" + xmlnode + "</nodes>";
		}

        /// <summary>
        /// Get the attribute value by its name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string this[string name]
		{
			get
			{
				int index = m_AttributesNames.IndexOf(name);

				if(index == -1) return null;

				return (string)m_AttributesValues[index];
			}
		}

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
		{
			get
			{
				return m_Value;
			}
		}

        /// <summary>
        /// Get the attribute value by its index
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.String.</returns>
        public string this[int index]
		{
			get
			{
				return (string)m_AttributesValues[index];
			}
		}

        /// <summary>
        /// Return the attribute count
        /// </summary>
        /// <value>The count.</value>
        public int Count
		{
			get
			{
				return m_AttributesNames.Count;
			}
		}



        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public XmlAttribute[] Attributes
		{
			get
			{
				XmlAttribute[] attrs = new XmlAttribute[m_AttributesNames.Count];

				for(int i = 0; i < attrs.Length;i++)
				{
					attrs[i] = new XmlAttribute((string)m_AttributesNames[i],
						(string)m_AttributesValues[i]);
				}

				return attrs;
			}
		}

        /// <summary>
        /// Gets a value indicating whether this instance has child.
        /// </summary>
        /// <value><c>true</c> if this instance has child; otherwise, <c>false</c>.</value>
        public bool HasChild
		{
			get
			{
				return m_HasChild;
			}
		}

        /// <summary>
        /// Return True if read success
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReadAll()
		{
			XmlTextReader xreader = new XmlTextReader(m_XmlNode,XmlNodeType.Document,null);

			bool element = false;

			try
			{
				xreader.Read();

				while(xreader.Read())
				{
					if(xreader.IsStartElement() && element == false)
					{
						m_LocalName = xreader.Value;
						while(xreader.MoveToNextAttribute())
						{
							m_AttributesNames.Add(xreader.LocalName);
							m_AttributesValues.Add(xreader.Value);
						}
						m_Value = xreader.ReadElementString();

						element = true;
					}
					if(element == true) break;
				}
			}
			catch
			{
				return false;
			}
			finally
			{
				xreader.Close();

				try
				{
					XmlTextReader xInnerReader = new XmlTextReader(m_XmlNode,XmlNodeType.Element,null);

					xInnerReader.Read();

					string xmlChild = xInnerReader.ReadInnerXml();

					xInnerReader.Close();

					if(xmlChild != null || (xmlChild != String.Empty))
						m_HasChild = true;
					else
						m_HasChild = false;

				}
				finally
				{
					//NOP	
				}	
				
			}
			return true;
		}
	}
}
