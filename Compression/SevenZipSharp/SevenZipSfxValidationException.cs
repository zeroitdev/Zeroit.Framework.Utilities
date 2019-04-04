// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipSfxValidationException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipSfxValidationException : SevenZipException
  {
    public static readonly string DefaultMessage = "Sfx settings validation failed.";

    public SevenZipSfxValidationException()
      : base(SevenZipSfxValidationException.DefaultMessage)
    {
    }

    public SevenZipSfxValidationException(string message)
      : base(SevenZipSfxValidationException.DefaultMessage, message)
    {
    }

    public SevenZipSfxValidationException(string message, Exception inner)
      : base(SevenZipSfxValidationException.DefaultMessage, message, inner)
    {
    }

    protected SevenZipSfxValidationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
