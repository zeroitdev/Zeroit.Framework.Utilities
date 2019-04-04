// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GDIColor.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class GDIColor. This class cannot be inherited.
    /// </summary>
    public sealed class GDIColor
    {
        /// <summary>
        /// The native color
        /// </summary>
        private int _NativeColor = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIColor"/> class.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public GDIColor(int red, int green, int blue)
        {
            this.calculateColor(red, green, blue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIColor"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public GDIColor(Color color)
        {
            _NativeColor = (color.B << 16 | color.G << 8 | color.R);
            this.calculateColor(color.R, color.G, color.B);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GDIColor"/> class.
        /// </summary>
        /// <param name="nativeColor">Color of the native.</param>
        public GDIColor(int nativeColor)
        {
            this._NativeColor = nativeColor;
        }


        /// <summary>
        /// Gets or sets the red.
        /// </summary>
        /// <value>The red.</value>
        public int Red
        {
            get
            {
              return (this.NativeColor) & 0xFF;
            }
            set
            {
                this.calculateColor(value, this.Green, this.Blue);
            }
        }

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        /// <value>The green.</value>
        public int Green
        {
            get
            {                
                return  (this.NativeColor >> 8) & 0xFF;
            }
            set
            {
                this.calculateColor(this.Red, value, this.Blue);
            }
        }

        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public int Blue
        {
            get
            {
                return (this.NativeColor >> 16) & 0xFF;
            }
            set
            {
                this.calculateColor(this.Red,this.Green,value);
            }
        }

        /// <summary>
        /// Gets the color of the native.
        /// </summary>
        /// <value>The color of the native.</value>
        public int NativeColor
        {
            get
            {
                return _NativeColor;
            }
        }

        /// <summary>
        /// Calculates the color.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        private void calculateColor(int r,int g,int b)
        {
            _NativeColor = (b << 16 | g << 8 | r);
        }
    }
}
