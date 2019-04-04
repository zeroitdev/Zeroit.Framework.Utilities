// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipCompressor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Zeroit.Framework.Utilities.SevenZip.Sdk;
using Zeroit.Framework.Utilities.SevenZip.Sdk.Compression.Lzma;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public sealed class SevenZipCompressor : SevenZipBase
  {
    private static int _LzmaDictionarySize = 4194304;
    private CompressionMethod _CompressionMethod = CompressionMethod.Default;
    private bool _CompressingFilesOnDisk;
    private OutArchiveFormat _ArchiveFormat;
    private int _VolumeSize;
    private string _ArchiveName;
    private bool _DirectoryCompress;
    private UpdateData _UpdateData;
    private uint _OldFilesCount;

    public CompressionLevel CompressionLevel { get; set; }

    public Dictionary<string, string> CustomParameters { get; private set; }

    public bool IncludeEmptyDirectories { get; set; }

    public bool PreserveDirectoryRoot { get; set; }

    public bool DirectoryStructure { get; set; }

    public CompressionMode CompressionMode { get; set; }

    public bool EncryptHeaders { get; set; }

    public bool ScanOnlyWritable { get; set; }

    public ZipEncryptionMethod ZipEncryptionMethod { get; set; }

    public string TempFolderPath { get; set; }

    public static void SetLibraryPath(string libraryPath)
    {
      SevenZipLibraryManager.SetLibraryPath(libraryPath);
    }

    public SevenZipCompressor()
    {
      this.DirectoryStructure = true;
      this.TempFolderPath = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User) + "\\";
      this.CompressionLevel = CompressionLevel.Normal;
      this.CompressionMode = CompressionMode.Create;
      this.ZipEncryptionMethod = ZipEncryptionMethod.ZipCrypto;
      this.CustomParameters = new Dictionary<string, string>();
      this._UpdateData = new UpdateData();
    }

    private static void ValidateStream(Stream stream)
    {
      if (!stream.CanWrite || !stream.CanSeek)
        throw new ArgumentException("The specified stream can not seek or is not writable.", nameof (stream));
    }

    private IOutArchive MakeOutArchive(IInStream inArchiveStream)
    {
      IInArchive inArchive = SevenZipLibraryManager.InArchive(Formats.InForOutFormats[this._ArchiveFormat], (object) this);
      using (ArchiveOpenCallback archiveOpenCallback = this.GetArchiveOpenCallback())
      {
        ulong maxCheckStartPosition = 32768;
        if (inArchive.Open(inArchiveStream, ref maxCheckStartPosition, (IArchiveOpenCallback) archiveOpenCallback) != 0)
        {
          if (!this.ThrowException((SevenZipBase) null, (Exception) new SevenZipArchiveException("Can not update the archive: Open() failed.")))
            return (IOutArchive) null;
        }
        this._OldFilesCount = inArchive.GetNumberOfItems();
      }
      return (IOutArchive) inArchive;
    }

    private bool MethodIsValid(CompressionMethod method)
    {
      if (method == CompressionMethod.Default)
        return true;
      switch (this._ArchiveFormat)
      {
        case OutArchiveFormat.SevenZip:
          if (method != CompressionMethod.Deflate)
            return method != CompressionMethod.Deflate64;
          return false;
        case OutArchiveFormat.Zip:
          return method != CompressionMethod.Ppmd;
        case OutArchiveFormat.GZip:
          return method == CompressionMethod.Deflate;
        case OutArchiveFormat.BZip2:
          return method == CompressionMethod.BZip2;
        case OutArchiveFormat.Tar:
          return method == CompressionMethod.Copy;
        default:
          return true;
      }
    }

    private bool SwitchIsInCustomParameters(string name)
    {
      return this.CustomParameters.ContainsKey(name);
    }

    private void SetCompressionProperties()
    {
      if (this._ArchiveFormat == OutArchiveFormat.Tar)
        return;
      ISetProperties setProperties = this.CompressionMode != CompressionMode.Create || this._UpdateData.FileNamesToModify != null ? (ISetProperties) SevenZipLibraryManager.InArchive(Formats.InForOutFormats[this._ArchiveFormat], (object) this) : (ISetProperties) SevenZipLibraryManager.OutArchive(this._ArchiveFormat, (object) this);
      if (setProperties == null)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new CompressionFailedException("The specified archive format is unsupported.")))
          return;
      }
      if (this.CustomParameters.ContainsKey("x") || this.CustomParameters.ContainsKey("m"))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new CompressionFailedException("The specified compression parameters are invalid.")))
          return;
      }
      List<IntPtr> numList = new List<IntPtr>(2 + this.CustomParameters.Count);
      List<PropVariant> propVariantList = new List<PropVariant>(2 + this.CustomParameters.Count);
      new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
      if (this._CompressionMethod == CompressionMethod.Default)
      {
        numList.Add(Marshal.StringToBSTR("x"));
        propVariantList.Add(new PropVariant());
        foreach (string key in this.CustomParameters.Keys)
        {
          numList.Add(Marshal.StringToBSTR(key));
          PropVariant propVariant = new PropVariant();
          if (key == "fb" || key == "pass" || key == "d")
          {
            propVariant.VarType = VarEnum.VT_UI4;
            propVariant.UInt32Value = Convert.ToUInt32(this.CustomParameters[key], (IFormatProvider) CultureInfo.InvariantCulture);
          }
          else
          {
            propVariant.VarType = VarEnum.VT_BSTR;
            propVariant.Value = Marshal.StringToBSTR(this.CustomParameters[key]);
          }
          propVariantList.Add(propVariant);
        }
      }
      else
      {
        numList.Add(Marshal.StringToBSTR("x"));
        numList.Add(this._ArchiveFormat == OutArchiveFormat.Zip ? Marshal.StringToBSTR("m") : Marshal.StringToBSTR("0"));
        propVariantList.Add(new PropVariant());
        PropVariant propVariant1 = new PropVariant() { VarType = VarEnum.VT_BSTR, Value = Marshal.StringToBSTR(Formats.MethodNames[this._CompressionMethod]) };
        propVariantList.Add(propVariant1);
        foreach (string key in this.CustomParameters.Keys)
        {
          numList.Add(Marshal.StringToBSTR(key));
          PropVariant propVariant2 = new PropVariant();
          if (key == "fb" || key == "pass" || key == "d")
          {
            propVariant2.VarType = VarEnum.VT_UI4;
            propVariant2.UInt32Value = Convert.ToUInt32(this.CustomParameters[key], (IFormatProvider) CultureInfo.InvariantCulture);
          }
          else
          {
            propVariant2.VarType = VarEnum.VT_BSTR;
            propVariant2.Value = Marshal.StringToBSTR(this.CustomParameters[key]);
          }
          propVariantList.Add(propVariant2);
        }
      }
      PropVariant propVariant3 = propVariantList[0];
      propVariant3.VarType = VarEnum.VT_UI4;
      switch (this.CompressionLevel)
      {
        case CompressionLevel.None:
          propVariant3.UInt32Value = 0U;
          break;
        case CompressionLevel.Fast:
          propVariant3.UInt32Value = 1U;
          break;
        case CompressionLevel.Low:
          propVariant3.UInt32Value = 3U;
          break;
        case CompressionLevel.Normal:
          propVariant3.UInt32Value = 5U;
          break;
        case CompressionLevel.High:
          propVariant3.UInt32Value = 7U;
          break;
        case CompressionLevel.Ultra:
          propVariant3.UInt32Value = 9U;
          break;
      }
      propVariantList[0] = propVariant3;
      if (this.EncryptHeaders && this._ArchiveFormat == OutArchiveFormat.SevenZip && !this.SwitchIsInCustomParameters("he"))
      {
        numList.Add(Marshal.StringToBSTR("he"));
        PropVariant propVariant1 = new PropVariant() { VarType = VarEnum.VT_BSTR, Value = Marshal.StringToBSTR("on") };
        propVariantList.Add(propVariant1);
      }
      if (this._ArchiveFormat == OutArchiveFormat.Zip && this.ZipEncryptionMethod != ZipEncryptionMethod.ZipCrypto && !this.SwitchIsInCustomParameters("em"))
      {
        numList.Add(Marshal.StringToBSTR("em"));
        PropVariant propVariant1 = new PropVariant() { VarType = VarEnum.VT_BSTR, Value = Marshal.StringToBSTR(Enum.GetName(typeof (ZipEncryptionMethod), (object) this.ZipEncryptionMethod)) };
        propVariantList.Add(propVariant1);
      }
      GCHandle gcHandle1 = GCHandle.Alloc((object) numList.ToArray(), GCHandleType.Pinned);
      GCHandle gcHandle2 = GCHandle.Alloc((object) propVariantList.ToArray(), GCHandleType.Pinned);
      try
      {
        setProperties?.SetProperties(gcHandle1.AddrOfPinnedObject(), gcHandle2.AddrOfPinnedObject(), numList.Count);
      }
      finally
      {
        gcHandle1.Free();
        gcHandle2.Free();
      }
    }

    private static int CommonRoot(ICollection<string> files)
    {
      List<string[]> strArrayList = new List<string[]>(files.Count);
      foreach (string file in (IEnumerable<string>) files)
        strArrayList.Add(file.Split(Path.DirectorySeparatorChar));
      int num = strArrayList[0].Length - 1;
      if (files.Count > 1)
      {
        for (int index = 1; index < files.Count; ++index)
        {
          if (num > strArrayList[index].Length)
            num = strArrayList[index].Length;
        }
      }
      string str = "";
      for (int index1 = 0; index1 < num; ++index1)
      {
        bool flag = true;
        int index2 = 1;
        while (index2 < files.Count && (flag &= strArrayList[index2 - 1][index1] == strArrayList[index2][index1]))
          ++index2;
        if (flag)
          str = str + strArrayList[0][index1] + (object) Path.DirectorySeparatorChar;
        else
          break;
      }
      return str.Length;
    }

    private static void CheckCommonRoot(string[] files, ref int commonRootLength)
    {
      string str;
      try
      {
        str = files[0].Substring(0, commonRootLength);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        throw new SevenZipInvalidFileNamesException("invalid common root.");
      }
      if (str.EndsWith(new string(Path.DirectorySeparatorChar, 1), StringComparison.CurrentCulture))
      {
        str = str.Substring(0, commonRootLength - 1);
        --commonRootLength;
      }
      foreach (string file in files)
      {
        if (!file.StartsWith(str, StringComparison.CurrentCulture))
          throw new SevenZipInvalidFileNamesException("invalid common root.");
      }
    }

    private static bool RecursiveDirectoryEmptyCheck(string directory)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(directory);
      if (directoryInfo.GetFiles().Length > 0)
        return false;
      bool flag = true;
      foreach (DirectoryInfo directory1 in directoryInfo.GetDirectories())
      {
        flag &= SevenZipCompressor.RecursiveDirectoryEmptyCheck(directory1.FullName);
        if (!flag)
          return false;
      }
      return true;
    }

    private static FileInfo[] ProduceFileInfoArray(string[] files, int commonRootLength, bool directoryCompress, bool directoryStructure)
    {
      List<FileInfo> fileInfoList = new List<FileInfo>(files.Length);
      string str = files[0].Substring(0, commonRootLength);
      if (directoryCompress)
      {
        foreach (string file in files)
          fileInfoList.Add(new FileInfo(file));
      }
      else if (!directoryStructure)
      {
        foreach (string file in files)
        {
          if (!Directory.Exists(file))
            fileInfoList.Add(new FileInfo(file));
        }
      }
      else
      {
        List<string> stringList = new List<string>(files.Length);
        SevenZipCompressor.CheckCommonRoot(files, ref commonRootLength);
        if (commonRootLength > 0)
        {
          ++commonRootLength;
          foreach (string file in files)
          {
            string[] strArray = file.Substring(commonRootLength).Split(Path.DirectorySeparatorChar);
            string fileName = str;
            for (int index = 0; index < strArray.Length; ++index)
            {
              fileName = fileName + (object) Path.DirectorySeparatorChar + strArray[index];
              if (!stringList.Contains(fileName))
              {
                fileInfoList.Add(new FileInfo(fileName));
                stringList.Add(fileName);
              }
            }
          }
        }
        else
        {
          foreach (string file in files)
          {
            string[] strArray = file.Substring(commonRootLength).Split(Path.DirectorySeparatorChar);
            string fileName = strArray[0];
            for (int index = 1; index < strArray.Length; ++index)
            {
              fileName = fileName + (object) Path.DirectorySeparatorChar + strArray[index];
              if (!stringList.Contains(fileName))
              {
                fileInfoList.Add(new FileInfo(fileName));
                stringList.Add(fileName);
              }
            }
          }
        }
      }
      return fileInfoList.ToArray();
    }

    private void AddFilesFromDirectory(string directory, ICollection<string> files, string searchPattern)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(directory);
      foreach (FileInfo file in directoryInfo.GetFiles(searchPattern))
      {
        if (!this.ScanOnlyWritable)
        {
          files.Add(file.FullName);
        }
        else
        {
          try
          {
            using (file.OpenWrite())
              ;
            files.Add(file.FullName);
          }
          catch (IOException ex)
          {
          }
        }
      }
      foreach (DirectoryInfo directory1 in directoryInfo.GetDirectories())
      {
        if (this.IncludeEmptyDirectories)
          files.Add(directory1.FullName);
        this.AddFilesFromDirectory(directory1.FullName, files, searchPattern);
      }
    }

    private ArchiveUpdateCallback GetArchiveUpdateCallback(FileInfo[] files, int rootLength, string password)
    {
      this.SetCompressionProperties();
      ArchiveUpdateCallback archiveUpdateCallback = string.IsNullOrEmpty(password) ? new ArchiveUpdateCallback(files, rootLength, this, this.GetUpdateData(), this.DirectoryStructure) : new ArchiveUpdateCallback(files, rootLength, password, this, this.GetUpdateData(), this.DirectoryStructure);
      archiveUpdateCallback.FileCompressionStarted += this.FileCompressionStarted;
      archiveUpdateCallback.Compressing += this.Compressing;
      archiveUpdateCallback.FileCompressionFinished += this.FileCompressionFinished;
      return archiveUpdateCallback;
    }

    private ArchiveUpdateCallback GetArchiveUpdateCallback(Stream inStream, string password)
    {
      this.SetCompressionProperties();
      ArchiveUpdateCallback archiveUpdateCallback = string.IsNullOrEmpty(password) ? new ArchiveUpdateCallback(inStream, this, this.GetUpdateData(), this.DirectoryStructure) : new ArchiveUpdateCallback(inStream, password, this, this.GetUpdateData(), this.DirectoryStructure);
      archiveUpdateCallback.FileCompressionStarted += this.FileCompressionStarted;
      archiveUpdateCallback.Compressing += this.Compressing;
      archiveUpdateCallback.FileCompressionFinished += this.FileCompressionFinished;
      return archiveUpdateCallback;
    }

    private ArchiveUpdateCallback GetArchiveUpdateCallback(Dictionary<Stream, string> streamDict, string password)
    {
      this.SetCompressionProperties();
      ArchiveUpdateCallback archiveUpdateCallback = string.IsNullOrEmpty(password) ? new ArchiveUpdateCallback(streamDict, this, this.GetUpdateData(), this.DirectoryStructure) : new ArchiveUpdateCallback(streamDict, password, this, this.GetUpdateData(), this.DirectoryStructure);
      archiveUpdateCallback.FileCompressionStarted += this.FileCompressionStarted;
      archiveUpdateCallback.Compressing += this.Compressing;
      archiveUpdateCallback.FileCompressionFinished += this.FileCompressionFinished;
      return archiveUpdateCallback;
    }

    private void FreeCompressionCallback(ArchiveUpdateCallback callback)
    {
      callback.FileCompressionStarted -= this.FileCompressionStarted;
      callback.Compressing -= this.Compressing;
      callback.FileCompressionFinished -= this.FileCompressionFinished;
    }

    private string GetTempArchiveFileName(string archiveName)
    {
      return this.TempFolderPath + Path.GetFileName(archiveName) + ".~";
    }

    private FileStream GetArchiveFileStream(string archiveName)
    {
      if ((this.CompressionMode != CompressionMode.Create || this._UpdateData.FileNamesToModify != null) && !File.Exists(archiveName))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new CompressionFailedException("file \"" + archiveName + "\" does not exist.")))
          return (FileStream) null;
      }
      if (this._VolumeSize != 0)
        return (FileStream) null;
      if (this.CompressionMode != CompressionMode.Create || this._UpdateData.FileNamesToModify != null)
        return File.Create(this.GetTempArchiveFileName(archiveName));
      return File.Create(archiveName);
    }

    private void FinalizeUpdate()
    {
      if (this._VolumeSize != 0 || this.CompressionMode == CompressionMode.Create && this._UpdateData.FileNamesToModify == null)
        return;
      File.Move(this.GetTempArchiveFileName(this._ArchiveName), this._ArchiveName);
    }

    private UpdateData GetUpdateData()
    {
      if (this._UpdateData.FileNamesToModify != null)
        return this._UpdateData;
      UpdateData updateData = new UpdateData() { Mode = (InternalCompressionMode) this.CompressionMode };
      switch (this.CompressionMode)
      {
        case CompressionMode.Create:
          updateData.FilesCount = uint.MaxValue;
          break;
        case CompressionMode.Append:
          updateData.FilesCount = this._OldFilesCount;
          break;
      }
      return updateData;
    }

    private ISequentialOutStream GetOutStream(Stream outStream)
    {
      if (!this._CompressingFilesOnDisk)
        return (ISequentialOutStream) new OutStreamWrapper(outStream, false);
      if (this._VolumeSize == 0 || this.CompressionMode != CompressionMode.Create || this._UpdateData.FileNamesToModify != null)
        return (ISequentialOutStream) new OutStreamWrapper(outStream, true);
      return (ISequentialOutStream) new OutMultiStreamWrapper(this._ArchiveName, this._VolumeSize);
    }

    private IInStream GetInStream()
    {
      if (!File.Exists(this._ArchiveName) || (this.CompressionMode == CompressionMode.Create || !this._CompressingFilesOnDisk) && this._UpdateData.FileNamesToModify == null)
        return (IInStream) null;
      return (IInStream) new InStreamWrapper((Stream) new FileStream(this._ArchiveName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), true);
    }

    private ArchiveOpenCallback GetArchiveOpenCallback()
    {
      if (!string.IsNullOrEmpty(this.Password))
        return new ArchiveOpenCallback(this._ArchiveName, this.Password);
      return new ArchiveOpenCallback(this._ArchiveName);
    }

    public event EventHandler<FileNameEventArgs> FileCompressionStarted;

    public event EventHandler FileCompressionFinished;

    public event EventHandler<ProgressEventArgs> Compressing;

    public event EventHandler<IntEventArgs> FilesFound;

    public event EventHandler CompressionFinished;

    private void OnCompressionFinished(EventArgs e)
    {
      if (this.CompressionFinished == null)
        return;
      try
      {
        this.CompressionFinished((object) this, e);
      }
      catch (Exception ex)
      {
        this.AddException(ex);
      }
    }

    public OutArchiveFormat ArchiveFormat
    {
      get
      {
        return this._ArchiveFormat;
      }
      set
      {
        this._ArchiveFormat = value;
        if (this.MethodIsValid(this._CompressionMethod))
          return;
        this._CompressionMethod = CompressionMethod.Default;
      }
    }

    public CompressionMethod CompressionMethod
    {
      get
      {
        return this._CompressionMethod;
      }
      set
      {
        this._CompressionMethod = !this.MethodIsValid(value) ? CompressionMethod.Default : value;
      }
    }

    public int VolumeSize
    {
      get
      {
        return this._VolumeSize;
      }
      set
      {
        this._VolumeSize = value > 0 ? value : 0;
      }
    }

    public void CompressFiles(string archiveName, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveName, "", fileFullNames);
    }

    public void CompressFiles(Stream archiveStream, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveStream, "", fileFullNames);
    }

    public void CompressFiles(string archiveName, int commonRootLength, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveName, commonRootLength, "", fileFullNames);
    }

    public void CompressFiles(Stream archiveStream, int commonRootLength, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveStream, commonRootLength, "", fileFullNames);
    }

    public void CompressFilesEncrypted(string archiveName, string password, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveName, SevenZipCompressor.CommonRoot((ICollection<string>) fileFullNames), password, fileFullNames);
    }

    public void CompressFilesEncrypted(Stream archiveStream, string password, params string[] fileFullNames)
    {
      this.CompressFilesEncrypted(archiveStream, SevenZipCompressor.CommonRoot((ICollection<string>) fileFullNames), password, fileFullNames);
    }

    public void CompressFilesEncrypted(string archiveName, int commonRootLength, string password, params string[] fileFullNames)
    {
      this._CompressingFilesOnDisk = true;
      this._ArchiveName = archiveName;
      using (FileStream archiveFileStream = this.GetArchiveFileStream(archiveName))
      {
        if (archiveFileStream == null)
          return;
        this.CompressFilesEncrypted((Stream) archiveFileStream, commonRootLength, password, fileFullNames);
      }
      this.FinalizeUpdate();
    }

    public void CompressFilesEncrypted(Stream archiveStream, int commonRootLength, string password, params string[] fileFullNames)
    {
      this.ClearExceptions();
      if (fileFullNames.Length > 1 && (this._ArchiveFormat == OutArchiveFormat.BZip2 || this._ArchiveFormat == OutArchiveFormat.GZip))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new CompressionFailedException("Can not compress more than one file in this format.")))
          return;
      }
      if (this._VolumeSize == 0 || !this._CompressingFilesOnDisk)
        SevenZipCompressor.ValidateStream(archiveStream);
      FileInfo[] files = (FileInfo[]) null;
      try
      {
        files = SevenZipCompressor.ProduceFileInfoArray(fileFullNames, commonRootLength, this._DirectoryCompress, this.DirectoryStructure);
      }
      catch (Exception ex)
      {
        if (!this.ThrowException((SevenZipBase) null, ex))
          return;
      }
      this._DirectoryCompress = false;
      if (this.FilesFound != null)
        this.FilesFound((object) this, new IntEventArgs(fileFullNames.Length));
      try
      {
        ISequentialOutStream outStream;
        using ((outStream = this.GetOutStream(archiveStream)) as IDisposable)
        {
          IInStream inStream;
          using ((inStream = this.GetInStream()) as IDisposable)
          {
            IOutArchive outArchive;
            if (this.CompressionMode == CompressionMode.Create || !this._CompressingFilesOnDisk)
            {
              SevenZipLibraryManager.LoadLibrary((object) this, (Enum) this._ArchiveFormat);
              outArchive = SevenZipLibraryManager.OutArchive(this._ArchiveFormat, (object) this);
            }
            else
            {
              SevenZipLibraryManager.LoadLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
              if ((outArchive = this.MakeOutArchive(inStream)) == null)
                return;
            }
            using (ArchiveUpdateCallback archiveUpdateCallback = this.GetArchiveUpdateCallback(files, commonRootLength, password))
            {
              try
              {
                if (files != null)
                  this.CheckedExecute(outArchive.UpdateItems(outStream, (uint) files.Length + this._OldFilesCount, (IArchiveUpdateCallback) archiveUpdateCallback), "The compression has failed for an unknown reason with code ", (SevenZipBase) archiveUpdateCallback);
              }
              finally
              {
                this.FreeCompressionCallback(archiveUpdateCallback);
              }
            }
          }
        }
      }
      finally
      {
        if (this.CompressionMode == CompressionMode.Create || !this._CompressingFilesOnDisk)
        {
          SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._ArchiveFormat);
        }
        else
        {
          SevenZipLibraryManager.FreeLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
          File.Delete(this._ArchiveName);
        }
        this._CompressingFilesOnDisk = false;
        this.OnCompressionFinished(EventArgs.Empty);
      }
      this.ThrowUserException();
    }

    public void CompressDirectory(string directory, string archiveName)
    {
      this.CompressDirectory(directory, archiveName, "", "*.*", true);
    }

    public void CompressDirectory(string directory, Stream archiveStream)
    {
      this.CompressDirectory(directory, archiveStream, "", "*.*", true);
    }

    public void CompressDirectory(string directory, string archiveName, string password)
    {
      this.CompressDirectory(directory, archiveName, password, "*.*", true);
    }

    public void CompressDirectory(string directory, Stream archiveStream, string password)
    {
      this.CompressDirectory(directory, archiveStream, password, "*.*", true);
    }

    public void CompressDirectory(string directory, string archiveName, bool recursion)
    {
      this.CompressDirectory(directory, archiveName, "", "*.*", recursion);
    }

    public void CompressDirectory(string directory, Stream archiveStream, bool recursion)
    {
      this.CompressDirectory(directory, archiveStream, "", "*.*", recursion);
    }

    public void CompressDirectory(string directory, string archiveName, string searchPattern, bool recursion)
    {
      this.CompressDirectory(directory, archiveName, "", searchPattern, recursion);
    }

    public void CompressDirectory(string directory, Stream archiveStream, string searchPattern, bool recursion)
    {
      this.CompressDirectory(directory, archiveStream, "", searchPattern, recursion);
    }

    public void CompressDirectory(string directory, string archiveName, bool recursion, string password)
    {
      this.CompressDirectory(directory, archiveName, password, "*.*", recursion);
    }

    public void CompressDirectory(string directory, Stream archiveStream, bool recursion, string password)
    {
      this.CompressDirectory(directory, archiveStream, password, "*.*", recursion);
    }

    public void CompressDirectory(string directory, string archiveName, string password, string searchPattern, bool recursion)
    {
      this._CompressingFilesOnDisk = true;
      this._ArchiveName = archiveName;
      using (FileStream archiveFileStream = this.GetArchiveFileStream(archiveName))
      {
        if (archiveFileStream == null && this._VolumeSize == 0)
          return;
        this.CompressDirectory(directory, (Stream) archiveFileStream, password, searchPattern, recursion);
      }
      this.FinalizeUpdate();
    }

    public void CompressDirectory(string directory, Stream archiveStream, string password, string searchPattern, bool recursion)
    {
      List<string> stringList = new List<string>();
      if (!Directory.Exists(directory))
        throw new ArgumentException("Directory \"" + directory + "\" does not exist!");
      if (SevenZipCompressor.RecursiveDirectoryEmptyCheck(directory))
        throw new SevenZipInvalidFileNamesException("the specified directory is empty!");
      if (recursion)
      {
        this.AddFilesFromDirectory(directory, (ICollection<string>) stringList, searchPattern);
      }
      else
      {
        foreach (FileInfo file in new DirectoryInfo(directory).GetFiles(searchPattern))
          stringList.Add(file.FullName);
      }
      int commonRootLength = directory.Length;
      if (directory.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
        directory = directory.Substring(0, directory.Length - 1);
      else
        ++commonRootLength;
      if (this.PreserveDirectoryRoot)
      {
        string directoryName = Path.GetDirectoryName(directory);
        commonRootLength = directoryName.Length + (directoryName.EndsWith("\\") ? 0 : 1);
      }
      this._DirectoryCompress = true;
      this.CompressFilesEncrypted(archiveStream, commonRootLength, password, stringList.ToArray());
    }

    public void CompressFileDictionary(Dictionary<string, string> fileDictionary, string archiveName)
    {
      this.CompressFileDictionary(fileDictionary, archiveName, "");
    }

    public void CompressFileDictionary(Dictionary<string, string> fileDictionary, string archiveName, string password)
    {
      this._CompressingFilesOnDisk = true;
      this._ArchiveName = archiveName;
      using (FileStream archiveFileStream = this.GetArchiveFileStream(archiveName))
      {
        if (archiveFileStream == null)
          return;
        this.CompressFileDictionary(fileDictionary, (Stream) archiveFileStream, password);
      }
      this.FinalizeUpdate();
    }

    public void CompressFileDictionary(Dictionary<string, string> fileDictionary, Stream archiveStream)
    {
      this.CompressFileDictionary(fileDictionary, archiveStream, "");
    }

    public void CompressFileDictionary(Dictionary<string, string> fileDictionary, Stream archiveStream, string password)
    {
      Dictionary<Stream, string> streamDictionary = new Dictionary<Stream, string>(fileDictionary.Count);
      foreach (string key in fileDictionary.Keys)
        streamDictionary.Add((Stream) new FileStream(key, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), fileDictionary[key]);
      this.CompressStreamDictionary(streamDictionary, archiveStream, password);
    }

    public void CompressStreamDictionary(Dictionary<Stream, string> streamDictionary, string archiveName)
    {
      this.CompressStreamDictionary(streamDictionary, archiveName, "");
    }

    public void CompressStreamDictionary(Dictionary<Stream, string> streamDictionary, string archiveName, string password)
    {
      this._CompressingFilesOnDisk = true;
      this._ArchiveName = archiveName;
      using (FileStream archiveFileStream = this.GetArchiveFileStream(archiveName))
      {
        if (archiveFileStream == null)
          return;
        this.CompressStreamDictionary(streamDictionary, (Stream) archiveFileStream, password);
      }
      this.FinalizeUpdate();
    }

    public void CompressStreamDictionary(Dictionary<Stream, string> streamDictionary, Stream archiveStream)
    {
      this.CompressStreamDictionary(streamDictionary, archiveStream, "");
    }

    public void CompressStreamDictionary(Dictionary<Stream, string> streamDictionary, Stream archiveStream, string password)
    {
      this.ClearExceptions();
      if (streamDictionary.Count > 1 && (this._ArchiveFormat == OutArchiveFormat.BZip2 || this._ArchiveFormat == OutArchiveFormat.GZip))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new CompressionFailedException("Can not compress more than one file in this format.")))
          return;
      }
      if (this._VolumeSize == 0 || !this._CompressingFilesOnDisk)
        SevenZipCompressor.ValidateStream(archiveStream);
      foreach (Stream key in streamDictionary.Keys)
      {
        if (key == null || !key.CanSeek || !key.CanRead)
        {
          if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The specified stream dictionary contains invalid streams.", nameof (streamDictionary))))
            return;
        }
      }
      try
      {
        ISequentialOutStream outStream;
        using ((outStream = this.GetOutStream(archiveStream)) as IDisposable)
        {
          IInStream inStream;
          using ((inStream = this.GetInStream()) as IDisposable)
          {
            IOutArchive outArchive;
            if (this.CompressionMode == CompressionMode.Create || !this._CompressingFilesOnDisk)
            {
              SevenZipLibraryManager.LoadLibrary((object) this, (Enum) this._ArchiveFormat);
              outArchive = SevenZipLibraryManager.OutArchive(this._ArchiveFormat, (object) this);
            }
            else
            {
              SevenZipLibraryManager.LoadLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
              if ((outArchive = this.MakeOutArchive(inStream)) == null)
                return;
            }
            using (ArchiveUpdateCallback archiveUpdateCallback = this.GetArchiveUpdateCallback(streamDictionary, password))
            {
              try
              {
                this.CheckedExecute(outArchive.UpdateItems(outStream, (uint) streamDictionary.Count, (IArchiveUpdateCallback) archiveUpdateCallback), "The compression has failed for an unknown reason with code ", (SevenZipBase) archiveUpdateCallback);
              }
              finally
              {
                this.FreeCompressionCallback(archiveUpdateCallback);
              }
            }
          }
        }
      }
      finally
      {
        if (this.CompressionMode == CompressionMode.Create || !this._CompressingFilesOnDisk)
        {
          SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._ArchiveFormat);
        }
        else
        {
          SevenZipLibraryManager.FreeLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
          File.Delete(this._ArchiveName);
        }
        this._CompressingFilesOnDisk = false;
        this.OnCompressionFinished(EventArgs.Empty);
      }
      this.ThrowUserException();
    }

    public void CompressStream(Stream inStream, Stream outStream)
    {
      this.CompressStream(inStream, outStream, "");
    }

    public void CompressStream(Stream inStream, Stream outStream, string password)
    {
      this.ClearExceptions();
      if (inStream.CanSeek && inStream.CanRead)
      {
        if (outStream.CanWrite)
          goto label_3;
      }
      if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The specified streams are invalid.")))
        return;
label_3:
      try
      {
        SevenZipLibraryManager.LoadLibrary((object) this, (Enum) this._ArchiveFormat);
        ISequentialOutStream outStream1;
        using ((outStream1 = this.GetOutStream(outStream)) as IDisposable)
        {
          using (ArchiveUpdateCallback archiveUpdateCallback = this.GetArchiveUpdateCallback(inStream, password))
          {
            try
            {
              this.CheckedExecute(SevenZipLibraryManager.OutArchive(this._ArchiveFormat, (object) this).UpdateItems(outStream1, 1U, (IArchiveUpdateCallback) archiveUpdateCallback), "The compression has failed for an unknown reason with code ", (SevenZipBase) archiveUpdateCallback);
            }
            finally
            {
              this.FreeCompressionCallback(archiveUpdateCallback);
            }
          }
        }
      }
      finally
      {
        SevenZipLibraryManager.FreeLibrary((object) this, (Enum) this._ArchiveFormat);
        this.OnCompressionFinished(EventArgs.Empty);
      }
      this.ThrowUserException();
    }

    public void ModifyArchive(string archiveName, Dictionary<int, string> newFileNames)
    {
      this.ModifyArchive(archiveName, newFileNames, "");
    }

    public void ModifyArchive(string archiveName, Dictionary<int, string> newFileNames, string password)
    {
      this.ClearExceptions();
      if (!SevenZipLibraryManager.ModifyCapable)
        throw new SevenZipLibraryException("The specified 7zip native library does not support this method.");
      if (!File.Exists(archiveName))
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("The specified archive does not exist.", nameof (archiveName))))
          return;
      }
      if (newFileNames != null)
      {
        if (newFileNames.Count != 0)
          goto label_8;
      }
      if (!this.ThrowException((SevenZipBase) null, (Exception) new ArgumentException("Invalid new file names.", nameof (newFileNames))))
        return;
