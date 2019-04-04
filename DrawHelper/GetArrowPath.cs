// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GetArrowPath.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing
{
    /// <summary>
    /// Class DrawRenderer.
    /// </summary>
    public static partial class DrawRenderer
    {

        #region DrawArrowPath

        /// <summary>
        /// Draws the arrow path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath DrawArrowPath(this GraphicsPath value, PointF startPoint, PointF endPoint)
        {
            return DrawArrowPath(value, startPoint, endPoint, 7);
        }

        /// <summary>
        /// Draws the arrow path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="arrowLength">Length of the arrow.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath DrawArrowPath(this GraphicsPath value, PointF startPoint, PointF endPoint, double arrowLength)
        {
            return DrawArrowPath(value, startPoint, endPoint, arrowLength, 1);
        }

        /// <summary>
        /// Draws an the arrow path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="arrowLength">Length of the arrow.</param>
        /// <param name="relativeValue">The relative value.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath DrawArrowPath(this GraphicsPath value, PointF startPoint, PointF endPoint,
            double arrowLength, double relativeValue)
        {
            //http://www.cnblogs.com/jasenkin/archive/2011/01/04/graphic_drawing_arrow_head_II.html

            double distance = Math.Abs(Math.Sqrt(
                (startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) +
                (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y)));

            if (distance == 0)
            {
                return new GraphicsPath();
            }

            double xa = endPoint.X + arrowLength * ((startPoint.X - endPoint.X)
                + (startPoint.Y - endPoint.Y) / relativeValue) / distance;
            double ya = endPoint.Y + arrowLength * ((startPoint.Y - endPoint.Y)
                - (startPoint.X - endPoint.X) / relativeValue) / distance;
            double xb = endPoint.X + arrowLength * ((startPoint.X - endPoint.X)
                - (startPoint.Y - endPoint.Y) / relativeValue) / distance;
            double yb = endPoint.Y + arrowLength * ((startPoint.Y - endPoint.Y)
                + (startPoint.X - endPoint.X) / relativeValue) / distance;

            PointF[] polygonPoints =
            {
                 new PointF(endPoint.X , endPoint.Y),
                 new PointF( (float)xa   ,  (float)ya),
                 new PointF( (float)xb   ,  (float)yb)
            };

            GraphicsPath path = new GraphicsPath();
            path.AddLines(polygonPoints);

            return path;
        }


        #endregion

    }


}
