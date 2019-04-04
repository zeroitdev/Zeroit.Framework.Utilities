// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-08-2018
// ***********************************************************************
// <copyright file="ByteRate.cs" company="Zeroit Dev Technologies">
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
using System;
using Zeroit.Framework.Utilities.StringProcessing.Humanizer;
using Zeroit.Framework.Utilities.StringProcessing.HumanizerLocalisation;

namespace Zeroit.Framework.Utilities.StringProcessing.HumanizerBytes
{

    /// <summary>
    /// Class to hold a ByteSize and a measurement interval, for the purpose of calculating the rate of transfer
    /// </summary>
    public class ByteRate
    {
        /// <summary>
        /// Quantity of bytes
        /// </summary>
        /// <value>The size.</value>
        public ByteSize Size { get; private set;}

        /// <summary>
        /// Interval that bytes were transferred in
        /// </summary>
        /// <value>The interval.</value>
        public TimeSpan Interval { get; private set; }

        /// <summary>
        /// Create a ByteRate with given quantity of bytes across an interval
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="interval">The interval.</param>
        public ByteRate(ByteSize size, TimeSpan interval)
        {
            this.Size = size;
            this.Interval = interval;
        }

        /// <summary>
        /// Calculate rate for the quantity of bytes and interval defined by this instance
        /// </summary>
        /// <param name="timeUnit">Unit of time to calculate rate for (defaults is per second)</param>
        /// <returns>System.String.</returns>
        public string Humanize(TimeUnit timeUnit = TimeUnit.Second)
        {
            return Humanize(null, timeUnit);
        }

        /// <summary>
        /// Calculate rate for the quantity of bytes and interval defined by this instance
        /// </summary>
        /// <param name="format">The string format to use for the number of bytes</param>
        /// <param name="timeUnit">Unit of time to calculate rate for (defaults is per second)</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotSupportedException">timeUnit must be Second, Minute, or Hour</exception>
        public string Humanize(string format, TimeUnit timeUnit = TimeUnit.Second)
        {
            TimeSpan displayInterval;
            string displayUnit;

            if (timeUnit == TimeUnit.Second)
            {
                displayInterval = TimeSpan.FromSeconds(1);
                displayUnit = "s";
            }
            else if (timeUnit == TimeUnit.Minute)
            {
                displayInterval = TimeSpan.FromMinutes(1);
                displayUnit = "min";
            }
            else if (timeUnit == TimeUnit.Hour)
            {
                displayInterval = TimeSpan.FromHours(1);
                displayUnit = "hour";
            }
            else
                throw new NotSupportedException("timeUnit must be Second, Minute, or Hour");

            return new ByteSize(Size.Bytes / Interval.TotalSeconds * displayInterval.TotalSeconds)
                .Humanize(format) + '/' + displayUnit;
        }
    }
}
