// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="OutBuffer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip.Sdk.Buffer
{
  internal class OutBuffer
  {
    private readonly byte[] m_Buffer;
    private readonly uint m_BufferSize;
    private uint m_Pos;
    private ulong m_ProcessedSize;
    private Stream m_Stream;

    public OutBuffer(uint bufferSize)
    {
      this.m_Buffer = new byte[bufferSize];
      this.m_BufferSize = bufferSize;
    }

    public void SetStream(Stream stream)
    {
      this.m_Stream = stream;
    }

    public void FlushStream()
    {
      this.m_Stream.Flush();
    }

    public void CloseStream()
    {
      this.m_Stream.Close();
    }

    public void ReleaseStream()
    {
      this.m_Stream = (Stream) null;
    }

    public void Init()
    {
      this.m_ProcessedSize = 0UL;
      this.m_Pos = 0U;
    }

    public void WriteByte(byte b)
    {
      this.m_Buffer[this.m_Pos++] = b;
      if (this.m_Pos < this.m_BufferSize)
        return;
      this.FlushData();
    }

    public void FlushData()
    {
      if (this.m_Pos == 0U)
        return;
      this.m_Stream.Write(this.m_Buffer, 0, (int) this.m_Pos);
      this.m_Pos = 0U;
    }

    public ulong GetProcessedSize()
    {
      return this.m_ProcessedSize + (ulong) this.m_Pos;
    }
  }
}
