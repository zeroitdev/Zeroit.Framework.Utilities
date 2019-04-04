// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="InBuffer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Buffer
{
  internal class InBuffer
  {
    private readonly byte[] m_Buffer;
    private readonly uint m_BufferSize;
    private uint m_Limit;
    private uint m_Pos;
    private ulong m_ProcessedSize;
    private Stream m_Stream;
    private bool m_StreamWasExhausted;

    private InBuffer(uint bufferSize)
    {
      this.m_Buffer = new byte[bufferSize];
      this.m_BufferSize = bufferSize;
    }

    private void Init(Stream stream)
    {
      this.m_Stream = stream;
      this.m_ProcessedSize = 0UL;
      this.m_Limit = 0U;
      this.m_Pos = 0U;
      this.m_StreamWasExhausted = false;
    }

    private bool ReadBlock()
    {
      if (this.m_StreamWasExhausted)
        return false;
      this.m_ProcessedSize += (ulong) this.m_Pos;
      int num = this.m_Stream.Read(this.m_Buffer, 0, (int) this.m_BufferSize);
      this.m_Pos = 0U;
      this.m_Limit = (uint) num;
      this.m_StreamWasExhausted = num == 0;
      return !this.m_StreamWasExhausted;
    }

    private void ReleaseStream()
    {
      this.m_Stream = (Stream) null;
    }

    private bool ReadByte(out byte b)
    {
      b = (byte) 0;
      if (this.m_Pos >= this.m_Limit && !this.ReadBlock())
        return false;
      b = this.m_Buffer[this.m_Pos++];
      return true;
    }

    private byte ReadByte()
    {
      if (this.m_Pos >= this.m_Limit && !this.ReadBlock())
        return byte.MaxValue;
      return this.m_Buffer[this.m_Pos++];
    }

    private ulong GetProcessedSize()
    {
      return this.m_ProcessedSize + (ulong) this.m_Pos;
    }
  }
}
