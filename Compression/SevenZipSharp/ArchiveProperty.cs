// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveProperty.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
