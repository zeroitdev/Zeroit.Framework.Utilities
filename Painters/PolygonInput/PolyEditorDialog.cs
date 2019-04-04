// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PolyEditorDialog.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;


namespace Zeroit.Framework.Utilities.GraphicsExtension
{
    /// <summary>
    /// Class PolyEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PolyEditorDialog : Form
    {

        #region Constructor
        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> with an empty polygon
        /// and default window position.
        /// </summary>
        public PolyEditorDialog() : this((PolygonInput)null)
        {

        }

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> using an existing polygon
        /// and default window position.
        /// </summary>
        /// <param name="polygonInput">The polygon input.</param>
        public PolyEditorDialog(PolygonInput polygonInput)
        {
            InitializeComponent();
            GridLineConstructorValues();
            MagnifierSecondConstructor();

            RetrievedValues(polygonInput);


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            
            
        }

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> with an empty polygon
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public PolyEditorDialog(Control c) : this(null, c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>PolygonEditorDialog</c> using an existing polygon
        /// and starting beneath a specified control.
        /// </summary>
        /// <param name="polygonInput">The polygon input.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public PolyEditorDialog(PolygonInput polygonInput, Control c)
        {
            InitializeComponent();

        }


        #endregion

        /// <summary>
        /// The fill poly
        /// </summary>
        private bool fillPoly = true;
        /// <summary>
        /// The draw axes
        /// </summary>
        private bool drawAxes = true;
        /// <summary>
        /// The show snap points
        /// </summary>
        private bool showSnapPoints = true;
        /// <summary>
        /// The show grid lines
        /// </summary>
        private bool showGridLines = true;
        /// <summary>
        /// The points
        /// </summary>
        private PointF[] points;
        /// <summary>
        /// The polygon input
        /// </summary>
        private PolygonInput polygonInput;
        /// <summary>
        /// The poly fill color
        /// </summary>
        private Color polyFillColor = Color.White;
        /// <summary>
        /// The poly draw color
        /// </summary>
        private Color polyDrawColor = Color.Cyan;
        /// <summary>
        /// The curved
        /// </summary>
        private bool curved = false;

        /// <summary>
        /// The fill mode
        /// </summary>
        private PolygonInput.FillModes fillMode = PolygonInput.FillModes.Both;

        /// <summary>
        /// Gets the polygon designed by the user.
        /// </summary>
        /// <value>The polygon designed by the user.</value>
        public PolygonInput PolygonInput
        {
            get { return polygonInput; }
        }




        #region Private Events

        /// <summary>
        /// Handles the Click event of the okBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            polygonInput = new PolygonInput(new List<List<Point>>()
            {
                new List<Point>()
                {
                    new Point(0,0),
                    new Point(50, 50),
                    new Point(100, 0),
                    new Point(0,0)
                }
            }, PolygonInput.FillModes.Both, PolygonInput.ShapeTypes.Polygon);

            Submit(polygonInput);

            timer.Tick -= timer_Tick;
            timer.Stop();
            timer.Dispose();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the cancelBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
            timer.Dispose();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of the closeBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            
            timer.Tick -= timer_Tick;
            timer.Stop();
            timer.Dispose();
            this.Close();
        }
        #endregion

        #region Retrieved Code

