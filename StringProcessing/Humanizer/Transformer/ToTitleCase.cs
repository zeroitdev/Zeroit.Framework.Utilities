// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ToTitleCase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;

namespace Zeroit.Framework.Utilities.StringProcessing.Humanizer
{
    /// <summary>
    /// Class ToTitleCase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.StringProcessing.Humanizer.IStringTransformer" />
    class ToTitleCase : IStringTransformer
    {
        /// <summary>
        /// Transform the input
        /// </summary>
        /// <param name="input">String to be transformed</param>
        /// <returns>System.String.</returns>
        public string Transform(string input)
        {
            var words = input.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == 0 || AllCapitals(word))
                    result.Add(word);
                else if(word.Length == 1)
                    result.Add(word.ToUpper());
                else 
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
            }

            return string.Join(" ", result);
        }

        /// <summary>
        /// Alls the capitals.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        static bool AllCapitals(string input)
        {
            return input.ToCharArray().All(char.IsUpper);
        }
    }
}