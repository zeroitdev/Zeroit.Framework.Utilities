// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PathFilter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;

namespace Zeroit.Framework.Utilities.IO.Compression.Core
{
    /// <summary>
    /// Scanning filters support these operations.
    /// </summary>
    public interface IScanFilter
	{
        /// <summary>
        /// Test a name to see if is 'matches' the filter.
        /// </summary>
        /// <param name="name">The name to test.</param>
        /// <returns>Returns true if the name matches the filter, false if it does not match.</returns>
        bool IsMatch(string name);
	}

    /// <summary>
    /// PathFilter filters directories and files by full path name.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Core.IScanFilter" />
    public class PathFilter : IScanFilter
	{
        /// <summary>
        /// Initialise a new instance of <see cref="PathFilter"></see>.
        /// </summary>
        /// <param name="filter">The <see cref="NameFilter"></see>filter expression to apply.</param>
        public PathFilter(string filter)
		{
			nameFilter = new NameFilter(filter);
		}

        /// <summary>
        /// Test a name to see if it matches the filter.
        /// </summary>
        /// <param name="name">The name to test.</param>
        /// <returns>True if the name matches, false otherwise.</returns>
        public virtual bool IsMatch(string name)
		{
			return nameFilter.IsMatch(Path.GetFullPath(name));
		}

        #region Instance Fields
        /// <summary>
        /// The name filter
        /// </summary>
        NameFilter nameFilter;
		#endregion
	}

    /// <summary>
    /// NameAnsSizeFilter filters based on name and file size.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Core.PathFilter" />
    public class NameAndSizeFilter : PathFilter
	{

        /// <summary>
        /// Initialise a new instance of NameAndSizeFilter.
        /// </summary>
        /// <param name="filter">The filter to apply.</param>
        /// <param name="minSize">The minimum file size to include.</param>
        /// <param name="maxSize">The maximum file size to include.</param>
        public NameAndSizeFilter(string filter, long minSize, long maxSize) : base(filter)
		{
			this.minSize = minSize;
			this.maxSize = maxSize;
		}

        /// <summary>
        /// Test a filename to see if it matches the filter.
        /// </summary>
        /// <param name="fileName">The filename to test.</param>
        /// <returns>True if the filter matches, false otherwise.</returns>
        public override bool IsMatch(string fileName)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			long length = fileInfo.Length;
			return base.IsMatch(fileName) &&
				(MinSize <= length) && (MaxSize >= length);
		}

        /// <summary>
        /// The minimum size
        /// </summary>
        long minSize = 0;

        /// <summary>
        /// The minimum size for a file that will match this filter.
        /// </summary>
        /// <value>The minimum size.</value>
        public long MinSize
		{
			get { return minSize; }
			set { minSize = value; }
		}

        /// <summary>
        /// The maximum size
        /// </summary>
        long maxSize = long.MaxValue;

        /// <summary>
        /// The maximum size for a file that will match this filter.
        /// </summary>
        /// <value>The maximum size.</value>
        public long MaxSize
		{
			get { return maxSize; }
			set { maxSize = value; }
		}
	}
}
