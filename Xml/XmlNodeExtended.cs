// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="XmlNodeExtended.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
        /// Ottiene un valore che indica se la classe pu� restituire informazioni sulla riga.
        /// </summary>
        /// <returns>true se � possibile specificare la <see cref="P:System.Xml.IXmlLineInfo.LineNumber"></see> e <see cref="P:System.Xml.IXmlLineInfo.LinePosition"></see>; in caso contrario false.</returns>
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
