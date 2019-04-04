// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WebServiceGenerator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Text;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Zeroit.Framework.Utilities.Web
{


    /// <summary>
    /// A class collection for generating Web Services
    /// </summary>
    public static class WebServiceGenerator
    {

        /// <summary>
        /// Generates WSDL to WebService
        /// </summary>
        /// <param name="from">For example TestWs.wsdl</param>
        /// <param name="outputFilePath">For example GeneratedWS.cs</param>
        public static void WSDLToWebService(string from, string outputFilePath)
        {
            WebServiceGenerator.Generate(from, outputFilePath);

        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="wsdlPath">Set input path</param>
        /// <param name="outputFilePath">Set output file path</param>
        public static void Generate(string wsdlPath, string outputFilePath)
        {
            if (File.Exists(wsdlPath) == false)
            {
                return;
            }

            ServiceDescription wsdlDescription = ServiceDescription.Read(wsdlPath);
            ServiceDescriptionImporter wsdlImporter = new ServiceDescriptionImporter();

            wsdlImporter.ProtocolName = "Soap12";
            wsdlImporter.AddServiceDescription(wsdlDescription, null, null);
            wsdlImporter.Style = ServiceDescriptionImportStyle.Server;

            wsdlImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

            CodeNamespace codeNamespace = new CodeNamespace();
            CodeCompileUnit codeUnit = new CodeCompileUnit();
            codeUnit.Namespaces.Add(codeNamespace);

            ServiceDescriptionImportWarnings importWarning = wsdlImporter.Import(codeNamespace, codeUnit);

            if (importWarning == 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                StringWriter stringWriter = new StringWriter(stringBuilder);

                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                codeProvider.GenerateCodeFromCompileUnit(codeUnit, stringWriter, new CodeGeneratorOptions());

                stringWriter.Close();

                File.WriteAllText(outputFilePath, stringBuilder.ToString(), Encoding.UTF8);
            }
            else
            {
                Console.WriteLine(importWarning);
            }
        }

    }
}
