// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    
    /// <summary>
    /// Class for rendering button and menu item, just a little part that have supports for BlackBlue color theme.
    /// </summary>
    public static class Button
    {
        #region Enumeration
        /// <summary>
        /// Enumeration to determine a split button location.
        /// </summary>
        /// <remarks><seealso cref="drawSplit"/></remarks>
        public enum SplitLocation
        {
            Top,
            Left,
            Right,
            Bottom
        }
        /// <summary>
        /// Enumeration to determine where(e.g. highlited, pressed) an effect occurs.
        /// </summary>
        /// <remarks><seealso cref="drawSplit"/></remarks>
        public enum SplitEffectLocation
        {
            None,
            Button,
            Split
        }
        #endregion

        #region Color Blend
        /// <summary>
        /// Represent a color blend on a disabled button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property DisabledBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend DisabledBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            ColorBlend aBlend = null;
            Color[] colors = new Color[4];
            float[] pos = new float[4];
            aBlend = new ColorBlend();
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                colors[0] = Color.FromArgb(244, 249, 251);
                colors[1] = Color.FromArgb(173, 211, 230);
                colors[2] = Color.FromArgb(145, 192, 217);
                colors[3] = Color.FromArgb(213, 236, 247);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(102, 115, 124);
                colors[1] = Color.FromArgb(76, 88, 104);
                colors[2] = Color.FromArgb(51, 65, 81);
                colors[3] = Color.FromArgb(35, 42, 61);
            }
            pos[0] = 0F;
            pos[1] = 0.4F;
            pos[2] = 0.4F;
            pos[3] = 1.0F;
            aBlend.Colors = colors;
            aBlend.Positions = pos;
            return aBlend;
        }
        /// <summary>
        /// Represent a color blend on a normal button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
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
                colors[0] = Color.FromArgb(217, 240, 251);
                colors[1] = Color.FromArgb(159, 212, 240);
                colors[2] = Color.FromArgb(126, 188, 224);
                colors[3] = Color.FromArgb(189, 233, 254);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(216, 216, 216);
                colors[1] = Color.FromArgb(75, 77, 76);
                colors[2] = Color.FromArgb(1, 3, 2);
                colors[3] = Color.FromArgb(0, 0, 0);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a focused button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property FocusedBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend FocusedBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
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
                colors[0] = Color.FromArgb(220, 252, 255);
                colors[1] = Color.FromArgb(124, 194, 236);
                colors[2] = Color.FromArgb(91, 172, 220);
                colors[3] = Color.FromArgb(190, 247, 255);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(11, 146, 255);
                colors[1] = Color.FromArgb(75, 77, 76);
                colors[2] = Color.FromArgb(1, 3, 2);
                colors[3] = Color.FromArgb(0, 0, 0);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a highlited (mouse hover) button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
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
                colors[0] = Color.FromArgb(255, 253, 232);
                colors[1] = Color.FromArgb(255, 235, 159);
                colors[2] = Color.FromArgb(255, 213, 67);
                colors[3] = Color.FromArgb(255, 222, 90);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(116, 193, 255);
                colors[1] = Color.FromArgb(0, 46, 92);
                colors[2] = Color.FromArgb(1, 2, 7);
                colors[3] = Color.FromArgb(0, 0, 0);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a highlited button, but mouse didn't hover on the button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedLightBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend HLitedLightBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
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
                colors[0] = Color.FromArgb(255, 254, 246);
                colors[1] = Color.FromArgb(255, 248, 221);
                colors[2] = Color.FromArgb(255, 241, 186);
                colors[3] = Color.FromArgb(255, 243, 197);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(116, 193, 255);
                colors[1] = Color.FromArgb(64, 110, 156);
                colors[2] = Color.FromArgb(65, 66, 71);
                colors[3] = Color.FromArgb(64, 64, 64);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a pressed button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
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
                colors[0] = Color.FromArgb(244, 179, 120);
                colors[1] = Color.FromArgb(253, 158, 67);
                colors[2] = Color.FromArgb(253, 132, 18);
                colors[3] = Color.FromArgb(254, 161, 80);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(60, 159, 212);
                colors[1] = Color.FromArgb(34, 89, 133);
                colors[2] = Color.FromArgb(17, 44, 82);
                colors[3] = Color.FromArgb(39, 108, 148);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a selected button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
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
                colors[0] = Color.FromArgb(244, 221, 199);
                colors[1] = Color.FromArgb(254, 200, 146);
                colors[2] = Color.FromArgb(254, 161, 66);
                colors[3] = Color.FromArgb(253, 229, 136);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(77, 101, 152);
                colors[1] = Color.FromArgb(32, 77, 146);
                colors[2] = Color.FromArgb(3, 58, 137);
                colors[3] = Color.FromArgb(5, 90, 176);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        /// <summary>
        /// Represent a color blend on a highlited selected button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>ColorBlend.</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedHLiteBlend(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As ColorBlend
        public static ColorBlend SelectedHLiteBlend(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
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
                colors[0] = Color.FromArgb(253, 187, 106);
                colors[1] = Color.FromArgb(252, 176, 89);
                colors[2] = Color.FromArgb(250, 160, 47);
                colors[3] = Color.FromArgb(252, 181, 17);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                colors[0] = Color.FromArgb(106, 148, 186);
                colors[1] = Color.FromArgb(33, 102, 144);
                colors[2] = Color.FromArgb(0, 81, 128);
                colors[3] = Color.FromArgb(4, 169, 235);
            }
            blend.Colors = colors;
            blend.Positions = pos;
            return blend;
        }
        #endregion

        #region Color Pen
        /// <summary>
        /// Represent a border pen on a normal button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen NormalBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(141, 173, 194));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new Pen(Color.FromArgb(0, 0, 0));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen on a disabled button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property DisabledBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen DisabledBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(161, 189, 207));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new Pen(Color.FromArgb(31, 31, 31));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen on a focused button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property FocusedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen FocusedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(121, 157, 182));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen on a highlited button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen HLitedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(219, 206, 153));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a border pen on a selected button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedBorderPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SelectedBorderPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(158, 130, 85));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a separator pen on a normal button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalSeparatorPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen NormalSeparatorPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(216, 194, 122));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new Pen(Color.FromArgb(0, 146, 198));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a separator pen on a highlited button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedSeparatorPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen HLitedSeparatorPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(205, 181, 131));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a separator pen on a selected button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedSeparatorPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SelectedSeparatorPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(176, 145, 96));
            }
            return Pens.Black;
        }
        /// <summary>
        /// Represent a separator pen on a pressed button.
        /// </summary>
        /// <param name="theme">Theme used to paint.</param>
        /// <value>Pen</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PressedSeparatorPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen PressedSeparatorPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new Pen(Color.FromArgb(168, 131, 86));
            }
            return Pens.Black;
        }
        #endregion

        #region Glowing Color
        /// <summary>
        /// Represent a glowing color on a normal button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color NormalGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(213, 236, 247);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(91, 95, 98);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a disabled button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property DisabledGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color DisabledGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(244, 249, 251);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(115, 124, 132);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a focused button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property FocusedGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color FocusedGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(189, 233, 254);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(60, 159, 180);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a highlited button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property HLitedGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color HLitedGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(255, 235, 173);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(3, 143, 196);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a pressed button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PressedGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color PressedGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(254, 160, 77);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(53, 156, 177);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a selected button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color SelectedGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(253, 241, 176);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(151, 240, 239);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        /// <summary>
        /// Represent a glowing color on a selected highlited button.
        /// </summary>
        /// <param name="theme">Them used to paint.</param>
        /// <value>Color</value>
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SelectedHLiteGlow(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Color
        public static Color SelectedHLiteGlow(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return Color.FromArgb(251, 179, 15);
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return Color.FromArgb(62, 187, 235);
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return new Color();
        }
        #endregion

        #region Drawing
        /// <summary>
        /// Draw a button on a Graphics object.
        /// </summary>
        /// <param name="g">Graphics object where the button to be drawn.</param>
        /// <param name="rect">Bounding rectangle of the button.</param>
        /// <param name="theme">Theme used to paint.</param>
        /// <param name="rounded">Rounded range of the corners of the rectangle.</param>
        /// <param name="enabled">Determine whether the button is enabled.</param>
        /// <param name="pressed">Determine whether the button is pressed.</param>
        /// <param name="selected">Determine whether the button is selected.</param>
        /// <param name="hlited">Determine whether the button is highlited.</param>
        /// <param name="focused">Determine whether the button has input focus.</param>
        public static void DrawButton(this System.Drawing.Graphics g, Rectangle rect, Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue, int rounded = 2, bool enabled = true, bool pressed = false, bool selected = false, bool hlited = false, bool focused = false)
        {
            if (g == null)
            {
                return;
            }
            if (rect.Width > 2 * rounded && rect.Width > 0 && rect.Height > 2 * rounded && rect.Height > 0)
            {
                GraphicsPath btnPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), rect, rounded, rounded, rounded, rounded);
                Pen borderPen = null;
                Color glowColor = new Color();
                GraphicsPath shadowPath = null;
                LinearGradientBrush bgBrush = new LinearGradientBrush(rect, Color.Black, Color.White, LinearGradientMode.Vertical);
                if (enabled)
                {
                    if (pressed)
                    {
                        bgBrush.InterpolationColors = PressedBlend(theme);
                        glowColor = PressedGlow(theme);
                        shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                    }
                    else
                    {
                        if (selected)
                        {
                            if (hlited)
                            {
                                bgBrush.InterpolationColors = SelectedHLiteBlend(theme);
                                glowColor = SelectedHLiteGlow(theme);
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                            }
                            else
                            {
                                bgBrush.InterpolationColors = SelectedBlend(theme);
                                glowColor = SelectedGlow(theme);
                                borderPen = SelectedBorderPen(theme);
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                            }
                        }
                        else
                        {
                            if (hlited)
                            {
                                bgBrush.InterpolationColors = HLitedBlend(theme);
                                glowColor = HLitedGlow(theme);
                                borderPen = HLitedBorderPen(theme);
                            }
                            else
                            {
                                if (focused)
                                {
                                    bgBrush.InterpolationColors = FocusedBlend(theme);
                                    glowColor = FocusedGlow(theme);
                                    borderPen = FocusedBorderPen(theme);
                                }
                                else
                                {
                                    bgBrush.InterpolationColors = NormalBlend(theme);
                                    glowColor = NormalGlow(theme);
                                    borderPen = NormalBorderPen(theme);
                                }
                            }
                        }
                    }
                }
                else
                {
                    bgBrush.InterpolationColors = DisabledBlend(theme);
                    glowColor = DisabledGlow(theme);
                    borderPen = DisabledBorderPen(theme);
                }
                GraphicsPath glowPath = null;
                if (rounded >= 0)
                {
                    glowPath = ControlRenderer.Drawing.GetGlowingPath(new GraphicsPath(), new Rectangle(rect.X + rounded, Convert.ToInt32(rect.Y + (0.4 * rect.Height)), rect.Width - (2 * rounded), Convert.ToInt32(0.6 * rect.Height)), ControlRenderer.Drawing.LightingGlowPoint.BottomCenter);
                }
                else
                {
                    glowPath = ControlRenderer.Drawing.GetGlowingPath(new GraphicsPath(), new Rectangle(rect.X, Convert.ToInt32(rect.Y + (0.4 * rect.Height)), rect.Width, Convert.ToInt32(0.6 * rect.Height)), ControlRenderer.Drawing.LightingGlowPoint.BottomCenter);
                }
                PathGradientBrush glowBrush = new PathGradientBrush(glowPath);
                Color[] sColors = new Color[2];
                sColors[0] = Color.Transparent;
                sColors[1] = Color.Transparent;
                glowBrush.CenterColor = glowColor;
                glowBrush.CenterPoint = new PointF(rect.X + (int)(rect.Width / 2.0), rect.Bottom - 2);
                glowBrush.SurroundColors = sColors;
                g.FillPath(bgBrush, btnPath);
                g.FillPath(glowBrush, glowPath);
                if (shadowPath != null)
                {
                    LinearGradientBrush shadowBrush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y, rect.Width, 5), Color.FromArgb(63, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical);
                    g.FillPath(shadowBrush, shadowPath);
                    shadowBrush.Dispose();
                    shadowPath.Dispose();
                }
                if (borderPen != null)
                {
                    g.DrawPath(borderPen, btnPath);
                    borderPen.Dispose();
                }
                glowBrush.Dispose();
                glowPath.Dispose();
                btnPath.Dispose();
                bgBrush.Dispose();
            }
        }
        /// <summary>
        /// Draw a split button on a Graphics object.
        /// </summary>
        /// <param name="g">Graphics object where the button to be drawn.</param>
        /// <param name="rect">Bounding rectangle of the button.</param>
        /// <param name="split">Split location of the split button.</param>
        /// <param name="splitSize">Size of the split.</param>
        /// <param name="theme">Theme used to paint.</param>
        /// <param name="rounded">Rounded range of the corners of the rectangle.</param>
        /// <param name="enabled">Determine whether the button is enabled.</param>
        /// <param name="pressed">Determine where the pressed state takes effect.</param>
        /// <param name="selected">Determine whether the button is selected.</param>
        /// <param name="hlited">Determine where the highlited state takes effect.</param>
        /// <param name="focused">Determine whether the button has input focus.</param>
        public static void DrawSplittButton(this System.Drawing.Graphics g, Rectangle rect, SplitLocation split, int splitSize, Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue, int rounded = 2, bool enabled = true, SplitEffectLocation pressed = SplitEffectLocation.None, bool selected = false, SplitEffectLocation hlited = SplitEffectLocation.None, bool focused = false)
        {
            if (g == null)
            {
                return;
            }
            if (rounded < 0)
            {
                rounded = 0;
            }
            switch (split)
            {
                case SplitLocation.Bottom:
                case SplitLocation.Top:
                    if (rect.Height <= splitSize + rounded)
                    {
                        return;
                    }
                    break;
                case SplitLocation.Left:
                case SplitLocation.Right:
                    if (rect.Width <= splitSize + rounded)
                    {
                        return;
                    }
                    break;
            }
            if (splitSize <= rounded)
            {
                return;
            }
            // Creating path
            Rectangle splitRect = new Rectangle();
            GraphicsPath btnPath = null;
            GraphicsPath splitPath = null;
            btnPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), rect, rounded, rounded, rounded, rounded);
            switch (split)
            {
                case SplitLocation.Top:
                    splitRect = new Rectangle(rect.X, rect.Y, rect.Width, splitSize);
                    splitPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), splitRect, rounded, rounded, 0, 0);
                    break;
                case SplitLocation.Left:
                    splitRect = new Rectangle(rect.X, rect.Y, splitSize, rect.Height);
                    splitPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), splitRect, rounded, 0, rounded, 0);
                    break;
                case SplitLocation.Right:
                    splitRect = new Rectangle(rect.Right - splitSize, rect.Y, splitSize, rect.Height);
                    splitPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), splitRect, 0, rounded, 0, rounded);
                    break;
                case SplitLocation.Bottom:
                    splitRect = new Rectangle(rect.X, rect.Bottom - splitSize, rect.Width, splitSize);
                    splitPath = ControlRenderer.Drawing.RoundedRectangle(new GraphicsPath(), splitRect, 0, 0, rounded, rounded);
                    break;
            }
            // Creating background brush
            LinearGradientBrush btnBrush = new LinearGradientBrush(rect, Color.Black, Color.White, LinearGradientMode.Vertical);
            LinearGradientBrush splitBrush = null;
            GraphicsPath shadowPath = null;
            Pen borderPen = null;
            Color glowColor = new Color();
            Pen separatorPen = null;
            if (enabled)
            {
                if (pressed != SplitEffectLocation.None)
                {
                    splitBrush = new LinearGradientBrush(rect, Color.Black, Color.White, LinearGradientMode.Vertical);
                    if (pressed == SplitEffectLocation.Button)
                    {
                        btnBrush.InterpolationColors = PressedBlend(theme);
                        splitBrush.InterpolationColors = HLitedLightBlend(theme);
                        shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                        glowColor = PressedGlow(theme);
                    }
                    else
                    {
                        btnBrush.InterpolationColors = HLitedLightBlend(theme);
                        splitBrush.InterpolationColors = PressedBlend(theme);
                        glowColor = PressedGlow(theme);
                        switch (split)
                        {
                            case SplitLocation.Top:
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), splitRect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded);
                                break;
                            case SplitLocation.Left:
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), splitRect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded);
                                break;
                            case SplitLocation.Right:
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), splitRect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded);
                                break;
                        }
                    }
                    separatorPen = PressedSeparatorPen(theme);
                }
                else
                {
                    if (selected)
                    {
                        if (hlited != SplitEffectLocation.None)
                        {
                            splitBrush = new LinearGradientBrush(rect, Color.Black, Color.White, LinearGradientMode.Vertical);
                            if (hlited == SplitEffectLocation.Button)
                            {
                                btnBrush.InterpolationColors = SelectedHLiteBlend(theme);
                                splitBrush.InterpolationColors = HLitedLightBlend(theme);
                                glowColor = SelectedHLiteGlow(theme);
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                            }
                            else
                            {
                                btnBrush.InterpolationColors = SelectedHLiteBlend(theme);
                                splitBrush.InterpolationColors = HLitedBlend(theme);
                                glowColor = SelectedHLiteGlow(theme);
                                shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                            }
                        }
                        else
                        {
                            btnBrush.InterpolationColors = SelectedBlend(theme);
                            glowColor = SelectedGlow(theme);
                            shadowPath = ControlRenderer.Drawing.GetInnerShadowPath(new GraphicsPath(), rect, ControlRenderer.Drawing.ShadowPoint.Top, 4, 4, rounded, rounded, rounded, rounded);
                        }
                        separatorPen = SelectedSeparatorPen(theme);
                    }
                    else
                    {
                        if (hlited != SplitEffectLocation.None)
                        {
                            splitBrush = new LinearGradientBrush(rect, Color.Black, Color.White, LinearGradientMode.Vertical);
                            if (hlited == SplitEffectLocation.Button)
                            {
                                btnBrush.InterpolationColors = HLitedBlend(theme);
                                splitBrush.InterpolationColors = HLitedLightBlend(theme);
                                glowColor = HLitedGlow(theme);
                                separatorPen = HLitedSeparatorPen(theme);
                            }
                            else
                            {
                                btnBrush.InterpolationColors = HLitedLightBlend(theme);
                                splitBrush.InterpolationColors = HLitedBlend(theme);
                                glowColor = HLitedGlow(theme);
                                separatorPen = HLitedSeparatorPen(theme);
                            }
                            borderPen = HLitedBorderPen(theme);
                        }
                        else
                        {
                            if (focused)
                            {
                                btnBrush.InterpolationColors = FocusedBlend(theme);
                                glowColor = FocusedGlow(theme);
                                borderPen = FocusedBorderPen(theme);
                            }
                            else
                            {
                                btnBrush.InterpolationColors = NormalBlend(theme);
                                glowColor = NormalGlow(theme);
                                borderPen = NormalBorderPen(theme);
                            }
                        }
                    }
                }
            }
            else
            {
                btnBrush.InterpolationColors = DisabledBlend(theme);
                glowColor = DisabledGlow(theme);
                borderPen = DisabledBorderPen(theme);
            }
            GraphicsPath glowPath = null;
            if (rounded >= 0)
            {
                glowPath = ControlRenderer.Drawing.GetGlowingPath(new GraphicsPath(), new Rectangle(rect.X + rounded, Convert.ToInt32(rect.Y + (0.4 * rect.Height)), rect.Width - (2 * rounded), Convert.ToInt32(0.6 * rect.Height)), ControlRenderer.Drawing.LightingGlowPoint.BottomCenter);
            }
            else
            {
                glowPath = ControlRenderer.Drawing.GetGlowingPath(new GraphicsPath(), new Rectangle(rect.X, Convert.ToInt32(rect.Y + (0.4 * rect.Height)), rect.Width, Convert.ToInt32(0.6 * rect.Height)), ControlRenderer.Drawing.LightingGlowPoint.BottomCenter);
            }
            PathGradientBrush glowBrush = new PathGradientBrush(glowPath);
            Color[] sColors = new Color[2];
            sColors[0] = Color.Transparent;
            sColors[1] = Color.Transparent;
            glowBrush.CenterColor = glowColor;
            glowBrush.CenterPoint = new PointF(rect.X + (int)(rect.Width / 2.0), rect.Bottom - 2);
            glowBrush.SurroundColors = sColors;
            g.FillPath(btnBrush, btnPath);
            if (pressed == SplitEffectLocation.Split)
            {
                if (splitBrush != null)
                {
                    g.FillPath(splitBrush, splitPath);
                    splitBrush.Dispose();
                    splitBrush = null;
                }
            }
            if (shadowPath != null)
            {
                LinearGradientBrush shadowBrush = new LinearGradientBrush(new Rectangle(rect.X, rect.Y, rect.Width, 5), Color.FromArgb(63, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical);
                g.FillPath(shadowBrush, shadowPath);
                shadowBrush.Dispose();
                shadowPath.Dispose();
            }
            if (splitBrush != null)
            {
                g.FillPath(splitBrush, splitPath);
                splitBrush.Dispose();
                splitBrush = null;
            }
            g.FillPath(glowBrush, glowPath);
            // Drawing separator line
            if (separatorPen != null)
            {
                Point p1 = new Point();
                Point p2 = new Point();
                switch (split)
                {
                    case SplitLocation.Top:
                        p1 = new Point(splitRect.X + 2, splitRect.Bottom - 1);
                        p2 = new Point(splitRect.Right - 3, splitRect.Bottom - 1);
                        break;
                    case SplitLocation.Bottom:
                        p1 = new Point(splitRect.X + 2, splitRect.Y);
                        p2 = new Point(splitRect.Right - 3, splitRect.Y);
                        break;
                    case SplitLocation.Left:
                        p1 = new Point(splitRect.Right - 1, splitRect.Y + 2);
                        p2 = new Point(splitRect.Right - 1, splitRect.Bottom - 3);
                        break;
                    case SplitLocation.Right:
                        p1 = new Point(splitRect.X, splitRect.Y + 2);
                        p2 = new Point(splitRect.X, splitRect.Bottom - 3);
                        break;
                }
                g.DrawLine(separatorPen, p1, p2);
                separatorPen.Dispose();
            }
            if (borderPen != null)
            {
                g.DrawPath(borderPen, btnPath);
                borderPen.Dispose();
            }
            glowBrush.Dispose();
            glowPath.Dispose();
            btnPath.Dispose();
            splitPath.Dispose();
            btnBrush.Dispose();
        }
        #endregion

    }
}
