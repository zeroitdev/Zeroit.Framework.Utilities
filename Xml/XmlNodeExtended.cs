// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="XmlNodeExtended.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Xml;

namespace Zeroit.Framework.Utilities.Xml
{
    /// <summary>
    /// Class XmlNodeExtended.
    /// </summary>
    /// <seealso cref="System.Xml.XmlElement" />
    /// <seealso cref="System.Xml.IXmlLineInfo" />
    public class XmlNodeExtended : XmlElement, IXmlLineInfo
    {
        /// <summary>
        /// The line number
        /// </summary>
        int lineNumber = 0;
        /// <summary>
        /// The line position
        /// </summary>
        int linePosition = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlNodeExtended"/> class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="localname">The localname.</param>
        /// <param name="nsURI">The ns URI.</param>
        /// <param name="doc">The document.</param>
        internal XmlNodeExtended(string prefix, string localname, string nsURI, XmlDocument doc)
            : base(prefix, localname, nsURI, doc)
        {
            ((XmlDocumentExtended)doc).IncrementElementCount();
        }

        /// <summary>
        /// Sets the line information.
        /// </summary>
        /// <param name="linenum">The linenum.</param>
        /// <param name="linepos">The linepos.</param>
        public void SetLineInfo(int linenum, int linepos)
        {
            lineNumber = linenum;
            linePosition = linepos;
        }


        /// <summary>
        /// Ottiene il numero corrente di riga.
        /// </summary>
        /// <value>The line number.</value>
        public int LineNumber
        {
            get
            {
                return lineNumber;
            }
        }
        /// <summary>
        /// Ottiene la posizione corrente di riga.
        /// </summary>
        /// <value>The line position.</value>
        public int LinePosition
        {
            get
            {
                return linePosition;
            }
        }

        /// <summary>
        /// Ottiene un valore che indica se la classe può restituire informazioni sulla riga.
        /// </summary>
        /// <returns>true se è possibile specificare la <see cref="P:System.Xml.IXmlLineInfo.LineNumber"></see> e <see cref="P:System.Xml.IXmlLineInfo.LinePosition"></see>; in caso contrario false.</returns>
        public bool HasLineInfo()
        {
            return true;
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
        /// Gets the owner document ex.
        /// </summary>
        /// <value>The owner document ex.</value>
        public XmlDocumentExtended OwnerDocumentEx
        {
            get
            {
                if (this.OwnerDocument is XmlDocumentExtended)
                    return (XmlDocumentExtended)this.OwnerDocument;
                return null;
            }
        }
    }// End LineInfoElement class.
}
