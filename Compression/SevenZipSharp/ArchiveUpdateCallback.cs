// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveUpdateCallback.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class ArchiveUpdateCallback : SevenZipBase, IArchiveUpdateCallback, ICryptoGetTextPassword2, IDisposable
  {
    private int _ActualFilesCount;
    private long _BytesCount;
    private long _BytesWritten;
    private long _BytesWrittenOld;
    private SevenZipCompressor _Compressor;
    private bool _DirectoryStructure;
    private float _DoneRate;
    private string[] _Entries;
    private FileInfo[] _Files;
    private InStreamWrapper _FileStream;
    private uint _IndexInArchive;
    private uint _IndexOffset;
    private int _RootLength;
    private Stream[] _Streams;
    private UpdateData _UpdateData;
    private List<InStreamWrapper> _WrappersToDispose;

    public ArchiveUpdateCallback(FileInfo[] files, int rootLength, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this.Init(files, rootLength, compressor, updateData, directoryStructure);
    }

    public ArchiveUpdateCallback(FileInfo[] files, int rootLength, string password, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
      : base(password)
    {
      this.Init(files, rootLength, compressor, updateData, directoryStructure);
    }

    public ArchiveUpdateCallback(Stream stream, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this.Init(stream, compressor, updateData, directoryStructure);
    }

    public ArchiveUpdateCallback(Stream stream, string password, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
      : base(password)
    {
      this.Init(stream, compressor, updateData, directoryStructure);
    }

    public ArchiveUpdateCallback(Dictionary<Stream, string> streamDict, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this.Init(streamDict, compressor, updateData, directoryStructure);
    }

    public ArchiveUpdateCallback(Dictionary<Stream, string> streamDict, string password, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
      : base(password)
    {
      this.Init(streamDict, compressor, updateData, directoryStructure);
    }

    private void CommonInit(SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this._Compressor = compressor;
      this._IndexInArchive = updateData.FilesCount;
      this._IndexOffset = updateData.Mode != InternalCompressionMode.Append ? 0U : this._IndexInArchive;
      if (this._Compressor.ArchiveFormat == OutArchiveFormat.Zip)
        this._WrappersToDispose = new List<InStreamWrapper>();
      this._UpdateData = updateData;
      this._DirectoryStructure = directoryStructure;
    }

    private void Init(FileInfo[] files, int rootLength, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this._Files = files;
      this._RootLength = rootLength;
      if (files != null)
      {
        foreach (FileInfo file in files)
        {
          if (file.Exists)
          {
            this._BytesCount += file.Length;
            if ((file.Attributes & FileAttributes.Directory) == (FileAttributes) 0)
              ++this._ActualFilesCount;
          }
        }
      }
      this.CommonInit(compressor, updateData, directoryStructure);
    }

    private void Init(Stream stream, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this._FileStream = new InStreamWrapper(stream, false);
      this._FileStream.BytesRead += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
      this._ActualFilesCount = 1;
      try
      {
        this._BytesCount = stream.Length;
      }
      catch (NotSupportedException ex)
      {
        this._BytesCount = -1L;
      }
      try
      {
        stream.Seek(0L, SeekOrigin.Begin);
      }
      catch (NotSupportedException ex)
      {
        this._BytesCount = -1L;
      }
      this.CommonInit(compressor, updateData, directoryStructure);
    }

    private void Init(Dictionary<Stream, string> streamDict, SevenZipCompressor compressor, UpdateData updateData, bool directoryStructure)
    {
      this._Streams = new Stream[streamDict.Count];
      streamDict.Keys.CopyTo(this._Streams, 0);
      this._Entries = new string[streamDict.Count];
      streamDict.Values.CopyTo(this._Entries, 0);
      this._ActualFilesCount = streamDict.Count;
      foreach (Stream stream in this._Streams)
        this._BytesCount += stream.Length;
      this.CommonInit(compressor, updateData, directoryStructure);
    }

    public event EventHandler<FileNameEventArgs> FileCompressionStarted;

    public event EventHandler<ProgressEventArgs> Compressing;

    public event EventHandler FileCompressionFinished;

    private void OnFileCompression(FileNameEventArgs e)
    {
      if (this.FileCompressionStarted == null)
        return;
      try
      {
        this.FileCompressionStarted((object) this, e);
      }
      catch (Exception ex)
      {
        this._Compressor.AddException(ex);
      }
    }

    private void OnCompressing(ProgressEventArgs e)
    {
      if (this.Compressing == null)
        return;
      try
      {
        this.Compressing((object) this, e);
      }
      catch (Exception ex)
      {
        this._Compressor.AddException(ex);
      }
    }

    private void OnFileCompressionFinished(EventArgs e)
    {
      if (this.FileCompressionFinished == null)
        return;
      try
      {
        this.FileCompressionFinished((object) this, e);
      }
      catch (Exception ex)
      {
        this._Compressor.AddException(ex);
      }
    }

    public void SetTotal(ulong total)
    {
    }

    public void SetCompleted(ref ulong completeValue)
    {
    }

    public int GetUpdateItemInfo(uint index, ref int newData, ref int newProperties, ref uint indexInArchive)
    {
      switch (this._UpdateData.Mode)
      {
        case InternalCompressionMode.Create:
          newData = 1;
          newProperties = 1;
          indexInArchive = uint.MaxValue;
          break;
        case InternalCompressionMode.Append:
          if (index < this._IndexInArchive)
          {
            newData = 0;
            newProperties = 0;
            indexInArchive = index;
            break;
          }
          newData = 1;
          newProperties = 1;
          indexInArchive = uint.MaxValue;
          break;
        case InternalCompressionMode.Modify:
          newData = 0;
          newProperties = Convert.ToInt32(this._UpdateData.FileNamesToModify.ContainsKey((int) index) && this._UpdateData.FileNamesToModify[(int) index] != null);
          indexInArchive = !this._UpdateData.FileNamesToModify.ContainsKey((int) index) || this._UpdateData.FileNamesToModify[(int) index] != null ? index : ((long) index != (long) (this._UpdateData.ArchiveFileData.Count - 1) ? (uint) (this._UpdateData.ArchiveFileData.Count - 1) : 0U);
          break;
      }
      return 0;
    }

    public int GetProperty(uint index, ItemPropId propID, ref PropVariant value)
    {
      index -= this._IndexOffset;
      try
      {
        switch (propID)
        {
          case ItemPropId.Path:
            value.VarType = VarEnum.VT_BSTR;
            string s1 = "default";
            if (this._UpdateData.Mode != InternalCompressionMode.Modify)
            {
              if (this._Files == null)
              {
                if (this._Entries != null)
                  s1 = this._Entries[ index];
              }
              else
                s1 = !this._DirectoryStructure ? this._Files[ index].Name : (this._RootLength <= 0 ? ((int) this._Files[ index].FullName[0]).ToString() + this._Files[ index].FullName.Substring(2) : this._Files[ index].FullName.Substring(this._RootLength));
            }
            else
              s1 = this._UpdateData.FileNamesToModify[(int) index];
            value.Value = Marshal.StringToBSTR(s1);
            break;
          case ItemPropId.Extension:
            value.VarType = VarEnum.VT_BSTR;
            if (this._UpdateData.Mode != InternalCompressionMode.Modify)
            {
              try
              {
                string s2 = this._Files != null ? this._Files[ index].Extension.Substring(1) : (this._Entries == null ? "" : Path.GetExtension(this._Entries[ index]));
                value.Value = Marshal.StringToBSTR(s2);
                break;
              }
              catch (ArgumentException ex)
              {
                value.Value = Marshal.StringToBSTR("");
                break;
              }
            }
            else
            {
              string extension = Path.GetExtension(this._UpdateData.ArchiveFileData[(int) index].FileName);
              value.Value = Marshal.StringToBSTR(extension);
              break;
            }
          case ItemPropId.IsDirectory:
            value.VarType = VarEnum.VT_BOOL;
            value.UInt64Value = this._UpdateData.Mode == InternalCompressionMode.Modify ? Convert.ToUInt64(this._UpdateData.ArchiveFileData[(int) index].IsDirectory) : (this._Files == null ? 0UL : (ulong) (byte) (this._Files[ index].Attributes & FileAttributes.Directory));
            break;
          case ItemPropId.Size:
            value.VarType = VarEnum.VT_UI8;
            ulong num = this._UpdateData.Mode == InternalCompressionMode.Modify ? this._UpdateData.ArchiveFileData[(int) index].Size : (this._Files != null ? ((this._Files[ index].Attributes & FileAttributes.Directory) == (FileAttributes) 0 ? (ulong) this._Files[ index].Length : 0UL) : (this._Streams != null ? (ulong) this._Streams[ index].Length : (this._BytesCount > 0L ? (ulong) this._BytesCount : 0UL)));
            value.UInt64Value = num;
            break;
          case ItemPropId.Attributes:
            value.VarType = VarEnum.VT_UI4;
            value.UInt32Value = this._UpdateData.Mode == InternalCompressionMode.Modify ? this._UpdateData.ArchiveFileData[(int) index].Attributes : (this._Files == null ? 32U : (uint) this._Files[ index].Attributes);
            break;
          case ItemPropId.CreationTime:
            value.VarType = VarEnum.VT_FILETIME;
            value.Int64Value = this._UpdateData.Mode == InternalCompressionMode.Modify ? this._UpdateData.ArchiveFileData[(int) index].CreationTime.ToFileTime() : (this._Files == null ? DateTime.Now.ToFileTime() : this._Files[ index].CreationTime.ToFileTime());
            break;
          case ItemPropId.LastAccessTime:
            value.VarType = VarEnum.VT_FILETIME;
            value.Int64Value = this._UpdateData.Mode == InternalCompressionMode.Modify ? this._UpdateData.ArchiveFileData[(int) index].LastAccessTime.ToFileTime() : (this._Files == null ? DateTime.Now.ToFileTime() : this._Files[ index].LastAccessTime.ToFileTime());
            break;
          case ItemPropId.LastWriteTime:
            value.VarType = VarEnum.VT_FILETIME;
            value.Int64Value = this._UpdateData.Mode == InternalCompressionMode.Modify ? this._UpdateData.ArchiveFileData[(int) index].LastWriteTime.ToFileTime() : (this._Files == null ? DateTime.Now.ToFileTime() : this._Files[ index].LastWriteTime.ToFileTime());
            break;
          case ItemPropId.IsAnti:
            value.VarType = VarEnum.VT_BOOL;
            value.UInt64Value = 0UL;
            break;
        }
      }
      catch (Exception ex)
      {
        this.AddException(ex);
      }
      return 0;
    }

    public int GetStream(uint index, out ISequentialInStream inStream)
    {
      index -= this._IndexOffset;
      if (this._Files != null)
      {
        if ((this._Files[ index].Attributes & FileAttributes.Directory) == (FileAttributes) 0)
        {
          try
          {
            this._FileStream = new InStreamWrapper((Stream) new FileStream(this._Files[ index].FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), true);
          }
          catch (Exception ex)
          {
            this.AddException(ex);
            inStream = (ISequentialInStream) null;
            return -1;
          }
          EventHandler<IntEventArgs> eventHandler = new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
          this._FileStream.BytesRead += eventHandler;
          this._FileStream.StreamSeek += eventHandler;
          inStream = (ISequentialInStream) this._FileStream;
        }
        else
          inStream = (ISequentialInStream) null;
        this._DoneRate += 1f / (float) this._ActualFilesCount;
        FileNameEventArgs e = new FileNameEventArgs(this._Files[ index].Name, PercentDoneEventArgs.ProducePercentDone(this._DoneRate));
        this.OnFileCompression(e);
        if (e.Cancel)
        {
          this.Canceled = true;
          return -1;
        }
      }
      else if (this._Streams == null)
      {
        inStream = (ISequentialInStream) this._FileStream;
      }
      else
      {
        this._FileStream = new InStreamWrapper(this._Streams[ index], true);
        this._FileStream.BytesRead += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
        inStream = (ISequentialInStream) this._FileStream;
        this._DoneRate += 1f / (float) this._ActualFilesCount;
        FileNameEventArgs e = new FileNameEventArgs(this._Entries[ index], PercentDoneEventArgs.ProducePercentDone(this._DoneRate));
        this.OnFileCompression(e);
        if (e.Cancel)
        {
          this.Canceled = true;
          return -1;
        }
      }
      return 0;
    }

    public long EnumProperties(IntPtr enumerator)
    {
      return 2147500033;
    }

    public void SetOperationResult(OperationResult operationResult)
    {
      if (operationResult != OperationResult.Ok && this.ReportErrors)
      {
        switch (operationResult)
        {
          case OperationResult.UnsupportedMethod:
            this.AddException((Exception) new ExtractionFailedException("Unsupported method error has occured."));
            break;
          case OperationResult.DataError:
            this.AddException((Exception) new ExtractionFailedException("File is corrupted. Data error has occured."));
            break;
          case OperationResult.CrcError:
            this.AddException((Exception) new ExtractionFailedException("File is corrupted. Crc check has failed."));
            break;
        }
      }
      if (this._FileStream != null)
      {
        try
        {
          if (this._Compressor.ArchiveFormat != OutArchiveFormat.Zip)
          {
            this._FileStream.Dispose();
            this._FileStream = (InStreamWrapper) null;
          }
          else
            this._WrappersToDispose.Add(this._FileStream);
        }
        catch (ObjectDisposedException ex)
        {
        }
      }
      this.OnFileCompressionFinished(EventArgs.Empty);
    }

    public int CryptoGetTextPassword2(ref int passwordIsDefined, out string password)
    {
      passwordIsDefined = string.IsNullOrEmpty(this.Password) ? 0 : 1;
      password = this.Password;
      return 0;
    }

    public void Dispose()
    {
      if (this._FileStream != null)
      {
        try
        {
          this._FileStream.Dispose();
        }
        catch (ObjectDisposedException ex)
        {
        }
      }
      if (this._WrappersToDispose != null)
      {
        foreach (InStreamWrapper inStreamWrapper in this._WrappersToDispose)
        {
          try
          {
            inStreamWrapper.Dispose();
          }
          catch (ObjectDisposedException ex)
          {
          }
        }
      }
      GC.SuppressFinalize((object) this);
    }

    private void IntEventArgsHandler(object sender, IntEventArgs e)
    {
      lock (this)
      {
        byte num = (byte) (this._BytesWrittenOld * 100L / this._BytesCount);
        this._BytesWritten += (long) e.Value;
        byte percentDone = (byte) (this._BytesWritten * 100L / this._BytesCount);
        if ((int) percentDone <= (int) num)
          return;
        this._BytesWrittenOld = this._BytesWritten;
        this.OnCompressing(new ProgressEventArgs(percentDone, (byte) ((uint) percentDone - (uint) num)));
      }
    }
  }
}
