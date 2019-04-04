// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-01-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-01-2019
// ***********************************************************************
// <copyright file="GetIPAddress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Net;

namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// Class WebURL.
    /// </summary>
    public static class WebURL
    {

        /// <summary>
        /// Gets the ip addresses from link.
        /// </summary>
        /// <param name="WebAddress">The web address.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GetIPAddressesFromLink(string WebAddress)
        {
            List<string> listOfLinks = new List<string>();

            IPHostEntry urlInfo;

            urlInfo = Dns.GetHostEntry(WebAddress);

            if (urlInfo.AddressList.Length > 0)
            {
                foreach (IPAddress ip in urlInfo.AddressList)
                {
                    listOfLinks.Add(ip.ToString());
                }
            }

            return listOfLinks;

        }

    }
}
