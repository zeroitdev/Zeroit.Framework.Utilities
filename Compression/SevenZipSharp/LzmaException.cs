// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="LzmaException.cs" company="Zeroit Dev Technologies">
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
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class LzmaException : SevenZipException
  {
    public const string DefaultMessage = "Specified stream is not a valid LZMA compressed stream!";

    public LzmaException()
      : base("Specified stream is not a valid LZMA compressed stream!")
    {
    }

    public LzmaException(string message)
      : base("Specified stream is not a valid LZMA compressed stream!", message)
    {
    }

    public LzmaException(string message, Exception inner)
      : base("Specified stream is not a valid LZMA compressed stream!", message, inner)
    {
    }

    protected LzmaException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