        /// <summary>
        /// Retrieveds the values.
        /// </summary>
        /// <param name="polygonInput">The polygon input.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public void RetrievedValues(PolygonInput polygonInput)
        {
            #region zoom

            float tempvalue = ((float)zoomTrackBar.Value / ((float)zoomTrackBar.Maximum - zoomTrackBar.Minimum)) * constantZoom;
            
            float ratio = (tempvalue / constantZoom) * 230;
            zoomLabel.Text = Convert.ToInt32(ratio).ToString() + "%";

            #endregion

            #region ListBox Code

            listBox1.Items.Clear();
            try
            {
                foreach (List<Point> points in polygonInput.Points)
                {

                    for (int i = 0; i < points.Count; i++)
                    {
                        listBox1.Items.Add("Point " + i + " : " + new Point(points[i].X, points[i].Y));
                    }

                    #region Working Code

                    //for (int i = 0; i < polygonInput.Points.Count; i++)
                    //{
                    //    //PolygonPoints = new List<List<Point>>()
                    //    //{
                    //    //    new List<Point>()
                    //    //    {
                    //    //        new Point(points[i].X, points[i].Y)
                    //    //    }
                    //    //};

                    //}

                    #endregion


                    polygons.Add(points);
                    picCanvas.Invalidate();
                }
            }
            catch (Exception e)
            {

            } 
            
            #endregion

            #region Canvas Values

            bm = new System.Drawing.Bitmap(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);

            if (snapPointsCheckBox.Checked)
            {
                for (int x = 0; x < picCanvas.ClientSize.Width; x += GridGap)
                {
                    for (int y = 0; y < picCanvas.ClientSize.Height; y += GridGap)
                    {
                        bm.SetPixel(x, y, Color.Cyan);
                    }
                }

                picCanvas.BackgroundImage = bm;
            }
            else
            {
                picCanvas.BackgroundImage = null;
            }
            #endregion

            #region FillMode

            switch (polygonInput.FillMode)
            {
                case PolygonInput.FillModes.Fill:
                    showNumbersCheckBox.Checked = true;
                    break;
                case PolygonInput.FillModes.Border:
                    showNumbersCheckBox.Checked = false;
                    break;
                case PolygonInput.FillModes.Both:
                    showNumbersCheckBox.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }



            #region Add Enum to ComboBox
            // get a list of member names from EasingFunctionTypes enum,
            // figure out the numeric value, and display
            foreach (string volume in Enum.GetNames(typeof(PolygonInput.FillModes)))
            {
                fillModeCombo.Items.Add(volume);

            }

            for (int i = 0; i < fillModeCombo.Items.Count; i++)
            {
                if (polygonInput.FillMode == (PolygonInput.FillModes)Enum.Parse(typeof(PolygonInput.FillModes), fillModeCombo.Items[i].ToString()))
                {
                    fillModeCombo.SelectedIndex = i;

                }

            }
            #endregion



            #endregion

            #region ShapeType

            switch (polygonInput.ShapeType)
            {
                case PolygonInput.ShapeTypes.Polygon:
                    curvedCheckBox.Checked = false;
                    break;
                case PolygonInput.ShapeTypes.Spline:
                    curvedCheckBox.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            #endregion
        }

        #endregion

        #region Submit Code

        /// <summary>
        /// Submits the specified polygon input.
        /// </summary>
        /// <param name="polygonInput">The polygon input.</param>
        private void Submit(PolygonInput polygonInput)
        {
            polygonInput.Points = PolygonPoints;

            polygonInput.FillMode =
                (PolygonInput.FillModes)Enum.Parse(typeof
                        (PolygonInput.FillModes),
                    fillModeCombo.SelectedItem.ToString());

            #region ShapeType
            
            if (curvedCheckBox.Checked == false)
            {
                polygonInput.ShapeType = PolygonInput.ShapeTypes.Polygon;
            }
            else
            {
                polygonInput.ShapeType = PolygonInput.ShapeTypes.Spline;
            }

            #endregion

        }

        #endregion

        #region Polygon Creation

        // The "size" of an object for mouse over purposes.
        /// <summary>
        /// The object radius
        /// </summary>
        private const int object_radius = 3;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        /// <summary>
        /// The over dist squared
        /// </summary>
        private const int over_dist_squared = object_radius * object_radius;

        // Each polygon is represented by a List<Point>.
        /// <summary>
        /// The polygons
        /// </summary>
        private List<List<Point>> polygons = new List<List<Point>>();

        // Points for the new polygon.
        /// <summary>
        /// The new polygon
        /// </summary>
        private List<Point> NewPolygon = null;

        // The current mouse position while drawing a new polygon.
        /// <summary>
        /// The new point
        /// </summary>
        private Point NewPoint;

        // The polygon and index of the corner we are moving.
        /// <summary>
        /// The moving polygon
        /// </summary>
        private List<Point> MovingPolygon = null;
        /// <summary>
        /// The moving point
        /// </summary>
        private int MovingPoint = -1;
        /// <summary>
        /// The offset x
        /// </summary>
        private int OffsetX, OffsetY;

        // The add point cursor.
        /// <summary>
        /// The add point cursor
        /// </summary>
        private Cursor AddPointCursor;

        /// <summary>
        /// Gets or sets the polygon points.
        /// </summary>
        /// <value>The polygon points.</value>
        public List<List<Point>> PolygonPoints
        {
            get { return polygons; }
            set
            {
                polygons = value;
            }
        }

        // Create the add point cursor.
        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            AddPointCursor = new Cursor(Properties.Resources.addPoint_24px.GetHicon());
            //MakeBackgroundGrid();
        }

        // Start or continue drawing a new polygon,
        // or start moving a corner or polygon.
        /// <summary>
        /// Handles the MouseDown event of the picCanvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            
            // See what we're over.
            Point mouse_pt = SnapToGrid(e.Location);
            List<Point> hit_polygon;
            int hit_point, hit_point2;
            Point closest_point;

