// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WindowX.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.Utilities.WindowsAPI;
using System.Runtime.InteropServices;
using Zeroit.Framework.Utilities.ControlUtils;
using Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils;

namespace Zeroit.Framework.Utilities.Forms
{
    /// <summary>
    /// Class for a Metroish form (like the Zune client, the GitHub Windows client, ...) without WPF
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MetroForm : Form
    {

        #region Constants

        #region Desktop Window Manager

        /// <summary>
        /// The DWM bb blurregion
        /// </summary>
        const int DWM_BB_BLURREGION = 2;
        /// <summary>
        /// The DWM bb enable
        /// </summary>
        const int DWM_BB_ENABLE = 1;
        /// <summary>
        /// The DWM bb transitiononmaximized
        /// </summary>
        const int DWM_BB_TRANSITIONONMAXIMIZED = 4;
        /// <summary>
        /// The DWM composed event name maximum length
        /// </summary>
        const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 0x40;
        /// <summary>
        /// The DWM frame duration default
        /// </summary>
        const int DWM_FRAME_DURATION_DEFAULT = -1;
        /// <summary>
        /// The DWM TNP opacity
        /// </summary>
        const int DWM_TNP_OPACITY = 4;
        /// <summary>
        /// The DWM TNP rectdestination
        /// </summary>
        const int DWM_TNP_RECTDESTINATION = 1;
        /// <summary>
        /// The DWM TNP rectsource
        /// </summary>
        const int DWM_TNP_RECTSOURCE = 2;
        /// <summary>
        /// The DWM TNP sourceclientareaonly
        /// </summary>
        const int DWM_TNP_SOURCECLIENTAREAONLY = 0x10;
        /// <summary>
        /// The DWM TNP visible
        /// </summary>
        const int DWM_TNP_VISIBLE = 8;
        /// <summary>
        /// The DWM composed event base name
        /// </summary>
        const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";
        /// <summary>
        /// The DWM composed event name format
        /// </summary>
        const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";

        #endregion

        #region WM

        /// <summary>
        /// The wm dwmcompositionchanged
        /// </summary>
        const int WM_DWMCOMPOSITIONCHANGED = 0x31e;
        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        const int WM_NCLBUTTONDOWN = 0xa1;

        #endregion

        #region Hittest

        /// <summary>
        /// The htclient
        /// </summary>
        const int HTCLIENT = 1;
        /// <summary>
        /// The htcaption
        /// </summary>
        const int HTCAPTION = 2;
        /// <summary>
        /// The htgrowbox
        /// </summary>
        const int HTGROWBOX = 4;
        /// <summary>
        /// The htsize
        /// </summary>
        const int HTSIZE = 4;
        /// <summary>
        /// The htminbutton
        /// </summary>
        const int HTMINBUTTON = 8;
        /// <summary>
        /// The htmaxbutton
        /// </summary>
        const int HTMAXBUTTON = 9;
        /// <summary>
        /// The htleft
        /// </summary>
        const int HTLEFT = 10;
        /// <summary>
        /// The htright
        /// </summary>
        const int HTRIGHT = 11;
        /// <summary>
        /// The httop
        /// </summary>
        const int HTTOP = 12;
        /// <summary>
        /// The httopleft
        /// </summary>
        const int HTTOPLEFT = 13;
        /// <summary>
        /// The httopright
        /// </summary>
        const int HTTOPRIGHT = 14;
        /// <summary>
        /// The htbottom
        /// </summary>
        const int HTBOTTOM = 15;
        /// <summary>
        /// The htbottomleft
        /// </summary>
        const int HTBOTTOMLEFT = 16;
        /// <summary>
        /// The htbottomright
        /// </summary>
        const int HTBOTTOMRIGHT = 17;
        /// <summary>
        /// The htborder
        /// </summary>
        const int HTBORDER = 18;

        #endregion

        /// <summary>
        /// The borderwidth
        /// </summary>
        const int BORDERWIDTH = 10;

        #endregion

        #region Readonly

        /// <summary>
        /// The DWM API available
        /// </summary>
        static readonly bool DwmApiAvailable = (Environment.OSVersion.Version.Major >= 6);
        /// <summary>
        /// The start color
        /// </summary>
        static readonly Color startColor = Color.FromArgb(102, 0, 0, 0);

        #endregion

        #region Members

        /// <summary>
        /// The margin ok
        /// </summary>
        bool _marginOk;
        /// <summary>
        /// The aero enabled
        /// </summary>
        bool _aeroEnabled;
        /// <summary>
        /// The DWM margins
        /// </summary>
        MARGINS _dwmMargins;
        /// <summary>
        /// The resize dir
        /// </summary>
        ResizeDirection _resizeDir;
        /// <summary>
        /// The button color
        /// </summary>
        Color _buttonColor;
        /// <summary>
        /// The hover color
        /// </summary>
        Color _hoverColor;
        /// <summary>
        /// The push color
        /// </summary>
        Color _pushColor;
        /// <summary>
        /// The minimum
        /// </summary>
        PushButton _min;
        /// <summary>
        /// The maximum
        /// </summary>
        PushButton _max;
        /// <summary>
        /// The close
        /// </summary>
        PushButton _close;

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Constructs a MetroForm form instance
        /// </summary>
        public MetroForm()
        {
            _buttonColor = startColor;
            _hoverColor = Color.FromArgb(80, 80, 80);
            _pushColor = Color.White;
            _aeroEnabled = false;
            _resizeDir = ResizeDirection.None;
            ClientSize = new Size(640, 480);
            MouseMove += new MouseEventHandler(OnMouseMove);
            MouseDown += new MouseEventHandler(OnMouseDown);
            Activated += new EventHandler(OnActivated);
            SetStyle(ControlStyles.ResizeRedraw, true);
            AutoScaleDimensions = new SizeF(6f, 13f);
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            SetupButtons();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the used close button.
        /// </summary>
        /// <value>The close button.</value>
        [Description("Gets the used close button.")]
        [Category("FormsX")]
        public PushButton CloseButton
        {
            get { return _close; }
        }

        /// <summary>
        /// Gets the used minimize button.
        /// </summary>
        /// <value>The minimize button.</value>
        [Description("Gets the used minimize button.")]
        [Category("FormsX")]
        public PushButton MinimizeButton
        {
            get { return _min; }
        }

        /// <summary>
        /// Gets the used maximize / shrink button.
        /// </summary>
        /// <value>The maximize button.</value>
        [Description("Gets the used maximize / shrink button.")]
        [Category("FormsX")]
        public PushButton MaximizeButton
        {
            get { return _max; }
        }

        /// <summary>
        /// Gets or sets the usual color of the buttons.
        /// </summary>
        /// <value>The color of the button.</value>
        [Description("Gets or sets the standard color of the three system buttons.")]
        [Category("FormsX")]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                SetButtonNormalImages();
            }
        }

