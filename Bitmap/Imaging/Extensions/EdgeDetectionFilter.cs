// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EdgeDetectionFilter.cs" company="Zeroit Dev Technologies">
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
    /// Edge Detection Filter
    /// </summary>
    public class EdgeDetectionFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "EdgeDetectionFilter"; }
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
                            { -1,  8, -1, }, 
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
    /// Edge Detection 45 Degrees Filter
    /// </summary>
    public class EdgeDetection45DegreeFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "EdgeDetection45DegreeFilter"; }
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
            new double[,] { { -1,  0,  0,  0,  0, }, 
                            {  0, -2,  0,  0,  0, }, 
                            {  0,  0,  6,  0,  0, },
                            {  0,  0,  0, -2,  0, },
                            {  0,  0,  0,  0, -1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }


    /// <summary>
    /// Get Horizontal Edge Detection Filter
    /// </summary>
    public class HorizontalEdgeDetectionFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "HorizontalEdgeDetectionFilter"; }
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
            new double[,] { {  0,  0,  0,  0,  0, }, 
                            {  0,  0,  0,  0,  0, }, 
                            { -1, -1,  2,  0,  0, },
                            {  0,  0,  0,  0,  0, },
                            {  0,  0,  0,  0,  0, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Vertical Edge Detection Filter
    /// </summary>
    public class VerticalEdgeDetectionFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "VerticalEdgeDetectionFilter"; }
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
            new double[,] { {  0,  0, -1,  0,  0, }, 
                            {  0,  0, -1,  0,  0, }, 
                            {  0,  0,  4,  0,  0, },
                            {  0,  0, -1,  0,  0, },
                            {  0,  0, -1,  0,  0, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }


    /// <summary>
    /// Edge Detectrion Top Left Bottom Right Filter
    /// </summary>
    public class EdgeDetectionTopLeftBottomRightFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "EdgeDetectionTopLeftBottomRightFilter"; }
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
            new double[,] { { -5,  0,  0, }, 
                            {  0,  0,  0, }, 
                            {  0,  0,  5, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
