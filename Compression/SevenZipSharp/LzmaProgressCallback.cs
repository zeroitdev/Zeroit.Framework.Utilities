// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="LzmaProgressCallback.cs" company="Zeroit Dev Technologies">
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

using Zeroit.Framework.Utilities.SevenZip.Sdk;
using System;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class LzmaProgressCallback : ICodeProgress
  {
    private readonly long _InSize;
    private float _OldPercentDone;

    public LzmaProgressCallback(long inSize, EventHandler<ProgressEventArgs> working)
    {
      this._InSize = inSize;
      this.Working += working;
    }

    public void SetProgress(long inSize, long outSize)
    {
      if (this.Working == null)
        return;
      float doneRate1 = ((float) inSize + 0.0f) / (float) this._InSize;
      float doneRate2 = doneRate1 - this._OldPercentDone;
      if ((double) doneRate2 * 100.0 < 1.0)
        doneRate2 = 0.0f;
      else
        this._OldPercentDone = doneRate1;
      this.Working((object) this, new ProgressEventArgs(PercentDoneEventArgs.ProducePercentDone(doneRate1), (double) doneRate2 > 0.0 ? PercentDoneEventArgs.ProducePercentDone(doneRate2) : (byte) 0));
    }

    public event EventHandler<ProgressEventArgs> Working;
  }
}
