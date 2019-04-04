// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="GraphicsBuffer.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// A class for rendering Graphics Buffer for controls
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public abstract class GraphicsBufferControl : Control 
    {
        /// <summary>
        /// Sets the type of double buffer to use
        /// </summary>
        public enum DoubleBufferMethod
        {
            /// <summary>
            /// The no double buffer
            /// </summary>
            NoDoubleBuffer,
            /// <summary>
            /// The built in double buffer
            /// </summary>
            BuiltInDoubleBuffer,
            /// <summary>
            /// The built in optimized double buffer
            /// </summary>
            BuiltInOptimizedDoubleBuffer,
            /// <summary>
            /// The manual double buffer11
            /// </summary>
            ManualDoubleBuffer11,
            /// <summary>
            /// The manual double buffer20
            /// </summary>
            ManualDoubleBuffer20
        };

        /// <summary>
        /// Used for either testing the control or drawing the control.
        /// </summary>
        public enum TestMode
        {
            /// <summary>
            /// The test
            /// </summary>
            Test = 1,
            /// <summary>
            /// The paint overridden
            /// </summary>
            PaintOverridden = 2
        }

        /// <summary>
        /// Used to when testing the control
        /// </summary>
        public enum GraphicTestMethods
        {
            /// <summary>
            /// The draw test
            /// </summary>
            DrawTest,
            /// <summary>
            /// The fill test
            /// </summary>
            FillTest
        };


        /// <summary>
        /// The no buffer graphics
        /// </summary>
        const System.Drawing.Graphics NO_BUFFER_GRAPHICS = null;
        /// <summary>
        /// The no back buffer
        /// </summary>
        const System.Drawing.Bitmap NO_BACK_BUFFER = null;
        /// <summary>
        /// The no managed back buffer
        /// </summary>
        const BufferedGraphics NO_MANAGED_BACK_BUFFER = null;

        /// <summary>
        /// The back buffer
        /// </summary>
        System.Drawing.Bitmap BackBuffer;
        /// <summary>
        /// The buffer graphics
        /// </summary>
        System.Drawing.Graphics BufferGraphics;
        /// <summary>
        /// The graphic manager
        /// </summary>
        BufferedGraphicsContext GraphicManager;
        /// <summary>
        /// The managed back buffer
        /// </summary>
        BufferedGraphics ManagedBackBuffer;

        /// <summary>
        /// The paint method
        /// </summary>
        DoubleBufferMethod _PaintMethod = DoubleBufferMethod.NoDoubleBuffer;
        /// <summary>
        /// The graphic test
        /// </summary>
        GraphicTestMethods _GraphicTest = GraphicTestMethods.DrawTest;

        /// <summary>
        /// The mode
        /// </summary>
        private TestMode mode = TestMode.PaintOverridden;
        /// <summary>
        /// The buffer background clear
        /// </summary>
        private Color bufferBackgroundClear = Color.Wheat;

        #region Public Properties

        /// <summary>
        /// Property for getting and setting the Test Methods
        /// </summary>
        /// <value>The graphic test.</value>
        public GraphicTestMethods GraphicTest
        {
            get { return _GraphicTest; }
            set
            {
                this.CreateGraphics().Clear(bufferBackgroundClear);
                _GraphicTest = value;
            }
        }

        /// <summary>
        /// Property to get and set the Color to clear Background
        /// </summary>
        /// <value>The buffer background clear.</value>
        public Color BufferBackgroundClear
        {
            get { return bufferBackgroundClear; }
            set
            {
                bufferBackgroundClear = value;
                
            }
        }

        /// <summary>
        /// Property for either drawing the actual control or testing the control
        /// </summary>
        /// <value>The mode.</value>
        public TestMode Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Memories the cleanup.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MemoryCleanup(object sender, EventArgs e)
        {
            if (BufferGraphics != NO_BUFFER_GRAPHICS)
                BufferGraphics.Dispose();

            if (BackBuffer != NO_BACK_BUFFER)
                BackBuffer.Dispose();

            if (ManagedBackBuffer != NO_MANAGED_BACK_BUFFER)
                ManagedBackBuffer.Dispose();
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DoubleBufferControl
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Resize += new System.EventHandler(this.DoubleBufferControl_Resize);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Handles the Resize event of the DoubleBufferControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoubleBufferControl_Resize(object sender, EventArgs e)
        {
            switch (_PaintMethod)
            {
                case DoubleBufferMethod.ManualDoubleBuffer11:
                    BackBuffer = new System.Drawing.Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                    BufferGraphics = System.Drawing.Graphics.FromImage(BackBuffer);
                    break;

                case DoubleBufferMethod.ManualDoubleBuffer20:
                    GraphicManager.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

                    if (ManagedBackBuffer != NO_MANAGED_BACK_BUFFER)
                        ManagedBackBuffer.Dispose();

                    ManagedBackBuffer = GraphicManager.Allocate(this.CreateGraphics(), ClientRectangle);
                    break;
            }

            this.Refresh();
        }

        /// <summary>
        /// Gets or sets the paint method.
        /// </summary>
        /// <value>The paint method.</value>
        public DoubleBufferMethod PaintMethod
        {
            get { return _PaintMethod; }
            set
            {
                _PaintMethod = value;
                RemovePaintMethods();

                switch (value)
                {
                    case DoubleBufferMethod.BuiltInDoubleBuffer:
                        this.SetStyle(ControlStyles.UserPaint, true);
                        this.DoubleBuffered = true;
                        break;
                    case DoubleBufferMethod.BuiltInOptimizedDoubleBuffer:
                        this.SetStyle(
                            ControlStyles.OptimizedDoubleBuffer |
                            ControlStyles.AllPaintingInWmPaint, true);
                        break;
                    case DoubleBufferMethod.ManualDoubleBuffer11:
                        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                        BackBuffer = new System.Drawing.Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                        BufferGraphics = System.Drawing.Graphics.FromImage(BackBuffer);
                        break;

                    case DoubleBufferMethod.ManualDoubleBuffer20:
                        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                        GraphicManager = BufferedGraphicsManager.Current;
                        GraphicManager.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                        ManagedBackBuffer = GraphicManager.Allocate(this.CreateGraphics(), ClientRectangle);
                        break;
                }
            }
        }

        /// <summary>
        /// Removes the paint methods.
        /// </summary>
        private void RemovePaintMethods()
        {
            this.DoubleBuffered = false;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

            if (BufferGraphics != NO_BUFFER_GRAPHICS)
            {
                BufferGraphics.Dispose();
                BufferGraphics = NO_BUFFER_GRAPHICS;
            }

            if (BackBuffer != NO_BACK_BUFFER)
            {
                BackBuffer.Dispose();
                BackBuffer = NO_BACK_BUFFER;
            }

            if (ManagedBackBuffer != NO_MANAGED_BACK_BUFFER)
                ManagedBackBuffer.Dispose();
        }

        /// <summary>
        /// Paints the double buffer11.
        /// </summary>
        /// <param name="ControlGraphics">The control graphics.</param>
        private void PaintDoubleBuffer11(System.Drawing.Graphics ControlGraphics)
        {
            switch (Mode)
            {
                case TestMode.Test:
                    LunchGraphicTest(BufferGraphics);
                    break;
                case TestMode.PaintOverridden:
                    MainPaint(BufferGraphics);
                    break;
            }

            // this draws the image from the buffer into the form area 
            // (note: DrawImageUnscaled is the fastest way)
            ControlGraphics.DrawImageUnscaled(BackBuffer, 0, 0);
        }

        /// <summary>
        /// Paints the double buffer20.
        /// </summary>
        /// <param name="ControlGraphics">The control graphics.</param>
        private void PaintDoubleBuffer20(System.Drawing.Graphics ControlGraphics)
        {
            try
            {
                switch (Mode)
                {
                    case TestMode.Test:
                        LunchGraphicTest(ManagedBackBuffer.Graphics);
                        break;
                    case TestMode.PaintOverridden:
                        MainPaint(ManagedBackBuffer.Graphics);
                        break;
                }
                
                // paint the picture in from the back buffer into the form draw area
                ManagedBackBuffer.Render(ControlGraphics);
            }
            catch (Exception Exp) { Console.WriteLine(Exp.Message); }
        }

        /// <summary>
        /// Lunches the graphic test.
        /// </summary>
        /// <param name="TempGraphics">The temporary graphics.</param>
        private void LunchGraphicTest(System.Drawing.Graphics TempGraphics)
        {
            int i;
            Random Rnd = new Random();
            Pen BlackPen = new Pen(new SolidBrush(Color.Black));
            Pen ColorPen = null;
            Rectangle TempRectangle;
            LinearGradientBrush ColorBrush = null;

            TempGraphics.Clear(Color.Wheat);

            switch (GraphicTest)
            {
                case GraphicTestMethods.DrawTest:
                    for (i = 0; i < 100; i++)
                    {
                        TempRectangle = new Rectangle(
                            Rnd.Next(0, Width),
                            Rnd.Next(0, Height),
                            Width - i,
                            Height - i);

                        ColorPen = new Pen(Color.FromArgb(127, Rnd.Next(0, 256), Rnd.Next(256), Rnd.Next(256)));
                        TempGraphics.DrawRectangle(ColorPen, TempRectangle);
                    }

                    ColorPen.Dispose();
                    break;

                case GraphicTestMethods.FillTest:
                    for (i = 0; i < 100; i++)
                    {
                        TempRectangle = new Rectangle(
                            Rnd.Next(0, Width),
                            Rnd.Next(0, Height),
                            Width - i,
                            Height - i);

                        ColorBrush = new LinearGradientBrush(
                                TempRectangle,
                                Color.FromArgb(127, Rnd.Next(0, 256), Rnd.Next(256), Rnd.Next(256)),
                                Color.FromArgb(127, Rnd.Next(0, 256), Rnd.Next(256), Rnd.Next(256)),
                                (LinearGradientMode)Rnd.Next(3));

                        TempGraphics.FillEllipse(ColorBrush, TempRectangle);

                    }

                    ColorBrush.Dispose();
                    break;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicsBufferControl"/> class.
        /// </summary>
        public GraphicsBufferControl()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            Application.ApplicationExit += new EventHandler(MemoryCleanup);
        }

        #endregion

        #region Main Paint to Override

        /// <summary>
        /// Mains the paint.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        protected virtual void MainPaint(System.Drawing.Graphics graphics)
        {
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (DesignMode)
            //{
            //    base.OnPaint(e);
            //    return;
            //}

            switch (Mode)
            {
                case TestMode.Test:
                    switch (_PaintMethod)
                    {
                        case DoubleBufferMethod.NoDoubleBuffer:
                            base.OnPaint(e);
                            LunchGraphicTest(e.Graphics);
                            break;

                        case DoubleBufferMethod.BuiltInDoubleBuffer:
                            LunchGraphicTest(e.Graphics);
                            break;

                        case DoubleBufferMethod.BuiltInOptimizedDoubleBuffer:
                            LunchGraphicTest(e.Graphics);
                            break;

                        case DoubleBufferMethod.ManualDoubleBuffer11:
                            PaintDoubleBuffer11(e.Graphics); break;

                        case DoubleBufferMethod.ManualDoubleBuffer20:
                            PaintDoubleBuffer20(e.Graphics); break;
                    }
                    break;
                case TestMode.PaintOverridden:
                    switch (_PaintMethod)
                    {
                        case DoubleBufferMethod.NoDoubleBuffer:
                            base.OnPaint(e);
                            MainPaint(e.Graphics);
                            break;

                        case DoubleBufferMethod.BuiltInDoubleBuffer:
                            MainPaint(e.Graphics);
                            break;

                        case DoubleBufferMethod.BuiltInOptimizedDoubleBuffer:
                            MainPaint(e.Graphics);
                            break;

                        case DoubleBufferMethod.ManualDoubleBuffer11:
                            PaintDoubleBuffer11(e.Graphics); break;

                        case DoubleBufferMethod.ManualDoubleBuffer20:
                            PaintDoubleBuffer20(e.Graphics); break;
                    }
                    break;
                
            }

            
        }


        #endregion


    }
}
