// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipBase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class SevenZipBase : MarshalByRefObject
  {
    private readonly List<Exception> _UserExceptions = new List<Exception>();
    private readonly string _Password;
    private readonly bool _ReportErrors;

    protected SevenZipBase()
    {
      this._Password = "";
      this._ReportErrors = true;
    }

    protected SevenZipBase(string password)
    {
      if (string.IsNullOrEmpty(password))
        throw new SevenZipException("Empty password was specified.");
      this._Password = password;
      this._ReportErrors = true;
    }

    protected string Password
    {
      get
      {
        return this._Password;
      }
    }

    protected bool Canceled { get; set; }

    protected bool ReportErrors
    {
      get
      {
        return this._ReportErrors;
      }
    }

    private ReadOnlyCollection<Exception> Exceptions
    {
      get
      {
        return new ReadOnlyCollection<Exception>((IList<Exception>) this._UserExceptions);
      }
    }

    internal void AddException(Exception e)
    {
      this._UserExceptions.Add(e);
    }

    internal void ClearExceptions()
    {
      this._UserExceptions.Clear();
    }

    private bool HasExceptions()
    {
      return this._UserExceptions.Count > 0;
    }

    internal bool ThrowException(SevenZipBase handler, params Exception[] e)
    {
      if (this._ReportErrors && (handler == null || !handler.Canceled))
        throw e[0];
      return false;
    }

    internal void ThrowUserException()
    {
      if (this.HasExceptions())
        throw new SevenZipException("The extraction was successful butsome exceptions were thrown in your events. Check UserExceptions for details.");
    }

    protected void CheckedExecute(int hresult, string message, SevenZipBase handler)
    {
      if (hresult == 0 && !handler.HasExceptions())
        return;
      if (!handler.HasExceptions())
      {
        if (hresult < -2000000000)
          this.ThrowException(handler, (Exception) new SevenZipException("The execution has failed due to the bug in the SevenZipSharp.\nPlease report about it to http://sevenzipsharp.codeplex.com/WorkItem/List.aspx, post the release number and attach the archive."));
        else
          this.ThrowException(handler, (Exception) new SevenZipException(message + hresult.ToString((IFormatProvider) CultureInfo.InvariantCulture) + (object) '.'));
      }
      else
        this.ThrowException(handler, handler.Exceptions[0]);
    }
  }
}
