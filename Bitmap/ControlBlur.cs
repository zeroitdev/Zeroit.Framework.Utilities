// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ControlBlur.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Zeroit.Framework.Utilities.BitmapUtils
{
    //public partial class Form1 : Form
    //{
    //    public Form1()
    //    {
    //        InitializeComponent();
    //    }

    //    private void button1_Click(object sender, EventArgs e)
    //    {
    //        System.Drawing.Bitmap bmp = Screenshot.TakeSnapshot(panel1);
    //        BitmapFilter.GaussianBlur(bmp, 4);

    //        PictureBox pb = new PictureBox();
    //        panel1.Controls.Add(pb);
    //        pb.Image = bmp;
    //        pb.Dock = DockStyle.Fill;
    //        pb.BringToFront();
    //    }
    //}

    /// <summary>
    /// A class to execute blur operations on images
    /// </summary>
    public static class BackgroundBlur
    {
        
        /// <summary>
        /// A function to blur a control
        /// </summary>
        /// <param name="control">Control to blur</param>
        /// <param name="pictureBox">Set a picture box</param>
        /// <param name="gausianWeight">Weight or size of the gausian blur</param>
        public static void BlurControl(Control control, PictureBox pictureBox, int gausianWeight)
        {
            System.Drawing.Bitmap bitmap = Screenshot.TakeSnapshot(control);
            BitmapFilter.GaussianBlur(bitmap, gausianWeight);
            //panel.Controls.Add(pictureBox);
            //control.FindForm().Controls.Add(pictureBox);
            //pictureBox.Location = control.Location;
            //pictureBox.Size = control.Size;
            pictureBox.Image = bitmap;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BringToFront();
        }


        public static System.Drawing.Bitmap BlurControl(System.Drawing.Bitmap bitmap, int gausianWeight)
        {
            BitmapFilter.GaussianBlur(bitmap, gausianWeight);

            return bitmap;
        }

    }

    /// <summary>
    /// Covalent matrix tranformations
    /// </summary>
    public class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;
        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }

    /// <summary>
    /// A blur Filter class
    /// </summary>
    public class BitmapFilter
    {
        /// <summary>
        /// A 3 by 3 Convalent Matrix
        /// </summary>
        /// <param name="b">Set Bitmap</param>
        /// <param name="m">Convalent Matrix</param>
        /// <returns></returns>
        private static bool Conv3x3(System.Drawing.Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            System.Drawing.Bitmap bSrc = (System.Drawing.Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                                    (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                                    (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                                    (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                                    (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                                    (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                                    (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        /// <summary>
        /// Gausian Blur function
        /// </summary>
        /// <param name="b">Set bitmap</param>
        /// <param name="nWeight">Set the weight of the bitmap which has a default value of 4 </param>
        /// <returns></returns>
        public static bool GaussianBlur(System.Drawing.Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return BitmapFilter.Conv3x3(b, m);
        }

        /// <summary>
        /// Bitmap Invert
        /// </summary>
        /// <param name="b">Set bitmap</param>
        /// <returns></returns>
        public static bool Invert(System.Drawing.Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        /// <summary>
        /// Bitmap Grayscale filter
        /// </summary>
        /// <param name="b">Set bitmap</param>
        /// <returns></returns>
        public static bool GrayScale(System.Drawing.Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        /// <summary>
        /// Bitmap Brightness
        /// </summary>
        /// <param name="b">Set bitmap</param>
        /// <param name="nBrightness">Sets the brightness level</param>
        /// <returns></returns>
        public static bool Brightness(System.Drawing.Bitmap b, int nBrightness)
        {
            if (nBrightness < -255 || nBrightness > 255)
                return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            int nVal = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(p[0] + nBrightness);

                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        /// <summary>
        /// Bitmap Contrast
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="nContrast">Set the contrast level</param>
        /// <returns></returns>
        public static bool Contrast(System.Drawing.Bitmap b, sbyte nContrast)
        {
            if (nContrast < -100) return false;
            if (nContrast > 100) return false;

            double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

            contrast *= contrast;

            int red, green, blue;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        pixel = red / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[2] = (byte)pixel;

                        pixel = green / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[1] = (byte)pixel;

                        pixel = blue / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[0] = (byte)pixel;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        /// <summary>
        /// Bitmap Gamma Filter
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="red">Set the red value. Max is 255</param>
        /// <param name="green">Set the green value. Max is 255</param>
        /// <param name="blue">Set the blue value. Max is 255</param>
        /// <returns></returns>
        public static bool Gamma(System.Drawing.Bitmap b, double red, double green, double blue)
        {
            if (red < .2 || red > 5) return false;
            if (green < .2 || green > 5) return false;
            if (blue < .2 || blue > 5) return false;

            byte[] redGamma = new byte[256];
            byte[] greenGamma = new byte[256];
            byte[] blueGamma = new byte[256];

            for (int i = 0; i < 256; ++i)
            {
                redGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / red)) + 0.5));
                greenGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / green)) + 0.5));
                blueGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / blue)) + 0.5));
            }

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        p[2] = redGamma[p[2]];
                        p[1] = greenGamma[p[1]];
                        p[0] = blueGamma[p[0]];

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        /// <summary>
        /// Bitmap Color
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="red">Set the red value. Max is 255</param>
        /// <param name="green">Set the green value. Max is 255</param>
        /// <param name="blue">Set the blue value. Max is 255</param>
        /// <returns></returns>
        public static bool Color(System.Drawing.Bitmap b, int red, int green, int blue)
        {
            if (red < -255 || red > 255) return false;
            if (green < -255 || green > 255) return false;
            if (blue < -255 || blue > 255) return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nPixel;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        nPixel = p[2] + red;
                        nPixel = Math.Max(nPixel, 0);
                        p[2] = (byte)Math.Min(255, nPixel);

                        nPixel = p[1] + green;
                        nPixel = Math.Max(nPixel, 0);
                        p[1] = (byte)Math.Min(255, nPixel);

                        nPixel = p[0] + blue;
                        nPixel = Math.Max(nPixel, 0);
                        p[0] = (byte)Math.Min(255, nPixel);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        
        /// <summary>
        /// Bitmap Smooth
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="nWeight">Set the weight of the bitmap.Default is 1</param>
        /// <returns></returns>
        public static bool Smooth(System.Drawing.Bitmap b, int nWeight /* default to 1 */)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;

            return BitmapFilter.Conv3x3(b, m);
        }

        /// <summary>
        /// Bitmap Mean Removal
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="nWeight">Set the weight of the bitmap.Default is 9</param>
        /// <returns></returns>
        public static bool MeanRemoval(System.Drawing.Bitmap b, int nWeight /* default to 9*/ )
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;

            return BitmapFilter.Conv3x3(b, m);
        }

        /// <summary>
        /// Bitmap Sharpen
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <param name="nWeight">Set the weight of the bitmap.Default is 11</param>
        /// <returns></returns>
        public static bool Sharpen(System.Drawing.Bitmap b, int nWeight /* default to 11*/ )
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(0);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
            m.Factor = nWeight - 8;

            return BitmapFilter.Conv3x3(b, m);
        }

        /// <summary>
        /// Bitmap EmbossLaplacian
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <returns></returns>
        public static bool EmbossLaplacian(System.Drawing.Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
            m.Pixel = 4;
            m.Offset = 127;

            return BitmapFilter.Conv3x3(b, m);
        }

        /// <summary>
        /// Bitmap Edge Detect Quick
        /// </summary>
        /// <param name="b">Set the bitmap</param>
        /// <returns></returns>
        public static bool EdgeDetectQuick(System.Drawing.Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = m.TopMid = m.TopRight = -1;
            m.MidLeft = m.Pixel = m.MidRight = 0;
            m.BottomLeft = m.BottomMid = m.BottomRight = 1;

            m.Offset = 127;

            return BitmapFilter.Conv3x3(b, m);
        }

        internal class Implementation
        {

            // You should not that Form implemented in this class are respective
            // forms created so do well to create the forms
            //


            private System.Drawing.Bitmap m_Bitmap;
            private System.Drawing.Bitmap m_Undo;
            private double Zoom = 1.0;

            private Control control;

            private int convMatTopLeft = 0;
            private int convMat_TopMid = 0;
            private int convMat_TopRight = 0;
            private int convMat_MidLeft = 0;
            private int convMat_MidRight = 0;
            private int convMat_BottomLeft = 0;
            private int convMat_BottomMid = 0;
            private int convMat_BottomRight = 0;
            private int convMat_Pixel = 0;
            private int convMat_Factor = 0;
            private int convMat_Offset = 0;
            



            public ConvMatrix Matrix
            {
                get
                {
                    ConvMatrix mat = new ConvMatrix();
                    mat.TopLeft = convMatTopLeft;
                    mat.TopMid = convMat_TopMid;
                    mat.TopRight = convMat_TopRight;
                    mat.MidLeft = convMat_MidLeft;
                    mat.MidRight = convMat_MidRight;
                    mat.BottomLeft = convMat_BottomLeft;
                    mat.BottomMid = convMat_BottomMid;
                    mat.BottomRight = convMat_BottomRight;
                    mat.Pixel = convMat_Pixel;
                    mat.Factor = convMat_Factor;
                    mat.Offset = convMat_Offset;
                    return mat;
                }
            }

            public Implementation()
            {
                m_Bitmap = new System.Drawing.Bitmap(2, 2);
            }

            private void Form_OnPaint(object sender, PaintEventArgs e)
            {
                
                System.Drawing.Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.DrawImage(m_Bitmap, new Rectangle(control.FindForm().AutoScrollPosition.X, control.FindForm().AutoScrollPosition.Y, (int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom)));
            }

            private void Filter_Invert(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.Invert(m_Bitmap))
                    control.Invalidate();
            }

            private void Filter_GrayScale(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.GrayScale(m_Bitmap))
                    control.Invalidate();
            }

            private void Filter_Brightness(object sender, System.EventArgs e)
            {
                Form dlg = new Form();
                
                int nValue = 0;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                    if (BitmapFilter.Brightness(m_Bitmap, nValue))
                        control.Invalidate();
                }
            }

            private void Filter_Contrast(object sender, System.EventArgs e)
            {
                Form dlg = new Form();
                int nValue = 0;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                    if (BitmapFilter.Contrast(m_Bitmap, (sbyte)nValue))
                        control.Invalidate();
                }

            }

            private void Filter_Gamma(object sender, System.EventArgs e)
            {
                Form dlg = new Form();
                int red = 1, green = 1 , blue = 1;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                    if (BitmapFilter.Gamma(m_Bitmap, red, green, blue))
                        control.Invalidate();
                }
            }

            private void Filter_Color(object sender, System.EventArgs e)
            {
                Form dlg = new Form();
                int red = 0, green = 0, blue = 0;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                    if (BitmapFilter.Color(m_Bitmap, red, green, blue))
                        control.Invalidate();
                }

            }

            private void OnZoom25(object sender, System.EventArgs e)
            {
                Zoom = .25;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom50(object sender, System.EventArgs e)
            {
                Zoom = .5;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom100(object sender, System.EventArgs e)
            {
                Zoom = 1.0;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom150(object sender, System.EventArgs e)
            {
                Zoom = 1.5;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom200(object sender, System.EventArgs e)
            {
                Zoom = 2.0;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom300(object sender, System.EventArgs e)
            {
                Zoom = 3.0;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnZoom500(object sender, System.EventArgs e)
            {
                Zoom = 5;
                control.FindForm().AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                control.Invalidate();
            }

            private void OnFilterSmooth(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.Smooth(m_Bitmap, 1))
                    control.Invalidate();
            }

            private void OnGaussianBlur(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.GaussianBlur(m_Bitmap, 4))
                    control.Invalidate();
            }

            private void OnMeanRemoval(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.MeanRemoval(m_Bitmap, 9))
                    control.Invalidate();
            }

            private void OnSharpen(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.Sharpen(m_Bitmap, 11))
                    control.Invalidate();
            }

            private void OnEmbossLaplacian(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.EmbossLaplacian(m_Bitmap))
                    control.Invalidate();
            }

            private void OnEdgeDetectQuick(object sender, System.EventArgs e)
            {
                m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                if (BitmapFilter.EdgeDetectQuick(m_Bitmap))
                    control.Invalidate();
            }

            private void OnUndo(object sender, System.EventArgs e)
            {
                System.Drawing.Bitmap temp = (System.Drawing.Bitmap)m_Bitmap.Clone();
                m_Bitmap = (System.Drawing.Bitmap)m_Undo.Clone();
                m_Undo = (System.Drawing.Bitmap)temp.Clone();
                control.Invalidate();
            }

            private void OnFilterCustom(object sender, System.EventArgs e)
            {
                Form dlg = new Form();

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    m_Undo = (System.Drawing.Bitmap)m_Bitmap.Clone();
                    if (BitmapFilter.Conv3x3(m_Bitmap, Matrix))
                        control.Invalidate();
                }

            }


        }


    }

    /// <summary>
    /// A class to implement a Screenshot of a control.
    /// </summary>
    public static class Screenshot
    {

        /// <summary>
        /// Creates a screenshot of the selected control
        /// </summary>
        /// <param name="ctl">Control to use</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap TakeSnapshot(Control ctl)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ctl.Size.Width, ctl.Size.Height);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(
                    ctl.PointToScreen(ctl.ClientRectangle.Location),
                    new Point(0, 0), ctl.ClientRectangle.Size
                );
            }
            return bmp;
        }
    }
}