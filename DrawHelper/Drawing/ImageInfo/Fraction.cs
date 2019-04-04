// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="Fraction.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.ImageInfo
{
	///<summary>Some values according EXIF specifications are stored as Fraction numbers.
 	///This Class helps to manipulate and display those numbers.</summary>
	public class Fraction 
	{
   		int num = 0;
   		int den = 1;
		///<summary>Creates a Fraction Number having Numerator and Denumerator.</summary>
		///<param name="num">Numerator</param>
		///<param name="den">Denumerator</param>
   		public Fraction(int num, int den) 
   		{
      		this.num = num;
      		this.den = den;
   		}
		///<summary>Creates a Fraction Number having Numerator and Denumerator.</summary>
		///<param name="num">Numerator</param>
		///<param name="den">Denumerator</param>
   		public Fraction(uint num, uint den) 
   		{
   			this.num = Convert.ToInt32(num);
   			this.den = Convert.ToInt32(den);
   		}
		
		///<summary>Creates a Fraction Number having only Numerator and assuming Denumerator=1.</summary>
		///<param name="num">Numerator</param>
   		public Fraction(int num) 
   		{
      		this.num = num;
   		}
   		
		///<summary>Used to display Fraction numbers like 12/17.</summary>
		public override string ToString()
		{
			if (den==1) return String.Format("{0}", num);
			//if ((den % 10) == 0 ) return String.Format("{0}", num / den);
			return String.Format("{0}/{1}", num, den);
		}
		
		///<summary>The Numerator</summary>
		public int Numerator 
		{
			get {return num;}
			set {num = value;}
		}

		///<summary>The Denumerator</summary>
		public int Denumerator 
		{
			get {return den;}
			set {den = value;}
		}
		
   		///<summary>Overloades operator + </summary>
   		public static Fraction operator +(Fraction a, Fraction b) 
   		{
      		return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
   		}

   		///<summary>Overloades operator * </summary>
   		public static Fraction operator *(Fraction a, Fraction b) 
   		{
      		return new Fraction(a.num * b.num, a.den * b.den);
   		}

   		///<summary>Retrives double value of a Frction number. Enables casting to double.</summary>
   		public static implicit operator double(Fraction f) 
   		{
      		return (double)f.num / f.den;
   		}
	}
}
