// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Format.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Text;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string greeting = "Hello {0}, my name is {1}, and I own you."


        //Console.WriteLine(greeting.Format("Adam", "Microsoft"))

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Shortcut for System.String.Format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The argument.</param>
        /// <param name="additionalArgs">The additional arguments.</param>
        /// <returns>System.String.</returns>
        public static string Format(this string format, object arg, params object[] additionalArgs)
        {
            if (additionalArgs == null || additionalArgs.Length == 0)
            {
                return string.Format(format, arg);
            }
            else
            {
                return string.Format(format, new object[] { arg }.Concat(additionalArgs).ToArray());
            }
        }

        //---------------------------------Implementation-----------------------------//

        //string date = "20101012";
        //date.Formating("####/##/##")

        //---------------------------------Implementation-----------------------------//


        /// <summary>
        /// Formating the string with a custom user-defined format.
        /// # sign is input characters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="format">the format string</param>
        /// <returns>formated string</returns>
        public static string Formating(this string input, string format)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            StringBuilder output = new StringBuilder();
            int j = 0;
            for (int i = 0; i < format.Length; i++)
            {
                switch (format[i])
                {
                    case '#':
                        output.Append(input[i - j]);
                        break;
                    default:
                        output.Append(format[i]);
                        j++;
                        break;
                }
            }
            return output.ToString();
        }

    }
}
