// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="SlideAnimation.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.Animation
{
    /// <summary>
    /// Class SlideAnimation.
    /// </summary>
    public static class SlideAnimation
    {

        //private int _Speed = 5;
        //public int Speed
        //{
        //    get { return _Speed; }
        //    set
        //    {
        //        if (value > 20 | value < -20)
        //        {
        //            MessageBox.Show("Speed needs to be in between -20 and 20.");
        //        }
        //        else
        //        {
        //            _Speed = value;
        //        }
        //    }
        //}

        /// <summary>
        /// Scrolls the left animation.
        /// </summary>
        /// <param name="Control1">The control1.</param>
        /// <param name="Control2">The control2.</param>
        /// <param name="Speed">The speed.</param>
        public static void ScrollLeftAnimation(this Control Control1, Control Control2, int Speed = 5)
        {
            
            if (Speed < -20)
            {
                Speed = -20;
            }

            if (Speed > 20)
            {
                Speed = 20;
            }

            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }

            int Slide = Control1.Width - (Control1.Width % Speed);

            int a = 0;
            for (a = 0; a <= Slide; a += Speed)
            {
                G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));

            //SelectedTab = (TabPage)Control2;

            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }

            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }

        /// <summary>
        /// Scrolls the right animation.
        /// </summary>
        /// <param name="Control1">The control1.</param>
        /// <param name="Control2">The control2.</param>
        /// <param name="Speed">The speed.</param>
        public static void ScrollRightAnimation(this Control Control1, Control Control2, int Speed = 5)
        {

            if (Speed < -20)
            {
                Speed = -20;
            }

            if (Speed > 20)
            {
                Speed = 20;
            }

            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }

            int Slide = Control1.Width - (Control1.Width % Speed);

            int a = 0;
            for (a = 0; a >= -Slide; a += -Speed)
            {
                G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));

            //SelectedTab = (TabPage)Control2;

            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }

            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }

        /// <summary>
        /// Scrolls up animation.
        /// </summary>
        /// <param name="Control1">The control1.</param>
        /// <param name="Control2">The control2.</param>
        /// <param name="Speed">The speed.</param>
        public static void ScrollUpAnimation(this Control Control1, Control Control2, int Speed = 5)
        {

            if (Speed < -20)
            {
                Speed = -20;
            }

            if (Speed > 20)
            {
                Speed = 20;
            }

            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }
            int Slide = Control1.Height - (Control1.Height % Speed);
            int a = 0;
            for (a = 0; a >= -Slide; a += -Speed)
            {
                G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(0, a + Control2.Height, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(0, a + Control2.Height, Control2.Width, Control2.Height));

            //SelectedTab = (TabPage)Control2;

            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }

            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }

        /// <summary>
        /// Scrolls down animation.
        /// </summary>
        /// <param name="Control1">The control1.</param>
        /// <param name="Control2">The control2.</param>
        /// <param name="Speed">The speed.</param>
        public static void ScrollDownAnimation(this Control Control1, Control Control2, int Speed = 5)
        {

            if (Speed < -20)
            {
                Speed = -20;
            }

            if (Speed > 20)
            {
                Speed = 20;
            }

            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));
            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }
            int Slide = Control1.Height - (Control1.Height % Speed);
            int a = 0;
            for (a = 0; a <= Slide; a += Speed)
            {
                G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(0, a - Control2.Height, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(0, a - Control2.Height, Control2.Width, Control2.Height));

            //SelectedTab = (TabPage)Control2;

            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }
            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }


    }
}
