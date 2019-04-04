// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ExtractionFailedException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class ExtractionFailedException : SevenZipException
  {
    public const string DefaultMessage = "Could not extract files!";

    public ExtractionFailedException()
      : base("Could not extract files!")
    {
    }

    public ExtractionFailedException(string message)
      : base("Could not extract files!", message)
    {
    }

    public ExtractionFailedException(string message, Exception inner)
      : base("Could not extract files!", message, inner)
    {
    }

    protected ExtractionFailedException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
