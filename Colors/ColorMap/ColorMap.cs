// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 12-31-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-31-2018
// ***********************************************************************
// <copyright file="ColorMap.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{

    /// <summary>
    /// Enum Map
    /// </summary>
    public enum Map
    {
        /// <summary>
        /// The autumn
        /// </summary>
        Autumn,
        /// <summary>
        /// The cool
        /// </summary>
        Cool,
        /// <summary>
        /// The jet
        /// </summary>
        Jet,
        /// <summary>
        /// The hot
        /// </summary>
        Hot,
        /// <summary>
        /// The gray
        /// </summary>
        Gray,
        /// <summary>
        /// The spring
        /// </summary>
        Spring,
        /// <summary>
        /// The summer
        /// </summary>
        Summer,
        /// <summary>
        /// The winter
        /// </summary>
        Winter
    }

    /// <summary>
    /// Class ColorMap.
    /// </summary>
    public static class ColorMap
    {

        /// <summary>
        /// Springs the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Spring(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }

            int[,] cmap = new int[colormapLength, 4];
            float[] spring = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                spring[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 255;
                cmap[i, 2] = (int)(255 * spring[i]);
                cmap[i, 3] = 255 - cmap[i, 1];
            }
            return cmap;
        }

        /// <summary>
        /// Summers the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Summer(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }

            int[,] cmap = new int[colormapLength, 4];
            float[] summer = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                summer[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * summer[i]);
                cmap[i, 2] = (int)(255 * 0.5f * (1 + summer[i]));
                cmap[i, 3] = (int)(255 * 0.4f);
            }
            return cmap;
        }

        /// <summary>
        /// Autumns the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Autumn(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }

            int[,] cmap = new int[colormapLength, 4];
            float[] autumn = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                autumn[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 255;
                cmap[i, 2] = (int)(255 * autumn[i]);
                cmap[i, 3] = 0;
            }
            return cmap;
        }

        /// <summary>
        /// Winters the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Winter(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }

            int[,] cmap = new int[colormapLength, 4];
            float[] winter = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                winter[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 0;
                cmap[i, 2] = (int)(255 * winter[i]);
                cmap[i, 3] = (int)(255 * (1.0f - 0.5f * winter[i]));
            }
            return cmap;
        }

        /// <summary>
        /// Grays the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Gray(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }


            int[,] cmap = new int[colormapLength, 4];
            float[] gray = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                gray[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * gray[i]);
                cmap[i, 2] = (int)(255 * gray[i]);
                cmap[i, 3] = (int)(255 * gray[i]);
            }
            return cmap;
        }

        /// <summary>
        /// Jets the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Jet(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }


            int[,] cmap = new int[colormapLength, 4];
            float[,] cMatrix = new float[colormapLength, 3];
            int n = (int)Math.Ceiling(colormapLength / 4.0f);
            int nMod = 0;
            float[] fArray = new float[3 * n - 1];
            int[] red = new int[fArray.Length];
            int[] green = new int[fArray.Length];
            int[] blue = new int[fArray.Length];

            if (colormapLength % 4 == 1)
            {
                nMod = 1;
            }

            for (int i = 0; i < fArray.Length; i++)
            {
                if (i < n)
                    fArray[i] = (float)(i + 1) / n;
                else if (i >= n && i < 2 * n - 1)
                    fArray[i] = 1.0f;
                else if (i >= 2 * n - 1)
                    fArray[i] = (float)(3 * n - 1 - i) / n;
                green[i] = (int)Math.Ceiling(n / 2.0f) - nMod + i;
                red[i] = green[i] + n;
                blue[i] = green[i] - n;
            }

            int nb = 0;
            for (int i = 0; i < blue.Length; i++)
            {
                if (blue[i] > 0)
                    nb++;
            }

            for (int i = 0; i < colormapLength; i++)
            {
                for (int j = 0; j < red.Length; j++)
                {
                    if (i == red[j] && red[j] < colormapLength)
                    {
                        cMatrix[i, 0] = fArray[i - red[0]];
                    }
                }
                for (int j = 0; j < green.Length; j++)
                {
                    if (i == green[j] && green[j] < colormapLength)
                        cMatrix[i, 1] = fArray[i - (int)green[0]];
                }
                for (int j = 0; j < blue.Length; j++)
                {
                    if (i == blue[j] && blue[j] >= 0)
                        cMatrix[i, 2] = fArray[fArray.Length - 1 - nb + i];
                }
            }

            for (int i = 0; i < colormapLength; i++)
            {
                cmap[i, 0] = alphaValue;
                for (int j = 0; j < 3; j++)
                {
                    cmap[i, j + 1] = (int)(cMatrix[i, j] * 255);
                }
            }
            return cmap;
        }

        /// <summary>
        /// Hots the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Hot(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }


            int[,] cmap = new int[colormapLength, 4];
            int n = 3 * colormapLength / 8;
            float[] red = new float[colormapLength];
            float[] green = new float[colormapLength];
            float[] blue = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                if (i < n)
                    red[i] = 1.0f * (i + 1) / n;
                else
                    red[i] = 1.0f;
                if (i < n)
                    green[i] = 0f;
                else if (i >= n && i < 2 * n)
                    green[i] = 1.0f * (i + 1 - n) / n;
                else
                    green[i] = 1f;
                if (i < 2 * n)
                    blue[i] = 0f;
                else
                    blue[i] = 1.0f * (i + 1 - 2 * n) / (colormapLength - 2 * n);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * red[i]);
                cmap[i, 2] = (int)(255 * green[i]);
                cmap[i, 3] = (int)(255 * blue[i]);
            }
            return cmap;
        }

        /// <summary>
        /// Cools the specified colormap length.
        /// </summary>
        /// <param name="colormapLength">Length of the colormap.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <returns>System.Int32[].</returns>
        private static int[,] Cool(int colormapLength = 64, int alphaValue = 255)
        {
            if (alphaValue > 255)
            {
                alphaValue = 255;
            }
            else if (alphaValue < 0)
            {
                alphaValue = 0;
            }


            int[,] cmap = new int[colormapLength, 4];
            float[] cool = new float[colormapLength];
            for (int i = 0; i < colormapLength; i++)
            {
                cool[i] = 1.0f * i / (colormapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * cool[i]);
                cmap[i, 2] = (int)(255 * (1 - cool[i]));
                cmap[i, 3] = 255;
            }
            return cmap;
        }

        /// <summary>
        /// Draws the color map bar.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="str">The string.</param>
        public static void DrawColorMapBar(this Graphics g, int x, int y, int width, int height,
            Map str)
        {
            int[,] cmap = new int[64, 4];
            switch (str)
            {
                case Map.Jet:
                    cmap = Jet();
                    break;
                case Map.Hot:
                    cmap = Hot();
                    break;
                case Map.Gray:
                    cmap = Gray();
                    break;
                case Map.Cool:
                    cmap = Cool();
                    break;
                case Map.Summer:
                    cmap = Summer();
                    break;
                case Map.Autumn:
                    cmap = Autumn();
                    break;
                case Map.Spring:
                    cmap = Spring();
                    break;
                case Map.Winter:
                    cmap = Winter();
                    break;
            }

            int ymin = 0;
            int ymax = 32;
            int dy = height / (ymax - ymin);
            int m = 64;
            for (int i = 0; i < 32; i++)
            {
                int colorIndex = (int)((i - ymin) * m / (ymax - ymin));
                SolidBrush aBrush = new SolidBrush(Color.FromArgb(
                    cmap[colorIndex, 0], cmap[colorIndex, 1],
                    cmap[colorIndex, 2], cmap[colorIndex, 3]));
                g.FillRectangle(aBrush, x, y + i * dy, width, dy);
            }
        }


    }

}