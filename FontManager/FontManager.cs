// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FontManager.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using Zeroit.Framework.Utilities.Properties;

namespace Zeroit.Framework.Utilities.FontLoader
{
    /// <summary>
    /// Roboto Font Manager
    /// </summary>
    public class RobotoFontManager
    {

        /// <summary>
        /// The roboto medium15
        /// </summary>
        public Font Roboto_Medium15;
        /// <summary>
        /// The roboto medium10
        /// </summary>
        public Font Roboto_Medium10;
        /// <summary>
        /// The roboto regular10
        /// </summary>
        public Font Roboto_Regular10;


        /// <summary>
        /// The roboto medium9
        /// </summary>
        public Font Roboto_Medium9;
        /// <summary>
        /// The roboto regular9
        /// </summary>
        public Font Roboto_Regular9;


        /// <summary>
        /// Initializes a new instance of the <see cref="RobotoFontManager"/> class.
        /// </summary>
        public RobotoFontManager()
        {
            Roboto_Medium15 = new Font(LoadFont(Resources.Roboto_Medium), 15f);
            Roboto_Medium10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
            Roboto_Regular10 = new Font(LoadFont(Resources.Roboto_Regular), 10f);

            Roboto_Medium9 = new Font(LoadFont(Resources.Roboto_Medium), 9f);
            Roboto_Regular9 = new Font(LoadFont(Resources.Roboto_Regular), 9f);
        }

        /// <summary>
        /// The private font collection
        /// </summary>
        private PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        /// <summary>
        /// Adds the font memory resource ex.
        /// </summary>
        /// <param name="pbFont">The pb font.</param>
        /// <param name="cbFont">The cb font.</param>
        /// <param name="pvd">The PVD.</param>
        /// <param name="pcFonts">The pc fonts.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        /// <summary>
        /// Load Font
        /// </summary>
        /// <param name="fontResource">Set font resource in byte</param>
        /// <returns>FontFamily.</returns>
        public FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }
        
    }

    /// <summary>
    /// A class collection for Font management
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        /// Get Font From Resources
        /// </summary>
        /// <param name="getFontFromProperties">Get font from properties</param>
        /// <param name="fontSize">Set Font Size</param>
        /// <returns>Font.</returns>
        public static Font GetFontFromResources(byte[] getFontFromProperties, int fontSize)
        {
            
            return new Font(LoadFont(getFontFromProperties), fontSize);
        }

        /// <summary>
        /// The private font collection
        /// </summary>
        private static PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        /// <summary>
        /// Adds the font memory resource ex.
        /// </summary>
        /// <param name="pbFont">The pb font.</param>
        /// <param name="cbFont">The cb font.</param>
        /// <param name="pvd">The PVD.</param>
        /// <param name="pcFonts">The pc fonts.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        /// <summary>
        /// Load Font
        /// </summary>
        /// <param name="fontResource">Set font from resource</param>
        /// <returns>FontFamily.</returns>
        public static FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }


        /// <summary>
        /// Loads the font.
        /// </summary>
        /// <param name="FontFromResources">The font from resources.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <returns>Font.</returns>
        public static Font LoadFont(byte[] FontFromResources, float FontSize)
        {
            return new Font(LoadFont(FontFromResources), FontSize);
        }

        /// <summary>
        /// Loads the font.
        /// </summary>
        /// <param name="FontFromResources">The font from resources.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="FontStyle">The font style.</param>
        /// <returns>Font.</returns>
        public static Font LoadFont(byte[] FontFromResources, float FontSize, FontStyle FontStyle)
        {
            return new Font(LoadFont(FontFromResources), FontSize, FontStyle);
        }
    }

    /// <summary>
    /// A class collection for specific font directives
    /// </summary>
    public static class FontDirectives
    {
        /// <summary>
        /// Segoe Font
        /// </summary>
        /// <param name="B">Set Font Style</param>
        /// <param name="S">Set Font Size</param>
        /// <returns>Font.</returns>
        public static Font SegoeFont(FontStyle B, int S)
        {
            return new Font("Segoe UI", S, B);
        }

        /// <summary>
        /// Global Font
        /// </summary>
        /// <param name="FontStyle">The font style.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="fontname">Set Font Name</param>
        /// <returns>Font.</returns>
        public static Font GlobalFont(FontStyle FontStyle, float FontSize, string fontname)
        {
            return new Font(fontname, FontSize, FontStyle);
        }

    }
}
