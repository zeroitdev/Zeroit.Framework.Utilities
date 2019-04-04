// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Column.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    
    /// <summary>
    /// Class for rendering column header.
    /// </summary>
    public static class Column
    {
        #region Color Blend
        /// <summary>
        /// Represent a color blend for a normal column.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <return>ColorBlend</return>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend NormalBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(255, 255, 255);
                colors[1] = Color.FromArgb(255, 255, 255);
                colors[2] = Color.FromArgb(246, 247, 249);
                colors[3] = Color.FromArgb(241, 242, 244);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for a selected column.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <return>ColorBlend</return>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend SelectedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(242, 249, 252);
                colors[1] = Color.FromArgb(242, 249, 252);
                colors[2] = Color.FromArgb(225, 241, 249);
                colors[3] = Color.FromArgb(216, 236, 246);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for a highlited column.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <return>ColorBlend</return>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend HLitedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(227, 247, 255);
                colors[1] = Color.FromArgb(227, 247, 255);
                colors[2] = Color.FromArgb(189, 237, 255);
                colors[3] = Color.FromArgb(183, 231, 251);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for a highlited column's dropdown.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <return>ColorBlend</return>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedDropDownBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend HLitedDropDownBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(228, 243, 251);
                colors[1] = Color.FromArgb(186, 224, 244);
                colors[2] = Color.FromArgb(152, 209, 239);
                colors[3] = Color.FromArgb(108, 180, 219);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend for a pressed column.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <return>ColorBlend</return>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PressedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend PressedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            ColorBlend blend = new ColorBlend();
            pos[0] = 0.0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(229, 244, 252);
                colors[1] = Color.FromArgb(196, 229, 246);
                colors[2] = Color.FromArgb(152, 209, 239);
                colors[3] = Color.FromArgb(104, 179, 219);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        #endregion

        #region Border Pen
        /// <summary>
        /// Represent a pen for a normal column border.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen NormalBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(213, 213, 213));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a pen for an active column border.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <returns>Pen</returns>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property ActiveBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen ActiveBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(147, 201, 227));
            }
            return Pens.Black;
        }

        #endregion

    }

}
