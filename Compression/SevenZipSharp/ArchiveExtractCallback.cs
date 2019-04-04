// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="ArchiveExtractCallback.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Zeroit.Framework.Utilities.SevenZip
{
  internal sealed class ArchiveExtractCallback : SevenZipBase, IArchiveExtractCallback, ICryptoGetTextPassword, IDisposable
  {
    private List<uint> _ActualIndexes;
    private IInArchive _Archive;
    private long _BytesCount;
    private long _BytesWritten;
    private long _BytesWrittenOld;
    private string _Directory;
    private float _DoneRate;
    private SevenZipExtractor _Extractor;
    private FakeOutStreamWrapper _FakeStream;
    private uint? _FileIndex;
    private int _FilesCount;
    private OutStreamWrapper _FileStream;

    public event EventHandler<FileInfoEventArgs> FileExtractionStarted;

    public event EventHandler FileExtractionFinished;

    public event EventHandler<OpenEventArgs> Open;

    public event EventHandler<ProgressEventArgs> Extracting;

    public event EventHandler<FileOverwriteEventArgs> FileExists;

    private void OnFileExists(FileOverwriteEventArgs e)
    {
      if (this.FileExists == null)
        return;
      try
      {
        this.FileExists((object) this, e);
      }
      catch (Exception ex)
      {
        this._Extractor.AddException(ex);
      }
    }

    private void OnOpen(OpenEventArgs e)
    {
      if (this.Open == null)
        return;
      try
      {
        this.Open((object) this, e);
      }
      catch (Exception ex)
      {
        this._Extractor.AddException(ex);
      }
    }

    private void OnFileExtractionStarted(FileInfoEventArgs e)
    {
      if (this.FileExtractionStarted == null)
        return;
      try
      {
        this.FileExtractionStarted((object) this, e);
      }
      catch (Exception ex)
      {
        this._Extractor.AddException(ex);
      }
    }

    private void OnFileExtractionFinished(EventArgs e)
    {
      if (this.FileExtractionFinished == null)
        return;
      try
      {
        this.FileExtractionFinished((object) this, e);
      }
      catch (Exception ex)
      {
        this._Extractor.AddException(ex);
      }
    }

    private void OnExtracting(ProgressEventArgs e)
    {
      if (this.Extracting == null)
        return;
      try
      {
        this.Extracting((object) this, e);
      }
      catch (Exception ex)
      {
        this._Extractor.AddException(ex);
      }
    }

    private void IntEventArgsHandler(object sender, IntEventArgs e)
    {
      int num1 = (int) (this._BytesWrittenOld * 100L / this._BytesCount);
      this._BytesWritten += (long) e.Value;
      int num2 = (int) (this._BytesWritten * 100L / this._BytesCount);
      if (num2 <= num1)
        return;
      if (num2 > 100)
        num1 = num2 = 0;
      this._BytesWrittenOld = this._BytesWritten;
      this.OnExtracting(new ProgressEventArgs((byte) num2, (byte) (num2 - num1)));
    }

    public void SetTotal(ulong total)
    {
      this._BytesCount = (long) total;
      this.OnOpen(new OpenEventArgs(total));
    }

    public void SetCompleted(ref ulong completeValue)
    {
    }

    public int GetStream(uint index, out ISequentialOutStream outStream, AskMode askExtractMode)
    {
      outStream = (ISequentialOutStream) null;
      if (askExtractMode == AskMode.Extract)
      {
        string str1 = this._Directory;
        for (int index1 = 0; index1 < 1; ++index1)
        {
          if (!this._FileIndex.HasValue)
          {
            if (this._ActualIndexes == null || this._ActualIndexes.Contains(index))
            {
              PropVariant var = new PropVariant();
              this._Archive.GetProperty(index, ItemPropId.Path, ref var);
              string str2 = NativeMethods.SafeCast<string>(var, "");
              if (string.IsNullOrEmpty(str2))
              {
                if (this._FilesCount == 1)
                {
                  string fileName = Path.GetFileName(this._Extractor.FileName);
                  string str3 = fileName.Substring(0, fileName.LastIndexOf('.'));
                  if (!str3.EndsWith(".tar", StringComparison.OrdinalIgnoreCase))
                    str3 += ".tar";
                  str2 = str3;
                }
                else
                  str2 = "[no name] " + index.ToString((IFormatProvider) CultureInfo.InvariantCulture);
              }
              str1 += str2;
              this._Archive.GetProperty(index, ItemPropId.IsDirectory, ref var);
              try
              {
                str1 = ArchiveExtractCallback.ValidateFileName(str1);
              }
              catch (Exception ex)
              {
                this.AddException(ex);
                break;
              }
              if (!NativeMethods.SafeCast<bool>(var, false))
              {
                this._Archive.GetProperty(index, ItemPropId.LastWriteTime, ref var);
                DateTime time = NativeMethods.SafeCast<DateTime>(var, DateTime.MinValue);
                if (File.Exists(str1))
                {
                  FileOverwriteEventArgs e = new FileOverwriteEventArgs(str1);
                  this.OnFileExists(e);
                  if (e.Cancel)
                  {
                    this.Canceled = true;
                    return -1;
                  }
                  if (string.IsNullOrEmpty(e.FileName))
                  {
                    outStream = (ISequentialOutStream) this._FakeStream;
                    break;
                  }
                  str1 = e.FileName;
                }
                try
                {
                  this._FileStream = new OutStreamWrapper((Stream) File.Create(str1), str1, time, true);
                }
                catch (Exception ex)
                {
                  if (ex is FileNotFoundException)
                    this.AddException((Exception) new IOException("The file \"" + str1 + "\" was not extracted due to the File.Create fail."));
                  else
                    this.AddException(ex);
                  outStream = (ISequentialOutStream) this._FakeStream;
                  break;
                }
                this._FileStream.BytesWritten += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
                outStream = (ISequentialOutStream) this._FileStream;
              }
              else if (!Directory.Exists(str1))
              {
                try
                {
                  Directory.CreateDirectory(str1);
                }
                catch (Exception ex)
                {
                  this.AddException(ex);
                }
                outStream = (ISequentialOutStream) this._FakeStream;
              }
            }
            else
              outStream = (ISequentialOutStream) this._FakeStream;
          }
          else
          {
            uint num = index;
            uint? fileIndex = this._FileIndex;
            if (((int) num != (int) fileIndex.GetValueOrDefault() ? 0 : (fileIndex.HasValue ? 1 : 0)) != 0)
            {
              outStream = (ISequentialOutStream) this._FileStream;
              this._FileIndex = new uint?();
            }
            else
              outStream = (ISequentialOutStream) this._FakeStream;
          }
        }
        this._DoneRate += 1f / (float) this._FilesCount;
        FileInfoEventArgs e1 = new FileInfoEventArgs(this._Extractor.ArchiveFileData[(int) index], PercentDoneEventArgs.ProducePercentDone(this._DoneRate));
        this.OnFileExtractionStarted(e1);
        if (e1.Cancel)
        {
          if (!string.IsNullOrEmpty(str1))
          {
            this._FileStream.Dispose();
            if (File.Exists(str1))
            {
              try
              {
                File.Delete(str1);
              }
              catch (Exception ex)
              {
                this.AddException(ex);
              }
            }
          }
          this.Canceled = true;
          return -1;
        }
      }
      return 0;
    }

    public void PrepareOperation(AskMode askExtractMode)
    {
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
      else
      {
        if (this._FileStream != null)
        {
          if (!this._FileIndex.HasValue)
          {
            try
            {
              this._FileStream.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
            }
            this._FileStream = (OutStreamWrapper) null;
          }
        }
        this.OnFileExtractionFinished(EventArgs.Empty);
      }
    }

    public int CryptoGetTextPassword(out string password)
    {
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
        this._FileStream = (OutStreamWrapper) null;
      }
      if (this._FakeStream == null)
        return;
      try
      {
        this._FakeStream.Dispose();
      }
      catch (ObjectDisposedException ex)
      {
      }
      this._FakeStream = (FakeOutStreamWrapper) null;
    }

    private static string ValidateFileName(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
        throw new SevenZipArchiveException("some archive name is null or empty.");
      List<string> stringList = new List<string>((IEnumerable<string>) fileName.Split(Path.DirectorySeparatorChar));
      foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
      {
        for (int index = 0; index < stringList.Count; ++index)
        {
          if ((invalidFileNameChar != ':' || index != 0) && !string.IsNullOrEmpty(stringList[index]))
          {
            while (stringList[index].IndexOf(invalidFileNameChar) > -1)
              stringList[index] = stringList[index].Replace(invalidFileNameChar, '_');
          }
        }
      }
      if (fileName.StartsWith(new string(Path.DirectorySeparatorChar, 2), StringComparison.CurrentCultureIgnoreCase))
      {
        stringList.RemoveAt(0);
        stringList.RemoveAt(0);
        stringList[0] = new string(Path.DirectorySeparatorChar, 2) + stringList[0];
      }
      if (stringList.Count > 2)
      {
        string path = stringList[0];
        for (int index = 1; index < stringList.Count - 1; ++index)
        {
          path = path + (object) Path.DirectorySeparatorChar + stringList[index];
          if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        }
      }
      return string.Join(new string(Path.DirectorySeparatorChar, 1), stringList.ToArray());
    }

    public ArchiveExtractCallback(IInArchive archive, string directory, int filesCount, List<uint> actualIndexes, SevenZipExtractor extractor)
    {
      this.Init(archive, directory, filesCount, actualIndexes, extractor);
    }

    public ArchiveExtractCallback(IInArchive archive, string directory, int filesCount, List<uint> actualIndexes, string password, SevenZipExtractor extractor)
      : base(password)
    {
      this.Init(archive, directory, filesCount, actualIndexes, extractor);
    }

    public ArchiveExtractCallback(IInArchive archive, Stream stream, int filesCount, uint fileIndex, SevenZipExtractor extractor)
    {
      this.Init(archive, stream, filesCount, fileIndex, extractor);
    }

    public ArchiveExtractCallback(IInArchive archive, Stream stream, int filesCount, uint fileIndex, string password, SevenZipExtractor extractor)
      : base(password)
    {
      this.Init(archive, stream, filesCount, fileIndex, extractor);
    }

    private void Init(IInArchive archive, string directory, int filesCount, List<uint> actualIndexes, SevenZipExtractor extractor)
    {
      this._Archive = archive;
      this._Directory = directory;
      this._FilesCount = filesCount;
      this._ActualIndexes = actualIndexes;
      if (!directory.EndsWith(new string(Path.DirectorySeparatorChar, 1), StringComparison.CurrentCulture))
        this._Directory += (string) (object) Path.DirectorySeparatorChar;
      this._FakeStream = new FakeOutStreamWrapper();
      this._FakeStream.BytesWritten += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
      this._Extractor = extractor;
    }

    private void Init(IInArchive archive, Stream stream, int filesCount, uint fileIndex, SevenZipExtractor extractor)
    {
      this._Archive = archive;
      this._FileStream = new OutStreamWrapper(stream, false);
      this._FileStream.BytesWritten += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
      this._FilesCount = filesCount;
      this._FileIndex = new uint?(fileIndex);
      this._FakeStream = new FakeOutStreamWrapper();
      this._FakeStream.BytesWritten += new EventHandler<IntEventArgs>(this.IntEventArgsHandler);
      this._Extractor = extractor;
    }
  }
}