        /// <summary>
        /// Gets or sets the color of the buttons while hovering.
        /// </summary>
        /// <value>The color of the hover.</value>
        [Description("Gets or sets the hover color of the three system buttons.")]
        [Category("FormsX")]
        public Color HoverColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
                SetButtonHoverImages();
            }
        }

        /// <summary>
        /// Gets or sets the color of the buttons while hovering.
        /// </summary>
        /// <value>The color of the push.</value>
        [Description("Gets or sets the push color of the three system buttons.")]
        [Category("FormsX")]
        public Color PushColor
        {
            get { return _pushColor; }
            set
            {
                _pushColor = value;
                SetButtonPushImages();
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the minimize box in the upper right corner.
        /// </summary>
        /// <value><c>true</c> if [minimize box]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets the visibility of the minimize box.")]
        [Category("FormsX")]
        public new bool MinimizeBox
        {
            get { return base.MinimizeBox; }
            set
            {
                base.MinimizeBox = value;
                _min.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the maximize box in the upper right corner.
        /// </summary>
        /// <value><c>true</c> if [maximize box]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets the visibility of the maximize box.")]
        [Category("FormsX")]
        public new bool MaximizeBox
        {
            get { return base.MaximizeBox; }
            set
            {
                base.MaximizeBox = value;
                _max.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the close box in the upper right corner.
        /// </summary>
        /// <value><c>true</c> if [close box]; otherwise, <c>false</c>.</value>
        [Description("Gets or sets the visibility of the close box.")]
        [Category("FormsX")]
        public bool CloseBox
        {
            get { return _close.Visible; }
            set
            {
                _close.Visible = value;
            }
        }

        /// <summary>
        /// Gets the status of the aero display manager.
        /// </summary>
        /// <value><c>true</c> if [aero enabled]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool AeroEnabled
        {
            get { return _aeroEnabled; }
        }

        /// <summary>
        /// Gets or sets the resize direction.
        /// </summary>
        /// <value>The resize direction.</value>
        ResizeDirection ResizeDirection
        {
            get { return _resizeDir; }
            set
            {
                _resizeDir = value;

                //Change cursor
                switch (value)
                {
                    case ResizeDirection.Left:
                        this.Cursor = Cursors.SizeWE;

                        break;
                    case ResizeDirection.Right:
                        this.Cursor = Cursors.SizeWE;

                        break;
                    case ResizeDirection.Top:
                        this.Cursor = Cursors.SizeNS;

                        break;
                    case ResizeDirection.Bottom:
                        this.Cursor = Cursors.SizeNS;

                        break;
                    case ResizeDirection.BottomLeft:
                        this.Cursor = Cursors.SizeNESW;

                        break;
                    case ResizeDirection.TopRight:
                        this.Cursor = Cursors.SizeNESW;

                        break;
                    case ResizeDirection.BottomRight:
                        this.Cursor = Cursors.SizeNWSE;

                        break;
                    case ResizeDirection.TopLeft:
                        this.Cursor = Cursors.SizeNWSE;

                        break;
                    default:
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the <see cref="E:Activated" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnActivated(object sender, EventArgs e)
        {
            Window.DwmExtendFrameIntoClientArea(Handle, ref _dwmMargins);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Width - BORDERWIDTH > e.Location.X && e.Location.X > BORDERWIDTH && e.Location.Y > BORDERWIDTH)
                {
                    MoveControl(Handle);
                }
                else if (this.WindowState != FormWindowState.Maximized)
                {
                    ResizeForm(_resizeDir);
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseMove(object sender, MouseEventArgs e)
        {        
            //Calculate which direction to resize based on mouse position

            if (e.Location.X < BORDERWIDTH & e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.TopLeft;
            else if (e.Location.X < BORDERWIDTH & e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.BottomLeft;
            else if (e.Location.X > Width - BORDERWIDTH & e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.BottomRight;
            else if (e.Location.X > Width - BORDERWIDTH & e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.TopRight;
            else if (e.Location.X < BORDERWIDTH)
                ResizeDirection = ResizeDirection.Left;
            else if (e.Location.X > Width - BORDERWIDTH)
                ResizeDirection = ResizeDirection.Right;
            else if (e.Location.Y < BORDERWIDTH)
                ResizeDirection = ResizeDirection.Top;
            else if (e.Location.Y > Height - BORDERWIDTH)
                ResizeDirection = ResizeDirection.Bottom;
            else
                ResizeDirection = ResizeDirection.None;
        }

        #endregion

        #region Message Loop

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            int WM_NCCALCSIZE = 0x83;
            int WM_NCHITTEST = 0x84;
            IntPtr result = default(IntPtr);

            int dwmHandled = Window.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out result);
            
            if (dwmHandled == 1)
            {
                m.Result = result;
                return;
            }

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                NCCALCSIZE_PARAMS nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

                // Adjust (shrink) the client rectangle to accommodate the border:
                nccsp.rect0.Top += 0;
                nccsp.rect0.Bottom += 0;
                nccsp.rect0.Left += 0;
                nccsp.rect0.Right += 0;

                if (!_marginOk)
                {
                    //Set what client area would be for passing to DwmExtendIntoClientArea.
                    //Also remember that at least one of these values NEEDS TO BE > 1, else
                    //it won't work.
                    _dwmMargins.cyTopHeight = 0;
                    _dwmMargins.cxLeftWidth = 0;
                    _dwmMargins.cyBottomHeight = 3;
                    _dwmMargins.cxRightWidth = 0;
                    _marginOk = true;
                }

                Marshal.StructureToPtr(nccsp, m.LParam, false);
                m.Result = IntPtr.Zero;
            }
            else if (m.Msg == WM_NCHITTEST && m.Result.ToInt32() == 0)
            {
                m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="dwValue">The dw value.</param>
        /// <returns>System.Int32.</returns>
        static int LoWord(int dwValue)
        {
            return dwValue & 0xffff;
        }

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="dwValue">The dw value.</param>
        /// <returns>System.Int32.</returns>
        static int HiWord(int dwValue)
        {
            return (dwValue >> 16) & 0xffff;
        }

        /// <summary>
        /// Hits the test nca.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>IntPtr.</returns>
        IntPtr HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
        {
            var p = new Point(LoWord(lparam.ToInt32()), HiWord(lparam.ToInt32()));
            var topleft = RectangleToScreen(new Rectangle(0, 0, _dwmMargins.cxLeftWidth, _dwmMargins.cxLeftWidth));

            if (topleft.Contains(p))
                return new IntPtr(HTTOPLEFT);

            var topright = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, 0, _dwmMargins.cxRightWidth, _dwmMargins.cxRightWidth));

            if (topright.Contains(p))
                return new IntPtr(HTTOPRIGHT);

            var botleft = RectangleToScreen(new Rectangle(0, Height - _dwmMargins.cyBottomHeight, _dwmMargins.cxLeftWidth, _dwmMargins.cyBottomHeight));

            if (botleft.Contains(p))
                return new IntPtr(HTBOTTOMLEFT);

            var botright = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, Height - _dwmMargins.cyBottomHeight, _dwmMargins.cxRightWidth, _dwmMargins.cyBottomHeight));

            if (botright.Contains(p))
                return new IntPtr(HTBOTTOMRIGHT);

            var top = RectangleToScreen(new Rectangle(0, 0, Width, _dwmMargins.cxLeftWidth));

            if (top.Contains(p))
                return new IntPtr(HTTOP);

            var cap = RectangleToScreen(new Rectangle(0, _dwmMargins.cxLeftWidth, Width, _dwmMargins.cyTopHeight - _dwmMargins.cxLeftWidth));

            if (cap.Contains(p))
                return new IntPtr(HTCAPTION);

            var left = RectangleToScreen(new Rectangle(0, 0, _dwmMargins.cxLeftWidth, Height));

            if (left.Contains(p))
                return new IntPtr(HTLEFT);

            var right = RectangleToScreen(new Rectangle(Width - _dwmMargins.cxRightWidth, 0, _dwmMargins.cxRightWidth, Height));

            if (right.Contains(p))
                return new IntPtr(HTRIGHT);

            var bottom = RectangleToScreen(new Rectangle(0, Height - _dwmMargins.cyBottomHeight, Width, _dwmMargins.cyBottomHeight));

            if (bottom.Contains(p))
                return new IntPtr(HTBOTTOM);

            return new IntPtr(HTCLIENT);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prevents a bug that occurs while restoring the form after a minimize operation.
        /// </summary>
        /// <param name="x">The upper left corner x-coordinate.</param>
        /// <param name="y">The upper left corner y-coordinate.</param>
        /// <param name="width">The new width of the form (it is too large - use current Width value).</param>
        /// <param name="height">The new height of the form (it is too large - use the current Height value).</param>
        /// <param name="specified">What kind of boundaries should be changed?!</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Width, Height, specified);
        }

        /// <summary>
        /// Uses the original PerformLayout() method (this is a workaround for the designer).
        /// </summary>
        public new void PerformLayout()
        {
            base.PerformLayout();

            if (ClientSize.Width - _close.Right != 14)
            {
                var k = ClientSize.Width - _close.Right - 14;
                _close.Location = new Point(_close.Location.X + k, _close.Location.Y);
                _max.Location = new Point(_max.Location.X + k, _max.Location.Y);
                _min.Location = new Point(_min.Location.X + k, _min.Location.Y);
            }
        }

        /// <summary>
        /// Moves the control.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        void MoveControl(IntPtr hWnd)
        {
            Window.ReleaseCapture();
            Window.SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        /// <summary>
        /// Resizes the form.
        /// </summary>
        /// <param name="direction">The direction.</param>
        void ResizeForm(ResizeDirection direction)
        {
            int dir = -1;

            switch (direction)
            {
                case ResizeDirection.Left:
                    dir = HTLEFT;
                    break;
                case ResizeDirection.TopLeft:
                    dir = HTTOPLEFT;
                    break;
                case ResizeDirection.Top:
                    dir = HTTOP;
                    break;
                case ResizeDirection.TopRight:
                    dir = HTTOPRIGHT;
                    break;
                case ResizeDirection.Right:
                    dir = HTRIGHT;
                    break;
                case ResizeDirection.BottomRight:
                    dir = HTBOTTOMRIGHT;
                    break;
                case ResizeDirection.Bottom:
                    dir = HTBOTTOM;
                    break;
                case ResizeDirection.BottomLeft:
                    dir = HTBOTTOMLEFT;
                    break;
            }

            if (dir != -1)
            {
                Window.ReleaseCapture();
                Window.SendMessage(Handle, WM_NCLBUTTONDOWN, dir, 0);
            }
        }

        /// <summary>
        /// Setups the buttons.
        /// </summary>
        void SetupButtons()
        {
            _min = new PushButton();
            _max = new PushButton();
            _close = new PushButton();
            _max.Width = _close.Width = _min.Width = 32;
            _max.Height = _close.Height = _min.Height = 32;
            _min.Location = new Point(552, 0);
            _max.Location = new Point(584, 0);
            _close.Location = new Point(616, 0);
            _max.Anchor = _close.Anchor = _min.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _min.Click += new EventHandler(OnMinimizeClick);
            _max.Click += new EventHandler(OnMaximizeClick);
            _close.Click += new EventHandler(OnCloseClick);
            _min.HoverBackColor = Color.FromArgb(224, 224, 224);
            _close.HoverBackColor = Color.FromArgb(224, 224, 224);
            _max.HoverBackColor = Color.FromArgb(224, 224, 224);
            _min.PushBackColor = Color.FromArgb(78, 166, 234);
            _close.PushBackColor = Color.FromArgb(78, 166, 234);
            _max.PushBackColor = Color.FromArgb(78, 166, 234);
            SetButtonNormalImages();
            SetButtonHoverImages();
            SetButtonPushImages();
            _close.ToolTipText = "Close";
            _min.ToolTipText = "Minimize";
            _max.ToolTipText = "Maximize";
            Controls.Add(_min);
            Controls.Add(_max);
            Controls.Add(_close);
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(WindowState != FormWindowState.Maximized && SizeGripStyle != SizeGripStyle.Hide)
                e.Graphics.DrawImage(Images.resize, new Point(Width - 10, Height - 10));
        }

        /// <summary>
        /// Sets the button push images.
        /// </summary>
        void SetButtonPushImages()
        {
            _min.PushImage = Images.min.ChangeColor(startColor, _pushColor);
            _close.PushImage = Images.close.ChangeColor(startColor, _pushColor);

            if (WindowState == FormWindowState.Maximized)
                _max.PushImage = Images.shrink.ChangeColor(startColor, _pushColor);
            else
                _max.PushImage = Images.max.ChangeColor(startColor, _pushColor);
        }

        /// <summary>
        /// Sets the button hover images.
        /// </summary>
        void SetButtonHoverImages()
        {
            _min.HoverImage = Images.min.ChangeColor(startColor, _hoverColor);
            _close.HoverImage = Images.close.ChangeColor(startColor, _hoverColor);

            if(WindowState == FormWindowState.Maximized)
                _max.HoverImage = Images.shrink.ChangeColor(startColor, _hoverColor);
            else
                _max.HoverImage = Images.max.ChangeColor(startColor, _hoverColor);
        }

        /// <summary>
        /// Sets the button normal images.
        /// </summary>
        void SetButtonNormalImages()
        {
            _min.Image = Images.min.ChangeColor(startColor, _buttonColor);
            _close.Image = Images.close.ChangeColor(startColor, _buttonColor);

            if (WindowState == FormWindowState.Maximized)
                _max.Image = Images.shrink.ChangeColor(startColor, _buttonColor);
            else
                _max.Image = Images.max.ChangeColor(startColor, _buttonColor);
        }

        /// <summary>
        /// Handles the <see cref="E:CloseClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the <see cref="E:MaximizeClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnMaximizeClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                _max.HoverImage = Images.shrink.ChangeColor(startColor, _hoverColor);
                _max.Image = Images.shrink.ChangeColor(startColor, _buttonColor);
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                _max.HoverImage = Images.max.ChangeColor(startColor, _hoverColor);
                _max.Image = Images.max.ChangeColor(startColor, _buttonColor);
                WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MinimizeClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnMinimizeClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

    }
}
