// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EmbossFilter.cs" company="Zeroit Dev Technologies">
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
    /// Emboss Filter
    /// </summary>
    public class EmbossFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "EmbossFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 128.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { 2, 0, 0, }, 
                            { 0,-1, 0, }, 
                            { 0, 0,-1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Emboss 45 Degree Filter 
    /// </summary>
    public class Emboss45DegreeFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "Emboss45DegreeFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 128.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1, -1, 0, }, 
                            { -1,  0, 1, }, 
                            {  0,  1, 1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Emboss Top Left Bottom Right Filter
    /// </summary>
    public class EmbossTopLeftBottomRightFilter : ConvolutionFilterBase
    {

        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "EmbossTopLeftBottomRightFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 128.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1, 0, 0, }, 
                            {  0, 0, 0, }, 
                            {  0, 0, 1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    /// <summary>
    /// Intense Emboss Filter
    /// </summary>
    public class IntenseEmbossFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "IntenseEmbossFilter"; }
        }

        private double factor = 1.0;

        /// <summary>
        /// Get Factor
        /// </summary>
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 128.0;

        /// <summary>
        /// Get Bias
        /// </summary>
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1, -1, -1, -1,  0, }, 
                            { -1, -1, -1,  0,  1, }, 
                            { -1, -1,  0,  1,  1, },
                            { -1,  0,  1,  1,  1, },
                            {  0,  1,  1,  1,  1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
