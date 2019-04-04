// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="CustomColorPicker.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Painters.Editors
{
    /// <summary>
    ///     Implements a color picker for selecting a customized color.
    /// </summary>
    public partial class CustomColorPicker : BaseColorPicker
    {
        /// <summary>
        /// 	Constructor with no starting color.
        /// </summary>
        public CustomColorPicker() : this(Color.Empty)
        {
		}

        /// <summary>
        /// 	Constructor with starting color.
        /// </summary>
        /// <param name="color">Starting color.</param>
        public CustomColorPicker(Color color)
        {
            InitializeComponent();


            
            bmPen = new Pen(Color.Black);
            bm = Properties.Resources.HSL200;
			bmRad = bm.Width / 2;
			bmMid = new Point(bitmapPanel.Width / 2, bitmapPanel.Height / 2);
			bmOff = new Point(bmMid.X - bmRad, bmMid.Y - bmRad);

			lumOff = new Point(4, bmOff.Y);
			lumHeight = bm.Height;
			lumMarkerPen = new Pen(Color.Black);
			lumMarkerBrush = null;

			lumY0 = Lum2Y(0.0);
			lumY1 = Lum2Y(1.0);

			SetColor(color);
        }

		private int setting = 0;

		private System.Drawing.Bitmap bm;
		private int bmRad;
		private Point bmOff;
		private Point bmMid;
		private Pen bmPen = null;
		private int bmX = -1; // current 
		private int bmY = -1;
		private bool bmMouseDown = false;

		private Point lumOff;
		private int lumHeight = -1;
		private GraphicsPath lumMarkerPath;
		private Pen lumMarkerPen = null;
		private Brush lumMarkerBrush = null;
		private bool lumMouseDown = false;
		private int lumMouseOffset; // Y offset

		private int lumY0;
		private int lumY1;

		private const int lumBarWidth = 20;
		private const int lumGap = 4;
		private const int lumMarkerWidth = 20;
		private const int lumMarkerHeight = 8;


		private const int huemax = 360;
		private const int satmax = 240;
		private const int lummax = 240;

		private const double RadToAngle = 180.0 / Math.PI;
		private const double AngleToRad = Math.PI / 180.0;

		// Current color
		private Color rgbColor;
		private HSColor hslColor;

        /// <summary>
        /// 	Set current selected color.
        /// </summary>
        /// <param name="color">Current color.</param>
        /// <returns><c>True</c>.</returns>
		public override bool SetColor(Color color)
		{
			setting++;
			alphaNud.Value = (decimal)color.A;
			setting--;

			rgbColor = Color.FromArgb(255, color);
			hslColor = HSColor.RGB2HSL(rgbColor);
			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetGraphics();
			SetColorPanel();
			return true;
		}

		private void SetRGBTextBoxes()
		{
			setting++;
			redTextBox.Text   = rgbColor.R.ToString();
			greenTextBox.Text = rgbColor.G.ToString();
			blueTextBox.Text  = rgbColor.B.ToString();
			setting--;
		}

		private void SetHSLTextBoxes()
		{
			setting++;
            hueTextBox.Text = ((int)Math.Round(hslColor.Hue % huemax)).ToString();
			satTextBox.Text = ((int)Math.Round(hslColor.Sat * satmax)).ToString();
			lumTextBox.Text = ((int)Math.Round(hslColor.Val * lummax)).ToString();
			setting--;
		}

		private void SetGraphics()
		{
			double radhue = hslColor.Hue * AngleToRad;
			bmX = bmOff.X + bmRad + (int)Math.Round(bmRad * hslColor.Sat * Math.Cos(radhue));
			bmY = bmOff.Y + bmRad - (int)Math.Round(bmRad * hslColor.Sat * Math.Sin(radhue));
			bitmapPanel.Invalidate();
			lumPanel.Invalidate();
			ClearLumMarker();
		}

		private Color GetArgbColor()
		{
			return Color.FromArgb((int)alphaNud.Value, rgbColor);
		}

        public Color Color
        {
            get { return Color.FromArgb((int) alphaNud.Value, rgbColor); }
        }

        public Color HSLColor
        {
            get { return hslColor.ToRGB(ColorSpace.HSL); }
        }

		private void SetColorPanel()
		{
			colorLabel.BackColor = rgbColor;
			colorALabel.BackColor = GetArgbColor();
		}

		private void UpdateFromRGB()
		{
			int r = GetInt(redTextBox);
			int g = GetInt(greenTextBox);
			int b = GetInt(blueTextBox);
			rgbColor = Color.FromArgb(r, g, b);
			hslColor = HSColor.RGB2HSL(rgbColor);
			SetHSLTextBoxes();
			SetGraphics();
			SetColorPanel();
		}

		private void UpdateFromHSL()
		{
			double hue = (double)GetInt(hueTextBox);
			double sat = (double)GetInt(satTextBox) / satmax;
			double lum = (double)GetInt(lumTextBox) / lummax;
			hslColor = new HSColor(hue, sat, lum);
			rgbColor = hslColor.ToRGB(ColorSpace.HSL);
			SetRGBTextBoxes();
            SetGraphics();
			SetColorPanel();
		}

		private void UpdateFromBitmapMouse(MouseEventArgs e)
		{
			// Calc cartesian coords
            int x = e.X - bmMid.X;
			int y = bmMid.Y - e.Y;
			int rad = (int)Math.Round(Math.Sqrt(x*x + y*y));

			double hue = Math.Atan2(y, x) * RadToAngle;
			if (hue < 0)
			{
				hue = 360 + hue;
			}

			// If rad is greater than bmRad, then must recalc bmX,bmY so that
			// they stay within the circle
			if (rad > bmRad)
			{
				double radRatio = (double)bmRad / (double)rad;
                bmX = (int)Math.Floor(x * radRatio) + bmMid.X;
				bmY = bmMid.Y - (int)Math.Floor(y * radRatio);
				rad = bmRad;
			}
			else
			{
                bmX = e.X;
                bmY = e.Y;
			}

			double sat = rad / (double)bmRad;

			hslColor = new HSColor(hue, sat, hslColor.Val);
			rgbColor = hslColor.ToRGB(ColorSpace.HSL);

			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetColorPanel();

            bitmapPanel.Invalidate();
			lumPanel.Invalidate();
			ClearLumMarker();
		}																	

		private void UpdateFromLumMouse(MouseEventArgs e)
		{
			double newLum = Math.Max(Math.Min(1.0, Y2Lum(e.Y + lumMouseOffset)), 0.0);

			hslColor = new HSColor(hslColor.Hue, hslColor.Sat, newLum);
            rgbColor = hslColor.ToRGB(ColorSpace.HSL);

			SetRGBTextBoxes();
			SetHSLTextBoxes();
			SetColorPanel();

			lumPanel.Invalidate();
			ClearLumMarker();
		}

		private void FixInt(TextBox textBox, int max)
		{
			if (textBox.Text.Length == 0)
			{
				return;
			}
			int val;
			if (Int32.TryParse(textBox.Text, out val) && val <= max)
			{
				return;
			}
			setting++;
			textBox.Text = max.ToString();
			setting--;
		}

		private int GetInt(TextBox textBox)
		{
			if (textBox.Text.Length == 0)
			{
				return 0;
			}
			int val = 0;
			Int32.TryParse(textBox.Text, out val);
			return val;
		}

        private void hueTextBox_TextChanged(object sender, EventArgs e)
        {
			if (setting == 0)
			{
				FixInt(hueTextBox, huemax);
				UpdateFromHSL();
			}
        }

        private void satTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(satTextBox, satmax);
				UpdateFromHSL();
			}
        }

        private void lumTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(lumTextBox, lummax);
				UpdateFromHSL();
			}
        }

        private void redTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(redTextBox, 255);
				UpdateFromRGB();
			}
        }

        private void greenTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(greenTextBox, 255);
				UpdateFromRGB();
			}
        }

        private void blueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (setting == 0)
			{
				FixInt(blueTextBox, 255);
				UpdateFromRGB();
			}
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
			bool want = (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back);
			e.Handled = !want;
        }

        private void bitmapPanel_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
			g.DrawImageUnscaled(bm, bmOff);
			g.DrawLine(bmPen, bmX,     bmY + 2, bmX,       bmY + 200);
            g.DrawLine(bmPen, bmX,     bmY - 2, bmX,       bmY - 200);
            g.DrawLine(bmPen, bmX + 2, bmY,     bmX + 200, bmY);
            g.DrawLine(bmPen, bmX - 2, bmY,     bmX - 200, bmY);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
			SelectColor(GetArgbColor());
		}

        private void bitmapPanel_MouseDown(object sender, MouseEventArgs e)
        {
			bmMouseDown = true;
			UpdateFromBitmapMouse(e);
        }

        private void bitmapPanel_MouseMove(object sender, MouseEventArgs e)
        {
			if (bmMouseDown)
			{
				UpdateFromBitmapMouse(e);
			}
        }

        private void bitmapPanel_MouseUp(object sender, MouseEventArgs e)
        {
			bmMouseDown = false;
        }

		private void ClearLumMarker()
		{
			if (lumMarkerPath != null)
			{
				lumMarkerPath.Dispose();
				lumMarkerPath = null;
			}
			if (lumMarkerBrush != null)
			{
				lumMarkerBrush.Dispose();
				lumMarkerBrush = null;
			}
		}

		private void MakeLumMarker()
		{
			if (lumMarkerPath == null)
			{
				lumMarkerPath = new GraphicsPath();
				int y = Lum2Y(hslColor.Val);
				int x = lumOff.X + lumBarWidth + lumGap;
				lumMarkerPath.AddPolygon(new Point[] { new Point(x, y),
												   new Point(x + lumMarkerWidth, y - lumMarkerHeight),
												   new Point(x + lumMarkerWidth, y + lumMarkerHeight),
												   new Point(x, y) } );
			}

			if (lumMarkerBrush == null)
			{
				lumMarkerBrush = new SolidBrush(GetLumColor(hslColor.Val));
			}
		}

		private int Lum2Y(double lum)
		{
			return lumOff.Y + lumHeight - 1 - (int)Math.Round(lum * (lumHeight - 1));
		}

		private double Y2Lum(int y)
		{
			return (double)(lumOff.Y + lumHeight - 1 - y) / (double)(lumHeight - 1);
		}

		private Color GetLumColor(double lum)
		{
			return HSColor.HSL2RGB(hslColor.Hue, hslColor.Sat, lum);
		}

        private void lumPanel_Paint(object sender, PaintEventArgs e)
        {
			if (lumHeight < 0)
			{
				return;
			}

            System.Drawing.Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
			Pen pen = new Pen(Color.White);

			for (int y = lumY1; y <= lumY0; y++)
			{
				double lum = Y2Lum(y);
				pen.Color = GetLumColor(lum);
				g.DrawLine(pen, lumOff.X, y, lumOff.X + lumBarWidth, y);
			}

			MakeLumMarker();
			g.FillPath(lumMarkerBrush, lumMarkerPath);
			//g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawPath(lumMarkerPen,   lumMarkerPath);
        }

        private void lumPanel_MouseDown(object sender, MouseEventArgs e)
        {
			if (lumMarkerPath.IsVisible(e.Location))
			{
				lumMouseDown = true;
				lumMouseOffset = Lum2Y(hslColor.Val) - e.Y;
			}
        }

        private void lumPanel_MouseMove(object sender, MouseEventArgs e)
        {
			if (lumMouseDown)
			{
				UpdateFromLumMouse(e);
			}
        }

        private void lumPanel_MouseUp(object sender, MouseEventArgs e)
        {
			lumMouseDown = false;
        }

        private void alphaNud_ValueChanged(object sender, EventArgs e)
        {
			if (setting == 0)
			{
				SetColorPanel();
			}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Select_Btn_MouseEnter(object sender, EventArgs e)
        {
            selectButton.FlatAppearance.BorderSize = 1;
            selectButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255);
        }

        private void Select_Btn_MouseLeave(object sender, EventArgs e)
        {
            selectButton.FlatAppearance.BorderSize = 0;
            selectButton.FlatAppearance.BorderColor = Color.FromArgb(22, 22, 22);
        }
    }
}
