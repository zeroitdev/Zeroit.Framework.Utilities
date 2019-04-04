// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DrawImage.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Zeroit.Framework.Utilities.GraphicsExtension.BitmapUtils
{
    /// <summary>
    /// A class collection for Image manipulation
    /// </summary>
    public static partial class BitmapManipulation
    {

        /// <summary>
        /// Draws the image and text for a control
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        /// <param name="control">The control.</param>
        /// <param name="Image">The image.</param>
        /// <param name="ImageSize">Size of the image.</param>
        /// <param name="ImageAlign">The image align.</param>
        /// <param name="ShowText">if set to <c>true</c> [show text].</param>
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="ForeColor">Color of the fore.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="lineAlignment">The line alignment.</param>
        public static void GetImage(
            this System.Drawing.Graphics g,
            Rectangle control,
            Image Image, 
            Size ImageSize,
            ContentAlignment ImageAlign,
            bool ShowText,
            string Text,
            Font Font,
            Color ForeColor,
            StringAlignment textAlignment,
            StringAlignment lineAlignment = StringAlignment.Center)
        {
            
            Rectangle r = new Rectangle(8, 8, ImageSize.Width, ImageSize.Height);

            switch (ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(control.Width / 2 - ImageSize.Width / 2, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(control.Width - 8 - ImageSize.Width, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8, control.Height / 2 - ImageSize.Height / 2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle(control.Width / 2 - ImageSize.Width / 2, control.Height / 2 - ImageSize.Height / 2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(control.Width - 8 - ImageSize.Width, control.Height / 2 - ImageSize.Height / 2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8, control.Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(control.Width / 2 - ImageSize.Width / 2, control.Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(control.Width - 8 - ImageSize.Width, control.Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
            }
            if (Image == null)
            {
                if (ShowText)
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), control,
                        new StringFormat
                        {
                            Alignment = textAlignment,
                            LineAlignment = lineAlignment

                        });

            }
            else
            {
                g.DrawImage(Image, r);

                if (ShowText)
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), control,
                        new StringFormat
                        {
                            Alignment = textAlignment,
                            LineAlignment = lineAlignment

                        });
            }
            
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns>Image.</returns>
        public static Image GetImage(this Image Image, string filePath)
        {
            return GetImage(Image,filePath, true);
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="memberCopy">if set to <c>true</c> [member copy].</param>
        /// <returns>Image.</returns>
        public static Image GetImage(this Image Image, string filePath, bool memberCopy)
        {
            return GetImage(Image,filePath, memberCopy, false);
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="memberCopy">if set to <c>true</c> [member copy].</param>
        /// <param name="markNotFind">if set to <c>true</c> [mark not find].</param>
        /// <returns>Image.</returns>
        public static Image GetImage(this Image Image, string filePath, bool memberCopy, bool markNotFind)
        {
            FileInfo file = new FileInfo(filePath);
            Image image = null;

            if (!file.Exists)
            {
                if (markNotFind)
                {
                    image = new System.Drawing.Bitmap(16, 16);
                    Mark.FileNotFind(image);
                    return image;
                }
                else
                {
                    return null;
                }
            }


            switch (file.Extension.ToLower())
            {
                case ".ico":
                    try
                    {
                        Icon icon = new Icon(file.FullName);
                        image = icon.ToBitmap();
                    }
                    catch
                    {
                        image = new System.Drawing.Bitmap(16, 16);
                        Mark.FileCanNotRead(image);
                    }
                    break;
                default:
                    if (memberCopy)
                    {
                        Image imgTemp = Image.FromFile(file.FullName);
                        image = new System.Drawing.Bitmap(imgTemp);
                        imgTemp.Dispose();
                    }
                    else
                    {
                        // Image.FromFile(file.FullName);会使文件一直处于被占用状态，必须手动释放
                        image = Image.FromFile(file.FullName);
                    }
                    break;
            }

            return image;
        }

        /// <summary>
        /// Calculates the background image rectangle.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="backgroundImage">The background image.</param>
        /// <param name="imageLayout">The image layout.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle CalculateBackgroundImageRectangle(this Rectangle bounds, Image backgroundImage, ImageLayout imageLayout)
        {
            Rectangle result = bounds;
            if (backgroundImage != null)
            {
                switch (imageLayout)
                {
                    case ImageLayout.None:
                        result.Size = backgroundImage.Size;
                        break;

                    case ImageLayout.Center:
                        {
                            result.Size = backgroundImage.Size;
                            Size size = bounds.Size;
                            if (size.Width > result.Width)
                            {
                                result.X = (size.Width - result.Width) / 2;
                            }
                            if (size.Height > result.Height)
                            {
                                result.Y = (size.Height - result.Height) / 2;
                            }
                            break;
                        }
                    case ImageLayout.Stretch:
                        result.Size = bounds.Size;
                        break;

                    case ImageLayout.Zoom:
                        {
                            Size size2 = backgroundImage.Size;
                            float num = (float)bounds.Width / (float)size2.Width;
                            float num2 = (float)bounds.Height / (float)size2.Height;
                            if (num < num2)
                            {
                                result.Width = bounds.Width;
                                result.Height = (int)((double)((float)size2.Height * num) + 0.5);
                                if (bounds.Y >= 0)
                                {
                                    result.Y = (bounds.Height - result.Height) / 2;
                                }
                            }
                            else
                            {
                                result.Height = bounds.Height;
                                result.Width = (int)((double)((float)size2.Width * num2) + 0.5);
                                if (bounds.X >= 0)
                                {
                                    result.X = (bounds.Width - result.Width) / 2;
                                }
                            }
                            break;
                        }
                }
            }
            return result;
        }

        /// <summary>
        /// Draws the background image.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="backgroundImage">The background image.</param>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="backgroundImageLayout">The background image layout.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="clipRect">The clip rect.</param>
        /// <param name="scrollOffset">The scroll offset.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <exception cref="ArgumentNullException">g</exception>
        public static void DrawBackgroundImage(this System.Drawing.Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset, RightToLeft rightToLeft)
        {
            if (g == null)
            {
                throw new ArgumentNullException(nameof(g));
            }
            if (backgroundImageLayout == ImageLayout.Tile)
            {
                using (TextureBrush textureBrush = new TextureBrush(backgroundImage, WrapMode.Tile))
                {
                    if (scrollOffset != Point.Empty)
                    {
                        Matrix transform = textureBrush.Transform;
                        transform.Translate((float)scrollOffset.X, (float)scrollOffset.Y);
                        textureBrush.Transform = transform;
                    }
                    g.FillRectangle(textureBrush, clipRect);
                    return;
                }
            }
            Rectangle rectangle = CalculateBackgroundImageRectangle(bounds, backgroundImage, backgroundImageLayout);
            if (rightToLeft == RightToLeft.Yes && backgroundImageLayout == ImageLayout.None)
            {
                rectangle.X += clipRect.Width - rectangle.Width;
            }
            using (SolidBrush solidBrush = new SolidBrush(backColor))
            {
                g.FillRectangle(solidBrush, clipRect);
            }
            if (!clipRect.Contains(rectangle))
            {
                if (backgroundImageLayout == ImageLayout.Stretch || backgroundImageLayout == ImageLayout.Zoom)
                {
                    rectangle.Intersect(clipRect);
                    g.DrawImage(backgroundImage, rectangle);
                    return;
                }
                if (backgroundImageLayout == ImageLayout.None)
                {
                    rectangle.Offset(clipRect.Location);
                    Rectangle destRect = rectangle;
                    destRect.Intersect(clipRect);
                    Rectangle rectangle2 = new Rectangle(Point.Empty, destRect.Size);
                    g.DrawImage(backgroundImage, destRect, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, GraphicsUnit.Pixel);
                    return;
                }
                Rectangle destRect2 = rectangle;
                destRect2.Intersect(clipRect);
                Rectangle rectangle3 = new Rectangle(new Point(destRect2.X - rectangle.X, destRect2.Y - rectangle.Y), destRect2.Size);
                g.DrawImage(backgroundImage, destRect2, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
                return;
            }
            else
            {
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                g.DrawImage(backgroundImage, rectangle, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttributes);
                imageAttributes.Dispose();
            }
        }

        /// <summary>
        /// Images the rectangle from zoom.
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="originalRect">The original rect.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle ImageRectangleFromZoom(Image img, Rectangle originalRect)
        {
            var result = new Rectangle();
            Size size = img.Size;
            float num = Math.Min((float)originalRect.Width / (float)size.Width, (float)originalRect.Height / (float)size.Height);
            result.Width = (int)((float)size.Width * num);
            result.Height = (int)((float)size.Height * num);
            result.X = (originalRect.Width - result.Width) / 2;
            result.X += result.Width / 7;
            result.Y = originalRect.Y + (originalRect.Height - result.Height) / 2;
            return result;
        }

        //The Rectangle (corresponds to the PictureBox.ClientRectangle)
        //we use here is the Form.ClientRectangle
        //Here is the Paint event handler of your Form1
        //use this method to draw the image like as the zooming feature of PictureBox
        /// <summary>
        /// Zooms the draw image.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="img">The img.</param>
        /// <param name="bounds">The bounds.</param>
        public static void ZoomDrawImage(System.Drawing.Graphics g, Image img, Rectangle bounds)
        {
            decimal r1 = (decimal)img.Width / img.Height;
            decimal r2 = (decimal)bounds.Width / bounds.Height;
            int w = bounds.Width;
            int h = bounds.Height;
            if (r1 > r2)
            {
                w = bounds.Width;
                h = (int)(w / r1);
            }
            else if (r1 < r2)
            {
                h = bounds.Height;
                w = (int)(r1 * h);
            }
            int x = bounds.X + (bounds.Width - w) / 2;
            int y = bounds.Y + (bounds.Height - h) / 2;
            var oldMode = g.InterpolationMode;
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(img, new Rectangle(x, y, w, h));
            g.InterpolationMode = oldMode;
        }

        /// <summary>
        /// Gets the bounding rectangle of an image required to fit
        /// in to the given rectangle keeping the image aspect ratio.
        /// </summary>
        /// <param name="image">The source image.</param>
        /// <param name="fit">The rectangle to fit in to.</param>
        /// <param name="hAlign">Horizontal image aligment in percent.</param>
        /// <param name="vAlign">Vertical image aligment in percent.</param>
        /// <returns>New image size.</returns>
        /// <exception cref="ArgumentException">
        /// hAlign must be between 0.0 and 100.0 (inclusive). - hAlign
        /// or
        /// vAlign must be between 0.0 and 100.0 (inclusive). - vAlign
        /// </exception>
        public static Rectangle GetSizedImageBounds(this Image image, Rectangle fit, float hAlign, float vAlign)
        {
            if (hAlign < 0 || hAlign > 100.0f)
                throw new ArgumentException("hAlign must be between 0.0 and 100.0 (inclusive).", "hAlign");
            if (vAlign < 0 || vAlign > 100.0f)
                throw new ArgumentException("vAlign must be between 0.0 and 100.0 (inclusive).", "vAlign");
            Size scaled = GetSizedImageBounds(image, fit.Size);
            int x = fit.Left + (int)(hAlign / 100.0f * (float)(fit.Width - scaled.Width));
            int y = fit.Top + (int)(vAlign / 100.0f * (float)(fit.Height - scaled.Height));

            return new Rectangle(x, y, scaled.Width, scaled.Height);
        }

        /// <summary>
        /// Gets the bounding rectangle of an image required to fit
        /// in to the given rectangle keeping the image aspect ratio.
        /// The image will be centered in the fit box.
        /// </summary>
        /// <param name="image">The source image.</param>
        /// <param name="fit">The rectangle to fit in to.</param>
        /// <returns>New image size.</returns>
        public static Rectangle GetSizedImageBounds(this Image image, Rectangle fit)
        {
            return GetSizedImageBounds(image, fit, 50.0f, 50.0f);
        }

        /// <summary>
        /// Gets the scaled size of an image required to fit
        /// in to the given size keeping the image aspect ratio.
        /// </summary>
        /// <param name="image">The source image.</param>
        /// <param name="fit">The size to fit in to.</param>
        /// <returns>New image size.</returns>
        public static Size GetSizedImageBounds(this Image image, Size fit)
        {
            float f = System.Math.Max((float)image.Width / (float)fit.Width, (float)image.Height / (float)fit.Height);
            if (f < 1.0f) f = 1.0f; // Do not upsize small images
            int width = (int)System.Math.Round((float)image.Width / f);
            int height = (int)System.Math.Round((float)image.Height / f);
            return new Size(width, height);
        }

        /// <summary>
        /// Resizes the image.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="desiredWidth">Width of the desired.</param>
        /// <param name="desiredHeight">Height of the desired.</param>
        /// <returns>Image.</returns>
        /// <exception cref="InvalidOperationException">Bounding Box of Resize Photo must be larger than 4X4 pixels.</exception>
        public static Image ResizeImage(Image sourceImage, int desiredWidth, int desiredHeight)
        {
            //No Image to scale
            if (sourceImage == null)
            {
                return null;
            }
            //throw error if bouning box is to small
            if (desiredWidth < 4 || desiredHeight < 4)
                throw new InvalidOperationException("Bounding Box of Resize Photo must be larger than 4X4 pixels.");
            var original = new System.Drawing.Bitmap(sourceImage);

            //store image widths in variable for easier use
            var oW = (decimal)original.Width;
            var oH = (decimal)original.Height;
            var dW = (decimal)desiredWidth;
            var dH = (decimal)desiredHeight;

            System.Drawing.Bitmap SquareTest = new System.Drawing.Bitmap(original, (int)dW, (int)dH);
            original.Dispose();
            return SquareTest;

            //check if image already fits
            if (oW < dW && oH < dH)
                return original; //image fits in bounding box, keep size (center with css) If we made it biger it would stretch the image resulting in loss of quality.

            //check for double squares
            if (oW == oH && dW == dH)
            {
                //image and bounding box are square, no need to calculate aspects, just downsize it with the bounding box
                System.Drawing.Bitmap square = new System.Drawing.Bitmap(original, (int)dW, (int)dH);
                original.Dispose();
                return square;
            }

            //check original image is square
            if (oW == oH)
            {
                //image is square, bounding box isn't.  Get smallest side of bounding box and resize to a square of that center the image vertically and horizonatally with Css there will be space on one side.
                int smallSide = (int)Math.Min(dW, dH);
                System.Drawing.Bitmap square = new System.Drawing.Bitmap(original, smallSide, smallSide);
                original.Dispose();
                return square;
            }

            //not dealing with squares, figure out resizing within aspect ratios            
            if (oW > dW && oH > dH) //image is wider and taller than bounding box
            {
                var r = Math.Min(dW, dH) / Math.Min(oW, oH); //two demensions so figure out which bounding box demension is the smallest and which original image demension is the smallest, already know original image is larger than bounding box
                var nH = oW * r; //will downscale the original image by an aspect ratio to fit in the bounding box at the maximum size within aspect ratio.
                var nW = oW * r;
                var resized = new System.Drawing.Bitmap(original, (int)nW, (int)nH);
                original.Dispose();
                return resized;
            }
            else
            {
                if (oW > dW) //image is wider than bounding box
                {
                    var r = dW / oW; //one demension (width) so calculate the aspect ratio between the bounding box width and original image width
                    var nW = oW * r; //downscale image by r to fit in the bounding box...
                    var nH = oW * r;
                    var resized = new System.Drawing.Bitmap(original, (int)nW, (int)nH);
                    original.Dispose();
                    return resized;
                }
                else
                {
                    //original image is taller than bounding box
                    var r = dH / oH;
                    var nH = oH * r;
                    var nW = oW * r;
                    var resized = new System.Drawing.Bitmap(original, (int)nW, (int)nH);
                    original.Dispose();
                    return resized;
                }
            }
        }

        /// <summary>
        /// Images to code.
        /// </summary>
        /// <param name="Img">The img.</param>
        /// <returns>System.String.</returns>
        public static string ImageToCode(System.Drawing.Bitmap Img)
        {
            return Convert.ToBase64String((byte[])System.ComponentModel.TypeDescriptor.GetConverter(Img).ConvertTo(Img, typeof(byte[])));
        }

        /// <summary>
        /// Codes to image.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <returns>Image.</returns>
        public static Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
            
        }

    }
}
