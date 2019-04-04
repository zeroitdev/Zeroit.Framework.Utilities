// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Registry.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Utilities.WindowsAPI
{
    /// <summary>
    /// Class to provide basic registry API access
    /// </summary>
    public class Registry
    {
        /// <summary>
        /// Regs the query value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] System.Text.StringBuilder lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, out uint lpType, [Optional] [MarshalAs(UnmanagedType.LPStr)]string lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref byte lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref int lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the query value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegQueryValueExA", SetLastError = true)]
        public static extern int RegQueryValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int lpReserved, ref uint lpType, [Optional] ref long lpData, ref uint lpcbData);

        /// <summary>
        /// Regs the set value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);

        /// <summary>
        /// Regs the set value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref int lpData, int cbData);

        /// <summary>
        /// Regs the set value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);

        /// <summary>
        /// Regs the set value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref long lpData, int cbData);

        /// <summary>
        /// Regs the set value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, IntPtr lpData, int cbData);

        /// <summary>
        /// Regs the set value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueEA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, [MarshalAs(UnmanagedType.LPStr)]string lpData, int cbData);

        /// <summary>
        /// Regs the set value ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
        public static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);

        /// <summary>
        /// Regs the set value ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="dwType">Type of the dw.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="cbData">The cb data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegSetValueExA", SetLastError = true)]
        public static extern int RegSetValueExA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, int Reserved, uint dwType, ref byte lpData, int cbData);

        /// <summary>
        /// Regs the close key.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", SetLastError = true)]
        public static extern int RegCloseKey(UIntPtr hKey);

        /// <summary>
        /// Regs the create key.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", SetLastError = true)]
        public static extern int RegCreateKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, ref UIntPtr phkResult);

        /// <summary>
        /// Regs the create key a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyA", SetLastError = true)]
        public static extern int RegCreateKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, ref UIntPtr phkResult);

        /// <summary>
        /// Regs the open key ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="options">The options.</param>
        /// <param name="samDesired">The sam desired.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", SetLastError = true)]
        public static extern int RegOpenKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        /// <summary>
        /// Regs the open key ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="options">The options.</param>
        /// <param name="samDesired">The sam desired.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegOpenKeyExA", SetLastError = true)]
        public static extern int RegOpenKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int options, int samDesired, ref UIntPtr phkResult);

        /// <summary>
        /// Regs the delete key a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyA", SetLastError = true)]
        public static extern int RegDeleteKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey);

        /// <summary>
        /// Regs the delete key.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteKeyW", SetLastError = true)]
        public static extern int RegDeleteKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey);

        /// <summary>
        /// Regs the delete value.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteValueW", SetLastError = true)]
        public static extern int RegDeleteValue(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName);

        /// <summary>
        /// Regs the delete value a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteValueA", SetLastError = true)]
        public static extern int RegDeleteValueA(UIntPtr hKey, [MarshalAs(UnmanagedType.LPStr)]string lpValueName);

        /// <summary>
        /// Regs the create key ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="lpClass">The lp class.</param>
        /// <param name="dwOptions">The dw options.</param>
        /// <param name="samDesired">The sam desired.</param>
        /// <param name="lpSecurityAttributes">The lp security attributes.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <param name="lpdwDisposition">The LPDW disposition.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", SetLastError = true)]
        public static extern int RegCreateKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

        /// <summary>
        /// Regs the create key ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="subKey">The sub key.</param>
        /// <param name="Reserved">The reserved.</param>
        /// <param name="lpClass">The lp class.</param>
        /// <param name="dwOptions">The dw options.</param>
        /// <param name="samDesired">The sam desired.</param>
        /// <param name="lpSecurityAttributes">The lp security attributes.</param>
        /// <param name="phkResult">The PHK result.</param>
        /// <param name="lpdwDisposition">The LPDW disposition.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegCreateKeyExA", SetLastError = true)]
        public static extern int RegCreateKeyExA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey, int Reserved, [MarshalAs(UnmanagedType.LPStr)]string lpClass, int dwOptions, int samDesired, ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

        /// <summary>
        /// Regs the enum key ex.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="index">The index.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpcbName">Name of the LPCB.</param>
        /// <param name="reserved">The reserved.</param>
        /// <param name="lpClass">The lp class.</param>
        /// <param name="lpcbClass">The LPCB class.</param>
        /// <param name="lpftLastWriteTime">The LPFT last write time.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyExW", SetLastError = true)]
        public static extern int RegEnumKeyEx(UIntPtr hKey, uint index, StringBuilder lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

        /// <summary>
        /// Regs the enum key ex a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="index">The index.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpcbName">Name of the LPCB.</param>
        /// <param name="reserved">The reserved.</param>
        /// <param name="lpClass">The lp class.</param>
        /// <param name="lpcbClass">The LPCB class.</param>
        /// <param name="lpftLastWriteTime">The LPFT last write time.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumKeyExA", SetLastError = true)]
        public static extern int RegEnumKeyExA(UIntPtr hKey, uint index, [MarshalAs(UnmanagedType.LPStr)]string lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);

        /// <summary>
        /// Regs the enum value.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="dwIndex">Index of the dw.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpcValueName">Name of the LPC value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumValueW", SetLastError = true)]
        public static extern int RegEnumValue(UIntPtr hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);

        /// <summary>
        /// Regs the enum value a.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="dwIndex">Index of the dw.</param>
        /// <param name="lpValueName">Name of the lp value.</param>
        /// <param name="lpcValueName">Name of the LPC value.</param>
        /// <param name="lpReserved">The lp reserved.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpData">The lp data.</param>
        /// <param name="lpcbData">The LPCB data.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegEnumValueA", SetLastError = true)]
        public static extern int RegEnumValueA(UIntPtr hKey, uint dwIndex, [MarshalAs(UnmanagedType.LPStr)]string lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);
    }
}
