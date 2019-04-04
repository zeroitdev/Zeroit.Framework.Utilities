// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ItemPropId.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal enum ItemPropId : uint
  {
    NoProperty = 0,
    HandlerItemIndex = 2,
    Path = 3,
    Name = 4,
    Extension = 5,
    IsDirectory = 6,
    Size = 7,
    PackedSize = 8,
    Attributes = 9,
    CreationTime = 10, // 0x0000000A
    LastAccessTime = 11, // 0x0000000B
    LastWriteTime = 12, // 0x0000000C
    Solid = 13, // 0x0000000D
    Commented = 14, // 0x0000000E
    Encrypted = 15, // 0x0000000F
    SplitBefore = 16, // 0x00000010
    SplitAfter = 17, // 0x00000011
    DictionarySize = 18, // 0x00000012
    Crc = 19, // 0x00000013
    Type = 20, // 0x00000014
    IsAnti = 21, // 0x00000015
    Method = 22, // 0x00000016
    HostOS = 23, // 0x00000017
    FileSystem = 24, // 0x00000018
    User = 25, // 0x00000019
    Group = 26, // 0x0000001A
    Block = 27, // 0x0000001B
    Comment = 28, // 0x0000001C
    Position = 29, // 0x0000001D
    Prefix = 30, // 0x0000001E
    NumSubDirs = 31, // 0x0000001F
    NumSubFiles = 32, // 0x00000020
    UnpackVersion = 33, // 0x00000021
    Volume = 34, // 0x00000022
    IsVolume = 35, // 0x00000023
    Offset = 36, // 0x00000024
    Links = 37, // 0x00000025
    NumBlocks = 38, // 0x00000026
    NumVolumes = 39, // 0x00000027
    TimeType = 40, // 0x00000028
    Bit64 = 41, // 0x00000029
    BigEndian = 42, // 0x0000002A
    Cpu = 43, // 0x0000002B
    PhysicalSize = 44, // 0x0000002C
    HeadersSize = 45, // 0x0000002D
    Checksum = 46, // 0x0000002E
    TotalSize = 4352, // 0x00001100
    FreeSpace = 4353, // 0x00001101
    ClusterSize = 4354, // 0x00001102
    VolumeName = 4355, // 0x00001103
    LocalName = 4608, // 0x00001200
    Provider = 4609, // 0x00001201
    UserDefined = 65536, // 0x00010000
  }
}
