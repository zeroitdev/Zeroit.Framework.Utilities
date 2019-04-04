// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CompileStringToAssembly.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
