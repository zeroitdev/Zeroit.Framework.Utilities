// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PortInUse.cs" company="Zeroit Dev Technologies">
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
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.FileSystemOperations
{
    /// <summary>
    /// A class collection for port manipulations
    /// </summary>
    public class PortImplementation
    {
        /// <summary>
        /// The get port status
        /// </summary>
        private string getPortStatus = "";

        /// <summary>
        /// Get Port in use
        /// </summary>
        /// <value>The get port in use.</value>
        public string GetPortInUse
        {
            get { return getPortStatus; }
            set
            {
                getPortStatus = value;
            }
        }

        /// <summary>
        /// Create an instance of PortImplementation
        /// </summary>
        /// <param name="port">The port.</param>
        public PortImplementation(int port)
        {
            
                try
                {
                
                #region Old Code
                //HttpListener httpListner = new HttpListener();
                //httpListner.Prefixes.Add("http://*:8080/");
                //httpListner.Start();

                //Console.WriteLine("Port: 8080 status: " + (PortInUse(8080) ? "in use" : "not in use"));

                //Console.ReadKey(); 
                #endregion


                HttpListener httpListner = new HttpListener();
                    httpListner.Prefixes.Add("http://*:" + port + "/");
                    httpListner.Start();

                    getPortStatus = "Port:" + port + " status: " + (PortInUse(port) ? "in use" : "not in use");

                    
                    httpListner.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }
            
            
        }

        /// <summary>
        /// Port in use
        /// </summary>
        /// <param name="port">Set port</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool PortInUse(int port)
        {
            bool inUse = false;
            
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }

            return inUse;
        }

    }
}
