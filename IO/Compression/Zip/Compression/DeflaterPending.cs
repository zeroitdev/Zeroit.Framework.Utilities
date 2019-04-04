// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="DeflaterPending.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.IO.Compression.Zip.Compression 
{

    /// <summary>
    /// This class stores the pending output of the Deflater.
    /// author of the original java version : Jochen Hoenicke
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.IO.Compression.Zip.Compression.PendingBuffer" />
    public class DeflaterPending : PendingBuffer
	{
        /// <summary>
        /// Construct instance with default buffer size
        /// </summary>
        public DeflaterPending() : base(DeflaterConstants.PENDING_BUF_SIZE)
		{
		}
	}
}
