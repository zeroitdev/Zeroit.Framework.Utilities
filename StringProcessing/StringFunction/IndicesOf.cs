// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IndicesOf.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {

        //---------------------------------Implementation-----------------------------//

        //public void TestStringIndicesOf()
        //{
        //    CollectionAssert.AreEquivalent("babbab".IndicesOf("b"), new[] { 0, 2, 3, 5 });
        //    CollectionAssert.AreEquivalent("babbab".IndicesOf("ba"), new[] { 0, 3 });
        //    CollectionAssert.AreEquivalent("babbab".IndicesOf("cgesahghts"), Enumerable.Empty<int>());
        //    CollectionAssert.AreEquivalent("babbab".IndicesOf(string.Empty), Enumerable.Empty<int>());
        //}

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Gets all the indexes in which a certain substring appears within the string.
        /// </summary>
        /// <param name="searchIn">The search in.</param>
        /// <param name="searchFor">The search for.</param>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public static IEnumerable<int> IndicesOf(this string searchIn, string searchFor)
        {
            if (string.IsNullOrEmpty(searchFor)) yield break;

            int lastLoc = searchIn.IndexOf(searchFor);
            while (lastLoc != -1)
            {
                yield return lastLoc;
                lastLoc = searchIn.IndexOf(searchFor, startIndex: lastLoc + 1);
            }
        }
    }
}
