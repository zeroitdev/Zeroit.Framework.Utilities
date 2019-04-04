// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Crypto.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class with API methods for cryptographic purposes
    /// </summary>
    public class Crypto
    {
        /// <summary>
        /// Crypts the acquire context w.
        /// </summary>
        /// <param name="hProv">The h prov.</param>
        /// <param name="pszContainer">The PSZ container.</param>
        /// <param name="pszProvider">The PSZ provider.</param>
        /// <param name="dwProvType">Type of the dw prov.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns>Boolean.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptAcquireContextW(ref IntPtr hProv, [MarshalAs(UnmanagedType.LPWStr)]string pszContainer, [MarshalAs(UnmanagedType.LPWStr)]string pszProvider, UInt32 dwProvType, UInt32 dwFlags);

        /// <summary>
        /// Crypts the gen random.
        /// </summary>
        /// <param name="hProv">The h prov.</param>
        /// <param name="dwLen">Length of the dw.</param>
        /// <param name="pbBuffer">The pb buffer.</param>
        /// <returns>Boolean.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptGenRandom(IntPtr hProv, UInt32 dwLen, IntPtr pbBuffer);

        /// <summary>
        /// Crypts the release context.
        /// </summary>
        /// <param name="hProv">The h prov.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns>Boolean.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CryptReleaseContext(IntPtr hProv, UInt32 dwFlags);
    }
}
