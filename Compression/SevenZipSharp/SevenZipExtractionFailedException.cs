// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipExtractionFailedException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipExtractionFailedException : SevenZipException
  {
    public const string DefaultMessage = "The extraction has failed for an unknown reason with code ";

    public SevenZipExtractionFailedException()
      : base("The extraction has failed for an unknown reason with code ")
    {
    }

    public SevenZipExtractionFailedException(string message)
      : base("The extraction has failed for an unknown reason with code ", message)
    {
    }

    public SevenZipExtractionFailedException(string message, Exception inner)
      : base("The extraction has failed for an unknown reason with code ", message, inner)
    {
    }

    protected SevenZipExtractionFailedException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
