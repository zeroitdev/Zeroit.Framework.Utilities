// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="SevenZipSfx.cs" company="Zeroit Dev Technologies">
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Zeroit.Framework.Utilities.SevenZip
{
  public class SevenZipSfx
  {
    private static readonly Dictionary<SfxModule, List<string>> SfxSupportedModuleNames = new Dictionary<SfxModule, List<string>>(3) { { SfxModule.Default, new List<string>(1) { "7zxSD_All.sfx" } }, { SfxModule.Simple, new List<string>(2) { "7z.sfx", "7zCon.sfx" } }, { SfxModule.Installer, new List<string>(2) { "7zS.sfx", "7zSD.sfx" } }, { SfxModule.Extended, new List<string>(4) { "7zxSD_All.sfx", "7zxSD_Deflate", "7zxSD_LZMA", "7zxSD_PPMd" } } };
    private SfxModule _Module;
    private string _ModuleFileName;
    private Dictionary<SfxModule, List<string>> _SfxCommands;

    public SevenZipSfx()
    {
      this._Module = SfxModule.Default;
      this.CommonInit();
    }

    public SevenZipSfx(SfxModule module)
    {
      if (module == SfxModule.Custom)
        throw new ArgumentException("You must specify the custom module executable.", nameof (module));
      this._Module = module;
      this.CommonInit();
    }

    public SevenZipSfx(string moduleFileName)
    {
      this._Module = SfxModule.Custom;
      this.ModuleFileName = moduleFileName;
      this.CommonInit();
    }

    public SfxModule SfxModule
    {
      get
      {
        return this._Module;
      }
    }

    public string ModuleFileName
    {
      get
      {
        return this._ModuleFileName;
      }
      set
      {
        if (!File.Exists(value))
          throw new ArgumentException("The specified file does not exist.");
        this._ModuleFileName = value;
        this._Module = SfxModule.Custom;
        string fileName = Path.GetFileName(value);
        foreach (SfxModule key in SevenZipSfx.SfxSupportedModuleNames.Keys)
        {
          if (SevenZipSfx.SfxSupportedModuleNames[key].Contains(fileName))
            this._Module = key;
        }
      }
    }

    private void CommonInit()
    {
      this.LoadCommandsFromResource("Configs");
    }

    private static string GetResourceString(string str)
    {
      return "SevenZip.sfx." + str;
    }

    private static SfxModule GetModuleByName(string name)
    {
      if (name.IndexOf("7z.sfx", StringComparison.Ordinal) > -1)
        return SfxModule.Simple;
      if (name.IndexOf("7zS.sfx", StringComparison.Ordinal) > -1)
        return SfxModule.Installer;
      if (name.IndexOf("7zxSD_All.sfx", StringComparison.Ordinal) > -1)
        return SfxModule.Extended;
      throw new SevenZipSfxValidationException("The specified configuration is unsupported.");
    }

    private void LoadCommandsFromResource(string xmlDefinitions)
    {
      using (Stream manifestResourceStream1 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SevenZipSfx.GetResourceString(xmlDefinitions + ".xml")))
      {
        if (manifestResourceStream1 == null)
          throw new SevenZipSfxValidationException("The configuration \"" + xmlDefinitions + "\" does not exist.");
        using (Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SevenZipSfx.GetResourceString(xmlDefinitions + ".xsd")))
        {
          if (manifestResourceStream2 == null)
            throw new SevenZipSfxValidationException("The configuration schema \"" + xmlDefinitions + "\" does not exist.");
          XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
          using (XmlReader schemaDocument = XmlReader.Create(manifestResourceStream2))
          {
            xmlSchemaSet.Add((string) null, schemaDocument);
            XmlReaderSettings settings = new XmlReaderSettings() { ValidationType = ValidationType.Schema, Schemas = xmlSchemaSet };
            string validationErrors = "";
            // ISSUE: reference to a compiler-generated field
            settings.ValidationEventHandler += (ValidationEventHandler) ((s, t) => validationErrors += string.Format((IFormatProvider) CultureInfo.InvariantCulture, "[{0}]: {1}\n", new object[2]
            {
              (object) t.Severity.ToString(),
              (object) t.Message
            }));
            using (XmlReader xmlReader = XmlReader.Create(manifestResourceStream1, settings))
            {
              this._SfxCommands = new Dictionary<SfxModule, List<string>>();
              xmlReader.Read();
              xmlReader.Read();
              xmlReader.Read();
              xmlReader.Read();
              xmlReader.Read();
              xmlReader.ReadStartElement("sfxConfigs");
              xmlReader.Read();
              do
              {
                SfxModule moduleByName = SevenZipSfx.GetModuleByName(xmlReader["modules"]);
                xmlReader.ReadStartElement("config");
                xmlReader.Read();
                if (xmlReader.Name == "id")
                {
                  List<string> stringList = new List<string>();
                  this._SfxCommands.Add(moduleByName, stringList);
                  do
                  {
                    stringList.Add(xmlReader["command"]);
                    xmlReader.Read();
                    xmlReader.Read();
                  }
                  while (xmlReader.Name == "id");
                  xmlReader.ReadEndElement();
                  xmlReader.Read();
                }
                else
                  this._SfxCommands.Add(moduleByName, (List<string>) null);
              }
              while (xmlReader.Name == "config");
            }
            if (!string.IsNullOrEmpty(validationErrors))
              throw new SevenZipSfxValidationException("\n" + validationErrors.Substring(0, validationErrors.Length - 1));
            this._SfxCommands.Add(SfxModule.Default, this._SfxCommands[SfxModule.Extended]);
          }
        }
      }
    }

    private void ValidateSettings(Dictionary<string, string> settings)
    {
      if (this._Module == SfxModule.Custom)
        return;
      List<string> sfxCommand = this._SfxCommands[this._Module];
      if (sfxCommand == null)
        return;
      List<string> stringList = new List<string>();
      foreach (string key in settings.Keys)
      {
        if (!sfxCommand.Contains(key))
          stringList.Add(key);
      }
      if (stringList.Count > 0)
      {
        StringBuilder stringBuilder = new StringBuilder("\nInvalid commands:\n");
        foreach (string str in stringList)
          stringBuilder.Append(str);
        throw new SevenZipSfxValidationException(stringBuilder.ToString());
      }
    }

    private static Stream GetSettingsStream(Dictionary<string, string> settings)
    {
      MemoryStream memoryStream = new MemoryStream();
      byte[] bytes1 = Encoding.UTF8.GetBytes(";!@Install@!UTF-8!" + (object) '\n');
      memoryStream.Write(bytes1, 0, bytes1.Length);
      foreach (string key in settings.Keys)
      {
        byte[] bytes2 = Encoding.UTF8.GetBytes(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}=\"{1}\"\n", new object[2]{ (object) key, (object) settings[key] }));
        memoryStream.Write(bytes2, 0, bytes2.Length);
      }
      byte[] bytes3 = Encoding.UTF8.GetBytes(";!@InstallEnd@!");
      memoryStream.Write(bytes3, 0, bytes3.Length);
      return (Stream) memoryStream;
    }

    private Dictionary<string, string> GetDefaultSettings()
    {
      switch (this._Module)
      {
        case SfxModule.Default:
        case SfxModule.Extended:
          return new Dictionary<string, string>() { { "GUIMode", "0" }, { "InstallPath", "." }, { "GUIFlags", "128+8" }, { "ExtractPathTitle", "7-Zip self-extracting archive" }, { "ExtractPathText", "Specify the path where to extract the files:" } };
        case SfxModule.Installer:
          return new Dictionary<string, string>() { { "Title", "7-Zip self-extracting archive" } };
        default:
          return (Dictionary<string, string>) null;
      }
    }

    private static void WriteStream(Stream src, Stream dest)
    {
      src.Seek(0L, SeekOrigin.Begin);
      byte[] buffer = new byte[32768];
      int count;
      while ((count = src.Read(buffer, 0, buffer.Length)) > 0)
        dest.Write(buffer, 0, count);
    }

    public void MakeSfx(Stream archive, string sfxFileName)
    {
      using (Stream sfxStream = (Stream) File.Create(sfxFileName))
        this.MakeSfx(archive, this.GetDefaultSettings(), sfxStream);
    }

    public void MakeSfx(Stream archive, Stream sfxStream)
    {
      this.MakeSfx(archive, this.GetDefaultSettings(), sfxStream);
    }

    public void MakeSfx(Stream archive, Dictionary<string, string> settings, string sfxFileName)
    {
      using (Stream sfxStream = (Stream) File.Create(sfxFileName))
        this.MakeSfx(archive, settings, sfxStream);
    }

    public void MakeSfx(Stream archive, Dictionary<string, string> settings, Stream sfxStream)
    {
      if (!sfxStream.CanWrite)
        throw new ArgumentException("The specified output stream can not write.", nameof (sfxStream));
      this.ValidateSettings(settings);
      using (Stream src = this._Module == SfxModule.Default ? Assembly.GetExecutingAssembly().GetManifestResourceStream(SevenZipSfx.GetResourceString(SevenZipSfx.SfxSupportedModuleNames[this._Module][0])) : (Stream) new FileStream(this._ModuleFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        SevenZipSfx.WriteStream(src, sfxStream);
      if (this._Module == SfxModule.Custom || this._SfxCommands[this._Module] != null)
      {
        using (Stream settingsStream = SevenZipSfx.GetSettingsStream(settings))
          SevenZipSfx.WriteStream(settingsStream, sfxStream);
      }
      SevenZipSfx.WriteStream(archive, sfxStream);
    }

    public void MakeSfx(string archiveFileName, string sfxFileName)
    {
      using (Stream sfxStream = (Stream) File.Create(sfxFileName))
      {
        using (Stream archive = (Stream) new FileStream(archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
          this.MakeSfx(archive, this.GetDefaultSettings(), sfxStream);
      }
    }

    public void MakeSfx(string archiveFileName, Stream sfxStream)
    {
      using (Stream archive = (Stream) new FileStream(archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        this.MakeSfx(archive, this.GetDefaultSettings(), sfxStream);
    }

    public void MakeSfx(string archiveFileName, Dictionary<string, string> settings, string sfxFileName)
    {
      using (Stream sfxStream = (Stream) File.Create(sfxFileName))
      {
        using (Stream archive = (Stream) new FileStream(archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
          this.MakeSfx(archive, settings, sfxStream);
      }
    }

    public void MakeSfx(string archiveFileName, Dictionary<string, string> settings, Stream sfxStream)
    {
      using (Stream archive = (Stream) new FileStream(archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        this.MakeSfx(archive, settings, sfxStream);
    }
  }
}
