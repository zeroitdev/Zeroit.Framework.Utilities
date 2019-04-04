// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="NameFilter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Zeroit.Framework.Utilities.IO.Compression.Core
{
    /// <summary>
    /// NameFilter is a string matching class which allows for both positive and negative
    /// matching.
    /// A filter is a sequence of independant <see cref="Regex"></see> regular expressions separated by semi-colons ';'
    /// Each expression can be prefixed by a plus '+' sign or a minus '-' sign to denote the expression
    /// is intended to include or exclude names.  If neither a plus or minus sign is found include is the default
    /// A given name is tested for inclusion before checking exclusions.  Only names matching an include spec
    /// and not matching an exclude spec are deemed to match the filter.
    /// An empty filter matches any name.
    /// </summary>
    public class NameFilter
	{
        /// <summary>
        /// Construct an instance based on the filter expression passed
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        public NameFilter(string filter)
		{
			this.filter = filter;
			inclusions = new ArrayList();
			exclusions = new ArrayList();
			Compile();
		}

        /// <summary>
        /// Test a string to see if it is a valid regular expression.
        /// </summary>
        /// <param name="e">The expression to test.</param>
        /// <returns>True if expression is a valid <see cref="System.Text.RegularExpressions.Regex" /> false otherwise.</returns>
        public static bool IsValidExpression(string e)
		{
			bool result = true;
			try {
				Regex exp = new Regex(e, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			}
			catch {
				result = false;
			}
			return result;
		}

        /// <summary>
        /// Test an expression to see if it is valid as a filter.
        /// </summary>
        /// <param name="toTest">The filter expression to test.</param>
        /// <returns>True if the expression is valid, false otherwise.</returns>
        public static bool IsValidFilterExpression(string toTest)
		{
			bool result = true;
		
			try
			{
				string[] items = toTest.Split(';');
				for (int i = 0; i < items.Length; ++i) {
					if (items[i] != null && items[i].Length > 0) {
						string toCompile;
			
						if (items[i][0] == '+')
							toCompile = items[i].Substring(1, items[i].Length - 1);
						else if (items[i][0] == '-')
							toCompile = items[i].Substring(1, items[i].Length - 1);
						else
							toCompile = items[i];
			
						Regex testRE = new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
			}
			catch (Exception) {
				result = false;
		 	}
		
			return result;
		}

        /// <summary>
        /// Convert this filter to its string equivalent.
        /// </summary>
        /// <returns>The string equivalent for this filter.</returns>
        public override string ToString()
		{
			return filter;
		}

        /// <summary>
        /// Test a value to see if it is included by the filter.
        /// </summary>
        /// <param name="testValue">The value to test.</param>
        /// <returns>True if the value is included, false otherwise.</returns>
        public bool IsIncluded(string testValue)
		{
			bool result = false;
			if (inclusions.Count == 0)
				result = true;
			else {
				foreach (Regex r in inclusions) {
					if (r.IsMatch(testValue)) {
						result = true;
						break;
					}
				}
			}
			return result;
		}

        /// <summary>
        /// Test a value to see if it is excluded by the filter.
        /// </summary>
        /// <param name="testValue">The value to test.</param>
        /// <returns>True if the value is excluded, false otherwise.</returns>
        public bool IsExcluded(string testValue)
		{
			bool result = false;
			foreach (Regex r in exclusions) {
				if (r.IsMatch(testValue)) {
					result = true;
					break;
				}
			}
			return result;
		}

        /// <summary>
        /// Test a value to see if it matches the filter.
        /// </summary>
        /// <param name="testValue">The value to test.</param>
        /// <returns>True if the value matches, false otherwise.</returns>
        public bool IsMatch(string testValue)
		{
			return IsIncluded(testValue) == true && IsExcluded(testValue) == false;
		}

        /// <summary>
        /// Compile this filter.
        /// </summary>
        void Compile()
		{
			if (filter == null)
				return;

			string[] items = filter.Split(';');
			for (int i = 0; i < items.Length; ++i) {
				if (items[i] != null && items[i].Length > 0) {
					bool include = items[i][0] != '-';
					string toCompile;

					if (items[i][0] == '+')
						toCompile = items[i].Substring(1, items[i].Length - 1);
					else if (items[i][0] == '-')
						toCompile = items[i].Substring(1, items[i].Length - 1);
					else
						toCompile = items[i];

					// NOTE: Regular expressions can fail to compile here for a number of reasons that cause an exception
					// these are left unhandled here as the caller is responsible for ensuring all is valid.
					// several functions IsValidFilterExpression and IsValidExpression are provided for such checking
					if (include)
						inclusions.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					else
						exclusions.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
				}
			}
		}

        #region Instance Fields
        /// <summary>
        /// The filter
        /// </summary>
        string filter;
        /// <summary>
        /// The inclusions
        /// </summary>
        ArrayList inclusions;
        /// <summary>
        /// The exclusions
        /// </summary>
        ArrayList exclusions;
		#endregion
	}
}
