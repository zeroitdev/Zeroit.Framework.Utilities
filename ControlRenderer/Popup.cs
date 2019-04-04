// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Popup.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// A class for rendering Popup
    /// </summary>
    public static class Popup
    {
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property PlacementBrush(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As SolidBrush
        public static SolidBrush PlacementBrush(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new SolidBrush(Color.FromArgb(233, 238, 238));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new SolidBrush(Color.FromArgb(125, 158, 201));
            }
            return new SolidBrush(Color.Black);
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SeparatorBrush(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As SolidBrush
        public static SolidBrush SeparatorBrush(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new SolidBrush(Color.FromArgb(221, 231, 238));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new SolidBrush(Color.FromArgb(163, 188, 218));
            }
            return new SolidBrush(Color.Black);
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property BackgroundBrush(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As SolidBrush
        public static SolidBrush BackgroundBrush(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new SolidBrush(Color.FromArgb(250, 250, 250));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new SolidBrush(Color.FromArgb(84, 84, 84));
            }
            return new SolidBrush(Color.Black);
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property NormalTextBrush(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As SolidBrush
        public static SolidBrush NormalTextBrush(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue
            if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
            {
                return new SolidBrush(Color.FromArgb(85, 119, 163));
            }
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            else if (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue)
            {
                return new SolidBrush(Color.FromArgb(255, 255, 255));
            }
            return new SolidBrush(Color.Black);
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property DisabledTextBrush(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As SolidBrush
        public static SolidBrush DisabledTextBrush(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
            //		Select Case theme
            //ORIGINAL LINE: Case Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue, Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue
            if ((theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) || (theme == Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.BlackBlue))
            {
                return new SolidBrush(Color.FromArgb(118, 118, 118));
            }
            return new SolidBrush(Color.Black);
        }
        //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a function:
        //ORIGINAL LINE: Public Shared ReadOnly Property SeparatorPen(Optional ByVal theme As Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue) As Pen
        public static Pen SeparatorPen(Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme theme = Zeroit.Framework.Utilities.GraphicsExtension.ControlRenderer.Drawing.ColorTheme.Blue)
        {
            return new Pen(Color.FromArgb(197, 197, 197));
        }
    }
}
