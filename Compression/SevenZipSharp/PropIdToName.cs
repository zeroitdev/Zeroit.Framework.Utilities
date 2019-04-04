// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="PropIdToName.cs" company="Zeroit Dev Technologies">
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

using System.Collections.Generic;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal static class PropIdToName
  {
    public static readonly Dictionary<ItemPropId, string> PropIdNames = new Dictionary<ItemPropId, string>(46) { { ItemPropId.Path, "Path" }, { ItemPropId.Name, "Name" }, { ItemPropId.IsDirectory, "Folder" }, { ItemPropId.Size, "Size" }, { ItemPropId.PackedSize, "Packed Size" }, { ItemPropId.Attributes, "Attributes" }, { ItemPropId.CreationTime, "Created" }, { ItemPropId.LastAccessTime, "Accessed" }, { ItemPropId.LastWriteTime, "Modified" }, { ItemPropId.Solid, "Solid" }, { ItemPropId.Commented, "Commented" }, { ItemPropId.Encrypted, "Encrypted" }, { ItemPropId.SplitBefore, "Split Before" }, { ItemPropId.SplitAfter, "Split After" }, { ItemPropId.DictionarySize, "Dictionary Size" }, { ItemPropId.Crc, "CRC" }, { ItemPropId.Type, "Type" }, { ItemPropId.IsAnti, "Anti" }, { ItemPropId.Method, "Method" }, { ItemPropId.HostOS, "Host OS" }, { ItemPropId.FileSystem, "File System" }, { ItemPropId.User, "User" }, { ItemPropId.Group, "Group" }, { ItemPropId.Block, "Block" }, { ItemPropId.Comment, "Comment" }, { ItemPropId.Position, "Position" }, { ItemPropId.Prefix, "Prefix" }, { ItemPropId.NumSubDirs, "Number of subdirectories" }, { ItemPropId.NumSubFiles, "Number of subfiles" }, { ItemPropId.UnpackVersion, "Unpacker version" }, { ItemPropId.Volume, "Volume" }, { ItemPropId.IsVolume, "IsVolume" }, { ItemPropId.Offset, "Offset" }, { ItemPropId.Links, "Links" }, { ItemPropId.NumBlocks, "Number of blocks" }, { ItemPropId.NumVolumes, "Number of volumes" }, { ItemPropId.TimeType, "Time type" }, { ItemPropId.Bit64, "64-bit" }, { ItemPropId.BigEndian, "Big endian" }, { ItemPropId.Cpu, "CPU" }, { ItemPropId.PhysicalSize, "Physical Size" }, { ItemPropId.HeadersSize, "Headers Size" }, { ItemPropId.Checksum, "Checksum" }, { ItemPropId.FreeSpace, "Free Space" }, { ItemPropId.ClusterSize, "Cluster Size" } };
  }
}
