// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Blur.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /* Fast Algorithms :
         Box Blur Algorithm by: Wojciech Jarosz on : 
         http://elynxsdk.free.fr/ext-docs/Blur/Fast_box_blur.pdf
         and the Fast Gaussian Algorithm by: Peter Kovesi on :
          http://www.peterkovesi.com/papers/FastGaussianSmoothing.pdf

    */
    /// <summary>
    /// Class Blur.
    /// </summary>
    public static class Blur
    {

        /// <summary>
        /// Gaussains the specified source.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="Radius">The radius.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Gaussain(BitmapWorker src , int Radius)
        {
            return FastGaussianBlur(src, Radius);
        }

        /// <summary>
        /// Boxes the blur.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="Radius">The radius.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker BoxBlur(BitmapWorker src, int Radius)
        {
            return FastBoxBlur(src, Radius);
        }



        /// <summary>
        /// Fasts the box blur.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>BitmapWorker.</returns>
        private static BitmapWorker FastBoxBlur(BitmapWorker img, int radius)
        {

            int kSize = radius;
            if (kSize % 2 == 0) kSize++;
            BitmapWorker Hblur = img.Clone();
            float Avg = (float)1 / kSize;

            for (int j = 0; j < img.Height(); j++)
            {

                float[] hSum = new float[] { 0f, 0f, 0f, 0f };
                float[] iAvg = new float[] { 0f, 0f, 0f, 0f };

                for (int x = 0; x < kSize; x++)
                {

                    Color tmpColor = img.GetPixel(x, j);
                    hSum[0] += tmpColor.A;
                    hSum[1] += tmpColor.R;
                    hSum[2] += tmpColor.G;
                    hSum[3] += tmpColor.B;



                }

                iAvg[0] = hSum[0] * Avg;
                iAvg[1] = hSum[1] * Avg;
                iAvg[2] = hSum[2] * Avg;
                iAvg[3] = hSum[3] * Avg;


                for (int i = 0; i < img.Width(); i++)
                {

                    if (i - kSize / 2 >= 0 && i + 1 + kSize / 2 < img.Width())
                    {
                        Color tmp_pColor = img.GetPixel(i - kSize / 2, j);
                        hSum[0] -= tmp_pColor.A;
                        hSum[1] -= tmp_pColor.R;
                        hSum[2] -= tmp_pColor.G;
                        hSum[3] -= tmp_pColor.B;
                        Color tmp_nColor = img.GetPixel(i + 1 + kSize / 2, j);
                        hSum[0] += tmp_nColor.A;
                        hSum[1] += tmp_nColor.R;
                        hSum[2] += tmp_nColor.G;
                        hSum[3] += tmp_nColor.B;
                        //
                        iAvg[0] = hSum[0] * Avg;
                        iAvg[1] = hSum[1] * Avg;
                        iAvg[2] = hSum[2] * Avg;
                        iAvg[3] = hSum[3] * Avg;



                    }


                    Hblur.SetPixel(i, j, Color.FromArgb((int)iAvg[0], (int)iAvg[1], (int)iAvg[2], (int)iAvg[3]));
                }

            }

            BitmapWorker total =Hblur.Clone();

            for (int i = 0; i < Hblur.Width(); i++)
            {
                float[] tSum = new float[] { 0f, 0f, 0f, 0f };
                float[] iAvg = new float[] { 0f, 0f, 0f, 0f };
                for (int y = 0; y < kSize; y++)
                {

                    Color tmpColor = Hblur.GetPixel(i, y);
                    tSum[0] += tmpColor.A;
                    tSum[1] += tmpColor.R;
                    tSum[2] += tmpColor.G;
                    tSum[3] += tmpColor.B;

                }
                iAvg[0] = tSum[0] * Avg;
                iAvg[1] = tSum[1] * Avg;
                iAvg[2] = tSum[2] * Avg;
                iAvg[3] = tSum[3] * Avg;

                for (int j = 0; j < Hblur.Height(); j++)
                {

                    if (j - kSize / 2 >= 0 && j + 1 + kSize / 2 < Hblur.Height())
                    {
                        Color tmp_pColor = Hblur.GetPixel(i, j - kSize / 2);
                        tSum[0] -= tmp_pColor.A;
                        tSum[1] -= tmp_pColor.R;
                        tSum[2] -= tmp_pColor.G;
                        tSum[3] -= tmp_pColor.B;
                        Color tmp_nColor = Hblur.GetPixel(i, j + 1 + kSize / 2);
                        tSum[0] += tmp_nColor.A;
                        tSum[1] += tmp_nColor.R;
                        tSum[2] += tmp_nColor.G;
                        tSum[3] += tmp_nColor.B;
                        //
                        iAvg[0] = tSum[0] * Avg;
                        iAvg[1] = tSum[1] * Avg;
                        iAvg[2] = tSum[2] * Avg;
                        iAvg[3] = tSum[3] * Avg;



                    }
                    total.SetPixel(i, j, Color.FromArgb((int)iAvg[0], (int)iAvg[1], (int)iAvg[2], (int)iAvg[3]));

                }

            }
            return total;

        }

        /// <summary>
        /// Fasts the gaussian blur.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="Raduis">The raduis.</param>
        /// <returns>BitmapWorker.</returns>
        private static BitmapWorker FastGaussianBlur(BitmapWorker src, int Raduis)
        {
            var bxs = boxesForGaussian(Raduis, 3);
            BitmapWorker img = FastBoxBlur(src, bxs[0]);
            BitmapWorker img_2 = FastBoxBlur(img, bxs[1]);
            BitmapWorker img_3 = FastBoxBlur(img_2, bxs[2]);
            return img_3;
        }

        /// <summary>
        /// Boxeses for gaussian.
        /// </summary>
        /// <param name="sigma">The sigma.</param>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32[].</returns>
        private static int[] boxesForGaussian(double sigma, int n)
        {
            double wIdeal = Math.Sqrt((12 * sigma * sigma / n) + 1);

            double wl = Math.Floor(wIdeal); if (wl % 2 == 0) wl--;
            double wu = wl + 2;

            double mIdeal = (12 * sigma * sigma - n * wl * wl - 4 * n * wl - 3 * n) / (-4 * wl - 4);
            double m = Math.Round(mIdeal);

            int[] sizes = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i < m) { sizes[i] = (int)wl; } else { sizes[i] = (int)wu; }
            }
            return sizes;
        }
    }
}
