// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Truncator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Gets a ITruncator
    /// </summary>
    public static class Truncator
    {
        /// <summary>
        /// Fixed length truncator
        /// </summary>
        /// <value>The length of the fixed.</value>
        public static ITruncator FixedLength
        {
            get
            {
                return new FixedLengthTruncator();
            }
        }

        /// <summary>
        /// Fixed number of characters truncator
        /// </summary>
        /// <value>The fixed number of characters.</value>
        public static ITruncator FixedNumberOfCharacters
        {
            get
            {
                return new FixedNumberOfCharactersTruncator();
            }
        }

        /// <summary>
        /// Fixed number of words truncator
        /// </summary>
        /// <value>The fixed number of words.</value>
        public static ITruncator FixedNumberOfWords
        {
            get
            {
                return new FixedNumberOfWordsTruncator();
            }
        }
    }
}
