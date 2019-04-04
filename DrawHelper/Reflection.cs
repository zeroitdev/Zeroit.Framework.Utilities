// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Reflection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class with extensions for Graphics objects
    /// </summary>
    public static partial class BitmapManipulation
    {

        #region Reflection

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="gap">The gap between the reflection part and the original in pixels.</param>
        /// <param name="height">The height of the reflection.</param>
        /// <param name="startAlpha">The opacity (0 to 1) at the beginning of the reflection.</param>
        /// <param name="endAlpha">The opacity (0 to 1) at the end of the reflection.</param>
        public static void DrawReflection(this System.Drawing.Graphics g, Image data, RectangleF origin, int gap, int height, float startAlpha, float endAlpha)
        {
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();

            for (int i = 0; i < height; i++)
            {
                cm.Matrix33 = startAlpha - i * (startAlpha - endAlpha) / height;
                ia.SetColorMatrix(cm);
                g.DrawImage(data, 
                    new Rectangle((int)origin.Left, (int)origin.Bottom + gap + i, (int)origin.Width, 1), 
                    origin.Left, origin.Bottom - 1 - i, origin.Width, 1, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="gap">The gap between the reflection part and the original in pixels.</param>
        /// <param name="height">The height of the reflection.</param>
        /// <param name="endAlpha">The opacity (0 to 1) in the end of the reflection.</param>
        public static void DrawReflection(this System.Drawing.Graphics g, Image data, RectangleF origin, int gap, int height, float endAlpha)
        {
            g.DrawReflection(data, origin, gap, height, 1f, endAlpha);
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="endAlpha">The opacity (0 to 1) in the end of the reflection.</param>
        public static void DrawReflection(this System.Drawing.Graphics g, Image data, RectangleF origin, float endAlpha)
        {
            g.DrawReflection(data, origin, 0, (int)origin.Height, 1f, endAlpha);
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        public static void DrawReflection(this System.Drawing.Graphics g, Image data, RectangleF origin)
        {
            g.DrawReflection(data, origin, 0f);
        }

        #endregion
        
    }
}
