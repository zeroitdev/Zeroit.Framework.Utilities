// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BlurFilter.cs" company="Zeroit Dev Technologies">
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
    /// 3x3 Blur Filter
    /// </summary>
    public class Blur3x3Filter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Blur3x3Filter"; }
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
            new double[,] { { 0.0, 0.2, 0.0, }, 
                            { 0.2, 0.2, 0.2, }, 
                            { 0.0, 0.2, 0.2, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// 5x5 Blur Filter
    /// </summary>
    public class Blur5x5Filter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Blur5x5Filter"; }
        }

        private double factor = 1.0 / 13.0;

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
            new double[,] { { 0, 0, 1, 0, 0, }, 
                            { 0, 1, 1, 1, 0, }, 
                            { 1, 1, 1, 1, 1, },
                            { 0, 1, 1, 1, 0, },
                            { 0, 0, 1, 0, 0, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// A 3x3 Gausian Blur Filter
    /// </summary>
    public class Gaussian3x3BlurFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Gaussian3x3BlurFilter"; }
        }

        private double factor = 1.0 / 16.0;

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
            new double[,] { { 1, 2, 1, }, 
                            { 2, 4, 2, }, 
                            { 1, 2, 1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// A 5x5 Gaussian Blur Filter
    /// </summary>
    public class Gaussian5x5BlurFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Gaussian5x5BlurFilter"; }
        }

        private double factor = 1.0 / 159.0;

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
            new double[,] { { 2, 04, 05, 04, 2 }, 
                            { 4, 09, 12, 09, 4 }, 
                            { 5, 12, 15, 12, 5 },
                            { 4, 09, 12, 09, 4 },
                            { 2, 04, 05, 04, 2 }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// A Motion Blur Filter
    /// </summary>
    public class MotionBlurFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "MotionBlurFilter"; }
        }

        private double factor = 1.0 / 18.0;

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
            new double[,] { {1, 0, 0, 0, 0, 0, 0, 0, 1,},
                            {0, 1, 0, 0, 0, 0, 0, 1, 0,},
                            {0, 0, 1, 0, 0, 0, 1, 0, 0,},
                            {0, 0, 0, 1, 0, 1, 0, 0, 0,},
                            {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                            {0, 0, 0, 1, 0, 1, 0, 0, 0,},
                            {0, 0, 1, 0, 0, 0, 1, 0, 0,},
                            {0, 1, 0, 0, 0, 0, 0, 1, 0,},
                            {1, 0, 0, 0, 0, 0, 0, 0, 1,}, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Motion Blur Left To Right Filter
    /// </summary>
    public class MotionBlurLeftToRightFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "MotionBlurLeftToRightFilter"; }
        }

        private double factor = 1.0 / 9.0;

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
            new double[,] { {1, 0, 0, 0, 0, 0, 0, 0, 0,},
                            {0, 1, 0, 0, 0, 0, 0, 0, 0,},
                            {0, 0, 1, 0, 0, 0, 0, 0, 0,},
                            {0, 0, 0, 1, 0, 0, 0, 0, 0,},
                            {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                            {0, 0, 0, 0, 0, 1, 0, 0, 0,},
                            {0, 0, 0, 0, 0, 0, 1, 0, 0,},
                            {0, 0, 0, 0, 0, 0, 0, 1, 0,},
                            {0, 0, 0, 0, 0, 0, 0, 0, 1,}, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Motion Blur Right to Left Filter
    /// </summary>
    public class MotionBlurRightToLeftFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "MotionBlurRightToLeftFilter"; }
        }

        private double factor = 1.0 / 9.0;

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
            new double[,] { {0, 0, 0, 0, 0, 0, 0, 0, 1,},
                            {0, 0, 0, 0, 0, 0, 0, 1, 0,},
                            {0, 0, 0, 0, 0, 0, 1, 0, 0,},
                            {0, 0, 0, 0, 0, 1, 0, 0, 0,},
                            {0, 0, 0, 0, 1, 0, 0, 0, 0,},
                            {0, 0, 0, 1, 0, 0, 0, 0, 0,},
                            {0, 0, 1, 0, 0, 0, 0, 0, 0,},
                            {0, 1, 0, 0, 0, 0, 0, 0, 0,},
                            {1, 0, 0, 0, 0, 0, 0, 0, 0,}, };
        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
