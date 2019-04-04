// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PolyInputUITypeEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Design;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class PolygonInputEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class PolygonInputEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <c>EditValue</c> method.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>UITypeEditorEditStyle.Modal</c></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Creates and displays a <c>PolygonEditorDialog</c> dialog if <c>value</c> is a <c>Polygon</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Polygon</c> being edited.</param>
        /// <returns>The new value of the <c>Polygon</c> being edited.</returns>
		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
                                         System.IServiceProvider provider,
                                         object value)
        {
            if (value is PolygonInput)
            {
                PolyEditorDialog dialog = new PolyEditorDialog((PolygonInput)value);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.PolygonInput;
                }
            }
            return value;
        }
    }
}

