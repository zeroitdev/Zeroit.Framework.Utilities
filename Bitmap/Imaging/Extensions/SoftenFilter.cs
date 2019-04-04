// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SoftenFilter.cs" company="Zeroit Dev Technologies">
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
    /// Soften Filter class
    /// </summary>
    public class SoftenFilter : ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public override string FilterName
        {
            get { return "SoftenFilter"; }
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
            new double[,] { { 1, 1, 1, }, 
                            { 1, 1, 1, }, 
                            { 1, 1, 1, }, };

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
