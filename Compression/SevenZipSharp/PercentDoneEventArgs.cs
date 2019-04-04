// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="PercentDoneEventArgs.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class PercentDoneEventArgs : EventArgs
  {
    private readonly byte _PercentDone;

    public PercentDoneEventArgs(byte percentDone)
    {
      if (percentDone > (byte) 100 || percentDone < (byte) 0)
        throw new ArgumentOutOfRangeException(nameof (percentDone), "The percent of finished work must be between 0 and 100.");
      this._PercentDone = percentDone;
    }

    public byte PercentDone
    {
      get
      {
        return this._PercentDone;
      }
    }

    public bool Cancel { get; set; }

    internal static byte ProducePercentDone(float doneRate)
    {
      return (byte) Math.Round((double) Math.Min(100f * doneRate, 100f), MidpointRounding.AwayFromZero);
    }
  }
}
