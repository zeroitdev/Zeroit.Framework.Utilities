// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-23-2018
// ***********************************************************************
// <copyright file="FontEnum.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Zeroit.Framework.Utilities.Win32;


namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.GDI
{
    /// <summary>
    /// Class FontList.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class FontList : UITypeEditor
    {
        /// <summary>
        /// The ed SVC
        /// </summary>
        private IWindowsFormsEditorService edSvc = null;
        /// <summary>
        /// The font listbox
        /// </summary>
        private ListBox FontListbox;

        /// <summary>
        /// Handles the DrawItem event of the LB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        private void LB_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (e.Index == -1)
                return;


            object li = FontListbox.Items[e.Index];
            string text = li.ToString();
            Brush bg, fg;

            if (selected)
            {
                bg = SystemBrushes.Highlight;
                fg = SystemBrushes.HighlightText;
                //fg=Brushes.Black;
            }
            else
            {
                bg = SystemBrushes.Window;
                fg = SystemBrushes.WindowText;
            }

            //e.Graphics.FillRectangle (SystemBrushes.Window,0,e.Bounds.Top,e.Bounds.Width ,FontListbox.ItemHeight); 			
            if (selected)
            {
                int ofs = 37;
                e.Graphics.FillRectangle(SystemBrushes.Window, new Rectangle(ofs, e.Bounds.Top, e.Bounds.Width - ofs, FontListbox.ItemHeight));
                e.Graphics.FillRectangle(SystemBrushes.Highlight, new Rectangle(ofs + 1, e.Bounds.Top + 1, e.Bounds.Width - ofs - 2, FontListbox.ItemHeight - 2));
                System.Windows.Forms.ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(ofs, e.Bounds.Top, e.Bounds.Width - ofs, FontListbox.ItemHeight));
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, 0, e.Bounds.Top, e.Bounds.Width, FontListbox.ItemHeight);
            }


            e.Graphics.DrawString(text, e.Font, fg, 38, e.Bounds.Top + 4);

            e.Graphics.SetClip(new Rectangle(1, e.Bounds.Top + 2, 34, FontListbox.ItemHeight - 4));


            e.Graphics.FillRectangle(SystemBrushes.Highlight, new Rectangle(1, e.Bounds.Top + 2, 34, FontListbox.ItemHeight - 4));

            IntPtr hdc = e.Graphics.GetHdc();
            GDIFont gf = new GDIFont(text, 9);
            int a = 0;
            IntPtr res = NativeGdi32Api.SelectObject(hdc, gf.hFont);
            NativeGdi32Api.SetTextColor(hdc, ColorTranslator.ToWin32(SystemColors.Window));
            NativeGdi32Api.SetBkMode(hdc, 0);
            NativeUser32Api.TabbedTextOut(hdc, 3, e.Bounds.Top + 5, "abc", 3, 0, ref a, 0);
            NativeGdi32Api.SelectObject(hdc, res);
            gf.Dispose();
            e.Graphics.ReleaseHdc(hdc);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(1, e.Bounds.Top + 2, 34, FontListbox.ItemHeight - 4));
            e.Graphics.ResetClip();

        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null
                && context.Instance != null
                && provider != null)
            {
                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));


                
                if (edSvc != null)
                {
                    // Create a CheckedListBox and populate it with all the enum values
                    FontListbox = new ListBox();
                    FontListbox.DrawMode = DrawMode.OwnerDrawFixed;
                    FontListbox.BorderStyle = BorderStyle.None;
                    FontListbox.Sorted = true;
                    FontListbox.MouseDown += new MouseEventHandler(this.OnMouseDown);
                    FontListbox.DoubleClick += new EventHandler(this.ValueChanged);
                    FontListbox.DrawItem += new DrawItemEventHandler(this.LB_DrawItem);
                    FontListbox.ItemHeight = 20;
                    FontListbox.MouseMove += new MouseEventHandler(this.OnMouseMoved);
                    FontListbox.Height = 200;
                    FontListbox.Width = 180;

                    ICollection fonts = new FontEnum().EnumFonts();
                    foreach (string font in fonts)
                    {
                        FontListbox.Items.Add(font);
                    }
                    edSvc.DropDownControl(FontListbox);
                    if (FontListbox.SelectedItem != null)
                        return FontListbox.SelectedItem.ToString();
                }
            }

            return value;
        }


        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// The handle lostfocus
        /// </summary>
        private bool handleLostfocus = false;

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!handleLostfocus && FontListbox.ClientRectangle.Contains(FontListbox.PointToClient(new Point(e.X, e.Y))))
            {
                FontListbox.LostFocus += new EventHandler(this.ValueChanged);
                handleLostfocus = true;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseMoved" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Values the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ValueChanged(object sender, EventArgs e)
        {
            if (edSvc != null)
            {
                edSvc.CloseDropDown();
            }
        }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            string text = e.Value.ToString();
            Bitmap bp = new Bitmap(e.Bounds.Width, e.Bounds.Height);
            Graphics g = Graphics.FromImage(bp);

            Brush bg, fg;

            bg = SystemBrushes.Window;
            fg = SystemBrushes.WindowText;

            g.FillRectangle(SystemBrushes.Highlight, e.Bounds);

            IntPtr hdc = g.GetHdc();
            GDIFont gf = new GDIFont(text, 9);
            int a = 0;
            IntPtr res = NativeGdi32Api.SelectObject(hdc, gf.hFont);
            NativeGdi32Api.SetTextColor(hdc, ColorTranslator.ToWin32(SystemColors.Window));
            NativeGdi32Api.SetBkMode(hdc, 0);
            NativeUser32Api.TabbedTextOut(hdc, 1, 1, "abc", 3, 0, ref a, 0);
            NativeGdi32Api.SelectObject(hdc, res);
            gf.Dispose();
            g.ReleaseHdc(hdc);
            e.Graphics.DrawImage(bp, e.Bounds.Left, e.Bounds.Top);

            //	e.Graphics.DrawString ("abc",new Font (text,10f),SystemBrushes.Window,3,0);
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    /// <summary>
    /// Class FontEnum.
    /// </summary>
    public class FontEnum
    {
        /// <summary>
        /// The fonts
        /// </summary>
        private Hashtable Fonts = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="FontEnum"/> class.
        /// </summary>
        public FontEnum()
        {
        }

        /// <summary>
        /// Enums the fonts.
        /// </summary>
        /// <returns>ICollection.</returns>
        public ICollection EnumFonts()
        {
            Bitmap bmp = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(bmp);

            IntPtr hDC = g.GetHdc();
            Fonts = new Hashtable();
            LogFont lf = new LogFont();
            lf.lfCharSet = 1;
            FONTENUMPROC callback = new FONTENUMPROC(this.CallbackFunc);
            NativeGdi32Api.EnumFontFamiliesEx(hDC, lf, callback, 0, 0);

            g.ReleaseHdc(hDC);
            g.Dispose();
            bmp.Dispose();
            return Fonts.Keys;
        }

        /// <summary>
        /// Callbacks the function.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="LParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        private int CallbackFunc(ENUMLOGFONTEX f, int a, int b, int LParam)
        {
            Fonts[f.elfLogFont.lfFaceName] = "abc";
            return 1;
        }

    }

}