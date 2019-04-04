// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="WordReader.cs" company="Zeroit Dev Technologies">
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

using System;
using System.Text;
using System.IO;

namespace Zeroit.Framework.Utilities.Text
{
    /// <summary>
    /// WordReader is a class for simplified reading of word from a string
    /// you can iterate on the string for word and get the current word you can
    /// set the a set of char as separator
    /// </summary>
    public class WordReader
	{
        /// <summary>
        /// The m text
        /// </summary>
        string m_Text = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordReader"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public WordReader(string text)
		{
			m_Text=text;
		}

        /// <summary>
        /// Froms the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>WordReader.</returns>
        public static WordReader FromFile(string filename)
		{
			string text = null;

			StreamReader sreader = new StreamReader(filename);

			text = sreader.ReadToEnd();

			sreader.Close();

			return new WordReader(text);
		}

        /// <summary>
        /// The m position
        /// </summary>
        int m_Position = 0;
        /// <summary>
        /// The m separators
        /// </summary>
        string[] m_Separators = new string[]{" ","\r","\n", "\t" ,"."};
        /// <summary>
        /// The m current word
        /// </summary>
        string m_CurrentWord = string.Empty;
        /// <summary>
        /// The m current separator
        /// </summary>
        string m_CurrentSeparator = string.Empty;
        /// <summary>
        /// The m last word
        /// </summary>
        string m_LastWord = String.Empty;
        /// <summary>
        /// The m ignores
        /// </summary>
        string[] m_Ignores = new string[0];
        /// <summary>
        /// The m is end
        /// </summary>
        bool m_IsEnd = false;


        /// <summary>
        /// Reads the specified separators.
        /// </summary>
        /// <param name="separators">The separators.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Read(string[] separators)
		{
			m_Separators = separators;

			return Read();
		}

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Read()
		{
			StringBuilder sbWord = new StringBuilder();

			if (m_Position == (m_Text.Length))
			{
				m_IsEnd = true;
				return false;
			}

			while(m_Position < m_Text.Length)
			{
				string cChar = m_Text[m_Position].ToString();

				if(Array.IndexOf(m_Ignores,cChar) > 0)
				{
					m_Position++;
					continue;
				}
				
				if(Array.IndexOf(m_Separators,cChar) == -1)
				{
					sbWord.Append(cChar);
					m_CurrentSeparator = null;
				}
				else
				{
					if(sbWord.Length == 0)
					{
						m_Position++;
						continue;
					}
					m_CurrentSeparator = cChar.ToString();
					m_Position++;
					break;
				}
				
				m_Position++;
			}
			m_LastWord = m_CurrentWord;
			m_CurrentWord = sbWord.ToString();

			if (m_Position == m_Text.Length)
			{
				m_IsEnd = true;
			}

			return true;
		}

        /// <summary>
        /// Gets or sets a value indicating whether this instance is end.
        /// </summary>
        /// <value><c>true</c> if this instance is end; otherwise, <c>false</c>.</value>
        public bool IsEnd
		{
			get
			{
				return m_IsEnd;
			}
			set
			{
				m_IsEnd = value;
			}
		}

        /// <summary>
        /// Gets the current word.
        /// </summary>
        /// <value>The current word.</value>
        public string CurrentWord
		{
			get
			{
				return m_CurrentWord;
			}
		}


        /// <summary>
        /// Gets the last word.
        /// </summary>
        /// <value>The last word.</value>
        public string LastWord
		{
			get
			{
				return m_LastWord;
			}
		}

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        public string[] Separator
		{
			get
			{
				return m_Separators;
			}
			set
			{
				m_Separators = value;
			}
		}
        /// <summary>
        /// Gets or sets the ignores.
        /// </summary>
        /// <value>The ignores.</value>
        public string[] Ignores
		{
			get
			{
				return m_Ignores;
			}
			set
			{
				m_Ignores = value;
			}
		}

        /// <summary>
        /// Gets the current separator.
        /// </summary>
        /// <value>The current separator.</value>
        public string CurrentSeparator
		{
			get
			{
				return m_CurrentSeparator;
			}
		}


	}
}
