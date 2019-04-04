// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveProperty.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.SevenZip
{
  public struct ArchiveProperty
  {
    public string Name { get; internal set; }

    public object Value { get; internal set; }

    public override bool Equals(object obj)
    {
      if (!(obj is ArchiveProperty))
        return false;
      return this.Equals((ArchiveProperty) obj);
    }

    public bool Equals(ArchiveProperty afi)
    {
      if (afi.Name == this.Name)
        return afi.Value == this.Value;
      return false;
    }

    public override int GetHashCode()
    {
      return this.Name.GetHashCode() ^ this.Value.GetHashCode();
    }

    public override string ToString()
    {
      return this.Name + " = " + this.Value;
    }

    public static bool operator ==(ArchiveProperty afi1, ArchiveProperty afi2)
    {
      return afi1.Equals(afi2);
    }

    public static bool operator !=(ArchiveProperty afi1, ArchiveProperty afi2)
    {
      return !afi1.Equals(afi2);
    }
  }
}
