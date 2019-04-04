// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="ShapeStar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes
{
    /// <summary>
    /// Class ShapeStar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapePolygon" />
    /// <seealso cref="Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.IRectangle" />
    public class ShapeStar : ShapePolygon,IRectangle
    {
        /// <summary>
        /// The corners
        /// </summary>
        private int _corners;

        /// <summary>
        /// The m width
        /// </summary>
        private float m_Width = 0;
        /// <summary>
        /// The m height
        /// </summary>
        private float m_Height = 0;


        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        internal ShapeStar()
        {
            
        }
        /// <summary>
        /// To the RAD.
        /// </summary>
        /// <param name="deg">The deg.</param>
        /// <returns>System.Single.</returns>
        private float ToRad(float deg)
        {

            return (float)(deg / 180 * Math.PI);
        
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="corners">The corners.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeStar(RectangleF ret, int corners,Pen pen,Brush brush)
        {
            _corners = corners;

            this.Points = Star(ret, corners);

           //this.Size = new SizeF(ret.Size.Width, ret.Size.Height);
            
            this.Pen = pen;
            this.Brush = brush;

            UpdatePath();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="corners">The corners.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="diff">The difference.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeStar(RectangleF ret, int corners, float rotation, float diff, Pen pen, Brush brush)
        {
            _corners = corners;

            this.Points = Star(ret, corners, ToRad(rotation), diff);
            this.Rotation = rotation;
            this.Pen = pen;
            this.Brush = brush;

            UpdatePath();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="corners">The corners.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeStar(RectangleF ret, int corners, float rotation, Pen pen, Brush brush)
        {
            _corners = corners;

            this.Points = Star(ret, corners, ToRad(rotation));
            this.Rotation = rotation;
            this.Pen = pen;
            this.Brush = brush;

            UpdatePath();
        }
        //***
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="Ir">The ir.</param>
        /// <param name="Er">The er.</param>
        /// <param name="corners">The corners.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeStar(PointF center, float Ir, float Er, int corners, Pen pen, Brush brush)
        {
            _corners = corners;

            this.Points = Star(center, Ir, Er, corners);
            
            this.Pen = pen;
            this.Brush = brush;

            UpdatePath();
        }
        //***

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStar"/> class.
        /// </summary>
        /// <param name="Center">The center.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="internalRadius">The internal radius.</param>
        /// <param name="corners">The corners.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        public ShapeStar(PointF Center, float radius, float internalRadius, int corners,float rotation, Pen pen, Brush brush)
        {
            _corners = corners;

            this.Points = Star(Center,internalRadius,radius,corners);
            this.Rotation = rotation;
            this.Pen = pen;
            this.Brush = brush;

            UpdatePath();
        }
        //************************************************************
        /// <summary>
        /// Stars the specified ret.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="num">The number.</param>
        /// <returns>PointF[].</returns>
        public PointF[] Star(RectangleF ret,int num)
         {
             PointF Center = new PointF(ret.Width / 2, ret.Height / 2);
             int ir = (int)( ret.Width / 3);
             int er=(int)ret.Width/2-2;
             return Star(Center, ir, er, num);

         }
        /// <summary>
        /// Stars the specified ret.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="num">The number.</param>
        /// <param name="PH">The ph.</param>
        /// <param name="diff">The difference.</param>
        /// <returns>PointF[].</returns>
        public PointF[] Star(RectangleF ret, int num,float PH,float diff)
         {
             PointF Center = new PointF(ret.Width / 2, ret.Height / 2);
            
             int er = (int)ret.Width / 2 - 2;
             int ir = (int)(er *diff);
             return Star(Center, ir, er, num, PH);

         }
        /// <summary>
        /// Stars the specified ret.
        /// </summary>
        /// <param name="ret">The ret.</param>
        /// <param name="num">The number.</param>
        /// <param name="PH">The ph.</param>
        /// <returns>PointF[].</returns>
        public PointF[] Star(RectangleF ret, int num, float PH)
         {
             PointF Center = new PointF(ret.Width / 2, ret.Height / 2);
             int ir = (int)(ret.Width / 3);
             int er = (int)ret.Width / 2 - 2;
             return Star(Center, ir, er, num, PH);

         }
        /// <summary>
        /// Stars the specified center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="Ir">The ir.</param>
        /// <param name="Er">The er.</param>
        /// <param name="num">The number.</param>
        /// <param name="PH">The ph.</param>
        /// <returns>PointF[].</returns>
        public PointF[] Star(PointF center, int Ir, int Er, int num, float PH)
         {
             PointF[] Points = new PointF[num * 2];

             float AngleStep = (float)(2 * Math.PI) / num;
             float phase = AngleStep / 2;
             float Angle = 0;
             for (int i = 0; i < num * 2; i += 2)
             {
                 Points[i].X = (int)(center.X + Er * Math.Cos(Angle + PH));
                 Points[i].Y = (int)(center.Y + Er * Math.Sin(Angle + PH));
                 Points[i + 1].X = (int)(center.X + Ir * Math.Cos(Angle + phase + PH));
                 Points[i + 1].Y = (int)(center.Y + Ir * Math.Sin(Angle + phase + PH));
                 Angle += AngleStep;
             }
             return Points;

         }
        //***  
        /// <summary>
        /// Stars the specified center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="Ir">The ir.</param>
        /// <param name="Er">The er.</param>
        /// <param name="num">The number.</param>
        /// <returns>PointF[].</returns>
        public PointF[] Star(PointF center ,float Ir,float Er, int num)
         {
             PointF[] Points = new PointF[num * 2];

             float AngleStep = (float)(2 * Math.PI) / num;
             float phase= AngleStep/2;
             float Angle = 0;
             for (int i = 0; i < num*2; i+=2)
             {
                 Points[i].X = (float)(center.X + Er*Math.Cos(Angle));
                 Points[i].Y = (float)(center.Y + Er * Math.Sin(Angle));
                 Points[i + 1].X = (float)(center.X + Ir*Math.Cos(Angle  + phase));
                 Points[i + 1].Y = (float)(center.Y +  Ir*Math.Sin(Angle  + phase));
                 Angle += AngleStep;
             }
             return Points;
         }

        /// <summary>
        /// Update the Shape
        /// </summary>
        public override void Update()
        {
            base.Update();
            this.Points = Star(new RectangleF(this.Location.X, 
                this.Location.Y, m_Width, m_Height)
                , _corners);

            UpdatePath();
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "{Zeroit.Framework.Utilities.GraphicsExtension.Drawing.Shapes.ShapeStar}";
        }


        #region IRectangle Members

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        public float Left
        {
            get
            {
                return this.Location.X;
            }
            set
            {
                this.Location = new PointF(value, this.Location.Y);
            }
        }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        public float Top
        {
            get
            {
                return this.Location.Y;
            }
            set
            {
                this.Location = new PointF(this.Location.X, value);
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public float Height
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        #endregion
}
}
