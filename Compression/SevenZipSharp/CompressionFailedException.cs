// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="CompressionFailedException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class CompressionFailedException : SevenZipException
  {
    public const string DefaultMessage = "Could not pack files!";

    public CompressionFailedException()
      : base("Could not pack files!")
    {
    }

    public CompressionFailedException(string message)
      : base("Could not pack files!", message)
    {
    }

    public CompressionFailedException(string message, Exception inner)
      : base("Could not pack files!", message, inner)
    {
    }

    protected CompressionFailedException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
