// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="EvaluateAndCalculate.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //string e = "10+10*4".Evaluate();
        //double d = "10+10*4".Calculate();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// JavaScript style Eval for simple calculations
        /// http://www.osix.net/modules/article/?id=761
        /// This is a safe evaluation.  IE will not allow for injection.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        public static string Evaluate(this string e)
        {
            Func<string, bool> VerifyAllowed = e1 =>
            {
                string allowed = "0123456789+-*/()%.,";
                for (int i = 0; i < e1.Length; i++)
                {
                    if (allowed.IndexOf("" + e1[i]) == -1)
                    {
                        return false;
                    }
                }
                return true;
            };

            if (e.Length == 0) { return string.Empty; }
            if (!VerifyAllowed(e)) { return "String contains illegal characters"; }
            if (e[0] == '-') { e = "0" + e; }
            string res = "";
            try
            {
                res = Calculate(e).ToString();
            }
            catch
            {
                return "The call caused an exception";
            }
            return res;
        }

        /// <summary>
        /// JavaScript Eval Calculations for simple calculations
        /// http://www.osix.net/modules/article/?id=761
        /// This is an unsafe calculation. IE may allow for injection.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>System.Double.</returns>
        public static double Calculate(this string e)
        {
            e = e.Replace(".", ",");
            if (e.IndexOf("(") != -1)
            {
                int a = e.LastIndexOf("(");
                int b = e.IndexOf(")", a);
                double middle = Calculate(e.Substring(a + 1, b - a - 1));
                return Calculate(e.Substring(0, a) + middle.ToString() + e.Substring(b + 1));
            }
            double result = 0;
            string[] plus = e.Split('+');
            if (plus.Length > 1)
            {
                // there were some +
                result = Calculate(plus[0]);
                for (int i = 1; i < plus.Length; i++)
                {
                    result += Calculate(plus[i]);
                }
                return result;
            }
            else
            {
                // no +
                string[] minus = plus[0].Split('-');
                if (minus.Length > 1)
                {
                    // there were some -
                    result = Calculate(minus[0]);
                    for (int i = 1; i < minus.Length; i++)
                    {
                        result -= Calculate(minus[i]);
                    }
                    return result;
                }
                else
                {
                    // no -
                    string[] mult = minus[0].Split('*');
                    if (mult.Length > 1)
                    {
                        // there were some *
                        result = Calculate(mult[0]);
                        for (int i = 1; i < mult.Length; i++)
                        {
                            result *= Calculate(mult[i]);
                        }
                        return result;
                    }
                    else
                    {
                        // no *
                        string[] div = mult[0].Split('/');
                        if (div.Length > 1)
                        {
                            // there were some /
                            result = Calculate(div[0]);
                            for (int i = 1; i < div.Length; i++)
                            {
                                result /= Calculate(div[i]);
                            }
                            return result;
                        }
                        else
                        {
                            // no /
                            string[] mod = mult[0].Split('%');
                            if (mod.Length > 1)
                            {
                                // there were some %
                                result = Calculate(mod[0]);
                                for (int i = 1; i < mod.Length; i++)
                                {
                                    result %= Calculate(mod[i]);
                                }
                                return result;
                            }
                            else
                            {
                                // no %
                                return double.Parse(e);
                            }
                        }
                    }
                }
            }
        }

    }
}
