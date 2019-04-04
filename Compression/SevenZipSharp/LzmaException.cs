// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="LzmaException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
