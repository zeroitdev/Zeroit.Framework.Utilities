// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TransparentControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Transparent
{
    /// <summary>
    /// Class TransparentControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(TranspControlDesigner))]
    public abstract class TransparentControl: Control
    {
        #region Private Fields
        /// <summary>
        /// The drag
        /// </summary>
        public bool drag = false;
        /// <summary>
        /// The back image
        /// </summary>
        private Image backImage = null;
        /// <summary>
        /// The fill color
        /// </summary>
        private Color fillColor = Color.White;
        /// <summary>
        /// The back color
        /// </summary>
        private Color backColor = Color.Transparent;
        /// <summary>
        /// The transp key
        /// </summary>
        private Color transpKey = Color.White;
        /// <summary>
        /// The opacity
        /// </summary>
        private int opacity = 100;
        /// <summary>
        /// The line width
        /// </summary>
        private int lineWidth = 2;
        /// <summary>
        /// The alpha
        /// </summary>
        private int alpha;
        /// <summary>
        /// The glass mode
        /// </summary>
        private bool glassMode = true;
        /// <summary>
        /// The pen color
        /// </summary>
        private Color penColor = Color.Black;
        /// <summary>
        /// The bounds
        /// </summary>
        private RectangleF bounds;
        /// <summary>
        /// The g
        /// </summary>
        protected System.Drawing.Graphics G;
        /// <summary>
        /// The b
        /// </summary>
        protected System.Drawing.Bitmap B;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentControl"/> class.
        /// </summary>
        public TransparentControl()
        {
            //Set style for double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            bounds = ClientRectangle;
            bounds.Inflate(-1.0f, -1.0f);

            alpha = (opacity * 255) / 100;
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the back image.
        /// </summary>
        /// <value>The back image.</value>
        public Image BackImage
        {
            get { return this.backImage; }
            set
            {
                this.backImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transp key.
        /// </summary>
        /// <value>The transp key.</value>
        public Color TranspKey
        {
            get { return this.transpKey; }
            set
            {
                this.transpKey = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the glass.
        /// </summary>
        /// <value>The color of the glass.</value>
        public Color GlassColor
        {
            get { return this.backColor; }
            set
            {
                this.backColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [glass mode].
        /// </summary>
        /// <value><c>true</c> if [glass mode]; otherwise, <c>false</c>.</value>
        public bool GlassMode
        {
            get { return this.glassMode; }
            set
            {
                this.glassMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get { return this.fillColor; }
            set
            {
                this.fillColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public int LineWidth
        {
            get { return this.lineWidth; }
            set
            {
                this.lineWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public int Opacity
        {
            get
            {
                if (opacity > 100) { opacity = 100; }
                else if (opacity < 1) { opacity = 0; }
                return this.opacity;
            }
            set
            {
                this.opacity = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get { return penColor; }
            set
            {
                penColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <value>The alpha.</value>
        [Browsable(false)]
        public int Alpha
        {
            get { return alpha; }

        }
        #endregion

        #region Overrides
        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            System.Drawing.Graphics g = e.Graphics;

            if (Parent != null && !drag)
            {
                BackColor = Color.Transparent;
                int index = Parent.Controls.GetChildIndex(this);

                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);

                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
            else
            {
                g.Clear(Parent.BackColor);
                g.FillRectangle(new SolidBrush(Color.FromArgb(opacity * 255 / 100, GlassColor)),
                                               this.ClientRectangle);
            }

            if (BackImage != null && GlassMode)
            {
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(BackImage);
                image.MakeTransparent(TranspKey);

                float a = (float)opacity / 100.0f;

                float[][] mtxItens = {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,a,0},
                new float[] {0,0,0,0,1}};
                ColorMatrix colorMatrix = new ColorMatrix(mtxItens);

                ImageAttributes imgAtb = new ImageAttributes();
                imgAtb.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

                g.DrawImage(
                        image,
                        ClientRectangle,
                        0.0f,
                        0.0f,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel,
                        imgAtb);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Move" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Rectangle pBounds = this.Bounds;
            pBounds.Inflate(pBounds.Width / 2, pBounds.Height / 2);
            this.Invalidate();
            if (this.Parent != null) this.Parent.Invalidate(pBounds, true);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Rectangle pBounds = this.Bounds;
            pBounds.Inflate(pBounds.Width / 2, pBounds.Height / 2);
            this.Invalidate();
            if (this.Parent != null) this.Parent.Invalidate(pBounds, true);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ///////////////////////////////
            //         SETTINGS          //
            ///////////////////////////////

            System.Drawing.Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.GammaCorrected;

            RectangleF bounds = this.ClientRectangle;
            alpha = (opacity * 255) / 100;

            float penWidth = (float)LineWidth;
            Pen pen = new Pen(Color.FromArgb(alpha, PenColor), penWidth);
            pen.Alignment = PenAlignment.Center;

            Brush brushColor = new SolidBrush(Color.FromArgb(alpha, FillColor));
            Brush bckColor = new SolidBrush(Color.FromArgb(alpha, GlassColor));


            #region Sample Code
            /////////////////////////////////
            ////    DRAW YOUR SHAPE HERE   //
            /////////////////////////////////

            //GraphicsPath shape = new GraphicsPath();
            //GraphicsPath regionShape = new GraphicsPath();
            //GraphicsPath innerShape = new GraphicsPath();

            //// Create a shape region for non glass mode
            //regionShape.AddEllipse(bounds);
            //Region region = new Region(regionShape);

            //// Create the inner region for non glass mode
            //RectangleF inner = bounds;
            //inner.Inflate(-penWidth, -penWidth);
            //inner.Inflate(-2.0f, -2.0f);
            //innerShape.AddEllipse(inner);
            //Region innerRegion = new Region(innerShape);

            //// Fill the region background
            //if (GlassMode)
            //{
            //    Region = new Region();
            //    if (GlassColor != Color.Transparent && Opacity > 0)
            //    {
            //        g.FillRegion(bckColor, Region);
            //    }
            //}
            //else
            //{
            //    // Make a hole inside the shape if FillColor is transparent
            //    if (FillColor == Color.Transparent || Opacity == 0)
            //    {
            //        region.Exclude(innerRegion);
            //    }
            //    Region = region;
            //}

            //// Add a shape to the path
            //bounds.Inflate(-1.0f, -1.0f); //fit the ellipse inside the region
            //shape.AddEllipse(bounds);

            //// Fill the shape with a color
            //if (FillColor != Color.Transparent && Opacity > 0)
            //{
            //    //g.FillPath(brushColor, shape);

            //    //FillShape(e);
            //}
            ////FillShape(e);

            //// Draw the shape outline
            //bounds.Inflate(-penWidth / 2.0f, -penWidth / 2.0f);

            //if (PenColor != Color.Transparent && Opacity > 0)
            //{
            //    //g.DrawEllipse(pen, bounds);

            //    //g.DrawPolygon(pen, new Point[] {
            //    //    new Point(0, 0),
            //    //    new Point(50, 50),
            //    //    new Point(100, 0),
            //    //    new Point(0,0)
            //    //});


            //    //DrawShape(e);
            //} 
            #endregion

            PaintHook(e);

            ///////////////////////////////
            //       FREES MEMORY        //
            ///////////////////////////////

            brushColor.Dispose();
            bckColor.Dispose();
            pen.Dispose();

            #region Dispose for sample code
            //regionShape.Dispose();
            //innerShape.Dispose();
            //shape.Dispose();
            //innerRegion.Dispose();
            //region.Dispose(); 
            #endregion

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the pen.
        /// </summary>
        /// <param name="penWidth">Width of the pen.</param>
        /// <returns>Pen.</returns>
        protected Pen GetPen(float penWidth)
        {
            int alpha = (Opacity * 255) / 100;

            penWidth = (float)LineWidth;
            Pen pen = new Pen(Color.FromArgb(alpha, PenColor), penWidth);
            pen.Alignment = PenAlignment.Center;

            return pen;
        }

        //public Brush GetBrush(Brush brush, Color gradientColor1, Color gradientColor2, GraphicsPath path, HatchStyle hatchstyle = HatchStyle.BackwardDiagonal)
        //{
        //    if(brush.GetType()== typeof(SolidBrush))
        //    {
        //        int alpha = (Opacity * 255) / 100;
        //        brush = new SolidBrush(Color.FromArgb(alpha,FillColor));
        //    }
        //    else if(brush.GetType() == typeof(LinearGradientBrush))
        //    {
        //        int alpha = (Opacity * 255) / 100;
        //        brush = new LinearGradientBrush(GetBounds(), Color.FromArgb(alpha, gradientColor1), Color.FromArgb(alpha, gradientColor2), 90f);
        //    }

        //    else if(brush.GetType() == typeof(HatchBrush))
        //    {
        //        brush = new HatchBrush(hatchstyle, Color.FromArgb(alpha, gradientColor1), Color.FromArgb(alpha, gradientColor2));
        //    }

        //    return brush;
        //}

        /// <summary>
        /// Gets the brush.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <returns>Brush.</returns>
        protected Brush GetBrush(Brush brush)
        {
            return brush;
        }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <returns>RectangleF.</returns>
        protected RectangleF GetBounds()
        {
            return bounds;
        }
        #endregion

        #region Main Paint Method

        /// <summary>
        /// Main Paint method to implement by all extended controls.
        /// This is where all the paint events should go
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected abstract void PaintHook(PaintEventArgs e); 

        #endregion

    }

    // internal class TranspControlDesigner : System.Windows.Forms.Design.ControlDesigner
    // {
    //     private TransparentControl control;

    //     protected override void OnMouseDragBegin(int x, int y)
    //     {
    //         base.OnMouseDragBegin(x, y);
    //         control = (TransparentControl)(this.Control);
    //         control.drag = true;

    //     }

    //     protected override void OnMouseLeave()
    //     {
    //         base.OnMouseLeave();
    //         control = (TransparentControl)(this.Control);
    //         control.drag = false;

    //   }

    //}


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(TranspControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class TranspControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class TranspControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        /// <summary>
        /// The control
        /// </summary>
        private TransparentControl control;

        /// <summary>
        /// Receives a call in response to the left mouse button being pressed and held while over the component.
        /// </summary>
        /// <param name="x">The x position of the mouse in screen coordinates.</param>
        /// <param name="y">The y position of the mouse in screen coordinates.</param>
        protected override void OnMouseDragBegin(int x, int y)
        {
            base.OnMouseDragBegin(x, y);
            control = (TransparentControl)(this.Control);
            control.drag = true;

        }

        /// <summary>
        /// Receives a call when the mouse first enters the control.
        /// </summary>
        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            control = (TransparentControl)(this.Control);
            control.drag = false;

        }

        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new TransparentControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class TransparentControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class TransparentControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private TransparentControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public TransparentControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as TransparentControl;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back image.
        /// </summary>
        /// <value>The back image.</value>
        public Image BackImage
        {
            get
            {
                return colUserControl.BackImage;
            }
            set
            {
                GetPropertyByName("BackImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the transp key.
        /// </summary>
        /// <value>The transp key.</value>
        public Color TranspKey
        {
            get
            {
                return colUserControl.TranspKey;
            }
            set
            {
                GetPropertyByName("TranspKey").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the glass.
        /// </summary>
        /// <value>The color of the glass.</value>
        public Color GlassColor
        {
            get
            {
                return colUserControl.GlassColor;
            }
            set
            {
                GetPropertyByName("GlassColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [glass mode].
        /// </summary>
        /// <value><c>true</c> if [glass mode]; otherwise, <c>false</c>.</value>
        public bool GlassMode
        {
            get
            {
                return colUserControl.GlassMode;
            }
            set
            {
                GetPropertyByName("GlassMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get
            {
                return colUserControl.FillColor;
            }
            set
            {
                GetPropertyByName("FillColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public int LineWidth
        {
            get
            {
                return colUserControl.LineWidth;
            }
            set
            {
                GetPropertyByName("LineWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public int Opacity
        {
            get
            {
                return colUserControl.Opacity;
            }
            set
            {
                GetPropertyByName("Opacity").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get
            {
                return colUserControl.PenColor;
            }
            set
            {
                GetPropertyByName("PenColor").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackImage",
                                 "BackImage", "Appearance",
                                 "Selects the background image."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("TranspKey",
                                 "Transparency Key", "Appearance",
                                 "Sets the transparency key."));

            items.Add(new DesignerActionPropertyItem("GlassColor",
                                 "Glass Color", "Appearance",
                                 "Sets the glass color."));

            items.Add(new DesignerActionPropertyItem("GlassMode",
                "Glass Mode", "Appearance",
                "Sets the glass mode."));

            items.Add(new DesignerActionPropertyItem("FillColor",
                "Fill Color", "Appearance",
                "Sets the fill color."));

            items.Add(new DesignerActionPropertyItem("LineWidth",
                "Line Width", "Appearance",
                "Sets the line width."));

            items.Add(new DesignerActionPropertyItem("Opacity",
                "Opacity", "Appearance",
                "Sets the opacity."));

            items.Add(new DesignerActionPropertyItem("PenColor",
                "Pen Color", "Appearance",
                "Sets the line color."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

}
