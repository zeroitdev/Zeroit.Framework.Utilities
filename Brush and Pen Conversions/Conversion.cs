// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Conversion.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// A class collection for Brush to Pen conversion
    /// </summary>
    public static class BrushToPen
    {
        /// <summary>
        /// Convert to Pen
        /// </summary>
        /// <param name="R">Red value</param>
        /// <param name="G">Green value</param>
        /// <param name="B">Blue value</param>
        /// <returns>Pen</returns>
        public static Pen ConvertToPen(this Pen pen, int R, int G, int B)
        {
            return new Pen(new SolidBrush(Color.FromArgb(R, G, B)));
        }

        /// <summary>
        /// Convert to Pen
        /// </summary>
        /// <param name="Brush">Set Solid Brush</param>
        /// <returns></returns>
        public static Pen ConvertToPen(this Pen pen, SolidBrush Brush)
        {
            return new Pen(Brush);
        }

        /// <summary>
        /// Convert to Pen
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Pen ConvertToPen(this Pen pen, Color Color)
        {
            return new Pen(new SolidBrush(Color));
        }
    }

    /// <summary>
    /// A class collection for Pen to Brush conversion
    /// </summary>    
    public static class PenToBrush
    {
        /// <summary>
        /// Conver to Brush
        /// </summary>
        /// <param name="R">Red Value</param>
        /// <param name="G">Green Value</param>
        /// <param name="B">Blue Value</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this SolidBrush Brush, int R, int G, int B)
        {
            return new SolidBrush(Color.FromArgb(R, G, B));
        }

        /// <summary>
        /// Convert to Brush
        /// </summary>
        /// <param name="Pen">Set Pen</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this SolidBrush Brush, Pen Pen)
        {
            return new SolidBrush(Pen.Color);
        }

        /// <summary>
        /// Convert to Brush 
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this SolidBrush Brush, Color Color)
        {
            return new SolidBrush(Color);
        }
        
        /// <summary>
        /// Convert to Brush
        /// </summary>
        /// <param name="Pen">Set Pen</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Pen Pen, Rectangle Rectangle, float GradientAngle)
        {
            return new LinearGradientBrush(Rectangle, Pen.Color, Pen.Color, GradientAngle);
        }

        /// <summary>
        /// Convert to Brush 
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Rectangle Rectangle, Color Color1, Color Color2, float GradientAngle)
        {
            return new LinearGradientBrush(Rectangle, Color1, Color2,GradientAngle);
        }


        /// <summary>
        /// Convert to Brush
        /// </summary>
        /// <param name="Pen">Set Pen</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Pen Pen, RectangleF Rectangle, float GradientAngle)
        {
            return new LinearGradientBrush(Rectangle, Pen.Color, Pen.Color, GradientAngle);
        }

        /// <summary>
        /// Convert to Brush 
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, RectangleF Rectangle, Color Color1, Color Color2, float GradientAngle)
        {
            return new LinearGradientBrush(Rectangle, Color1, Color2, GradientAngle);
        }

        /// <summary>
        /// Convert to Brush
        /// </summary>
        /// <param name="Pen">Set Pen</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Pen Pen, Point Point1, Point Point2, float GradientAngle)
        {
            return new LinearGradientBrush(Point1, Point2, Pen.Color, Pen.Color);
        }

        /// <summary>
        /// Convert to Brush 
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Point Point1, Point Point2, Color Color1, Color Color2, float GradientAngle)
        {
            return new LinearGradientBrush(Point1, Point2, Color1, Color2);
        }


        /// <summary>
        /// Convert to Brush
        /// </summary>
        /// <param name="Pen">Set Pen</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, Pen Pen, PointF Point1, PointF Point2, float GradientAngle)
        {
            return new LinearGradientBrush(Point1, Point2, Pen.Color, Pen.Color);
        }

        /// <summary>
        /// Convert to Brush 
        /// </summary>
        /// <param name="Color">Set Color</param>
        /// <returns></returns>
        public static Brush ConvertToBrush(this LinearGradientBrush Brush, PointF Point1, PointF Point2, Color Color1, Color Color2, float GradientAngle)
        {
            return new LinearGradientBrush(Point1, Point2, Color1, Color2);
        }

    }

}
