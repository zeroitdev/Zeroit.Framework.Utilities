// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-25-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ID3v1.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.IO;

namespace Zeroit.Framework.Utilities.Audio.Mp3
{
    /// <summary>
    /// Class ID3v1.
    /// </summary>
    public class ID3v1
    {
        /// <summary>
        /// The title
        /// </summary>
        public string Title;
        /// <summary>
        /// The artist
        /// </summary>
        public string Artist;
        /// <summary>
        /// The album
        /// </summary>
        public string Album;
        /// <summary>
        /// The year
        /// </summary>
        public string Year;
        /// <summary>
        /// The comment
        /// </summary>
        public string Comment;
        /// <summary>
        /// The genre identifier
        /// </summary>
        public int GenreID;
        /// <summary>
        /// The track
        /// </summary>
        public int Track;

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName;
        /// <summary>
        /// The file has tag
        /// </summary>
        public bool FileHasTag;
        /// <summary>
        /// The trim chars
        /// </summary>
        protected static char[] TrimChars = new char[] { '\0', ' ' };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            Title = "";
            Artist = "";
            Album = "";
            Year = "";
            Comment = "";

            GenreID = 0;
            Track = 0;

            FileName = "";
            FileHasTag = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ID3v1"/> class.
        /// </summary>
        public ID3v1()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ID3v1"/> class.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        public ID3v1(string FileName)
        {
            Initialize();
            this.FileName = FileName;
        }
        /// <summary>
        /// Trims the data.
        /// </summary>
        public void TrimData()
        {
            Title = Title.Trim();
            Artist = Artist.Trim();
            Album = Album.Trim();
            Year = Year.Trim();
            Comment = Comment.Trim();
        }

        /// <summary>
        /// Prepares for save.
        /// </summary>
        public void PrepareForSave()
        {
            TrimData();
            if (Title.Length > 30) 
                Title = Title.Substring(0, 30);
            if (Artist.Length > 30) 
                Artist = Artist.Substring(0, 30);
            if (Album.Length > 30) 
                Album = Album.Substring(0, 30);
            if (Year.Length > 4) 
                Year = Year.Substring(0, 4);
            if (Comment.Length > 28) 
                Comment = Comment.Substring(0, 28);
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>ID3v1.</returns>
        public static ID3v1 LoadFromFile(string FileName)
        {
			byte[] Buffer = new byte[128];
		    FileStream xStream;
            try
            {
                xStream = new FileStream(FileName, FileMode.Open);
                xStream.Seek(-128, SeekOrigin.End);
                xStream.Read(Buffer, 0, 128);
                xStream.Close();
            }
            catch (FileNotFoundException EX)
            {
                return null;
            }
  
			// Convert the Byte Array to a String
//			Encoding  xASCII = new ASCIIEncoding();   // NB: Encoding is an Abstract class
            Encoding xASCII = Encoding.Default;
            string ID3TagString = xASCII.GetString(Buffer);
  
			// If there is an attched ID3 v1.x TAG then read it 
			if (ID3TagString .Substring(0,3) == "TAG") 
			{
                ID3v1 xInfo=new ID3v1();
                xInfo.FileName = FileName;
                xInfo.Title=ID3TagString.Substring(  3, 30).Trim(ID3v1.TrimChars);
                xInfo.Artist = ID3TagString.Substring(33, 30).Trim(ID3v1.TrimChars);
                xInfo.Album = ID3TagString.Substring(63, 30).Trim(ID3v1.TrimChars);
                xInfo.Year = ID3TagString.Substring(93, 4).Trim(ID3v1.TrimChars);
                xInfo.Comment = ID3TagString.Substring(97, 28).Trim(ID3v1.TrimChars);
  
				// Get the track number if TAG conforms to ID3 v1.1
				if (ID3TagString[125]==0)
					xInfo.Track = Buffer[126];
				else
					xInfo.Track = 0;
				xInfo.GenreID = Buffer[127];
                xInfo.FileHasTag = true;
                return xInfo;
			}
            return null;
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="xInfo">The x information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SaveToFile(string FileName, ID3v1 xInfo)
        {
            ID3v1 xTemp = ID3v1.LoadFromFile(FileName);
            xInfo.FileName=FileName;
            if (xTemp == null)
                xInfo.FileHasTag = false;
            else
                xInfo.FileHasTag = true;
            return xInfo.UpdateFile();

        }
        /// <summary>
        /// Updates the file.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateFile()
        {
            PrepareForSave();

            byte[] Buffer = new byte[128];
            for (int i = 0; i < Buffer.Length; i++) 
                Buffer[i] = Convert.ToByte(0);

            Encoding xASCII = Encoding.Default;// new ASCIIEncoding();   
            // Copy "TAG" to Array
            byte[] xArray = xASCII.GetBytes("TAG");
            Array.Copy(xArray, 0, Buffer, 0, xArray.Length);
            xArray = xASCII.GetBytes(Title);
            Array.Copy(xArray, 0, Buffer, 3, xArray.Length);
            xArray = xASCII.GetBytes(Artist);
            Array.Copy(xArray, 0, Buffer, 33, xArray.Length);
            xArray = xASCII.GetBytes(Album);
            Array.Copy(xArray, 0, Buffer, 63, xArray.Length);
            xArray = xASCII.GetBytes(Year);
            Array.Copy(xArray, 0, Buffer, 93, xArray.Length);
            xArray = xASCII.GetBytes(Comment);
            Array.Copy(xArray, 0, Buffer, 97, xArray.Length);
            if(Track!=0)
                Buffer[126] = System.Convert.ToByte(Track);
            else
                Buffer[125] = System.Convert.ToByte(1);

            Buffer[127] = System.Convert.ToByte(GenreID);

            FileStream xStream = new FileStream(FileName, FileMode.OpenOrCreate);
            if (FileHasTag)
                xStream.Seek(-128, SeekOrigin.End);
            else
                xStream.Seek(0, SeekOrigin.End);
            xStream.Write(Buffer, 0, 128);
            xStream.Close();
            return true;
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            string Temp = "";
            Temp+="Title: "+Title+Environment.NewLine;
            Temp+="Artist: "+Artist+Environment.NewLine;
            Temp+="Album: "+Album+Environment.NewLine;
            Temp+="Year: "+Year+Environment.NewLine;
            Temp+="Comment: "+Comment+Environment.NewLine;
            Temp+="GenreID: "+GenreID+Environment.NewLine;
            Temp+="Track: "+Track+Environment.NewLine;
            return Temp;
        }
    }
}
