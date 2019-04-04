// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipExtractor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Zeroit.Framework.Utilities.SevenZip.Sdk;
using Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.Lzma;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class SevenZipExtractor : SevenZipBase, IDisposable
  {
    private List<ArchiveFileInfo> _ArchiveFileData;
    private IInArchive _Archive;
    private IInStream _ArchiveStream;
    private ArchiveOpenCallback _OpenCallback;
    private string _FileName;
    private Stream _InStream;
    private long? _PackedSize;
    private long? _UnpackedSize;
    private uint? _FilesCount;
    private bool? _IsSolid;
    private bool _Opened;
    private bool _Disposed;
    private InArchiveFormat _Format;
    private ReadOnlyCollection<ArchiveFileInfo> _ArchiveFileInfoCollection;
    private ReadOnlyCollection<ArchiveProperty> _ArchiveProperties;

    public static void SetLibraryPath(string libraryPath)
    {
      SevenZipLibraryManager.SetLibraryPath(libraryPath);
    }

    private void Init(string archiveFullName)
    {
      this._FileName = archiveFullName;
      this._Format = FileChecker.CheckSignature(archiveFullName);
      SevenZipLibraryManager.LoadLibrary((object) this, (Enum) this._Format);
      try
      {
        this._Archive = SevenZipLibraryManager.InArchive(this._Format, (object) this);
      }
      catch (SevenZipLibraryException ex)
      {
        SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._Format);
        throw;
      }
    }

    private void Init(Stream stream)
    {
      SevenZipExtractor.ValidateStream(stream);
      this._Format = FileChecker.CheckSignature(stream);
      SevenZipLibraryManager.LoadLibrary((object) this, (Enum) this._Format);
      try
      {
        this._InStream = stream;
        this._Archive = SevenZipLibraryManager.InArchive(this._Format, (object) this);
        this._PackedSize = new long?(stream.Length);
      }
      catch (SevenZipLibraryException ex)
      {
        SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._Format);
        throw;
      }
    }

    public SevenZipExtractor(Stream archiveStream)
    {
      this.Init(archiveStream);
    }

    public SevenZipExtractor(string archiveFullName)
    {
      this.Init(archiveFullName);
    }

    public SevenZipExtractor(string archiveFullName, string password)
      : base(password)
    {
      this.Init(archiveFullName);
    }

    public SevenZipExtractor(Stream archiveStream, string password)
      : base(password)
    {
      this.Init(archiveStream);
    }

    public string FileName
    {
      get
      {
        this.DisposedCheck();
        return this._FileName;
      }
    }

    public long PackedSize
    {
      get
      {
        this.DisposedCheck();
        if (this._PackedSize.HasValue)
          return this._PackedSize.Value;
        if (this._FileName == null)
          return -1;
        return new FileInfo(this._FileName).Length;
      }
    }

    public long UnpackedSize
    {
      get
      {
        this.DisposedCheck();
        if (!this._UnpackedSize.HasValue)
          return -1;
        return this._UnpackedSize.Value;
      }
    }

    public bool IsSolid
    {
      get
      {
        this.DisposedCheck();
        if (!this._IsSolid.HasValue)
          this.GetArchiveInfo(true);
        return this._IsSolid.Value;
      }
    }

    [CLSCompliant(false)]
    public uint FilesCount
    {
      get
      {
        this.DisposedCheck();
        if (!this._FilesCount.HasValue)
          this.GetArchiveInfo(true);
        return this._FilesCount.Value;
      }
    }

    public InArchiveFormat Format
    {
      get
      {
        this.DisposedCheck();
        return this._Format;
      }
    }

    private ArchiveOpenCallback GetArchiveOpenCallback()
    {
      if (this._OpenCallback == null)
        this._OpenCallback = string.IsNullOrEmpty(this.Password) ? new ArchiveOpenCallback(this._FileName) : new ArchiveOpenCallback(this._FileName, this.Password);
      return this._OpenCallback;
    }

    private void DisposedCheck()
    {
      if (this._Disposed)
        throw new ObjectDisposedException(nameof (SevenZipExtractor));
    }

    private static void ValidateStream(Stream stream)
    {
      if (!stream.CanSeek || !stream.CanRead)
        throw new ArgumentException("The specified stream can not seek or read.", nameof (stream));
      if (stream.Length == 0L)
        throw new ArgumentException("The specified stream has zero length.", nameof (stream));
    }

    public void Dispose()
    {
      if (!this._Disposed)
      {
        if (this._Opened)
        {
          try
          {
            this._Archive.Close();
            this._Archive = (IInArchive) null;
            this._ArchiveFileData = (List<ArchiveFileInfo>) null;
            this._ArchiveProperties = (ReadOnlyCollection<ArchiveProperty>) null;
            this._ArchiveFileInfoCollection = (ReadOnlyCollection<ArchiveFileInfo>) null;
            this._InStream = (Stream) null;
          }
          catch (InvalidComObjectException ex)
          {
          }
        }
        if (this._OpenCallback != null)
        {
          try
          {
            this._OpenCallback.Dispose();
          }
          catch (ObjectDisposedException ex)
          {
          }
          this._OpenCallback = (ArchiveOpenCallback) null;
        }
        if (this._ArchiveStream != null)
        {
          if (this._ArchiveStream is IDisposable)
          {
            try
            {
              if (this._ArchiveStream is DisposeVariableWrapper)
                (this._ArchiveStream as DisposeVariableWrapper).DisposeStream = true;
              (this._ArchiveStream as IDisposable).Dispose();
            }
            catch (ObjectDisposedException ex)
            {
            }
            this._ArchiveStream = (IInStream) null;
          }
        }
        if (!string.IsNullOrEmpty(this._FileName))
          SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._Format);
      }
      this._Disposed = true;
      GC.SuppressFinalize((object) this);
    }

    public event EventHandler<FileInfoEventArgs> FileExtractionStarted;

    public event EventHandler FileExtractionFinished;

    public event EventHandler ExtractionFinished;

    public event EventHandler<ProgressEventArgs> Extracting;

    public event EventHandler<FileOverwriteEventArgs> FileExists;

    private void OnExtractionFinished(EventArgs e)
    {
      if (this.ExtractionFinished == null)
        return;
      this.ExtractionFinished((object) this, e);
    }

    public void Check()
    {
      this.DisposedCheck();
      try
      {
        this.InitArchiveFileData(false);
        IInStream archiveStream = this.GetArchiveStream(true);
        ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback();
        ulong maxCheckStartPosition = 32768;
        if (!this._Opened && this._Archive.Open(archiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
        {
          if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
            return;
        }
        this._Opened = true;
        using (ArchiveExtractCallback archiveExtractCallback = this.GetArchiveExtractCallback("", (int) this._FilesCount.Value, (List<uint>) null))
        {
          try
          {
            this.CheckedExecute(this._Archive.Extract((uint[]) null, uint.MaxValue, 1, (IArchiveExtractCallback) archiveExtractCallback), "The extraction has failed for an unknown reason with code ", (SevenZipBase) archiveExtractCallback);
          }
          finally
          {
            this.FreeArchiveExtractCallback(archiveExtractCallback);
          }
        }
      }
      finally
      {
        this._Archive.Close();
        this._ArchiveStream = (IInStream) null;
        this._Opened = false;
      }
    }

    private IInStream GetArchiveStream(bool dispose)
    {
      if (this._ArchiveStream != null)
      {
        if (this._ArchiveStream is DisposeVariableWrapper)
          (this._ArchiveStream as DisposeVariableWrapper).DisposeStream = dispose;
        return this._ArchiveStream;
      }
      if (this._InStream != null)
      {
        this._InStream.Seek(0L, SeekOrigin.Begin);
        this._ArchiveStream = (IInStream) new InStreamWrapper(this._InStream, false);
      }
      else if (!this._FileName.EndsWith(".001", StringComparison.OrdinalIgnoreCase))
      {
        this._ArchiveStream = (IInStream) new InStreamWrapper((Stream) new FileStream(this._FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), dispose);
      }
      else
      {
        this._ArchiveStream = (IInStream) new InMultiStreamWrapper(this._FileName, dispose);
        this._PackedSize = new long?((this._ArchiveStream as InMultiStreamWrapper).Length);
      }
      return this._ArchiveStream;
    }

    private void GetArchiveInfo(bool disposeStream)
    {
      if (this._Archive == null)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
          ;
      }
      else
      {
        IInStream archiveStream;
        using ((archiveStream = this.GetArchiveStream(disposeStream)) as IDisposable)
        {
          ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback();
          ulong maxCheckStartPosition = 32768;
          if (!this._Opened)
          {
            if (this._Archive.Open(archiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
            {
              if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
                return;
            }
            this._Opened = !disposeStream;
          }
          this._FilesCount = new uint?(this._Archive.GetNumberOfItems());
          uint? filesCount1 = this._FilesCount;
          if ((filesCount1.GetValueOrDefault() != 0U ? 0 : (filesCount1.HasValue ? 1 : 0)) != 0)
          {
            if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
              return;
          }
          PropVariant var = new PropVariant();
          this._ArchiveFileData = new List<ArchiveFileInfo>((int) this._FilesCount.Value);
          uint index1 = 0;
          while (true)
          {
            uint num = index1;
            uint? filesCount2 = this._FilesCount;
            if ((num >= filesCount2.GetValueOrDefault() ? 0 : (filesCount2.HasValue ? 1 : 0)) != 0)
            {
              try
              {
                ArchiveFileInfo archiveFileInfo = new ArchiveFileInfo() { Index = (int) index1 };
                this._Archive.GetProperty(index1, ItemPropId.Path, ref var);
                archiveFileInfo.FileName = NativeMethods.SafeCast<string>(var, "[no name]");
                this._Archive.GetProperty(index1, ItemPropId.LastWriteTime, ref var);
                archiveFileInfo.LastWriteTime = NativeMethods.SafeCast<DateTime>(var, DateTime.Now);
                this._Archive.GetProperty(index1, ItemPropId.CreationTime, ref var);
                archiveFileInfo.CreationTime = NativeMethods.SafeCast<DateTime>(var, DateTime.Now);
                this._Archive.GetProperty(index1, ItemPropId.LastAccessTime, ref var);
                archiveFileInfo.LastAccessTime = NativeMethods.SafeCast<DateTime>(var, DateTime.Now);
                this._Archive.GetProperty(index1, ItemPropId.Size, ref var);
                archiveFileInfo.Size = NativeMethods.SafeCast<ulong>(var, 0UL);
                this._Archive.GetProperty(index1, ItemPropId.Attributes, ref var);
                archiveFileInfo.Attributes = NativeMethods.SafeCast<uint>(var, 0U);
                this._Archive.GetProperty(index1, ItemPropId.IsDirectory, ref var);
                archiveFileInfo.IsDirectory = NativeMethods.SafeCast<bool>(var, false);
                this._Archive.GetProperty(index1, ItemPropId.Encrypted, ref var);
                archiveFileInfo.Encrypted = NativeMethods.SafeCast<bool>(var, false);
                this._Archive.GetProperty(index1, ItemPropId.Crc, ref var);
                archiveFileInfo.Crc = NativeMethods.SafeCast<uint>(var, 0U);
                this._Archive.GetProperty(index1, ItemPropId.Comment, ref var);
                archiveFileInfo.Comment = NativeMethods.SafeCast<string>(var, "");
                this._ArchiveFileData.Add(archiveFileInfo);
              }
              catch (InvalidCastException ex)
              {
                this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException("probably archive is corrupted."));
              }
              ++index1;
            }
            else
              break;
          }
          uint archiveProperties = this._Archive.GetNumberOfArchiveProperties();
          List<ArchiveProperty> archivePropertyList = new List<ArchiveProperty>((int) archiveProperties);
          for (uint index2 = 0; index2 < archiveProperties; ++index2)
          {
            string name;
            ItemPropId propId;
            ushort varType;
            this._Archive.GetArchivePropertyInfo(index2, out name, out propId, out varType);
            this._Archive.GetArchiveProperty(propId, ref var);
            if (propId == ItemPropId.Solid)
              this._IsSolid = new bool?(NativeMethods.SafeCast<bool>(var, true));
            if (PropIdToName.PropIdNames.ContainsKey(propId))
              archivePropertyList.Add(new ArchiveProperty()
              {
                Name = PropIdToName.PropIdNames[propId],
                Value = var.Object
              });
          }
          this._ArchiveProperties = new ReadOnlyCollection<ArchiveProperty>((IList<ArchiveProperty>) archivePropertyList);
          if (!this._IsSolid.HasValue && this._Format == InArchiveFormat.Zip)
            this._IsSolid = new bool?(false);
          if (!this._IsSolid.HasValue)
            this._IsSolid = new bool?(true);
        }
        if (disposeStream)
        {
          this._Archive.Close();
          this._ArchiveStream = (IInStream) null;
        }
        this._ArchiveFileInfoCollection = new ReadOnlyCollection<ArchiveFileInfo>((IList<ArchiveFileInfo>) this._ArchiveFileData);
      }
    }

    private void InitArchiveFileData(bool disposeStream)
    {
      if (this._ArchiveFileData != null)
        return;
      this.GetArchiveInfo(disposeStream);
    }

    private static uint[] SolidIndexes(uint[] indexes)
    {
      int val1 = 0;
      foreach (uint index in indexes)
        val1 = Math.Max(val1, (int) index);
      if (val1 <= 0)
        return indexes;
      int length = val1 + 1;
      uint[] numArray = new uint[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = (uint) index;
      return numArray;
    }

    private static bool CheckIndexes(params int[] indexes)
    {
      bool flag = true;
      foreach (int index in indexes)
      {
        if (index < 0)
        {
          flag = false;
          break;
        }
      }
      return flag;
    }

    private ArchiveExtractCallback GetArchiveExtractCallback(string directory, int filesCount, List<uint> actualIndexes)
    {
      ArchiveExtractCallback archiveExtractCallback = string.IsNullOrEmpty(this.Password) ? new ArchiveExtractCallback(this._Archive, directory, filesCount, actualIndexes, this) : new ArchiveExtractCallback(this._Archive, directory, filesCount, actualIndexes, this.Password, this);
      archiveExtractCallback.Open += (EventHandler<OpenEventArgs>) ((s, e) => this._UnpackedSize = new long?((long) e.TotalSize));
      archiveExtractCallback.FileExtractionStarted += this.FileExtractionStarted;
      archiveExtractCallback.FileExtractionFinished += this.FileExtractionFinished;
      archiveExtractCallback.Extracting += this.Extracting;
      archiveExtractCallback.FileExists += this.FileExists;
      return archiveExtractCallback;
    }

    private ArchiveExtractCallback GetArchiveExtractCallback(Stream stream, uint index, int filesCount)
    {
      ArchiveExtractCallback archiveExtractCallback = string.IsNullOrEmpty(this.Password) ? new ArchiveExtractCallback(this._Archive, stream, filesCount, index, this) : new ArchiveExtractCallback(this._Archive, stream, filesCount, index, this.Password, this);
      archiveExtractCallback.Open += (EventHandler<OpenEventArgs>) ((s, e) => this._UnpackedSize = new long?((long) e.TotalSize));
      archiveExtractCallback.FileExtractionStarted += this.FileExtractionStarted;
      archiveExtractCallback.FileExtractionFinished += this.FileExtractionFinished;
      archiveExtractCallback.Extracting += this.Extracting;
      archiveExtractCallback.FileExists += this.FileExists;
      return archiveExtractCallback;
    }

    private void FreeArchiveExtractCallback(ArchiveExtractCallback callback)
    {
      callback.Open -= (EventHandler<OpenEventArgs>) ((s, e) => this._UnpackedSize = new long?((long) e.TotalSize));
      callback.FileExtractionStarted -= this.FileExtractionStarted;
      callback.FileExtractionFinished -= this.FileExtractionFinished;
      callback.Extracting -= this.Extracting;
      callback.FileExists -= this.FileExists;
    }

    public ReadOnlyCollection<ArchiveFileInfo> ArchiveFileData
    {
      get
      {
        this.DisposedCheck();
        this.InitArchiveFileData(true);
        return this._ArchiveFileInfoCollection;
      }
    }

    public ReadOnlyCollection<ArchiveProperty> ArchiveProperties
    {
      get
      {
        this.DisposedCheck();
        if (this._ArchiveProperties == null)
          this.GetArchiveInfo(true);
        return this._ArchiveProperties;
      }
    }

    public ReadOnlyCollection<string> ArchiveFileNames
    {
      get
      {
        this.DisposedCheck();
        this.InitArchiveFileData(true);
        List<string> stringList = new List<string>(this._ArchiveFileData.Count);
        foreach (ArchiveFileInfo archiveFileInfo in this._ArchiveFileData)
          stringList.Add(archiveFileInfo.FileName);
        return new ReadOnlyCollection<string>((IList<string>) stringList);
      }
    }

    public void ExtractFile(string fileName, Stream stream)
    {
      this.DisposedCheck();
      this.InitArchiveFileData(false);
      int index = -1;
      foreach (ArchiveFileInfo archiveFileInfo in this._ArchiveFileData)
      {
        if (archiveFileInfo.FileName == fileName && !archiveFileInfo.IsDirectory)
        {
          index = archiveFileInfo.Index;
          break;
        }
      }
      if (index == -1)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentOutOfRangeException(nameof (fileName), "The specified file name was not found in the archive file table.")))
          ;
      }
      else
        this.ExtractFile(index, stream);
    }

    public void ExtractFile(int index, Stream stream)
    {
      this.DisposedCheck();
      this.ClearExceptions();
      if (!SevenZipExtractor.CheckIndexes(index))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The index must be more or equal to zero.", nameof (index))))
          return;
      }
      if (!stream.CanWrite)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The specified stream can not be written.", nameof (stream))))
          return;
      }
      this.InitArchiveFileData(false);
      long num = (long) index;
      uint? filesCount = this._FilesCount;
      uint? nullable = filesCount.HasValue ? new uint?(filesCount.GetValueOrDefault() - 1U) : new uint?();
      if ((num <= (long) nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentOutOfRangeException(nameof (index), "The specified index is greater than the archive files count.")))
          return;
      }
      uint[] indexes = new uint[1]{ (uint) index };
      if (this._IsSolid.Value)
        indexes = SevenZipExtractor.SolidIndexes(indexes);
      IInStream archiveStream = this.GetArchiveStream(false);
      ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback();
      ulong maxCheckStartPosition = 32768;
      if (!this._Opened)
      {
        if (this._Archive.Open(archiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
          this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException());
        this._Opened = true;
      }
      using (ArchiveExtractCallback archiveExtractCallback = this.GetArchiveExtractCallback(stream, (uint) index, indexes.Length))
      {
        try
        {
          this.CheckedExecute(this._Archive.Extract(indexes, (uint) indexes.Length, 0, (IArchiveExtractCallback) archiveExtractCallback), "The extraction has failed for an unknown reason with code ", (SevenZipBase) archiveExtractCallback);
        }
        finally
        {
          this.FreeArchiveExtractCallback(archiveExtractCallback);
        }
      }
      this.OnExtractionFinished(EventArgs.Empty);
      this.ThrowUserException();
    }

    public void ExtractFiles(string directory, params int[] indexes)
    {
      this.DisposedCheck();
      this.ClearExceptions();
      if (!SevenZipExtractor.CheckIndexes(indexes))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The indexes must be more or equal to zero.", nameof (indexes))))
          return;
      }
      this.InitArchiveFileData(false);
      uint[] numArray = new uint[indexes.Length];
      for (int index = 0; index < indexes.Length; ++index)
        numArray[index] = (uint) indexes[index];
      foreach (uint num in numArray)
      {
        uint? filesCount = this._FilesCount;
        if ((num < filesCount.GetValueOrDefault() ? 0 : (filesCount.HasValue ? 1 : 0)) != 0)
        {
          if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentOutOfRangeException(nameof (indexes), "Index must be less than " + this._FilesCount.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "!")))
            return;
        }
      }
      List<uint> actualIndexes = new List<uint>((IEnumerable<uint>) numArray);
      actualIndexes.Sort();
      uint[] indexes1 = actualIndexes.ToArray();
      if (this._IsSolid.Value)
        indexes1 = SevenZipExtractor.SolidIndexes(indexes1);
      try
      {
        IInStream archiveStream;
        using ((archiveStream = this.GetArchiveStream(actualIndexes.Count != 1)) as IDisposable)
        {
          ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback();
          ulong maxCheckStartPosition = 32768;
          if (!this._Opened)
          {
            if (this._Archive.Open(archiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
            {
              if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
                return;
            }
            this._Opened = true;
          }
          using (ArchiveExtractCallback archiveExtractCallback = this.GetArchiveExtractCallback(directory, (int) this._FilesCount.Value, actualIndexes))
          {
            try
            {
              this.CheckedExecute(this._Archive.Extract(indexes1, (uint) indexes1.Length, 0, (IArchiveExtractCallback) archiveExtractCallback), "The extraction has failed for an unknown reason with code ", (SevenZipBase) archiveExtractCallback);
            }
            finally
            {
              this.FreeArchiveExtractCallback(archiveExtractCallback);
            }
          }
        }
        this.OnExtractionFinished(EventArgs.Empty);
      }
      finally
      {
        if (actualIndexes.Count > 1)
        {
          this._Archive.Close();
          this._ArchiveStream = (IInStream) null;
          this._Opened = false;
        }
      }
      this.ThrowUserException();
    }

    public void ExtractFiles(string directory, params string[] fileNames)
    {
      this.DisposedCheck();
      this.InitArchiveFileData(false);
      List<int> intList = new List<int>(fileNames.Length);
      List<string> stringList = new List<string>((IEnumerable<string>) this.ArchiveFileNames);
      foreach (string fileName in fileNames)
      {
        if (!stringList.Contains(fileName))
        {
          if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentOutOfRangeException(nameof (fileNames), "File \"" + fileName + "\" was not found in the archive file table.")))
            return;
        }
        else
        {
          foreach (ArchiveFileInfo archiveFileInfo in this._ArchiveFileData)
          {
            if (archiveFileInfo.FileName == fileName && !archiveFileInfo.IsDirectory)
            {
              intList.Add(archiveFileInfo.Index);
              break;
            }
          }
        }
      }
      this.ExtractFiles(directory, intList.ToArray());
    }

    public void ExtractFiles(ExtractFileCallback extractFileCallback)
    {
      this.DisposedCheck();
      this.InitArchiveFileData(false);
      if (this.IsSolid)
        return;
      foreach (ArchiveFileInfo archiveFileInfo in this.ArchiveFileData)
      {
        ExtractFileCallbackArgs extractFileCallbackArgs = new ExtractFileCallbackArgs(archiveFileInfo);
        extractFileCallback(extractFileCallbackArgs);
        if (extractFileCallbackArgs.CancelExtraction)
          break;
        if (extractFileCallbackArgs.ExtractToStream != null || extractFileCallbackArgs.ExtractToFile != null)
        {
          bool flag = false;
          try
          {
            if (extractFileCallbackArgs.ExtractToStream != null)
            {
              this.ExtractFile(archiveFileInfo.Index, extractFileCallbackArgs.ExtractToStream);
            }
            else
            {
              using (FileStream fileStream = new FileStream(extractFileCallbackArgs.ExtractToFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 8192, FileOptions.SequentialScan))
                this.ExtractFile(archiveFileInfo.Index, (Stream) fileStream);
            }
            flag = true;
          }
          catch (Exception ex)
          {
            extractFileCallbackArgs.Exception = ex;
            extractFileCallbackArgs.Reason = ExtractFileCallbackReason.Failure;
            extractFileCallback(extractFileCallbackArgs);
            if (!this.ThrowException((SevenZipBase) null, ex))
              break;
          }
          if (flag)
          {
            extractFileCallbackArgs.Reason = ExtractFileCallbackReason.Done;
            extractFileCallback(extractFileCallbackArgs);
          }
        }
      }
    }

    public void ExtractArchive(string directory)
    {
      this.DisposedCheck();
      this.ClearExceptions();
      this.InitArchiveFileData(false);
      try
      {
        IInStream archiveStream;
        using ((archiveStream = this.GetArchiveStream(true)) as IDisposable)
        {
          ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback();
          ulong maxCheckStartPosition = 32768;
          if (!this._Opened && this._Archive.Open(archiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
          {
            if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException()))
              return;
          }
          this._Opened = true;
          using (ArchiveExtractCallback archiveExtractCallback = this.GetArchiveExtractCallback(directory, (int) this._FilesCount.Value, (List<uint>) null))
          {
            try
            {
              this.CheckedExecute(this._Archive.Extract((uint[]) null, uint.MaxValue, 0, (IArchiveExtractCallback) archiveExtractCallback), "The extraction has failed for an unknown reason with code ", (SevenZipBase) archiveExtractCallback);
              this.OnExtractionFinished(EventArgs.Empty);
            }
            finally
            {
              this.FreeArchiveExtractCallback(archiveExtractCallback);
            }
          }
        }
      }
      finally
      {
        this._Archive.Close();
        this._ArchiveStream = (IInStream) null;
        this._Opened = false;
      }
      this.ThrowUserException();
    }

    internal static byte[] GetLzmaProperties(Stream inStream, out long outSize)
    {
      byte[] buffer = new byte[5];
      if (inStream.Read(buffer, 0, 5) != 5)
        throw new LzmaException();
      outSize = 0L;
      for (int index = 0; index < 8; ++index)
      {
        int num = inStream.ReadByte();
        if (num < 0)
          throw new LzmaException();
        outSize |= (long) (byte) num << (index << 3);
      }
      return buffer;
    }

    public static void DecompressStream(Stream inStream, Stream outStream, int? inLength, EventHandler<ProgressEventArgs> codeProgressEvent)
    {
      if (!inStream.CanRead || !outStream.CanWrite)
        throw new ArgumentException("The specified streams are invalid.");
      Decoder decoder = new Decoder();
      long inSize = (inLength.HasValue ? (long) inLength.Value : inStream.Length) - inStream.Position;
      long outSize;
      decoder.SetDecoderProperties(SevenZipExtractor.GetLzmaProperties(inStream, out outSize));
      decoder.Code(inStream, outStream, inSize, outSize, (ICodeProgress) new LzmaProgressCallback(inSize, codeProgressEvent));
    }

    public static byte[] ExtractBytes(byte[] data)
    {
      using (MemoryStream memoryStream1 = new MemoryStream(data))
      {
        Decoder decoder = new Decoder();
        memoryStream1.Seek(0L, SeekOrigin.Begin);
        using (MemoryStream memoryStream2 = new MemoryStream())
        {
          long outSize;
          decoder.SetDecoderProperties(SevenZipExtractor.GetLzmaProperties((Stream) memoryStream1, out outSize));
          decoder.Code((Stream) memoryStream1, (Stream) memoryStream2, memoryStream1.Length - memoryStream1.Position, outSize, (ICodeProgress) null);
          return memoryStream2.ToArray();
        }
      }
    }
  }
}
