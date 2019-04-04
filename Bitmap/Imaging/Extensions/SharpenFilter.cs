// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SharpenFilter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/

namespace Zeroit.Framework.Utilities.BitmapUtils.Imaging.ImageConvolutionFilters
{
    /// <summary>
    /// A class for Sharpen Filter
    /// </summary>
    public class SharpenFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "SharpenFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1, -1, -1, }, 
                            { -1,  9, -1, }, 
                            { -1, -1, -1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Sharpern 3x3 Filter class
    /// </summary>
    public class Sharpen3x3Filter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Sharpen3x3Filter"; }
        }

        private double factor = 1.0;
        
        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { 0,-1, 0, }, 
                            { -1, 5, -1, }, 
                            { 0,-1, 0, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// A Sharpen 3x3 Factor Filter
    /// </summary>
    public class Sharpen3x3FactorFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Sharpen3x3FactorFilter"; }
        }

        private double factor = 1.0 / 3.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { {  0, -2,  0, }, 
                            { -2, 11, -2, }, 
                            {  0, -2,  0, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Sharpen 5x5 Filter class
    /// </summary>
    public class Sharpen5x5Filter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Sharpen5x5Filter"; }
        }

        private double factor = 1.0 / 8.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1, -1, -1, -1, -1, }, 
                            { -1,  2,  2,  2, -1, }, 
                            { -1,  2,  8,  2,  1, },
                            { -1,  2,  2,  2, -1, },
                            { -1, -1, -1, -1, -1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Intense Sharpen Filter class
    /// </summary>
    public class IntenseSharpenFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "IntenseSharpenFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { 1,  1,  1, }, 
                            { 1, -7,  1, }, 
                            { 1,  1,  1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
