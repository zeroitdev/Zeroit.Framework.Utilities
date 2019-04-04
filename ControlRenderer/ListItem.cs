// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ListItem.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    
    /// <summary>
    /// Class for rendering list item.
    /// </summary>
    public static class ListItem
    {

        #region Color Blend
        /// <summary>
        /// Represent a color blend for selected item in a list that lost it focus input.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <returns>ColorBlend.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBlurBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend SelectedBlurBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[2];
            float[] pos = new float[2];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(248, 248, 248);
                colors[1] = Color.FromArgb(229, 229, 229);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for selected item in focused list.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <returns>ColorBlend.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend SelectedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[2];
            float[] pos = new float[2];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(239, 246, 252);
                colors[1] = Color.FromArgb(212, 239, 255);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for selected and highlighted item.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <returns>ColorBlend.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedHLiteBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend SelectedHLiteBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[2];
            float[] pos = new float[2];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(236, 245, 255);
                colors[1] = Color.FromArgb(208, 229, 255);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for highlighted item.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <returns>ColorBlend.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend HLitedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[2];
            float[] pos = new float[2];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(252, 253, 255);
                colors[1] = Color.FromArgb(237, 245, 255);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for pressed item.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <returns>ColorBlend.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PressedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend PressedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[2];
            float[] pos = new float[2];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(160, 189, 227);
                colors[1] = Color.FromArgb(255, 255, 255);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        
        #endregion

        #region Border Pen
        /// <summary>
        /// Represent a border pen for selected item in a list that lost it focus input.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBlurBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SelectedBlurBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(217, 217, 217));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen for selected item in a focused list.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SelectedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(177, 217, 229));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen for highlighted item in a list.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen HLitedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(185, 215, 252));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen for selected and highlighted item in a list.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedHLiteBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SelectedHLiteBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(132, 172, 221));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen for pressed item in a list.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen.</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PressedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen PressedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(104, 140, 175));
            }
            return Pens.Black;
        }
        #endregion

    }
}
