// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="HslColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities
{
    /// <summary>
    /// Class HSLColor.
    /// </summary>
    public class HSLColor
    {
        // Private data members below are on scale 0-1
        // They are scaled for use externally based on scale
        /// <summary>
        /// The hue
        /// </summary>
        private double hue = 1.0;
        /// <summary>
        /// The saturation
        /// </summary>
        private double saturation = 1.0;
        /// <summary>
        /// The luminosity
        /// </summary>
        private double luminosity = 1.0;

        /// <summary>
        /// The scale
        /// </summary>
        private const double scale = 240.0;

        /// <summary>
        /// Get and set Hue
        /// </summary>
        /// <value>The hue.</value>
        public double Hue
        {
            get { return hue * scale; }
            set { hue = CheckRange(value / scale); }
        }

        /// <summary>
        /// Get and set Saturation
        /// </summary>
        /// <value>The saturation.</value>
        public double Saturation
        {
            get { return saturation * scale; }
            set { saturation = CheckRange(value / scale); }
        }

        /// <summary>
        /// Get and set Luminosity
        /// </summary>
        /// <value>The luminosity.</value>
        public double Luminosity
        {
            get { return luminosity * scale; }
            set { luminosity = CheckRange(value / scale); }
        }

        /// <summary>
        /// Checks the range.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Double.</returns>
        private double CheckRange(double value)
        {
            if (value < 0.0)
                value = 0.0;
            else if (value > 1.0)
                value = 1.0;
            return value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("H: {0:#0.##} S: {1:#0.##} L: {2:#0.##}", Hue, Saturation, Luminosity);
        }

        /// <summary>
        /// To the RGB string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToRGBString()
        {
            Color color = (Color)this;
            return String.Format("R: {0:#0.##} G: {1:#0.##} B: {2:#0.##}", color.R, color.G, color.B);
        }

        #region Casts to/from System.Drawing.Color
        /// <summary>
        /// Performs an implicit conversion from <see cref="HSLColor"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="hslColor">Color of the HSL.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color(HSLColor hslColor)
        {
            double r = 0, g = 0, b = 0;
            if (hslColor.luminosity != 0)
            {
                if (hslColor.saturation == 0)
                    r = g = b = hslColor.luminosity;
                else
                {
                    double temp2 = GetTemp2(hslColor);
                    double temp1 = 2.0 * hslColor.luminosity - temp2;

                    r = GetColorComponent(temp1, temp2, hslColor.hue + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, hslColor.hue);
                    b = GetColorComponent(temp1, temp2, hslColor.hue - 1.0 / 3.0);
                }
            }
            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }

        /// <summary>
        /// Gets the color component.
        /// </summary>
        /// <param name="temp1">The temp1.</param>
        /// <param name="temp2">The temp2.</param>
        /// <param name="temp3">The temp3.</param>
        /// <returns>System.Double.</returns>
        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            temp3 = MoveIntoRange(temp3);
            if (temp3 < 1.0 / 6.0)
                return temp1 + (temp2 - temp1) * 6.0 * temp3;
            else if (temp3 < 0.5)
                return temp2;
            else if (temp3 < 2.0 / 3.0)
                return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            else
                return temp1;
        }
        /// <summary>
        /// Moves the into range.
        /// </summary>
        /// <param name="temp3">The temp3.</param>
        /// <returns>System.Double.</returns>
        private static double MoveIntoRange(double temp3)
        {
            if (temp3 < 0.0)
                temp3 += 1.0;
            else if (temp3 > 1.0)
                temp3 -= 1.0;
            return temp3;
        }
        /// <summary>
        /// Gets the temp2.
        /// </summary>
        /// <param name="hslColor">Color of the HSL.</param>
        /// <returns>System.Double.</returns>
        private static double GetTemp2(HSLColor hslColor)
        {
            double temp2;
            if (hslColor.luminosity < 0.5)  //<=??
                temp2 = hslColor.luminosity * (1.0 + hslColor.saturation);
            else
                temp2 = hslColor.luminosity + hslColor.saturation - (hslColor.luminosity * hslColor.saturation);
            return temp2;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Color"/> to <see cref="HSLColor"/>.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator HSLColor(Color color)
        {
            HSLColor hslColor = new HSLColor();
            hslColor.hue = color.GetHue() / 360.0; // we store hue as 0-1 as opposed to 0-360 
            hslColor.luminosity = color.GetBrightness();
            hslColor.saturation = color.GetSaturation();
            return hslColor;
        }
        #endregion

        /// <summary>
        /// Sets the RGB.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public void SetRGB(int red, int green, int blue)
        {
            HSLColor hslColor = (HSLColor)Color.FromArgb(red, green, blue);
            this.hue = hslColor.hue;
            this.saturation = hslColor.saturation;
            this.luminosity = hslColor.luminosity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HSLColor"/> class.
        /// </summary>
        public HSLColor() { }

        /// <summary>
        /// Creates an instance of the HSL color
        /// </summary>
        /// <param name="color">Set RGB color</param>
        public HSLColor(Color color)
        {
            SetRGB(color.R, color.G, color.B);
        }

        /// <summary>
        /// Creates an instance of the HSL color
        /// </summary>
        /// <param name="red">Set red value</param>
        /// <param name="green">Set green value</param>
        /// <param name="blue">Set blue value</param>
        public HSLColor(int red, int green, int blue)
        {
            SetRGB(red, green, blue);
        }

        /// <summary>
        /// Creates and instance of the HSL color
        /// </summary>
        /// <param name="hue">Hue value</param>
        /// <param name="saturation">Saturation value</param>
        /// <param name="luminosity">Luminosity value</param>
        public HSLColor(double hue, double saturation, double luminosity)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminosity = luminosity;
        }

    }
}
