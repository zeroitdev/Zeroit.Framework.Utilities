// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Effects.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// Class BitmapEffects.
    /// </summary>
    public static class BitmapEffects
    {
        //public Blur CustomBlur = new Blur(); //the use in Form1.cs for example: "layer1 = effects.CustomBlur.Gaussain(layer1, 10);"

        /// <summary>
        /// Convolves the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="kernel">The kernel.</param>
        /// <param name="kw">The kw.</param>
        /// <param name="kh">The kh.</param>
        /// <returns>BitmapWorker.</returns>
        static BitmapWorker Convolve(BitmapWorker image, float[,] kernel, int kw, int kh)
        {
            BitmapWorker temp = image.Clone();

            // int kh = kernel;
            //int kw = kh; //kernel[0].Length / 2;
            int i = 0, j = 0, n = 0, m = 0, cr, cg, cb, ca,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < h; i++)
            {
                for (j = 0; j < w; j++)
                {
                    //kernel loop
                    float r = 0, g = 0, b = 0, a = 0;
                    for (n = -kh; n <= kh; n++)
                    {
                        for (m = -kw; m <= kw; m++)
                        {
                            if (i + n >= 0 && i + n < h)
                            {
                                if (j + m >= 0 && j + m < w)
                                {
                                    float f = kernel[m + kw, n + kh];
                                    if (f == 0) { continue; }
                                    Color colortemp = image.GetPixel(j + m, i + n);
                                    cr = colortemp.R; cg = colortemp.G; cb = colortemp.B; ca = colortemp.A;

                                    r += cr * f;
                                    g += cg * f;
                                    b += cb * f;
                                    a += ca * f;
                                }
                            }
                        }
                    }
                    //kernel loop end

                    temp.SetPixel(j, i, Color.FromArgb((int)Util.clamp(a, 0, 255), (int)Util.clamp(r, 0, 255), (int)Util.clamp(g, 0, 255), (int)Util.clamp(b, 0, 255)));
                }
            }
            return temp;

        }

        /// <summary>
        /// #### Adjust [-255,255 for each channel]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="pr">The pr.</param>
        /// <param name="pg">The pg.</param>
        /// <param name="pb">The pb.</param>
        /// <param name="pa">The pa.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Adjust(BitmapWorker image, float pr, float pg, float pb, float pa)
        {
            float cr = 0, cg = 0, cb = 0, ca = 0;
            pr /= 100; pg /= 100; pb /= 100; pa /= 100;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    if (pr > 0) cr += (255 - cr) * pr; else cr -= cr * Math.Abs(pr);
                    if (pg > 0) cg += (255 - cg) * pg; else cg -= cg * Math.Abs(pg);
                    if (pb > 0) cb += (255 - cb) * pb; else cb -= cb * Math.Abs(pb);
                    if (pa > 0) ca += (255 - ca) * pa; else ca -= ca * Math.Abs(pa);
                    /*
                    cr *= (1.0f + pr);
                    cg *= (1.0f + pg);
                    cb *= (1.0f + pb);
                    ca *= (1.0f + ca);
                    */


                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255), (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Brighten [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Brighten(BitmapWorker image, float p)
        {
            p = Util.normalize(p, -255, 255, -100, 100);
            float cr = 0, cg = 0, cb = 0, ca = 0;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr += (p);
                    cg += (p);
                    cb += (p);
                    ca += (p);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255), (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Alpha [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Alpha(BitmapWorker image, float p)
        {
            p = Util.normalize(p, 0, 255, -100, 100);
            float cr = 0, cg = 0, cb = 0, ca =0;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    ca = (p);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Saturate [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Saturate(BitmapWorker image, float p)
        {

            p = Util.normalize(p, 0, 2, -100, 100);
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;
                    float avg = (cr + cg + cb) / 3;

                    cr = avg + p * (cr - avg);
                    cg = avg + p * (cg - avg);
                    cb = avg + p * (cb - avg);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Invert
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Invert(BitmapWorker image)
        {
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr = 255 - cr;
                    cg = 255 - cg;
                    cb = 255 - cb;

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Posterize [1, 255]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Posterize(BitmapWorker image, float p)
        {
            p = Util.clamp(p, 1, 255);
            int step = (int)Math.Floor(255 / p);
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;


                    cr = (float)Math.Floor(cr / (float)(step)) * step;
                    cg = (float)Math.Floor(cg / (float)(step)) * step;
                    cb = (float)Math.Floor(cb / (float)(step)) * step;

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Gamma [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Gamma(BitmapWorker image, float p)
        {
            p = Util.normalize(p, 0, 2, -100, 100);

            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr = (float)Math.Pow(cr, p);
                    cg = (float)Math.Pow(cg, p);
                    cb = (float)Math.Pow(cb, p);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }


        /// <summary>
        /// Contrasts the c.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="c">The c.</param>
        /// <returns>System.Single.</returns>
        static float ContrastC(float f, float c) { return (f - 0.5f) * c + 0.5f; }

        /// <summary>
        /// #### Constrast [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Contrast(BitmapWorker image, float p)
        {
            p = Util.normalize(p, 0, 2, -100, 100);

            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr = 255 * ContrastC(cr / 255, p);
                    cg = 255 * ContrastC(cg / 255, p);
                    cb = 255 * ContrastC(cb / 255, p);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Sepia
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Sepia(BitmapWorker image)
        {
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;
                    float tcr = cr, tcg = cg, tcb = cb;
                    cr = (tcr * 0.393f) + (tcg * 0.769f) + (tcb * 0.189f);
                    cg = (tcr * 0.349f) + (tcg * 0.686f) + (tcb * 0.168f);
                    cb = (tcr * 0.272f) + (tcg * 0.534f) + (tcb * 0.131f);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// #### Subtract [No Range]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Subtract(BitmapWorker image)
        {
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr -= cr;
                    cg -= cg;
                    cb -= cb;

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }


        /// <summary>
        /// #### Fill [No Range]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Fill(BitmapWorker image, int r, int g, int b)
        {
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr = r;
                    cg = g;
                    cb = b;

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }



        /// <summary>
        /// #### Blur ['simple', 'gaussian']
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Blur(BitmapWorker image, string p)
        {

            BitmapWorker result;
            if (p == "simple")
            {
                result = Convolve(image, new float[,]{
                {1.0f/9, 1.0f/9, 1.0f/9},
                {1.0f/9, 1.0f/9, 1.0f/9},
                {1.0f/9, 1.0f/9, 1.0f/9}
                }, 1, 1
                );
            }
            else //gaussian
            {
                result = Convolve(image, new float[,]{
                {1.0f/273, 4.0f/273, 7.0f/273, 4.0f/273, 1.0f/273},
                {4.0f/273, 16.0f/273, 26.0f/273, 16.0f/273, 4.0f/273},
                {7.0f/273, 26.0f/273, 41.0f/273, 26.0f/273, 7.0f/273},
                {4.0f/273, 16.0f/273, 26.0f/273, 16.0f/273, 4.0f/273},             
                {1.0f/273, 4.0f/273, 7.0f/273, 4.0f/273, 1.0f/273}
                }, 2, 2);
            }

            return result;
        }

        /// <summary>
        /// #### Sharpen
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Shapern(BitmapWorker image)
        {
            BitmapWorker result;

            result = Convolve(image, new float[,]{
            {0.0f, -0.2f,  0.0f},
            {-0.2f, 1.8f, -0.2f},
            {0.0f, -0.2f,  0.0f}
            }, 1, 1
            );


            return result;
        }

        /// <summary>
        /// Curveses the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="s">The s.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="e">The e.</param>
        /// <returns>BitmapWorker.</returns>
        static BitmapWorker Curves(BitmapWorker image, Point s, Point c1, Point c2, Point e)
        {
            Bezier bezier = new Bezier(s, c1, c2, e);
            int[] points = bezier.genColorTable();

            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    cr = points[(int)cr];
                    cg = points[(int)cg];
                    cb = points[(int)cb];

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;

        }

        /// <summary>
        /// #### Expose [-100, 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Expose(BitmapWorker image, float p)
        {

            p = Util.normalize(p, -1, 1, -100, 100);
            Point c1 = new Point(0, (int)(255 * p));
            Point c2 = new Point((int)(255 - (255 * p)), 255);
            return Curves(image, new Point(0, 0), c1, c2, new Point(255, 255));
        }

        /// <summary>
        /// #### Vignette
        /// (red,green,blue) of the vignette effect to apply
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Vignetter(BitmapWorker image, int r, int g, int b)
        {
            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width(),
            centerw = w / 2,
            centerh = h / 2,
            maxdist = dist(0, 0, centerw, centerh);

            
            maxdist = (int)(maxdist*0.6f);
            int radius = maxdist / 2;

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;
                    int distance = dist(i, j, centerw, centerh);
                    distance = (distance>radius)?distance-radius:0;

                    float ratio = ((distance / (float)(maxdist)));
                    cr = (1 - ratio) * cr + (ratio * r);
                    cg = (1 - ratio) * cg + (ratio * g);
                    cb = (1 - ratio) * cb + (ratio * b);

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        /// <summary>
        /// Dists the specified x1.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <returns>System.Int32.</returns>
        static int dist(int x1, int y1, int x2, int y2)
        {
            return (int) Math.Sqrt((Math.Abs(x1-x2)*Math.Abs(x1-x2) + Math.Abs(y1-y2)*Math.Abs(y1-y2)));
            //return approx_distance(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        /*FAST APPROX OF DISTANCE
        http://www.flipcode.com/archives/Fast_Approximate_Distance_Functions.shtml
        */

        /// <summary>
        /// Approxes the distance.
        /// </summary>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <returns>System.Int32.</returns>
        static int approx_distance(int dx, int dy)
        {
            int min, max, approx;

            if (dx < 0) dx = -dx;
            if (dy < 0) dy = -dy;

            if (dx < dy)
            {
                min = dx;
                max = dy;
            }
            else
            {
                min = dy;
                max = dx;
            }

            approx = (max * 1007) + (min * 441);
            if (max < (min << 4))
                approx -= (max * 40);

            // add 512 for proper rounding
            return ((approx + 512) >> 10);
        }


        /// <summary>
        /// #### Noise [0 - 100]
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="p">The p.</param>
        /// <returns>BitmapWorker.</returns>
        public static BitmapWorker Noise(BitmapWorker image, int p)
        {
            int adjust = (int)(p * 2.55f);
            Random rand = new Random(adjust);
            int temprand = 0;

            float cr = 0, cg = 0, cb = 0, ca;
            int i = 0, j = 0,
            h = image.Height(),
            w = image.Width();

            for (i = 0; i < w; i++)
            {
                for (j = 0; j < h; j++)
                {
                    Color temp = image.GetPixel(i, j);
                    cr = temp.R; cg = temp.G; cb = temp.B; ca = temp.A;

                    temprand = rand.Next(adjust * -1, adjust);

                    cr += temprand;
                    cg += temprand;
                    cb += temprand;

                    image.SetPixel(i, j, Color.FromArgb((int)Util.clamp(ca, 0, 255), (int)Util.clamp(cr, 0, 255),
                        (int)Util.clamp(cg, 0, 255), (int)Util.clamp(cb, 0, 255)));
                }
            }
            return image;
        }

        
    }
}
