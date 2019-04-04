// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-14-2018
// ***********************************************************************
// <copyright file="To.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// A portal to string transformation using IStringTransformer
    /// </summary>
    public static class To
    {
        /// <summary>
        /// Transforms a string using the provided transformers. Transformations are applied in the provided order.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="transformers">The transformers.</param>
        /// <returns>System.String.</returns>
        public static string Transform(this string input, params IStringTransformer[] transformers)
        {
            return transformers.Aggregate(input, (current, stringTransformer) => stringTransformer.Transform(current));
        }

        /// <summary>
        /// Changes string to title case
        /// </summary>
        /// <value>The title case.</value>
        /// <example>
        /// "INvalid caSEs arE corrected" -&gt; "Invalid Cases Are Corrected"
        /// </example>
        public static IStringTransformer TitleCase
        {
            get
            {
                return new ToTitleCase();
            }
        }

        /// <summary>
        /// Changes the string to lower case
        /// </summary>
        /// <value>The lower case.</value>
        /// <example>
        /// "Sentence casing" -&gt; "sentence casing"
        /// </example>
        public static IStringTransformer LowerCase
        {
            get
            {
                return new ToLowerCase();
            }
        }

        /// <summary>
        /// Changes the string to upper case
        /// </summary>
        /// <value>The upper case.</value>
        /// <example>
        /// "lower case statement" -&gt; "LOWER CASE STATEMENT"
        /// </example>
        public static IStringTransformer UpperCase
        {
            get
            {
                return new ToUpperCase();
            }
        }

        /// <summary>
        /// Changes the string to sentence case
        /// </summary>
        /// <value>The sentence case.</value>
        /// <example>
        /// "lower case statement" -&gt; "Lower case statement"
        /// </example>
        public static IStringTransformer SentenceCase
        {
            get
            {
                return new ToSentenceCase();
            }
        }
    }
}
