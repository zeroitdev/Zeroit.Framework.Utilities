// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipException.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  [Serializable]
  public class SevenZipException : Exception
  {
    internal const string UserExceptionMessage = "The extraction was successful butsome exceptions were thrown in your events. Check UserExceptions for details.";

    public SevenZipException()
      : base("SevenZip unknown exception.")
    {
    }

    public SevenZipException(string defaultMessage)
      : base(defaultMessage)
    {
    }

    public SevenZipException(string defaultMessage, string message)
      : base(defaultMessage + " Message: " + message)
    {
    }

    public SevenZipException(string defaultMessage, string message, Exception inner)
      : base(defaultMessage + (defaultMessage.EndsWith(" ", StringComparison.CurrentCulture) ? "" : " Message: ") + message, inner)
    {
    }

    public SevenZipException(string defaultMessage, Exception inner)
      : base(defaultMessage, inner)
    {
    }

    protected SevenZipException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
