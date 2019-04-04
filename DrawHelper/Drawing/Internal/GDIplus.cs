// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-22-2018
// ***********************************************************************
// <copyright file="GDIplus.cs" company="Zeroit Dev Technologies">
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

#region Using directives

using System;
using System.Drawing;
using System.Security;
using System.Runtime.InteropServices;

#endregion

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Internal
{

    /// <summary>
    /// Class GDIplus.
    /// </summary>
    [SuppressUnmanagedCodeSecurityAttribute()]
	internal static class GDIplus
	{

        /// <summary>
        /// The GDI plus DLL
        /// </summary>
        private const string GDIPlusDLL = "gdiplus.dll";

        /// <summary>
        /// Converts the point to memory.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>IntPtr.</returns>
        /// <exception cref="ArgumentNullException">points</exception>
        internal static IntPtr ConvertPointToMemory(Point[] points)
		{
			if(points == null)
			{
				throw new ArgumentNullException("points");
			}
			int j = Marshal.SizeOf(new GPPOINT().GetType());
			int k = (int)points.Length;
			IntPtr i2 = Marshal.AllocHGlobal(k * j);
			for(int i1 = 0; i1 < k; i1++)
			{
				Marshal.StructureToPtr(new GPPOINT(points[i1]), (IntPtr)((long)i2 + i1 * j), false);
			}
			return i2;
		}

        /// <summary>
        /// Converts the point to memory.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>IntPtr.</returns>
        /// <exception cref="ArgumentNullException">points</exception>
        internal static IntPtr ConvertPointToMemory(PointF[] points)
		{
			if(points == null)
			{
				throw new ArgumentNullException("points");
			}
			int j = Marshal.SizeOf(new GPPOINTF().GetType());
			int k = (int)points.Length;
			IntPtr i2 = Marshal.AllocHGlobal(k * j);
			for(int i1 = 0; i1 < k; i1++)
			{
				Marshal.StructureToPtr(new GPPOINTF(points[i1]), (IntPtr)((long)i2 + i1 * j), false);
			}
			return i2;
		}

        /// <summary>
        /// Gdips the create path.
        /// </summary>
        /// <param name="brushMode">The brush mode.</param>
        /// <param name="path">The path.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePath(int brushMode, ref IntPtr path);

        /// <summary>
        /// Gdips the color of the set path gradient center.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientCenterColor(HandleRef brush, int color);

        /// <summary>
        /// Gdips the set path gradient center point.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="point">The point.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientCenterPoint(HandleRef brush, GPPOINTF point);

        /// <summary>
        /// Gdips the create path gradient.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="count">The count.</param>
        /// <param name="wrapMode">The wrap mode.</param>
        /// <param name="brush">The brush.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePathGradient(HandleRef points, int count, int wrapMode, out IntPtr brush);

        /// <summary>
        /// Gdips the set path gradient preset blend.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="blend">The blend.</param>
        /// <param name="positions">The positions.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientPresetBlend(HandleRef brush, HandleRef blend, HandleRef positions, int count);

        /// <summary>
        /// Gdips the set path gradient focus scales.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="xScale">The x scale.</param>
        /// <param name="yScale">The y scale.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientFocusScales(HandleRef brush, float xScale, float yScale);

        /// <summary>
        /// Gdips the create path gradient from path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="brush">The brush.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePathGradientFromPath(HandleRef path, out IntPtr brush);

        /// <summary>
        /// Gdips the get path points.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="points">The points.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipGetPathPoints(HandleRef path, HandleRef points, int count);

        /// <summary>
        /// Gdips the add path curve3 i.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="memorypts">The memorypts.</param>
        /// <param name="count">The count.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="numberOfSegments">The number of segments.</param>
        /// <param name="tension">The tension.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathCurve3I(HandleRef path, HandleRef memorypts, int count, int offset, int numberOfSegments, float tension);

        /// <summary>
        /// Gdips the add path arc.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="sweepAngle">The sweep angle.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathArc(HandleRef path, float x, float y, float width, float height, float startAngle, float sweepAngle);

        /// <summary>
        /// Gdips the add path line.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathLine(HandleRef path, float x1, float y1, float x2, float y2);

        /// <summary>
        /// Gdips the close path figure.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.Int32.</returns>
        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipClosePathFigure(HandleRef path);

        /// <summary>
        /// Gdips the create bitmap from GDI dib.
        /// </summary>
        /// <param name="bminfo">The bminfo.</param>
        /// <param name="pixdat">The pixdat.</param>
        /// <param name="image">The image.</param>
        /// <returns>System.Int32.</returns>
        [DllImport(GDIPlusDLL, SetLastError = true)]
		internal static extern int GdipCreateBitmapFromGdiDib(IntPtr bminfo, IntPtr pixdat, ref IntPtr image);

        /// <summary>
        /// Gdips the create hbitmap from bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="hbmReturn">The HBM return.</param>
        /// <param name="background">The background.</param>
        /// <returns>System.Int32.</returns>
        [DllImport(GDIPlusDLL)]
		internal static extern int GdipCreateHBITMAPFromBitmap(IntPtr bitmap, ref IntPtr hbmReturn, int background);

        /// <summary>
        /// Gdips the create bitmap from hbitmap.
        /// </summary>
        /// <param name="hbitmap">The hbitmap.</param>
        /// <param name="hpalette">The hpalette.</param>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>System.Int32.</returns>
        [DllImport(GDIPlusDLL, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
		internal static extern int GdipCreateBitmapFromHBITMAP(HandleRef hbitmap, HandleRef hpalette, out IntPtr bitmap);
 


	}

    /// <summary>
    /// Class GPPOINT.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
	class GPPOINT
	{
        /// <summary>
        /// The x
        /// </summary>
        internal int X;
        /// <summary>
        /// The y
        /// </summary>
        internal int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINT"/> class.
        /// </summary>
        internal GPPOINT()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINT"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        internal GPPOINT(PointF pt)
		{
			X = (int)pt.X;
			Y = (int)pt.Y;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINT"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        internal GPPOINT(Point pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

        /// <summary>
        /// To the point.
        /// </summary>
        /// <returns>PointF.</returns>
        internal PointF ToPoint()
		{
			return new PointF((float)X, (float)Y);
		}
	}

    /// <summary>
    /// Class GPPOINTF.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
	class GPPOINTF
	{
        /// <summary>
        /// The x
        /// </summary>
        internal float X;

        /// <summary>
        /// The y
        /// </summary>
        internal float Y;


        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINTF"/> class.
        /// </summary>
        internal GPPOINTF()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINTF"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        internal GPPOINTF(PointF pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GPPOINTF"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        internal GPPOINTF(Point pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

        /// <summary>
        /// To the point.
        /// </summary>
        /// <returns>PointF.</returns>
        internal PointF ToPoint()
		{
			return new PointF(X, Y);
		}
	}

}
