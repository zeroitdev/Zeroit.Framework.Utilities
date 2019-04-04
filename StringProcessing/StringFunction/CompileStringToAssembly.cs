// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CompileStringToAssembly.cs" company="Zeroit Dev Technologies">
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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CSharp;


namespace Zeroit.Framework.Utilities.StringProcessing
{
    /// <summary>
    /// Class StringFunctions.
    /// </summary>
    public static partial class StringFunctions
    {
        //---------------------------------Implementation-----------------------------//

        //var results = @"include System;

        //public class Example1
        //{
        //   public string Prop { get; set; }
        //}".CSharpCompile();

        //---------------------------------Implementation-----------------------------//

        /// <summary>
        /// Compiles the string to assembly. .NET 4
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="dllName">Name of the DLL.</param>
        /// <param name="additionalAssemblies">The additional assemblies.</param>
        /// <returns>CompilerResults.</returns>
        public static CompilerResults CompileStringToAssembly(this string code, string dllName = "dynamicCompile", params string[] additionalAssemblies)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var parameters = new CompilerParameters
            {
                ReferencedAssemblies = {
                    "mscorlib.dll",
                    "System.Core.dll",
                },
                OutputAssembly = dllName,
                GenerateExecutable = false,
                GenerateInMemory = true,
            };

            parameters.ReferencedAssemblies.AddRange(additionalAssemblies);

            return csc.CompileAssemblyFromSource(parameters, code);
        }

    }
}
