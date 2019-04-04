// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="DisposeVariableWrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal class DisposeVariableWrapper
  {
    public bool DisposeStream { get; set; }

    protected DisposeVariableWrapper(bool disposeStream)
    {
      this.DisposeStream = disposeStream;
    }
  }
}
