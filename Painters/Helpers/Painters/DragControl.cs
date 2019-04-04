// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DragControl.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
//using Zeroit.Framework.Form.UIThemes;

#endregion

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{

    /// <summary>
    /// Class DragControl.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
    public class DragControl : Component
    {
        /// <summary>
        /// The drag 0
        /// </summary>
        private Drag drag_0 = new Drag();

        /// <summary>
        /// The control 0
        /// </summary>
        private Control control_0;

        /// <summary>
        /// The container control 0
        /// </summary>
        private ContainerControl containerControl_0;

        /// <summary>
        /// The bool 0
        /// </summary>
        private bool bool_0 = true;

        /// <summary>
        /// The bool 1
        /// </summary>
        private bool bool_1 = true;

        /// <summary>
        /// The bool 2
        /// </summary>
        private bool bool_2 = true;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// The timer 0
        /// </summary>
        private System.Windows.Forms.Timer timer_0;



        /// <summary>
        /// Gets or sets the container control.
        /// </summary>
        /// <value>The container control.</value>
        private ContainerControl containerControl
        {
            get
            {
                return this.containerControl_0;
            }
            set
            {
                this.containerControl_0 = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DragControl"/> is fixed.
        /// </summary>
        /// <value><c>true</c> if fixed; otherwise, <c>false</c>.</value>
        public bool Fixed
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DragControl"/> is horizontal.
        /// </summary>
        /// <value><c>true</c> if horizontal; otherwise, <c>false</c>.</value>
        public bool Horizontal
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.ComponentModel.ISite" /> of the <see cref="T:System.ComponentModel.Component" />.
        /// </summary>
        /// <value>The site.</value>
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                base.Site = value;
                if (value == null)
                {
                    return;
                }
                IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service != null)
                {
                    IComponent rootComponent = service.RootComponent;
                    if (!(rootComponent is ContainerControl))
                    {
                        do
                        {
                            if (num != num1)
                            {
                                break;
                            }
                            num1 = 1;
                            num2 = num;
                            num = 1;
                        }
                        while (1 <= num2);
                        return;
                    }
                    this.containerControl = rootComponent as ContainerControl;
                    return;
                }
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
        }

        /// <summary>
        /// Gets or sets the target control.
        /// </summary>
        /// <value>The target control.</value>
        public Control TargetControl
        {
            get
            {
                return this.control_0;
            }
            set
            {
                this.control_0 = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DragControl"/> is vertical.
        /// </summary>
        /// <value><c>true</c> if vertical; otherwise, <c>false</c>.</value>
        public bool Vertical
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragControl"/> class.
        /// </summary>
        public DragControl()
        {
            this.method_3();
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragControl"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public DragControl(IContainer container)
        {
            container.Add(this);
            this.method_3();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Drags the specified horixontal.
        /// </summary>
        /// <param name="horixontal">if set to <c>true</c> [horixontal].</param>
        /// <param name="Vertical">if set to <c>true</c> [vertical].</param>
        public void Drag(bool horixontal = true, bool Vertical = true)
        {
            this.drag_0.MoveObject(Vertical, horixontal);
        }

        /// <summary>
        /// Grabs the specified control.
        /// </summary>
        /// <param name="_control">The control.</param>
        public void Grab(Control _control)
        {
            this.drag_0.Grab(_control);
        }

        /// <summary>
        /// Grabs this instance.
        /// </summary>
        public void Grab()
        {
            Control containerControl0 = this.containerControl_0;
            this.drag_0.Grab(containerControl0);
        }

        /// <summary>
        /// Handles the 0 event of the method control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void method_0(object sender, MouseEventArgs e)
        {
            this.Drag(this.Vertical, this.Horizontal);
        }

        /// <summary>
        /// Handles the 1 event of the method control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void method_1(object sender, MouseEventArgs e)
        {
            this.Release();
        }

        /// <summary>
        /// Handles the 2 event of the method control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void method_2(object sender, MouseEventArgs e)
        {
            if (!this.bool_0)
            {
                this.Grab((Control)sender);
                return;
            }
            Control parent = (Control)sender;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            this.Grab(parent);
        }

        /// <summary>
        /// Methods the 3.
        /// </summary>
        private void method_3()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0)
            {
                Enabled = true,
                Interval = 1
            };
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            this.drag_0.Release();
        }

        /// <summary>
        /// Handles the Tick event of the timer_0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_0_Tick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                this.timer_0.Stop();
                Control control0 = this.containerControl;
                if (this.control_0 != null)
                {
                    control0 = this.control_0;
                }
                control0.MouseDown += new MouseEventHandler(this.method_2);
                control0.MouseMove += new MouseEventHandler(this.method_0);
                control0.MouseUp += new MouseEventHandler(this.method_1);
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        #region Additions

        /// <summary>
        /// Gets or sets the size grip.
        /// </summary>
        /// <value>The size grip.</value>
        public int SizeGrip
        {
            get { return drag_0.SizeGrip; }
            set
            {
                drag_0.SizeGrip = value;
                //TargetControl.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public int Caption
        {
            get { return drag_0.Caption; }
            set
            {
                drag_0.Caption = value;
                //TargetControl.Invalidate();
            }
        }

        #endregion
    }

    //public class ZeroitDragControl : Component
    //{
    //    private Drag drag_0 = new Drag();
    //    private ContainerControl containerControl_0;
    //    private IContainer icontainer_0;
    //    private Control control_0;
    //    private bool bool_0 = true;
    //    private ContainerControl containerControl
    //    {
    //        get
    //        {
    //            return this.containerControl_0;
    //        }
    //        set
    //        {
    //            this.containerControl_0 = value;
    //        }
    //    }

    //    private System.Windows.Forms.Timer timer_0;

    //    public override ISite Site
    //    {
    //        get
    //        {
    //            return base.Site;
    //        }
    //        set
    //        {
    //            int num = 0;
    //            int num1 = 0;
    //            int num2;
    //            base.Site = value;
    //            if (value == null)
    //            {
    //                return;
    //            }
    //            IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
    //            if (service != null)
    //            {
    //                IComponent rootComponent = service.RootComponent;
    //                if (!(rootComponent is ContainerControl))
    //                {
    //                    do
    //                    {
    //                        if (num != num1)
    //                        {
    //                            break;
    //                        }
    //                        num1 = 1;
    //                        num2 = num;
    //                        num = 1;
    //                    }
    //                    while (1 <= num2);
    //                    return;
    //                }
    //                this.containerControl = rootComponent as ContainerControl;
    //                return;
    //            }
    //            do
    //            {
    //                if (num != num1)
    //                {
    //                    break;
    //                }
    //                num1 = 1;
    //                num2 = num;
    //                num = 1;
    //            }
    //            while (1 <= num2);
    //        }
    //    }

    //    public Control TargetControl
    //    {
    //        get
    //        {
    //            return this.control_0;
    //        }
    //        set
    //        {
    //            this.control_0 = value;
    //        }
    //    }


    //    public ZeroitDragControl()
    //    {
    //        this.method_3();

    //    }

    //    public ZeroitDragControl(IContainer container)
    //    {
    //        container.Add(this);
    //        this.method_3();
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && this.icontainer_0 != null)
    //        {
    //            this.icontainer_0.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }


    //    public void Grab(Control _control)
    //    {
    //        this.drag_0.Grab(_control);
    //    }

    //    public void Grab()
    //    {
    //        Control containerControl0 = this.containerControl_0;
    //        this.drag_0.Grab(containerControl0);
    //    }

    //    public void Release()
    //    {
    //        this.drag_0.Release();
    //    }


    //    private void method_1(object sender, MouseEventArgs e)
    //    {
    //        this.Release();
    //    }

    //    private void method_2(object sender, MouseEventArgs e)
    //    {
    //        if (!this.bool_0)
    //        {
    //            this.Grab((Control)sender);
    //            return;
    //        }
    //        Control parent = (Control)sender;
    //        while (parent.Parent != null)
    //        {
    //            parent = parent.Parent;
    //        }
    //        this.Grab(parent);
    //    }

    //    private void method_3()
    //    {
    //        this.icontainer_0 = new System.ComponentModel.Container();
    //        this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0)
    //        {
    //            Enabled = true,
    //            Interval = 1
    //        };
    //        this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    //    }

    //    private void timer_0_Tick(object sender, EventArgs e)
    //    {
    //        int num = 0;
    //        int num1 = 0;
    //        int num2;
    //        try
    //        {
    //            this.timer_0.Stop();
    //            Control control0 = this.containerControl;
    //            if (this.control_0 != null)
    //            {
    //                control0 = this.control_0;
    //            }
    //            //control0.MouseDown += new MouseEventHandler(this.method_2);
    //            //control0.MouseMove += new MouseEventHandler(this.method_0);
    //            control0.MouseUp += new MouseEventHandler(this.method_1);
    //        }
    //        catch (Exception exception)
    //        {
    //        }
    //        do
    //        {
    //            if (num != num1)
    //            {
    //                break;
    //            }
    //            num1 = 1;
    //            num2 = num;
    //            num = 1;
    //        }
    //        while (1 <= num2);
    //    }

    //}

    /// <summary>
    /// Class Drag.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class Drag : System.Windows.Forms.Form
    {
        /// <summary>
        /// The bool 0
        /// </summary>
        private bool bool_0;

        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0;

        /// <summary>
        /// The int 1
        /// </summary>
        private int int_1;

        /// <summary>
        /// The control 0
        /// </summary>
        private Control control_0;

        #region Additions

        /// <summary>
        /// The c grip
        /// </summary>
        private int cGrip = 10;      // Grip size
        /// <summary>
        /// The c caption
        /// </summary>
        private int cCaption = 32;   // Caption bar height;

        /// <summary>
        /// Gets or sets the size grip.
        /// </summary>
        /// <value>The size grip.</value>
        public int SizeGrip
        {
            get { return cGrip; }
            set
            {
                cGrip = value;
                //control_0.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public int Caption
        {
            get { return cCaption; }
            set
            {
                cCaption = value;
                //control_0.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        public Drag()
        {
        }


        /// <summary>
        /// Grabs the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        public void Grab(Control a)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                this.control_0 = a;
                this.bool_0 = true;
                System.Drawing.Point mousePosition = Control.MousePosition;
                this.int_0 = mousePosition.X - this.control_0.Left;
                mousePosition = Control.MousePosition;
                this.int_1 = mousePosition.Y - this.control_0.Top;
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Moves the object.
        /// </summary>
        /// <param name="Horizontal">if set to <c>true</c> [horizontal].</param>
        /// <param name="Vertical">if set to <c>true</c> [vertical].</param>
        public void MoveObject(bool Horizontal = true, bool Vertical = true)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                if (this.bool_0)
                {
                    int x = Control.MousePosition.X;
                    int y = Control.MousePosition.Y;
                    if (Vertical)
                    {
                        this.control_0.Top = y - this.int_1;
                    }
                    if (Horizontal)
                    {
                        this.control_0.Left = x - this.int_0;
                    }
                }
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            this.bool_0 = false;
        }

        

    }
}
