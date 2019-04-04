// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FilterBase.cs" company="Zeroit Dev Technologies">
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
    /// An abstract class base for Convolution Filter
    /// </summary>
    public abstract class ConvolutionFilterBase
    {
        /// <summary>
        /// Get Filter Name
        /// </summary>
        public abstract string FilterName
        {
            get;
        }

        /// <summary>
        /// Get Factor
        /// </summary>
        public abstract double Factor
        {
            get;
        }

        /// <summary>
        /// Get Bias
        /// </summary>
        public abstract double Bias
        {
            get;
        }

        /// <summary>
        /// Get Filter Matrix
        /// </summary>
        public abstract double[,] FilterMatrix
        {
            get;
        }
    }
}
