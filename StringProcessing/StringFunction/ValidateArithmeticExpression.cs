// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ValidateArithmeticExpression.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string s = "(2+5)/3*(1*6)";
        //s.ValidateArithmeticExpression();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// The arithmetic expression
        /// </summary>
        static Regex ArithmeticExpression = new Regex(@"(?x)
                ^
                (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                (?>(?:
                    [-+*/]
                    (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                )*)
                (?(p)(?!))
                $
            ");
        /// <summary>
        /// Validates the arithmetic expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ValidateArithmeticExpression(this string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return false;
            return ArithmeticExpression.IsMatch(expression);
        }

    }
}