            if (NewPolygon != null)
            {
                // We are already drawing a polygon.
                // If it's the right mouse button, finish this polygon.
                if (e.Button == MouseButtons.Right)
                {
                    // Finish this polygon.
                    if (NewPolygon.Count > 2) polygons.Add(NewPolygon);
                    NewPolygon = null;

                    // We no longer are drawing.
                    picCanvas.MouseMove += picCanvas_MouseMove_NotDrawing;
                    picCanvas.MouseMove -= picCanvas_MouseMove_Drawing;
                }
                else
                {
                    // Add a point to this polygon.
                    if (NewPolygon[NewPolygon.Count - 1] != mouse_pt)
                    {
                        NewPolygon.Add(mouse_pt);
                    }
                }

                
            }

            else if (MouseIsOverCornerPoint(mouse_pt, out hit_polygon, out hit_point))
            {
                // Start dragging this corner.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDrawing;
                picCanvas.MouseMove += picCanvas_MouseMove_MovingCorner;
                picCanvas.MouseUp += picCanvas_MouseUp_MovingCorner;

                // Remember the polygon and point number.
                MovingPolygon = hit_polygon;
                MovingPoint = hit_point;

                // Remember the offset from the mouse to the point.
                OffsetX = hit_polygon[hit_point].X - e.X;
                OffsetY = hit_polygon[hit_point].Y - e.Y;

                if (e.Button == MouseButtons.Right)
                {

                    
                    MovingPolygon.Remove(new Point(MovingPolygon[hit_point].X, MovingPolygon[hit_point].Y));

                }

                //foreach (Point points in MovingPolygon)
                //{
                //    for (int i = 0; i < MovingPolygon.Count; i++)
                //    {
                //        listBox1.Items.Add("Point " + i + " : " + new Point(points.X, points.Y));

                //        if (listBox1.Items.Count > MovingPolygon.Count)
                //        {
                //            listBox1.Items.Clear();
                //            listBox1.Items.Add("Point " + i + " : " + new Point(points.X, points.Y));
                //        }
                //    }

                //    listBox1.Invalidate();

                //}

                foreach (List<Point> points in polygons)
                {

                    for (int i = 0; i < points.Count; i++)
                    {

                        listBox1.Items.Add("Point " + i + " : " + new Point(points[i].X, points[i].Y));
                        
                    }
                    
                }

                if (listBox1.Items.Count > MovingPolygon.Count)
                {
                    listBox1.Items.Clear();
                }
                

            }

            else if (MouseIsOverEdge(mouse_pt, out hit_polygon,
                out hit_point, out hit_point2, out closest_point))
            {
                // Add a point.
                hit_polygon.Insert(hit_point + 1, closest_point);
            }

