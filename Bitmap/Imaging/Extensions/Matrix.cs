// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Matrix.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging
{

    /// <summary>
    /// A class Collection for Matrix computations
    /// </summary>
    public static class Matrix
    {
        /// <summary>
        /// Rotate Matrix
        /// </summary>
        /// <param name="baseKernel">Set Base Kernel</param>
        /// <param name="degrees">Set Degrees</param>
        /// <returns></returns>
        public static double[, ,] RotateMatrix(double[,] baseKernel, 
                                                    double degrees)
        {
            double[, ,] kernel = new double[(int)(360 / degrees), 
               baseKernel.GetLength(0), baseKernel.GetLength(1)];

            int xOffset = baseKernel.GetLength(1) / 2;
            int yOffset = baseKernel.GetLength(0) / 2;

            for (int y = 0; y < baseKernel.GetLength(0); y++)
            {
                for (int x = 0; x < baseKernel.GetLength(1); x++)
                {
                    for (int compass = 0; compass < 
                        kernel.GetLength(0); compass++)
                    {
                        double radians = compass * degrees *
                                         Math.PI / 180.0;

                        int resultX = (int)(Math.Round((x - xOffset) *
                                   Math.Cos(radians) - (y - yOffset) *
                                   Math.Sin(radians)) + xOffset);

                        int resultY = (int)(Math.Round((x - xOffset) *
                                   Math.Sin(radians) + (y - yOffset) *
                                   Math.Cos(radians)) + yOffset);

                        kernel[compass, resultY, resultX] =
                                                    baseKernel[y, x];
                    }
                }
            }

            return kernel;
        }
        /// <summary>
        /// Prewitt 3x3x4 Matrix
        /// </summary>
        public static double[, ,] Prewitt3x3x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -1,  0,  1, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Prewitt 3x3x8 Matrix
        /// </summary>
        public static double[, ,] Prewitt3x3x8
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -1,  0,  1, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 45);


                return kernel;
            }
        }

        /// <summary>
        /// Prewitt 5x5x4 Matrix
        /// </summary>
        public static double[, ,] Prewitt5x5x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -2, -1,  0,  1, 2, }, 
                  { -2, -1,  0,  1, 2, },
                  { -2, -1,  0,  1, 2, },
                  { -2, -1,  0,  1, 2, }, 
                  { -2, -1,  0,  1, 2, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Prewitt 3x3 Horizontal Matrix
        /// </summary>
        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                    { -1,  0,  1, },
                    { -1,  0,  1, }, };
            }
        }

        /// <summary>
        /// Prewitt 3x3 Vertical Matrix
        /// </summary>
        public static double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                    {  0,  0,  0, },
                    { -1, -1, -1, }, };
            }
        }

        /// <summary>
        /// Kirsch 3x3x4 Matrix
        /// </summary>
        public static double[, ,] Kirsch3x3x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -3, -3,  5, }, 
                  { -3,  0,  5, }, 
                  { -3, -3,  5, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Kirsch 3x3x8 Matrix
        /// </summary>
        public static double[, ,] Kirsch3x3x8
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -3, -3,  5, }, 
                  { -3,  0,  5, }, 
                  { -3, -3,  5, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 45);


                return kernel;
            }
        }

        /// <summary>
        /// Kirsch 3x3 Horizontal Matrix
        /// </summary>
        public static double[,] Kirsch3x3Horizontal
        {
            get
            {
                return new double[,]
                { {  5,  5,  5, },
                    { -3,  0, -3, },
                    { -3, -3, -3, }, };
            }
        }

        /// <summary>
        /// Kirsch 3x3 Vertical Matrix
        /// </summary>
        public static double[,] Kirsch3x3Vertical
        {
            get
            {
                return new double[,]
                { {  5, -3, -3, },
                    {  5,  0, -3, },
                    {  5, -3, -3, }, };
            }
        }

        /// <summary>
        /// Sobel 3x3x4 Matrix
        /// </summary>
        public static double[, ,] Sobel3x3x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -2,  0,  2, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Sobel 3x3x8 Matrix
        /// </summary>
        public static double[, ,] Sobel3x3x8
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -2,  0,  2, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 45);


                return kernel;
            }
        }

        /// <summary>
        /// Sobel 5x5x4 Matrix
        /// </summary>
        public static double[, ,] Sobel5x5x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { {  -5,  -4,  0,   4,  5, }, 
                  {  -8, -10,  0,  10,  8, },
                  { -10, -20,  0,  20, 10, },
                  {  -8, -10,  0,  10,  8, }, 
                  {  -5,  -4,  0,   4,  5, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Sobel 3x3 Horizontal Matrix
        /// </summary>
        public static double[,] Sobel3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                    { -2,  0,  2, },
                    { -1,  0,  1, }, };
            }
        }

        /// <summary>
        /// Sobel 3x3 Vertical Matrix
        /// </summary>
        public static double[,] Sobel3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                    {  0,  0,  0, },
                    { -1, -2, -1, }, };
            }
        }
        
        /// <summary>
        /// Scharr 3x3x4 Matrix
        /// </summary>
        public static double[, ,] Scharr3x3x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -3,  0,  3, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Scharr 3x3x8 Matrix
        /// </summary>
        public static double[, ,] Scharr3x3x8
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { { -1,  0,  1, }, 
                  { -3,  0,  3, }, 
                  { -1,  0,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 45);


                return kernel;
            }
        }

        /// <summary>
        /// Scharr 5x5x4 Matrix
        /// </summary>
        public static double[, ,] Scharr5x5x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { {  -1,  -1,  0,   1,  1, }, 
                  {  -2,  -2,  0,   2,  2, },
                  {  -3,  -6,  0,   6,  3, },
                  {  -2,  -2,  0,   2,  2, }, 
                  {  -1,  -1,  0,   1,  1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Isotropic 3x3x4 Matrix
        /// </summary>
        public static double[, ,] Isotropic3x3x4
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { {            -1,  0,             1, }, 
                  { -Math.Sqrt(2),  0,  Math.Sqrt(2), }, 
                  {            -1,  0,             1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 90);


                return kernel;
            }
        }

        /// <summary>
        /// Isotropic 3x3x8 Matrix
        /// </summary>
        public static double[, ,] Isotropic3x3x8
        {
            get
            {
                double[,] baseKernel = new double[,] 
                { {            -1,  0,             1, }, 
                  { -Math.Sqrt(2),  0,  Math.Sqrt(2), }, 
                  {            -1,  0,             1, }, };

                double[, ,] kernel = RotateMatrix(baseKernel, 45);


                return kernel;
            }
        }

        /// <summary>
        /// Gaussian 3x3 Matrix
        /// </summary>
        public static double[,] Gaussian3x3
        {
            get
            {
                return new double[,]
                { { 1, 2, 1, },
                    { 2, 4, 2, },
                    { 1, 2, 1, }, };
            }
        }

        /// <summary>
        /// Gaussian 5x5 Matrix
        /// </summary>
        public static double[,] Gaussian5x5
        {
            get
            {
                return new double[,]
                { { 2, 04, 05, 04, 2 },
                    { 4, 09, 12, 09, 4 },
                    { 5, 12, 15, 12, 5 },
                    { 4, 09, 12, 09, 4 },
                    { 2, 04, 05, 04, 2 }, };
            }
        }

        /// <summary>
        /// Gaussian 7x7 Matrix
        /// </summary>
        public static double[,] Gaussian7x7
        {
            get
            {
                return new double[,]
                { { 1,  1,  2,  2,  2,  1,  1, },
                    { 1,  2,  2,  4,  2,  2,  1, },
                    { 2,  2,  4,  8,  4,  2,  2, },
                    { 2,  4,  8, 16,  8,  4,  2, },
                    { 2,  2,  4,  8,  4,  2,  2, },
                    { 1,  2,  2,  4,  2,  2,  1, },
                    { 1,  1,  2,  2,  2,  1,  1, }, };
            }
        }

        /// <summary>
        /// Gaussian 5x5 Type1 Matrix
        /// </summary>
        public static double[,] Gaussian5x5Type1
        {
            get
            {
                return new double[,]
                { { 2, 04, 05, 04, 2 },
                    { 4, 09, 12, 09, 4 },
                    { 5, 12, 15, 12, 5 },
                    { 4, 09, 12, 09, 4 },
                    { 2, 04, 05, 04, 2 }, };
            }
        }

        /// <summary>
        /// Gaussian 5x5 Type2 Matrix
        /// </summary>
        public static double[,] Gaussian5x5Type2
        {
            get
            {
                return new double[,]
                { {  1,   4,  6,  4,  1 },
                    {  4,  16, 24, 16,  4 },
                    {  6,  24, 36, 24,  6 },
                    {  4,  16, 24, 16,  4 },
                    {  1,   4,  6,  4,  1 }, };
            }
        }

        /// <summary>
        /// GaussianBlur 3x3 Matrix
        /// </summary>
        public static double[,] GaussianBlur3x3
        {
            get
            {
                return new double[,]
                { { 1, 2, 1, },
                  { 2, 4, 2, },
                  { 1, 2, 1, }, };
            }
        }

        /// <summary>
        /// GaussianBlur 5x5 Matrix
        /// </summary>
        public static double[,] GaussianBlur5x5
        {
            get
            {
                return new double[,]
                { { 2, 04, 05, 04, 2 },
                  { 4, 09, 12, 09, 4 },
                  { 5, 12, 15, 12, 5 },
                  { 4, 09, 12, 09, 4 },
                  { 2, 04, 05, 04, 2 }, };
            }
        }

        /// <summary>
        /// LowPass 3x3 Matrix
        /// </summary>
        public static double[,] LowPass3x3
        {
            get
            {
                return new double[,]
                { { 1, 2, 1, },
                    { 2, 4, 2, },
                    { 1, 2, 1, }, };
            }
        }

        /// <summary>
        /// LowPass 5x5 Matrix
        /// </summary>
        public static double[,] LowPass5x5
        {
            get
            {
                return new double[,]
                { { 1, 1,  1, 1, 1,},
                    { 1, 4,  4, 4, 1,},
                    { 1, 4, 12, 4, 1,},
                    { 1, 4,  4, 4, 1,},
                    { 1, 1,  1, 1, 1,}, };
            }
        }

        /// <summary>
        /// Laplacian 3x3 Matrix
        /// </summary>
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1,  },
                    { -1,  8, -1,  },
                    { -1, -1, -1,  }, };
            }
        }

        /// <summary>
        /// Laplacian 5x5 Matrix
        /// </summary>
        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                    { -1, -1, -1, -1, -1, },
                    { -1, -1, 24, -1, -1, },
                    { -1, -1, -1, -1, -1, },
                    { -1, -1, -1, -1, -1  }, };
            }
        }

        /// <summary>
        /// Laplacian Of Gaussian Matrix
        /// </summary>
        public static double[,] LaplacianOfGaussian
        {
            get
            {
                return new double[,]
                { {  0,   0, -1,  0,  0 },
                    {  0,  -1, -2, -1,  0 },
                    { -1,  -2, 16, -2, -1 },
                    {  0,  -1, -2, -1,  0 },
                    {  0,   0, -1,  0,  0 }, };
            }
        }

        /// <summary>
        /// Mean 3x3 Matrix
        /// </summary>
        public static double[,] Mean3x3
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, },
                  { 1, 1, 1, },
                  { 1, 1, 1, }, };
            }
        }

        /// <summary>
        /// Mean 5x5 Matrix
        /// </summary>
        public static double[,] Mean5x5
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1}, };
            }
        }
        
        /// <summary>
        /// Mean 7x7 Matrix
        /// </summary>
        public static double[,] Mean7x7
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1}, };
            }
        }

        /// <summary>
        /// Mean 9x9 Matrix
        /// </summary>
        public static double[,] Mean9x9
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1, 1, 1, 1, 1}, };
            }
        }

        /// <summary>
        /// Motion Blur 5x5 Matrix
        /// </summary>
        public static double[,] MotionBlur5x5
        {
            get
            {
                return new double[,]
                { { 1, 0, 0, 0, 1},
                  { 0, 1, 0, 1, 0},
                  { 0, 0, 1, 0, 0},
                  { 0, 1, 0, 1, 0},
                  { 1, 0, 0, 0, 1}, };
            }
        }

        /// <summary>
        /// Motion Blur 5x5 At 45 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur5x5At45Degrees
        {
            get
            {
                return new double[,]
                { { 0, 0, 0, 0, 1},
                  { 0, 0, 0, 1, 0},
                  { 0, 0, 1, 0, 0},
                  { 0, 1, 0, 0, 0},
                  { 1, 0, 0, 0, 0}, };
            }
        }

        /// <summary>
        /// Motion Blur 5x5 At 135 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur5x5At135Degrees
        {
            get
            {
                return new double[,]
                { { 1, 0, 0, 0, 0},
                  { 0, 1, 0, 0, 0},
                  { 0, 0, 1, 0, 0},
                  { 0, 0, 0, 1, 0},
                  { 0, 0, 0, 0, 1}, };
            }
        }

        /// <summary>
        /// Motion Blur 7x7 Matrix
        /// </summary>
        public static double[,] MotionBlur7x7
        {
            get
            {
                return new double[,]
                { { 1, 0, 0, 0, 0, 0, 1},
                  { 0, 1, 0, 0, 0, 1, 0},
                  { 0, 0, 1, 0, 1, 0, 0},
                  { 0, 0, 0, 1, 0, 0, 0},
                  { 0, 0, 1, 0, 1, 0, 0},
                  { 0, 1, 0, 0, 0, 1, 0},
                  { 1, 0, 0, 0, 0, 0, 1}, };
            }
        }

        /// <summary>
        /// Motion Blur 7x7 At 45 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur7x7At45Degrees
        {
            get
            {
                return new double[,]
                { { 0, 0, 0, 0, 0, 0, 1},
                  { 0, 0, 0, 0, 0, 1, 0},
                  { 0, 0, 0, 0, 1, 0, 0},
                  { 0, 0, 0, 1, 0, 0, 0},
                  { 0, 0, 1, 0, 0, 0, 0},
                  { 0, 1, 0, 0, 0, 0, 0},
                  { 1, 0, 0, 0, 0, 0, 0}, };
            }
        }

        /// <summary>
        /// Motion Blur 7x7 At 135 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur7x7At135Degrees
        {
            get
            {
                return new double[,]
                { { 1, 0, 0, 0, 0, 0, 0},
                  { 0, 1, 0, 0, 0, 0, 0},
                  { 0, 0, 1, 0, 0, 0, 0},
                  { 0, 0, 0, 1, 0, 0, 0},
                  { 0, 0, 0, 0, 1, 0, 0},
                  { 0, 0, 0, 0, 0, 1, 0},
                  { 0, 0, 0, 0, 0, 0, 1}, };
            }
        }

        /// <summary>
        /// Motion Blur 9x9 Matrix
        /// </summary>
        public static double[,] MotionBlur9x9
        {
            get
            {
                return new double[,]
                { {1, 0, 0, 0, 0, 0, 0, 0, 1,},
                  {0, 1, 0, 0, 0, 0, 0, 1, 0,},
                  {0, 0, 1, 0, 0, 0, 1, 0, 0,},
                  {0, 0, 0, 1, 0, 1, 0, 0, 0,},
                  {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                  {0, 0, 0, 1, 0, 1, 0, 0, 0,},
                  {0, 0, 1, 0, 0, 0, 1, 0, 0,},
                  {0, 1, 0, 0, 0, 0, 0, 1, 0,},
                  {1, 0, 0, 0, 0, 0, 0, 0, 1,}, };
            }
        }

        /// <summary>
        /// Motion Blur 9x9 At 45 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur9x9At45Degrees
        {
            get
            {
                return new double[,]
                { {0, 0, 0, 0, 0, 0, 0, 0, 1,},
                  {0, 0, 0, 0, 0, 0, 0, 1, 0,},
                  {0, 0, 0, 0, 0, 0, 1, 0, 0,},
                  {0, 0, 0, 0, 0, 1, 0, 0, 0,},
                  {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                  {0, 0, 0, 1, 0, 0, 0, 0, 0,},
                  {0, 0, 1, 0, 0, 0, 0, 0, 0,},
                  {0, 1, 0, 0, 0, 0, 0, 0, 0,},
                  {1, 0, 0, 0, 0, 0, 0, 0, 0,}, };
            }
        }

        /// <summary>
        /// Motion Blur 9x9 At 135 Degrees Matrix
        /// </summary>
        public static double[,] MotionBlur9x9At135Degrees
        {
            get
            {
                return new double[,]
                { {1, 0, 0, 0, 0, 0, 0, 0, 0,},
                  {0, 1, 0, 0, 0, 0, 0, 0, 0,},
                  {0, 0, 1, 0, 0, 0, 0, 0, 0,},
                  {0, 0, 0, 1, 0, 0, 0, 0, 0,},
                  {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                  {0, 0, 0, 0, 0, 1, 0, 0, 0,},
                  {0, 0, 0, 0, 0, 0, 1, 0, 0,},
                  {0, 0, 0, 0, 0, 0, 0, 1, 0,},
                  {0, 0, 0, 0, 0, 0, 0, 0, 1,}, };
            }
        }

        /// <summary>
        /// Sharpen 3x3 Matrix
        /// </summary>
        public static double[,] Sharpen3x3
        {
            get
            {
                return new double[,]
                { { -1, -2, -1, },
                    {  2,  4,  2, },
                    {  1,  2,  1, }, };
            }
        }

        /// <summary>
        /// Sharpen 7 to 1 Matrix
        /// </summary>
        public static double[,] Sharpen7To1
        {
            get
            {
                return new double[,]
                { { 1,  1,  1, },
                  { 1, -7,  1, },
                  { 1,  1,  1, }, };
            }
        }

        /// <summary>
        /// Sharpen 9 to 1 Matrix
        /// </summary>
        public static double[,] Sharpen9To1
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, },
                  { -1,  9, -1, },
                  { -1, -1, -1, }, };
            }
        }

        /// <summary>
        /// Sharpen 12 to 1 Matrix
        /// </summary>
        public static double[,] Sharpen12To1
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, },
                  { -1, 12, -1, },
                  { -1, -1, -1, }, };
            }
        }

        /// <summary>
        /// Sharpen 24 to 1 Matrix
        /// </summary>
        public static double[,] Sharpen24To1
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, 24, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, }, };
            }
        }

        /// <summary>
        /// Sharpen 48 to 1 Matrix
        /// </summary>
        public static double[,] Sharpen48To1
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, -1, -1,},
                  { -1, -1, -1, -1, -1, -1, -1,},
                  { -1, -1, -1, -1, -1, -1, -1,},
                  { -1, -1, -1, 48, -1, -1, -1,},
                  { -1, -1, -1, -1, -1, -1, -1,},
                  { -1, -1, -1, -1, -1, -1, -1,},
                  { -1, -1, -1, -1, -1, -1, -1,}, };
            }
        }

        /// <summary>
        /// Sharpen 5 to 4 Matrix
        /// </summary>
        public static double[,] Sharpen5To4
        {
            get
            {
                return new double[,]
                { {  0, -1,  0, },
                  { -1,  5, -1, },
                  {  0, -1,  0, }, };
            }
        }

        /// <summary>
        /// Sharpen 10 to 8 Matrix
        /// </summary>
        public static double[,] Sharpen10To8
        {
            get
            {
                return new double[,]
                { {  0, -2,  0, },
                  { -2, 10, -2, },
                  {  0, -2,  0, }, };
            }
        }

        /// <summary>
        /// Sharpen 11 to 8 Matrix
        /// </summary>
        public static double[,] Sharpen11To8
        {
            get
            {
                return new double[,]
                { {  0, -2,  0, },
                  { -2, 11, -2, },
                  {  0, -2,  0, }, };
            }
        }

        /// <summary>
        /// Sharpen 821 Matrix
        /// </summary>
        public static double[,] Sharpen821
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1,  2,  2,  2, -1, },
                  { -1,  2,  8,  2,  1, },
                  { -1,  2,  2,  2, -1, },
                  { -1, -1, -1, -1, -1, }, };
            }
        }

    }

}