label_8:
      try
      {
        using (SevenZipExtractor sevenZipExtractor = new SevenZipExtractor(archiveName))
        {
          this._UpdateData = new UpdateData();
          ArchiveFileInfo[] array = new ArchiveFileInfo[sevenZipExtractor.ArchiveFileData.Count];
          sevenZipExtractor.ArchiveFileData.CopyTo(array, 0);
          this._UpdateData.ArchiveFileData = new List<ArchiveFileInfo>((IEnumerable<ArchiveFileInfo>) array);
        }
        this._UpdateData.FileNamesToModify = newFileNames;
        this._UpdateData.Mode = InternalCompressionMode.Modify;
      }
      catch (SevenZipException ex)
      {
        if (!this.ThrowException((SevenZipBase) null, (Exception) ex))
          return;
      }
      try
      {
        this._CompressingFilesOnDisk = true;
        ISequentialOutStream outStream;
        using ((outStream = this.GetOutStream((Stream) this.GetArchiveFileStream(archiveName))) as IDisposable)
        {
          this._ArchiveName = archiveName;
          IInStream inStream;
          using ((inStream = this.GetInStream()) as IDisposable)
          {
            SevenZipLibraryManager.LoadLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
            IOutArchive outArchive;
            if ((outArchive = this.MakeOutArchive(inStream)) == null)
              return;
            using (ArchiveUpdateCallback archiveUpdateCallback = this.GetArchiveUpdateCallback((FileInfo[]) null, 0, password))
            {
              try
              {
                this.CheckedExecute(outArchive.UpdateItems(outStream, this._OldFilesCount, (IArchiveUpdateCallback) archiveUpdateCallback), "The compression has failed for an unknown reason with code ", (SevenZipBase) archiveUpdateCallback);
              }
              finally
              {
                this.FreeCompressionCallback(archiveUpdateCallback);
              }
            }
          }
        }
      }
      finally
      {
        SevenZipLibraryManager.FreeLibrary((object) this, (Enum) Formats.InForOutFormats[this._ArchiveFormat]);
        File.Delete(archiveName);
        this.FinalizeUpdate();
        this._CompressingFilesOnDisk = false;
        this._UpdateData.FileNamesToModify = (Dictionary<int, string>) null;
        this._UpdateData.ArchiveFileData = (List<ArchiveFileInfo>) null;
        this.OnCompressionFinished(EventArgs.Empty);
      }
      this.ThrowUserException();
    }

    public static int LzmaDictionarySize
    {
      get
      {
        return SevenZipCompressor._LzmaDictionarySize;
      }
      set
      {
        SevenZipCompressor._LzmaDictionarySize = value;
      }
    }

    internal static void WriteLzmaProperties(Encoder encoder)
    {
      CoderPropId[] propIDs = new CoderPropId[8]{ CoderPropId.DictionarySize, CoderPropId.PosStateBits, CoderPropId.LitContextBits, CoderPropId.LitPosBits, CoderPropId.Algorithm, CoderPropId.NumFastBytes, CoderPropId.MatchFinder, CoderPropId.EndMarker };
      object[] properties = new object[8]{ (object) SevenZipCompressor._LzmaDictionarySize, (object) 2, (object) 3, (object) 0, (object) 2, (object) 256, (object) "bt4", (object) false };
      encoder.SetCoderProperties(propIDs, properties);
    }

    public static void CompressStream(Stream inStream, Stream outStream, int? inLength, EventHandler<ProgressEventArgs> codeProgressEvent)
    {
      if (!inStream.CanRead || !outStream.CanWrite)
        throw new ArgumentException("The specified streams are invalid.");
      Encoder encoder = new Encoder();
      SevenZipCompressor.WriteLzmaProperties(encoder);
      encoder.WriteCoderProperties(outStream);
      long inSize = inLength.HasValue ? (long) inLength.Value : inStream.Length;
      for (int index = 0; index < 8; ++index)
        outStream.WriteByte((byte) (inSize >> 8 * index));
      encoder.Code(inStream, outStream, -1L, -1L, (ICodeProgress) new LzmaProgressCallback(inSize, codeProgressEvent));
    }

    public static byte[] CompressBytes(byte[] data)
    {
      using (MemoryStream memoryStream1 = new MemoryStream(data))
      {
        using (MemoryStream memoryStream2 = new MemoryStream())
        {
          Encoder encoder = new Encoder();
          SevenZipCompressor.WriteLzmaProperties(encoder);
          encoder.WriteCoderProperties((Stream) memoryStream2);
          long length = memoryStream1.Length;
          for (int index = 0; index < 8; ++index)
            memoryStream2.WriteByte((byte) (length >> 8 * index));
          encoder.Code((Stream) memoryStream1, (Stream) memoryStream2, -1L, -1L, (ICodeProgress) null);
          return memoryStream2.ToArray();
        }
      }
    }
  }
}