            else if (MouseIsOverPolygon(mouse_pt, out hit_polygon))
            {
                

                // Start moving this polygon.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDrawing;
                picCanvas.MouseMove += picCanvas_MouseMove_MovingPolygon;
                picCanvas.MouseUp += picCanvas_MouseUp_MovingPolygon;

                // Remember the polygon.
                MovingPolygon = hit_polygon;

                // Remember the offset from the mouse to the segment's first point.
                OffsetX = hit_polygon[0].X - e.X;
                OffsetY = hit_polygon[0].Y - e.Y;


                if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Do you want to delete the shape", "Delete Shape", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        polygons.Remove(MovingPolygon);
                    }
                }

                //for (int i = 0; i < MovingPolygon.Count; i++)
                //{
                //    polygonMenuStrip.Show(e.X, e.Y);
                //}
                

                foreach (List<Point> points in polygons)
                {

                    for (int i = 0; i < points.Count; i++)
                    {

                        listBox1.Items.Add("Point " + i + " : " + new Point(points[i].X, points[i].Y));

                    }
                    

                }

                //if (listBox1.Items.Count > MovingPolygon.Count)
                //{
                //    listBox1.Items.Clear();
                //}



            }

            else
            {
                // Start a new polygon.
                NewPolygon = new List<Point>();
                NewPoint = mouse_pt;
                NewPolygon.Add(mouse_pt);

                // Get ready to work on the new polygon.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDrawing;
                picCanvas.MouseMove += picCanvas_MouseMove_Drawing;
            }

            


            // Redraw.
            picCanvas.Invalidate();
        }

        // Move the next point in the new polygon.
        /// <summary>
        /// Handles the Drawing event of the picCanvas_MouseMove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            NewPoint = SnapToGrid(e.Location);
            picCanvas.Invalidate();
        }

        // Move the selected corner.
        /// <summary>
        /// Handles the MovingCorner event of the picCanvas_MouseMove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseMove_MovingCorner(object sender, MouseEventArgs e)
        {
            // Move the point.
            MovingPolygon[MovingPoint] =
                SnapToGrid(new Point(e.X + OffsetX, e.Y + OffsetY));

            // Redraw.
            picCanvas.Invalidate();
        }

        // Finish moving the selected corner.
        /// <summary>
        /// Handles the MovingCorner event of the picCanvas_MouseUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseUp_MovingCorner(object sender, MouseEventArgs e)
        {
            picCanvas.MouseMove += picCanvas_MouseMove_NotDrawing;
            picCanvas.MouseMove -= picCanvas_MouseMove_MovingCorner;
            picCanvas.MouseUp -= picCanvas_MouseUp_MovingCorner;
        }

        // Move the selected polygon.
        /// <summary>
        /// Handles the MovingPolygon event of the picCanvas_MouseMove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseMove_MovingPolygon(object sender, MouseEventArgs e)
        {
            // See how far the first point will move.
            int new_x1 = e.X + OffsetX;
            int new_y1 = e.Y + OffsetY;

            int dx = new_x1 - MovingPolygon[0].X;
            int dy = new_y1 - MovingPolygon[0].Y;

            // Snap the movement to a multiple of the grid distance.
            dx = GridGap * (int)(Math.Round((float)dx / GridGap));
            dy = GridGap * (int)(Math.Round((float)dy / GridGap));

            if (dx == 0 && dy == 0) return;

            // Move the polygon.
            for (int i = 0; i < MovingPolygon.Count; i++)
            {
                MovingPolygon[i] = new Point(
                    MovingPolygon[i].X + dx,
                    MovingPolygon[i].Y + dy);
            }

            // Redraw.
            picCanvas.Invalidate();
        }

        // Finish moving the selected polygon.
        /// <summary>
        /// Handles the MovingPolygon event of the picCanvas_MouseUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseUp_MovingPolygon(object sender, MouseEventArgs e)
        {
            picCanvas.MouseMove += picCanvas_MouseMove_NotDrawing;
            picCanvas.MouseMove -= picCanvas_MouseMove_MovingPolygon;
            picCanvas.MouseUp -= picCanvas_MouseUp_MovingPolygon;
        }

        // See if we're over a polygon or corner point.
        /// <summary>
        /// Handles the NotDrawing event of the picCanvas_MouseMove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseMove_NotDrawing(object sender, MouseEventArgs e)
        {
            
            Cursor new_cursor = Cursors.Cross;

            // See what we're over.
            Point mouse_pt = SnapToGrid(e.Location);
            List<Point> hit_polygon;
            int hit_point, hit_point2;
            Point closest_point;

            #region Points To Label

            //if (showCordinatesCheckBox.Checked)
            //{
            //    cordinatesLabel.Visible = true;
            //    cordinatesLabel.Text = "X : " + mouse_pt.X + " \n" + "Y : " + mouse_pt.Y;
            //    cordinatesLabel.Location = new Point(mouse_pt.X + 20, mouse_pt.Y);

            //}

            if (showCordinatesCheckBox.Checked)
            {
                cordinateLabelTransparent.Visible = true;
                cordinateLabelTransparent.Text = "X : " + mouse_pt.X + " \n" + "Y : " + mouse_pt.Y;
                cordinateLabelTransparent.Location = new Point(mouse_pt.X + 100, mouse_pt.Y);

            }

            #endregion

            if (MouseIsOverCornerPoint(mouse_pt, out hit_polygon, out hit_point))
            {
                new_cursor = Cursors.SizeAll;
                
            }
            else if (MouseIsOverEdge(mouse_pt, out hit_polygon,
                out hit_point, out hit_point2, out closest_point))
            {
                new_cursor = AddPointCursor;
            }
            else if (MouseIsOverPolygon(mouse_pt, out hit_polygon))
            {
                new_cursor = Cursors.Hand;
            }

            // Set the new cursor.
            if (picCanvas.Cursor != new_cursor)
            {
                picCanvas.Cursor = new_cursor;
            }
        }

        // Redraw old polygons in blue. Draw the new polygon in green.
        // Draw the final segment dashed.
        /// <summary>
        /// Handles the Paint event of the picCanvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GridLine(e);

            if (curvedCheckBox.Checked)
            {
                // Draw the old polygons.
                foreach (List<Point> polygon in polygons)
                {


                    #region Old Code
                    //// Draw the polygon.
                    //if (fillPoly)
                    //{
                    //    e.Graphics.FillClosedCurve(new SolidBrush(polyFillColor), polygon.ToArray());

                    //}

                    //e.Graphics.DrawClosedCurve(new Pen(polyDrawColor, 1f), polygon.ToArray()); 
                    #endregion

                    // Draw the polygon.
                    switch (fillMode)
                    {
                        case PolygonInput.FillModes.Fill:
                            e.Graphics.FillClosedCurve(new SolidBrush(polyFillColor), polygon.ToArray());

                            break;
                        case PolygonInput.FillModes.Border:
                            e.Graphics.DrawClosedCurve(new Pen(polyDrawColor, 1f), polygon.ToArray());

                            break;
                        case PolygonInput.FillModes.Both:
                            e.Graphics.FillClosedCurve(new SolidBrush(polyFillColor), polygon.ToArray());
                            e.Graphics.DrawClosedCurve(new Pen(polyDrawColor, 1f), polygon.ToArray());

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    // Draw the corners.
                    foreach (Point corner in polygon)
                    {
                        Rectangle rect = new Rectangle(
                            corner.X - object_radius, corner.Y - object_radius,
                            2 * object_radius + 1, 2 * object_radius + 1);

                        if (showVerticesCheckBox.Checked)
                        {
                            e.Graphics.FillEllipse(Brushes.White, rect);
                            e.Graphics.DrawEllipse(Pens.Black, rect);
                        }

                    }

                    for (int i = 0; i < polygon.Count; i++)
                    {
                        if (showNumbersCheckBox.Checked)
                        {
                            e.Graphics.DrawString(i.ToString(), new Font("Verdana", 7), new SolidBrush(Color.Yellow), polygon[i]);

                        }

                    }
                }

                // Draw the new polygon.
                if (NewPolygon != null)
                {
                    // Draw the new polygon.
                    if (NewPolygon.Count > 1)
                    {
                        e.Graphics.DrawLines(new Pen(Color.Cyan), NewPolygon.ToArray());
                    }

                    // Draw the newest edge.
                    if (NewPolygon.Count > 0)
                    {
                        using (Pen dashed_pen = new Pen(Color.Red))
                        {
                            dashed_pen.DashPattern = new float[] { 3, 3 };
                            e.Graphics.DrawLine(dashed_pen,
                                NewPolygon[NewPolygon.Count - 1],
                                NewPoint);
                        }
                    }
                }

            }
            else
            {
                // Draw the old polygons.
                foreach (List<Point> polygon in polygons)
                {
                    #region Old Code
                    //// Draw the polygon.
                    //if (fillPoly)
                    //{
                    //    e.Graphics.FillPolygon(new SolidBrush(polyFillColor), polygon.ToArray());

                    //}

                    //e.Graphics.DrawPolygon(new Pen(polyDrawColor, 1f), polygon.ToArray()); 
                    #endregion

                    switch (fillMode)
                    {
                        case PolygonInput.FillModes.Fill:
                            e.Graphics.FillPolygon(new SolidBrush(polyFillColor), polygon.ToArray());

                            break;
                        case PolygonInput.FillModes.Border:
                            e.Graphics.DrawPolygon(new Pen(polyDrawColor, 1f), polygon.ToArray());

                            break;
                        case PolygonInput.FillModes.Both:
                            e.Graphics.FillPolygon(new SolidBrush(polyFillColor), polygon.ToArray());
                            e.Graphics.DrawPolygon(new Pen(polyDrawColor, 1f), polygon.ToArray());

                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    // Draw the corners.
                    foreach (Point corner in polygon)
                    {
                        Rectangle rect = new Rectangle(
                            corner.X - object_radius, corner.Y - object_radius,
                            2 * object_radius + 1, 2 * object_radius + 1);

                        if (showVerticesCheckBox.Checked)
                        {
                            e.Graphics.FillEllipse(Brushes.White, rect);
                            e.Graphics.DrawEllipse(Pens.Black, rect);
                        }

                    }

                    for (int i = 0; i < polygon.Count; i++)
                    {
                        if (showNumbersCheckBox.Checked)
                        {
                            e.Graphics.DrawString(i.ToString(), new Font("Verdana", 7), new SolidBrush(Color.Yellow), polygon[i]);

                        }
                    }
                }

                // Draw the new polygon.
                if (NewPolygon != null)
                {
                    // Draw the new polygon.
                    if (NewPolygon.Count > 1)
                    {
                        e.Graphics.DrawLines(new Pen(Color.Cyan), NewPolygon.ToArray());
                    }

                    // Draw the newest edge.
                    if (NewPolygon.Count > 0)
                    {
                        using (Pen dashed_pen = new Pen(Color.Red))
                        {
                            dashed_pen.DashPattern = new float[] { 3, 3 };
                            e.Graphics.DrawLine(dashed_pen,
                                NewPolygon[NewPolygon.Count - 1],
                                NewPoint);
                        }
                    }
                }

            }


            if (drawAxes)
            {
                e.Graphics.DrawLine(new Pen(Color.White), new Point(0, picCanvas.Height / 2),
                    new Point(picCanvas.Width - 5, picCanvas.Height / 2));

                e.Graphics.DrawLine(new Pen(Color.White), new Point(picCanvas.Width / 2, 0),
                    new Point(picCanvas.Width / 2, picCanvas.Height - 7));
            }

            MakeBackgroundGrid();

        }

        // See if the mouse is over a corner point.
        /// <summary>
        /// Mouses the is over corner point.
        /// </summary>
        /// <param name="mouse_pt">The mouse pt.</param>
        /// <param name="hit_polygon">The hit polygon.</param>
        /// <param name="hit_pt">The hit pt.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MouseIsOverCornerPoint(Point mouse_pt, out List<Point> hit_polygon, out int hit_pt)
        {
            // See if we're over a corner point.
            foreach (List<Point> polygon in polygons)
            {
                // See if we're over one of the polygon's corner points.
                for (int i = 0; i < polygon.Count; i++)
                {
                    // See if we're over this point.
                    if (FindDistanceToPointSquared(polygon[i], mouse_pt) < over_dist_squared)
                    {
                        // We're over this point.
                        hit_polygon = polygon;
                        hit_pt = i;
                        return true;
                    }
                }
            }

            hit_polygon = null;
            hit_pt = -1;
            return false;
        }

        // See if the mouse is over a polygon's edge.
        /// <summary>
        /// Mouses the is over edge.
        /// </summary>
        /// <param name="mouse_pt">The mouse pt.</param>
        /// <param name="hit_polygon">The hit polygon.</param>
        /// <param name="hit_pt1">The hit PT1.</param>
        /// <param name="hit_pt2">The hit PT2.</param>
        /// <param name="closest_point">The closest point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MouseIsOverEdge(Point mouse_pt, out List<Point> hit_polygon, out int hit_pt1, out int hit_pt2, out Point closest_point)
        {
            // Examine each polygon.
            // Examine them in reverse order to check the ones on top first.
            for (int pgon = polygons.Count - 1; pgon >= 0; pgon--)
            {
                List<Point> polygon = polygons[pgon];

                // See if we're over one of the polygon's segments.
                for (int p1 = 0; p1 < polygon.Count; p1++)
                {
                    // Get the index of the polygon's next point.
                    int p2 = (p1 + 1) % polygon.Count;

                    // See if we're over the segment between these points.
                    PointF closest;
                    if (FindDistanceToSegmentSquared(mouse_pt,
                        polygon[p1], polygon[p2], out closest) < over_dist_squared)
                    {
                        // We're over this segment.
                        hit_polygon = polygon;
                        hit_pt1 = p1;
                        hit_pt2 = p2;
                        closest_point = Point.Round(closest);
                        return true;
                    }
                }
            }

            hit_polygon = null;
            hit_pt1 = -1;
            hit_pt2 = -1;
            closest_point = new Point(0, 0);
            return false;
        }

        // See if the mouse is over a polygon's body.
        /// <summary>
        /// Mouses the is over polygon.
        /// </summary>
        /// <param name="mouse_pt">The mouse pt.</param>
        /// <param name="hit_polygon">The hit polygon.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MouseIsOverPolygon(Point mouse_pt, out List<Point> hit_polygon)
        {
            // Examine each polygon.
            // Examine them in reverse order to check the ones on top first.
            for (int i = polygons.Count - 1; i >= 0; i--)
            {
                // Make a GraphicsPath representing the polygon.
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(polygons[i].ToArray());

                // See if the point is inside the GraphicsPath.
                if (path.IsVisible(mouse_pt))
                {
                    hit_polygon = polygons[i];
                    return true;
                }
            }

            hit_polygon = null;
            return false;
        }

        #region DistanceFunctions

        // Calculate the distance squared between two points.
        /// <summary>
        /// Finds the distance to point squared.
        /// </summary>
        /// <param name="pt1">The PT1.</param>
        /// <param name="pt2">The PT2.</param>
        /// <returns>System.Int32.</returns>
        private int FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            int dx = pt1.X - pt2.X;
            int dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        // Calculate the distance squared between
        // point pt and the segment p1 --> p2.
        /// <summary>
        /// Finds the distance to segment squared.
        /// </summary>
        /// <param name="pt">The pt.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="closest">The closest.</param>
        /// <returns>System.Double.</returns>
        private double FindDistanceToSegmentSquared(PointF pt, PointF p1, PointF p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            // return Math.Sqrt(dx * dx + dy * dy);
            return dx * dx + dy * dy;
        }

        #endregion DistanceFunctions

        // The grid spacing.
        /// <summary>
        /// The grid gap
        /// </summary>
        private const int GridGap = 8;

        // Snap to the nearest grid point.
        /// <summary>
        /// Snaps to grid.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>Point.</returns>
        private Point SnapToGrid(Point point)
        {
            int x = GridGap * (int)Math.Round((float)point.X / GridGap);
            int y = GridGap * (int)Math.Round((float)point.Y / GridGap);
            return new Point(x, y);
        }

        // Give the PictureBox a grid background.
        /// <summary>
        /// Handles the Resize event of the picCanvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            MakeBackgroundGrid();
        }


        /// <summary>
        /// Handles the CheckedChanged event of the drawAxis control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void drawAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (drawAxis.Checked)
            {
                drawAxes = true;
            }
            else
            {
                drawAxes = false;
            }

            picCanvas.Invalidate();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the snapPointsCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void snapPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (snapPointsCheckBox.Checked)
            {
                showSnapPoints = true;
                picCanvas.BackgroundImage = bm;
                picCanvas.Invalidate();
            }
            else
            {
                picCanvas.BackgroundImage = null;
                showSnapPoints = false;
                picCanvas.Invalidate();
            }
        }

        /// <summary>
        /// The bm
        /// </summary>
        private System.Drawing.Bitmap bm;
        /// <summary>
        /// Makes the background grid.
        /// </summary>
        private void MakeBackgroundGrid()
        {
             
            if (showSnapPoints)
            {
                
                for (int x = 0; x < picCanvas.ClientSize.Width; x += GridGap)
                {
                    for (int y = 0; y < picCanvas.ClientSize.Height; y += GridGap)
                    {
                        bm.SetPixel(x, y, Color.Cyan);
                    }
                }
                //picCanvas.BackgroundImage = bm;
                
            }
            else
            {
                try
                {
                    //picCanvas.BackgroundImage = null;
                    
                }
                catch (Exception exception)
                {

                }

            }

            
            
            
        }

        #endregion

        #region Zoom Codes

        /// <summary>
        /// The zooms
        /// </summary>
        private static float[] zooms = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f,
            0.6f, 0.7f, 0.8f, 0.9f, 1.0f,
            1.1f, 1.2f, 1.3f, 1.4f, 1.5f,
            2.0f, 2.2f, 2.5f, 3.0f, 3.5f,
            4.0f, 5.0f, 6.0f, 7.0f, 8.0f };

        /// <summary>
        /// Grids the line constructor values.
        /// </summary>
        private void GridLineConstructorValues()
        {
            zoomTrackBar.Minimum = 0;
            zoomTrackBar.Maximum = zooms.Length - 1;
            zoomTrackBar.Value = defaultZoomIndex;
            UpdateZoom();
        }

        /// <summary>
        /// Updates the zoom.
        /// </summary>
        private void UpdateZoom()
        {
            zoomLabel.Text = zooms[zoomTrackBar.Value].ToString("F1");
        }

        /// <summary>
        /// Grids the line.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void GridLine(PaintEventArgs e)
        {
            const int gridSize = 10;

            System.Drawing.Graphics g = e.Graphics;
            Size cs = picCanvas.ClientSize;

            Pen gridPen = new Pen(Color.LimeGreen);
            gridPen.DashStyle = DashStyle.Dot;

            Pen polyPen = new Pen(Color.Cyan, 2.0f);

            zoom = zooms[zoomTrackBar.Value] * gridSize;
            mx = cs.Width / 2;
            my = cs.Height / 2;

            if (gridLinesCheckBox.Checked)
            {
                int gx = mx % gridSize;
                while (gx < cs.Width)
                {
                    g.DrawLine(gridPen, gx, 0, gx, cs.Height - 1);
                    gx += gridSize;
                }

                int gy = my % gridSize;
                while (gy < cs.Height)
                {
                    g.DrawLine(gridPen, 0, gy, cs.Width - 1, gy);
                    gy += gridSize;
                }
            }


            #region Old Code
            //if (polygons.Count > 0)
            //{
            //    foreach (List<Point> points in polygons)
            //    {
            //        foreach (Point point in points)
            //        {
            //            Point p1 = Tog(point);
            //            if (polygons.Count == 1)
            //            {
            //                g.DrawLine(polyPen, p1, p1);
            //            }
            //            else
            //            {
            //                for (int i = 0; i < points.Count; i++)
            //                {
            //                    Point p2 = Tog(points[i]);
            //                    g.DrawLine(polyPen, p1, p2);
            //                    p1 = p2;
            //                }


            //            }
            //        }
            //    }
            //} 
            #endregion


        }

        /// <summary>
        /// The zoom
        /// </summary>
        private float zoom;
        /// <summary>
        /// The mx
        /// </summary>
        private int mx;
        /// <summary>
        /// My
        /// </summary>
        private int my;
        /// <summary>
        /// The default zoom index
        /// </summary>
        private const int defaultZoomIndex = 9;
        /// <summary>
        /// Togs the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>PointF.</returns>
        private PointF Tog(PointF p)
        {
            return Tog(p.X, p.Y);
        }

        /// <summary>
        /// Togs the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>Point.</returns>
        private Point Tog(Point p)
        {
            return Tog(p.X, p.Y);
        }

        /// <summary>
        /// Togs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Point.</returns>
        private Point Tog(float x, float y)
        {
            return new Point(Convert.ToInt32(mx + x * zoom), Convert.ToInt32((float)my - y * zoom));
        }

        /// <summary>
        /// Handles the Scroll event of the zoomTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            //UpdateZoom();

            timer.Stop();

            float tempvalue = ((float)zoomTrackBar.Value / ((float)zoomTrackBar.Maximum - zoomTrackBar.Minimum)) * constantZoom;


            float ratio = (tempvalue / constantZoom) * 230;
            zoomLabel.Text = Convert.ToInt32(ratio).ToString() + "%";

            if (ratio > 115)
            {
                zoomInOut = constantZoom;
            }
            else
            {
                zoomInOut = 1;
            }
            
            

        }

        /// <summary>
        /// Handles the CheckedChanged event of the gridLinesCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gridLinesCheckBox.Checked)
            {
                showGridLines = true;
                picCanvas.Invalidate();
            }
            else
            {
                picCanvas.Invalidate();
                showGridLines = true;
            }
        }

        /// <summary>
        /// Togs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>PointF.</returns>
        private PointF Tog(double x, double y)
        {
            return new PointF((float)(mx + x * zoom), (float)(my - y * zoom));
        }

        /// <summary>
        /// Handles the Click event of the addPoint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void addPoint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the shape", "Delete Shape", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                polygons.Remove(MovingPolygon);
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the magnifierBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void magnifierBtn_MouseEnter(object sender, EventArgs e)
        {
            magnifierBtn.SizeMode = PictureBoxSizeMode.AutoSize;
            magnifierBtn.Image = Properties.Resources.mangnifier_over;
        }

        /// <summary>
        /// Handles the MouseLeave event of the magnifierBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void magnifierBtn_MouseLeave(object sender, EventArgs e)
        {
            magnifierBtn.SizeMode = PictureBoxSizeMode.AutoSize;
            magnifierBtn.Image = Properties.Resources.magnifier_search;
        }


        /// <summary>
        /// Handles the Click event of the magnifierBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void magnifierBtn_Click(object sender, EventArgs e)
        {
            
            
        }

        /// <summary>
        /// Handles the Click event of the magnifierSettingsBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void magnifierSettingsBtn_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the ValueChanged event of the zoomTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the MouseLeave event of the zoomTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomTrackBar_MouseLeave(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the curvedCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void curvedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the fillModeCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void fillModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fillModeCombo.SelectedIndex ==
                (int)PolygonInput.FillModes.Both)
            {

                fillMode = PolygonInput.FillModes.Both;
                picCanvas.Invalidate();
            }

            else if (fillModeCombo.SelectedIndex ==
                     (int)PolygonInput.FillModes.Fill)
            {
                fillMode = PolygonInput.FillModes.Fill;
                picCanvas.Invalidate();
            }
            else
            {
                fillMode = PolygonInput.FillModes.Border;
                picCanvas.Invalidate();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the showNumbersCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the showVerticesCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showVerticesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        /// <summary>
        /// Handles the MouseLeave event of the picCanvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picCanvas_MouseLeave(object sender, EventArgs e)
        {
            #region Points To Label

            //cordinatesLabel.Visible = false;
            //cordinatesLabel.Location = new Point(265, 361);

            cordinateLabelTransparent.Visible = false;
            cordinateLabelTransparent.Location = new Point(265, 361);

            #endregion
        }

        /// <summary>
        /// Handles the CheckedChanged event of the showCordinatesCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showCordinatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the zoomCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (zoomCheckBox.Checked)
            {
                timer.Start();
            }
            else
            {
                magnifierScreen.Image = null;
                timer.Stop();
            }
        }

        

        #endregion


        

    }




}
