// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="XmlDocumentExtended.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Xml;

namespace Zeroit.Framework.Utilities.Xml
{
    /// <summary>
    /// Class XmlDocumentExtended.
    /// </summary>
    /// <seealso cref="System.Xml.XmlDocument" />
    public class XmlDocumentExtended : XmlDocument
    {
        /// <summary>
        /// The m element count
        /// </summary>
        private int m_ElementCount;

        /// <summary>
        /// The m reader
        /// </summary>
        private XmlTextReader m_Reader = null;

        /// <summary>
        /// The m real file name
        /// </summary>
        private string m_RealFileName;

        /// <summary>
        /// Gets the name of the real file.
        /// </summary>
        /// <value>The name of the real file.</value>
        public string RealFileName
        {
            get { return m_RealFileName; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDocumentExtended"/> class.
        /// </summary>
        public XmlDocumentExtended()
            : base()
        {
            m_ElementCount = 0;
        }

        /// <summary>
        /// Creates the element.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="localname">The localname.</param>
        /// <param name="nsURI">The ns URI.</param>
        /// <returns>XmlElement.</returns>
        public override XmlElement CreateElement(string prefix, string localname, string nsURI)
        {
            XmlNodeExtended elem = new XmlNodeExtended(prefix, localname, nsURI, this);

            elem.SetLineInfo(m_Reader.LineNumber, m_Reader.LinePosition);


            return elem;
        }

        /// <summary>
        /// Selects the single node ex.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns>XmlNodeExtended.</returns>
        public XmlNodeExtended SelectSingleNodeEx(string xpath)
        {
            return (XmlNodeExtended)this.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Loads the XML document from the specified URL.
        /// </summary>
        /// <param name="filename">URL for the file containing the XML document to load. The URL can be either a local file or an HTTP URL (a Web address).</param>
        public override void Load(string filename)
        {
            m_RealFileName = filename;

            m_Reader = new XmlTextReader(filename);

            base.Load(m_Reader);

            m_Reader.Close();
        }

        /// <summary>
        /// Loads the specified in stream.
        /// </summary>
        /// <param name="inStream">The in stream.</param>
        public override void Load(System.IO.Stream inStream)
        {
            m_Reader = new XmlTextReader(inStream);

            base.Load(m_Reader);

            m_Reader.Close();
        }

        /// <summary>
        /// Loads the specified text reader.
        /// </summary>
        /// <param name="txtReader">The text reader.</param>
        public override void Load(System.IO.TextReader txtReader)
        {
            m_Reader = new XmlTextReader(txtReader);

            base.Load(m_Reader);

            m_Reader.Close();
        }

        /// <summary>
        /// Loads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public override void Load(XmlReader reader)
        {
            string xml = reader.ReadOuterXml();

            m_Reader = new XmlTextReader(xml, XmlNodeType.Document, null);

            base.Load(m_Reader);

            m_Reader.Close();
        }

        /// <summary>
        /// Loads the XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public override void LoadXml(string xml)
        {
            m_Reader = new XmlTextReader(xml, XmlNodeType.Document, null);

            base.Load(m_Reader);

            m_Reader.Close();
        }

        /// <summary>
        /// Increments the element count.
        /// </summary>
        public void IncrementElementCount()
        {
            m_ElementCount++;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount()
        {
            return m_ElementCount;
        }

    }
}
