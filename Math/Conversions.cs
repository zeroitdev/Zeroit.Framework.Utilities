// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-02-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-02-2019
// ***********************************************************************
// <copyright file="Conversions.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.Maths
{
	/// <summary>
	/// Class that does the conversions
	/// </summary>
	public static class HexConversion
	{
		
	    #region Public Methods
		
		/// <summary>
		/// Convert base 2, 8, 10 or 16 to any output of base 2, 8, 10, 16
		/// </summary>
		/// <param name="inputType">Input type as a text value.</param>
		/// <param name="value">String value to convert.</param>
		/// <param name="outputType">Output type as a text value.</param>
		/// <returns>String value of the conversion.</returns>
		public static string Input2Output(string inputType, string value, string outputType)
		{
			// Convert the current input type into Decimal
			UInt32 currInput = Input2Binary( value, inputType );

			// Convert the Decimal value to the correct output value
			return Binary2Output( value, currInput, outputType );
		}

		/// <summary>
		/// Convert base 2, 8, 10 or 16 to a binary value
		/// </summary>
		/// <param name="txtObject">The textbox text that has the value to convert</param>
		/// <param name="numberStyle">The combo box text for input type</param>
		/// <returns>Decimal representation of the input value</returns>
		public static UInt32 Input2Binary(string txtObject, string numberStyle)
		{
			UInt64 currInput = 0;

			// Convert the current input into binary (convert string from base 'n')
			switch( numberStyle.ToUpper() )
			{
				case "HEXADECIMAL":
					currInput = Convert.ToUInt64(txtObject, 16);
					break;
				case "DECIMAL":
					currInput = Convert.ToUInt64(txtObject, 10);
					break;
				case "OCTAL":
					currInput = Convert.ToUInt64(txtObject, 8);
					break;
				case "BINARY":
					currInput = Convert.ToUInt64(txtObject, 2);
					break;
			}
			
			// Verify that the value is in the correct range
			if( currInput > UInt32.MaxValue ) 
			{
				throw new System.OverflowException("Value is too large. Please revise!");
			}

			return (UInt32) currInput;
		}

		/// <summary>
		/// Convert a binary value either base 2, 8, 10 or 16
		/// </summary>
		/// <param name="txtObject">The textbox text that has the value to convert</param>
		/// <param name="currVal">Decimal value of the input type</param>
		/// <param name="numberStyle">The combo box text for output type</param>
		public static string Binary2Output(string txtObject, UInt32 currVal, string numberStyle)
		{
			// Convert the int to the correct output
			switch( numberStyle.ToUpper() )
			{
				case "HEXADECIMAL":
					txtObject = Convert.ToString(currVal, 16).ToUpper();
					break;
				case "DECIMAL":
					txtObject = Convert.ToString(currVal, 10);
					break;
				case "OCTAL":
					txtObject = Convert.ToString(currVal, 8);
					break;
				case "BINARY":
					txtObject = Convert.ToString(currVal, 2);
					break;
			}

			if( txtObject == String.Empty )
			{
				throw new System.NullReferenceException();
			}

			return txtObject;
		}
		
	    #endregion
	}
}
