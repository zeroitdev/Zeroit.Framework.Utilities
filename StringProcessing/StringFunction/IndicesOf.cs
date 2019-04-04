// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IndicesOf.cs" company="Zeroit Dev Technologies">
//    This program contains Utilities for all C# programming activities.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
