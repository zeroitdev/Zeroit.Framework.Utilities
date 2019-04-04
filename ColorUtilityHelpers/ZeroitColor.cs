// Decompiled with JetBrains decompiler
// Type: System.Drawing.ZeroitColor
// Assembly: System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 601B0B19-9CD6-4155-A530-575F2FBA2670
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Drawing.dll

using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Drawing;
using System;

namespace Zeroit.Framework.Utilities
{
    /// <summary>Represents an ARGB (alpha, red, green, blue) color.</summary>
    [TypeConverter(typeof(ColorConverter))]
    [DebuggerDisplay("{NameAndARGBValue}")]
    [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [Serializable]
    public struct ZeroitColor
    {
        /// <summary>Represents a color that is null.</summary>
        public static readonly ZeroitColor Empty = new ZeroitColor();
        private static short StateKnownColorValid = 1;
        private static short StateARGBValueValid = 2;
        private static short StateValueMask = ZeroitColor.StateARGBValueValid;
        private static short StateNameValid = 8;
        private static long NotDefinedValue = 0;
        private const int ARGBAlphaShift = 24;
        private const int ARGBRedShift = 16;
        private const int ARGBGreenShift = 8;
        private const int ARGBBlueShift = 0;
        private readonly string name;
        private readonly long value;
        private readonly short knownColor;
        private readonly short state;

        /// <summary>Gets a system-defined color.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Transparent
        {
            get
            {
                return new ZeroitColor(KnownColor.Transparent);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF0F8FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor AliceBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.AliceBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFAEBD7.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor AntiqueWhite
        {
            get
            {
                return new ZeroitColor(KnownColor.AntiqueWhite);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Aqua
        {
            get
            {
                return new ZeroitColor(KnownColor.Aqua);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF7FFFD4.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Aquamarine
        {
            get
            {
                return new ZeroitColor(KnownColor.Aquamarine);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF0FFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Azure
        {
            get
            {
                return new ZeroitColor(KnownColor.Azure);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF5F5DC.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Beige
        {
            get
            {
                return new ZeroitColor(KnownColor.Beige);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFE4C4.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Bisque
        {
            get
            {
                return new ZeroitColor(KnownColor.Bisque);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF000000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Black
        {
            get
            {
                return new ZeroitColor(KnownColor.Black);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFEBCD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor BlanchedAlmond
        {
            get
            {
                return new ZeroitColor(KnownColor.BlanchedAlmond);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF0000FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Blue
        {
            get
            {
                return new ZeroitColor(KnownColor.Blue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF8A2BE2.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor BlueViolet
        {
            get
            {
                return new ZeroitColor(KnownColor.BlueViolet);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFA52A2A.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Brown
        {
            get
            {
                return new ZeroitColor(KnownColor.Brown);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDEB887.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor BurlyWood
        {
            get
            {
                return new ZeroitColor(KnownColor.BurlyWood);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF5F9EA0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor CadetBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.CadetBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF7FFF00.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Chartreuse
        {
            get
            {
                return new ZeroitColor(KnownColor.Chartreuse);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFD2691E.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Chocolate
        {
            get
            {
                return new ZeroitColor(KnownColor.Chocolate);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF7F50.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Coral
        {
            get
            {
                return new ZeroitColor(KnownColor.Coral);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF6495ED.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor CornflowerBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.CornflowerBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFF8DC.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Cornsilk
        {
            get
            {
                return new ZeroitColor(KnownColor.Cornsilk);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDC143C.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Crimson
        {
            get
            {
                return new ZeroitColor(KnownColor.Crimson);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Cyan
        {
            get
            {
                return new ZeroitColor(KnownColor.Cyan);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00008B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF008B8B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkCyan
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkCyan);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFB8860B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkGoldenrod
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkGoldenrod);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFA9A9A9.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkGray
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF006400.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFBDB76B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkKhaki
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkKhaki);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF8B008B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkMagenta
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkMagenta);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF556B2F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkOliveGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkOliveGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF8C00.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkOrange
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkOrange);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF9932CC.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkOrchid
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkOrchid);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF8B0000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkRed
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkRed);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFE9967A.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkSalmon
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkSalmon);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF8FBC8F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkSeaGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkSeaGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF483D8B.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkSlateBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkSlateBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF2F4F4F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkSlateGray
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkSlateGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00CED1.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkTurquoise
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkTurquoise);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF9400D3.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DarkViolet
        {
            get
            {
                return new ZeroitColor(KnownColor.DarkViolet);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF1493.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DeepPink
        {
            get
            {
                return new ZeroitColor(KnownColor.DeepPink);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00BFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DeepSkyBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.DeepSkyBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF696969.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DimGray
        {
            get
            {
                return new ZeroitColor(KnownColor.DimGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF1E90FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor DodgerBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.DodgerBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFB22222.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Firebrick
        {
            get
            {
                return new ZeroitColor(KnownColor.Firebrick);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFAF0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor FloralWhite
        {
            get
            {
                return new ZeroitColor(KnownColor.FloralWhite);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF228B22.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor ForestGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.ForestGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF00FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Fuchsia
        {
            get
            {
                return new ZeroitColor(KnownColor.Fuchsia);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDCDCDC.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Gainsboro
        {
            get
            {
                return new ZeroitColor(KnownColor.Gainsboro);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF8F8FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor GhostWhite
        {
            get
            {
                return new ZeroitColor(KnownColor.GhostWhite);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFD700.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Gold
        {
            get
            {
                return new ZeroitColor(KnownColor.Gold);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDAA520.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Goldenrod
        {
            get
            {
                return new ZeroitColor(KnownColor.Goldenrod);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF808080.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> strcture representing a system-defined color.</returns>
        public static ZeroitColor Gray
        {
            get
            {
                return new ZeroitColor(KnownColor.Gray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF008000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Green
        {
            get
            {
                return new ZeroitColor(KnownColor.Green);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFADFF2F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor GreenYellow
        {
            get
            {
                return new ZeroitColor(KnownColor.GreenYellow);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF0FFF0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Honeydew
        {
            get
            {
                return new ZeroitColor(KnownColor.Honeydew);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF69B4.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor HotPink
        {
            get
            {
                return new ZeroitColor(KnownColor.HotPink);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFCD5C5C.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor IndianRed
        {
            get
            {
                return new ZeroitColor(KnownColor.IndianRed);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF4B0082.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Indigo
        {
            get
            {
                return new ZeroitColor(KnownColor.Indigo);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFFF0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Ivory
        {
            get
            {
                return new ZeroitColor(KnownColor.Ivory);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF0E68C.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Khaki
        {
            get
            {
                return new ZeroitColor(KnownColor.Khaki);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFE6E6FA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Lavender
        {
            get
            {
                return new ZeroitColor(KnownColor.Lavender);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFF0F5.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LavenderBlush
        {
            get
            {
                return new ZeroitColor(KnownColor.LavenderBlush);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF7CFC00.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LawnGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.LawnGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFACD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LemonChiffon
        {
            get
            {
                return new ZeroitColor(KnownColor.LemonChiffon);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFADD8E6.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.LightBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF08080.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightCoral
        {
            get
            {
                return new ZeroitColor(KnownColor.LightCoral);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFE0FFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightCyan
        {
            get
            {
                return new ZeroitColor(KnownColor.LightCyan);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFAFAD2.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightGoldenrodYellow
        {
            get
            {
                return new ZeroitColor(KnownColor.LightGoldenrodYellow);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF90EE90.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.LightGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFD3D3D3.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightGray
        {
            get
            {
                return new ZeroitColor(KnownColor.LightGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFB6C1.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightPink
        {
            get
            {
                return new ZeroitColor(KnownColor.LightPink);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFA07A.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightSalmon
        {
            get
            {
                return new ZeroitColor(KnownColor.LightSalmon);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF20B2AA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightSeaGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.LightSeaGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF87CEFA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightSkyBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.LightSkyBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF778899.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightSlateGray
        {
            get
            {
                return new ZeroitColor(KnownColor.LightSlateGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFB0C4DE.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightSteelBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.LightSteelBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFFE0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LightYellow
        {
            get
            {
                return new ZeroitColor(KnownColor.LightYellow);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FF00.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Lime
        {
            get
            {
                return new ZeroitColor(KnownColor.Lime);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF32CD32.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor LimeGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.LimeGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFAF0E6.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Linen
        {
            get
            {
                return new ZeroitColor(KnownColor.Linen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF00FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Magenta
        {
            get
            {
                return new ZeroitColor(KnownColor.Magenta);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF800000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Maroon
        {
            get
            {
                return new ZeroitColor(KnownColor.Maroon);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF66CDAA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumAquamarine
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumAquamarine);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF0000CD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFBA55D3.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumOrchid
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumOrchid);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF9370DB.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumPurple
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumPurple);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF3CB371.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumSeaGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumSeaGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF7B68EE.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumSlateBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumSlateBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FA9A.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumSpringGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumSpringGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF48D1CC.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumTurquoise
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumTurquoise);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFC71585.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MediumVioletRed
        {
            get
            {
                return new ZeroitColor(KnownColor.MediumVioletRed);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF191970.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MidnightBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.MidnightBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF5FFFA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MintCream
        {
            get
            {
                return new ZeroitColor(KnownColor.MintCream);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFE4E1.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor MistyRose
        {
            get
            {
                return new ZeroitColor(KnownColor.MistyRose);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFE4B5.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Moccasin
        {
            get
            {
                return new ZeroitColor(KnownColor.Moccasin);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFDEAD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor NavajoWhite
        {
            get
            {
                return new ZeroitColor(KnownColor.NavajoWhite);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF000080.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Navy
        {
            get
            {
                return new ZeroitColor(KnownColor.Navy);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFDF5E6.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor OldLace
        {
            get
            {
                return new ZeroitColor(KnownColor.OldLace);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF808000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Olive
        {
            get
            {
                return new ZeroitColor(KnownColor.Olive);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF6B8E23.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor OliveDrab
        {
            get
            {
                return new ZeroitColor(KnownColor.OliveDrab);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFA500.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Orange
        {
            get
            {
                return new ZeroitColor(KnownColor.Orange);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF4500.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor OrangeRed
        {
            get
            {
                return new ZeroitColor(KnownColor.OrangeRed);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDA70D6.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Orchid
        {
            get
            {
                return new ZeroitColor(KnownColor.Orchid);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFEEE8AA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PaleGoldenrod
        {
            get
            {
                return new ZeroitColor(KnownColor.PaleGoldenrod);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF98FB98.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PaleGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.PaleGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFAFEEEE.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PaleTurquoise
        {
            get
            {
                return new ZeroitColor(KnownColor.PaleTurquoise);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDB7093.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PaleVioletRed
        {
            get
            {
                return new ZeroitColor(KnownColor.PaleVioletRed);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFEFD5.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PapayaWhip
        {
            get
            {
                return new ZeroitColor(KnownColor.PapayaWhip);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFDAB9.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PeachPuff
        {
            get
            {
                return new ZeroitColor(KnownColor.PeachPuff);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFCD853F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Peru
        {
            get
            {
                return new ZeroitColor(KnownColor.Peru);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFC0CB.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Pink
        {
            get
            {
                return new ZeroitColor(KnownColor.Pink);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFDDA0DD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Plum
        {
            get
            {
                return new ZeroitColor(KnownColor.Plum);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFB0E0E6.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor PowderBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.PowderBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF800080.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Purple
        {
            get
            {
                return new ZeroitColor(KnownColor.Purple);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF0000.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Red
        {
            get
            {
                return new ZeroitColor(KnownColor.Red);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFBC8F8F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor RosyBrown
        {
            get
            {
                return new ZeroitColor(KnownColor.RosyBrown);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF4169E1.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor RoyalBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.RoyalBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF8B4513.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SaddleBrown
        {
            get
            {
                return new ZeroitColor(KnownColor.SaddleBrown);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFA8072.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Salmon
        {
            get
            {
                return new ZeroitColor(KnownColor.Salmon);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF4A460.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SandyBrown
        {
            get
            {
                return new ZeroitColor(KnownColor.SandyBrown);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF2E8B57.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SeaGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.SeaGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFF5EE.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SeaShell
        {
            get
            {
                return new ZeroitColor(KnownColor.SeaShell);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFA0522D.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Sienna
        {
            get
            {
                return new ZeroitColor(KnownColor.Sienna);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFC0C0C0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Silver
        {
            get
            {
                return new ZeroitColor(KnownColor.Silver);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF87CEEB.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SkyBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.SkyBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF6A5ACD.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SlateBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.SlateBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF708090.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SlateGray
        {
            get
            {
                return new ZeroitColor(KnownColor.SlateGray);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFAFA.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Snow
        {
            get
            {
                return new ZeroitColor(KnownColor.Snow);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FF7F.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SpringGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.SpringGreen);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF4682B4.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor SteelBlue
        {
            get
            {
                return new ZeroitColor(KnownColor.SteelBlue);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFD2B48C.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Tan
        {
            get
            {
                return new ZeroitColor(KnownColor.Tan);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF008080.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Teal
        {
            get
            {
                return new ZeroitColor(KnownColor.Teal);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFD8BFD8.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Thistle
        {
            get
            {
                return new ZeroitColor(KnownColor.Thistle);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF6347.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Tomato
        {
            get
            {
                return new ZeroitColor(KnownColor.Tomato);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF40E0D0.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Turquoise
        {
            get
            {
                return new ZeroitColor(KnownColor.Turquoise);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFEE82EE.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Violet
        {
            get
            {
                return new ZeroitColor(KnownColor.Violet);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF5DEB3.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Wheat
        {
            get
            {
                return new ZeroitColor(KnownColor.Wheat);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor White
        {
            get
            {
                return new ZeroitColor(KnownColor.White);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFF5F5F5.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor WhiteSmoke
        {
            get
            {
                return new ZeroitColor(KnownColor.WhiteSmoke);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFF00.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor Yellow
        {
            get
            {
                return new ZeroitColor(KnownColor.Yellow);
            }
        }

        /// <summary>Gets a system-defined color that has an ARGB value of #FF9ACD32.</summary>
        /// <returns>A <see cref="T:System.Drawing.ZeroitColor" /> representing a system-defined color.</returns>
        public static ZeroitColor YellowGreen
        {
            get
            {
                return new ZeroitColor(KnownColor.YellowGreen);
            }
        }

        /// <summary>Gets the red component value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The red component value of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public byte R
        {
            get
            {
                return (byte)((ulong)(this.Value >> 16) & (ulong)byte.MaxValue);
            }
        }

        /// <summary>Gets the green component value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The green component value of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public byte G
        {
            get
            {
                return (byte)((ulong)(this.Value >> 8) & (ulong)byte.MaxValue);
            }
        }

        /// <summary>Gets the blue component value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The blue component value of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public byte B
        {
            get
            {
                return (byte)((ulong)this.Value & (ulong)byte.MaxValue);
            }
        }

        /// <summary>Gets the alpha component value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The alpha component value of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public byte A
        {
            get
            {
                return (byte)((ulong)(this.Value >> 24) & (ulong)byte.MaxValue);
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:System.Drawing.ZeroitColor" /> structure is a predefined color. Predefined colors are represented by the elements of the <see cref="T:System.Drawing.KnownColor" /> enumeration.</summary>
        /// <returns>true if this <see cref="T:System.Drawing.ZeroitColor" /> was created from a predefined color by using either the <see cref="M:System.Drawing.ZeroitColor.FromName(System.String)" /> method or the <see cref="M:System.Drawing.ZeroitColor.FromKnownColor(System.Drawing.KnownColor)" /> method; otherwise, false.</returns>
        public bool IsKnownColor
        {
            get
            {
                return ((uint)this.state & (uint)ZeroitColor.StateKnownColorValid) > 0U;
            }
        }

        /// <summary>Specifies whether this <see cref="T:System.Drawing.ZeroitColor" /> structure is uninitialized.</summary>
        /// <returns>This property returns true if this color is uninitialized; otherwise, false.</returns>
        public bool IsEmpty
        {
            get
            {
                return (int)this.state == 0;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:System.Drawing.ZeroitColor" /> structure is a named color or a member of the <see cref="T:System.Drawing.KnownColor" /> enumeration.</summary>
        /// <returns>true if this <see cref="T:System.Drawing.ZeroitColor" /> was created by using either the <see cref="M:System.Drawing.ZeroitColor.FromName(System.String)" /> method or the <see cref="M:System.Drawing.ZeroitColor.FromKnownColor(System.Drawing.KnownColor)" /> method; otherwise, false.</returns>
        public bool IsNamedColor
        {
            get
            {
                if (((int)this.state & (int)ZeroitColor.StateNameValid) == 0)
                    return this.IsKnownColor;
                return true;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:System.Drawing.ZeroitColor" /> structure is a system color. A system color is a color that is used in a Windows display element. System colors are represented by elements of the <see cref="T:System.Drawing.KnownColor" /> enumeration.</summary>
        /// <returns>true if this <see cref="T:System.Drawing.ZeroitColor" /> was created from a system color by using either the <see cref="M:System.Drawing.ZeroitColor.FromName(System.String)" /> method or the <see cref="M:System.Drawing.ZeroitColor.FromKnownColor(System.Drawing.KnownColor)" /> method; otherwise, false.</returns>
        public bool IsSystemColor
        {
            get
            {
                if (!this.IsKnownColor)
                    return false;
                if ((int)this.knownColor > 26)
                    return (int)this.knownColor > 167;
                return true;
            }
        }

        private string NameAndARGBValue
        {
            get
            {
                return string.Format((IFormatProvider)CultureInfo.CurrentCulture, "{{Name={0}, ARGB=({1}, {2}, {3}, {4})}}", (object)this.Name, (object)this.A, (object)this.R, (object)this.G, (object)this.B);
            }
        }

        /// <summary>Gets the name of this <see cref="T:System.Drawing.ZeroitColor" />.</summary>
        /// <returns>The name of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public string Name
        {
            get
            {
                if (((int)this.state & (int)ZeroitColor.StateNameValid) != 0)
                    return this.name;
                if (this.IsKnownColor)
                    return KnownColorTable.KnownColorToName((KnownColor)this.knownColor) ?? ((KnownColor)this.knownColor).ToString();
                return Convert.ToString(this.value, 16);
            }
        }

        private long Value
        {
            get
            {
                if (((int)this.state & (int)ZeroitColor.StateValueMask) != 0)
                    return this.value;
                if (this.IsKnownColor)
                    return (long)KnownColorTable.KnownColorToArgb((KnownColor)this.knownColor);
                return ZeroitColor.NotDefinedValue;
            }
        }

        internal ZeroitColor(KnownColor knownColor)
        {
            this.value = 0L;
            this.state = ZeroitColor.StateKnownColorValid;
            this.name = (string)null;
            this.knownColor = (short)knownColor;
        }

        public ZeroitColor(long value, short state, string name, KnownColor knownColor)
        {
            this.value = value;
            this.state = state;
            this.name = name;
            this.knownColor = (short)knownColor;
        }

        /// <summary>Tests whether two specified <see cref="T:System.Drawing.ZeroitColor" /> structures are equivalent.</summary>
        /// <param name="left">The <see cref="T:System.Drawing.ZeroitColor" /> that is to the left of the equality operator. </param>
        /// <param name="right">The <see cref="T:System.Drawing.ZeroitColor" /> that is to the right of the equality operator. </param>
        /// <returns>true if the two <see cref="T:System.Drawing.ZeroitColor" /> structures are equal; otherwise, false.</returns>
        public static bool operator ==(ZeroitColor left, ZeroitColor right)
        {
            if (left.value != right.value || (int)left.state != (int)right.state || (int)left.knownColor != (int)right.knownColor)
                return false;
            if (left.name == right.name)
                return true;
            if (left.name == null || right.name == null)
                return false;
            return left.name.Equals(right.name);
        }

        /// <summary>Tests whether two specified <see cref="T:System.Drawing.ZeroitColor" /> structures are different.</summary>
        /// <param name="left">The <see cref="T:System.Drawing.ZeroitColor" /> that is to the left of the inequality operator. </param>
        /// <param name="right">The <see cref="T:System.Drawing.ZeroitColor" /> that is to the right of the inequality operator. </param>
        /// <returns>true if the two <see cref="T:System.Drawing.ZeroitColor" /> structures are different; otherwise, false.</returns>
        public static bool operator !=(ZeroitColor left, ZeroitColor right)
        {
            return !(left == right);
        }

        private static void CheckByte(int value, string name)
        {
            if (value < 0 || value > (int)byte.MaxValue)
                throw new ArgumentException("InvalidEx2BoundArgument" /*Convert.ToString((object)name.ToString()) + (object)value.ToString() + (object)0.ToString() + Convert.ToString((object)byte.MaxValue.ToString())*/);
        }

        public static long MakeArgb(byte alpha, byte red, byte green, byte blue)
        {
            return (long)(uint)((int)red << 16 | (int)green << 8 | (int)blue | (int)alpha << 24) & (long)uint.MaxValue;
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from a 32-bit ARGB value.</summary>
        /// <param name="argb">A value specifying the 32-bit ARGB value. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> structure that this method creates.</returns>
        public static ZeroitColor FromArgb(int argb)
        {
            return new ZeroitColor((long)argb & (long)uint.MaxValue, ZeroitColor.StateARGBValueValid, (string)null, (KnownColor)0);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from the four ARGB component (alpha, red, green, and blue) values. Although this method allows a 32-bit value to be passed for each component, the value of each component is limited to 8 bits.</summary>
        /// <param name="alpha">The alpha component. Valid values are 0 through 255. </param>
        /// <param name="red">The red component. Valid values are 0 through 255. </param>
        /// <param name="green">The green component. Valid values are 0 through 255. </param>
        /// <param name="blue">The blue component. Valid values are 0 through 255. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> that this method creates.</returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="alpha" />, <paramref name="red" />, <paramref name="green" />, or <paramref name="blue" /> is less than 0 or greater than 255.</exception>
        public static ZeroitColor FromArgb(int alpha, int red, int green, int blue)
        {
            ZeroitColor.CheckByte(alpha, "alpha");
            ZeroitColor.CheckByte(red, "red");
            ZeroitColor.CheckByte(green, "green");
            ZeroitColor.CheckByte(blue, "blue");
            return new ZeroitColor(ZeroitColor.MakeArgb((byte)alpha, (byte)red, (byte)green, (byte)blue), ZeroitColor.StateARGBValueValid, (string)null, (KnownColor)0);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from the specified <see cref="T:System.Drawing.ZeroitColor" /> structure, but with the new specified alpha value. Although this method allows a 32-bit value to be passed for the alpha value, the value is limited to 8 bits.</summary>
        /// <param name="alpha">The alpha value for the new <see cref="T:System.Drawing.ZeroitColor" />. Valid values are 0 through 255. </param>
        /// <param name="baseColor">The <see cref="T:System.Drawing.ZeroitColor" /> from which to create the new <see cref="T:System.Drawing.ZeroitColor" />. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> that this method creates.</returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="alpha" /> is less than 0 or greater than 255.</exception>
        public static ZeroitColor FromArgb(int alpha, ZeroitColor baseColor)
        {
            ZeroitColor.CheckByte(alpha, "alpha");
            return new ZeroitColor(ZeroitColor.MakeArgb((byte)alpha, baseColor.R, baseColor.G, baseColor.B), ZeroitColor.StateARGBValueValid, (string)null, (KnownColor)0);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from the specified 8-bit color values (red, green, and blue). The alpha value is implicitly 255 (fully opaque). Although this method allows a 32-bit value to be passed for each color component, the value of each component is limited to 8 bits.</summary>
        /// <param name="red">The red component value for the new <see cref="T:System.Drawing.ZeroitColor" />. Valid values are 0 through 255. </param>
        /// <param name="green">The green component value for the new <see cref="T:System.Drawing.ZeroitColor" />. Valid values are 0 through 255. </param>
        /// <param name="blue">The blue component value for the new <see cref="T:System.Drawing.ZeroitColor" />. Valid values are 0 through 255. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> that this method creates.</returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="red" />, <paramref name="green" />, or <paramref name="blue" /> is less than 0 or greater than 255.</exception>
        public static ZeroitColor FromArgb(int red, int green, int blue)
        {
            return ZeroitColor.FromArgb((int)byte.MaxValue, red, green, blue);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from the specified predefined color.</summary>
        /// <param name="color">An element of the <see cref="T:System.Drawing.KnownColor" /> enumeration. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> that this method creates.</returns>
        public static ZeroitColor FromKnownColor(KnownColor color)
        {
            if (!Zeroit.Framework.Utilities.ClientUtils.IsEnumValid((Enum)color, (int)color, 1, 174))
                return ZeroitColor.FromName(color.ToString());
            return new ZeroitColor(color);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.ZeroitColor" /> structure from the specified name of a predefined color.</summary>
        /// <param name="name">A string that is the name of a predefined color. Valid names are the same as the names of the elements of the <see cref="T:System.Drawing.KnownColor" /> enumeration. </param>
        /// <returns>The <see cref="T:System.Drawing.ZeroitColor" /> that this method creates.</returns>
        public static ZeroitColor FromName(string name)
        {
            object namedColor = Zeroit.Framework.Utilities.ColorConverter.GetNamedColor(name);
            if (namedColor != null)
                return (ZeroitColor)namedColor;
            return new ZeroitColor(ZeroitColor.NotDefinedValue, ZeroitColor.StateNameValid, name, (KnownColor)0);
        }

        //internal static object GetNamedColor(string name)
        //{
        //    object color = null;
        //    // First, check to see if this is a standard name.
        //    //
        //    color = Color.FromKnownColor(();
        //    if (color != null)
        //    {
        //        return color;
        //    }
        //    // Ok, how about a system color?
        //    //
        //    color = SystemColors[name];
        //    return color;
        //}

        

        /// <summary>Gets the hue-saturation-brightness (HSB) brightness value for this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The brightness of this <see cref="T:System.Drawing.ZeroitColor" />. The brightness ranges from 0.0 through 1.0, where 0.0 represents black and 1.0 represents white.</returns>
        public float GetBrightness()
        {
            float num1 = (float)this.R / (float)byte.MaxValue;
            float num2 = (float)this.G / (float)byte.MaxValue;
            float num3 = (float)this.B / (float)byte.MaxValue;
            float num4 = num1;
            float num5 = num1;
            if ((double)num2 > (double)num4)
                num4 = num2;
            if ((double)num3 > (double)num4)
                num4 = num3;
            if ((double)num2 < (double)num5)
                num5 = num2;
            if ((double)num3 < (double)num5)
                num5 = num3;
            return (float)(((double)num4 + (double)num5) / 2.0);
        }

        /// <summary>Gets the hue-saturation-brightness (HSB) hue value, in degrees, for this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The hue, in degrees, of this <see cref="T:System.Drawing.ZeroitColor" />. The hue is measured in degrees, ranging from 0.0 through 360.0, in HSB color space.</returns>
        public float GetHue()
        {
            if ((int)this.R == (int)this.G && (int)this.G == (int)this.B)
                return 0.0f;
            float num1 = (float)this.R / (float)byte.MaxValue;
            float num2 = (float)this.G / (float)byte.MaxValue;
            float num3 = (float)this.B / (float)byte.MaxValue;
            float num4 = 0.0f;
            float num5 = num1;
            float num6 = num1;
            if ((double)num2 > (double)num5)
                num5 = num2;
            if ((double)num3 > (double)num5)
                num5 = num3;
            if ((double)num2 < (double)num6)
                num6 = num2;
            if ((double)num3 < (double)num6)
                num6 = num3;
            float num7 = num5 - num6;
            if ((double)num1 == (double)num5)
                num4 = (num2 - num3) / num7;
            else if ((double)num2 == (double)num5)
                num4 = (float)(2.0 + ((double)num3 - (double)num1) / (double)num7);
            else if ((double)num3 == (double)num5)
                num4 = (float)(4.0 + ((double)num1 - (double)num2) / (double)num7);
            float num8 = num4 * 60f;
            if ((double)num8 < 0.0)
                num8 += 360f;
            return num8;
        }

        /// <summary>Gets the hue-saturation-brightness (HSB) saturation value for this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The saturation of this <see cref="T:System.Drawing.ZeroitColor" />. The saturation ranges from 0.0 through 1.0, where 0.0 is grayscale and 1.0 is the most saturated.</returns>
        public float GetSaturation()
        {
            float num1 = (float)this.R / (float)byte.MaxValue;
            float num2 = (float)this.G / (float)byte.MaxValue;
            float num3 = (float)this.B / (float)byte.MaxValue;
            float num4 = 0.0f;
            float num5 = num1;
            float num6 = num1;
            if ((double)num2 > (double)num5)
                num5 = num2;
            if ((double)num3 > (double)num5)
                num5 = num3;
            if ((double)num2 < (double)num6)
                num6 = num2;
            if ((double)num3 < (double)num6)
                num6 = num3;
            if ((double)num5 != (double)num6)
                num4 = ((double)num5 + (double)num6) / 2.0 > 0.5 ? (float)(((double)num5 - (double)num6) / (2.0 - (double)num5 - (double)num6)) : (float)(((double)num5 - (double)num6) / ((double)num5 + (double)num6));
            return num4;
        }

        /// <summary>Gets the 32-bit ARGB value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>The 32-bit ARGB value of this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public int ToArgb()
        {
            return (int)this.Value;
        }

        /// <summary>Gets the <see cref="T:System.Drawing.KnownColor" /> value of this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>An element of the <see cref="T:System.Drawing.KnownColor" /> enumeration, if the <see cref="T:System.Drawing.ZeroitColor" /> is created from a predefined color by using either the <see cref="M:System.Drawing.ZeroitColor.FromName(System.String)" /> method or the <see cref="M:System.Drawing.ZeroitColor.FromKnownColor(System.Drawing.KnownColor)" /> method; otherwise, 0.</returns>
        public KnownColor ToKnownColor()
        {
            return (KnownColor)this.knownColor;
        }

        /// <summary>Converts this <see cref="T:System.Drawing.ZeroitColor" /> structure to a human-readable string.</summary>
        /// <returns>A string that is the name of this <see cref="T:System.Drawing.ZeroitColor" />, if the <see cref="T:System.Drawing.ZeroitColor" /> is created from a predefined color by using either the <see cref="M:System.Drawing.ZeroitColor.FromName(System.String)" /> method or the <see cref="M:System.Drawing.ZeroitColor.FromKnownColor(System.Drawing.KnownColor)" /> method; otherwise, a string that consists of the ARGB component names and their values.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(32);
            stringBuilder.Append(this.GetType().Name);
            stringBuilder.Append(" [");
            if (((int)this.state & (int)ZeroitColor.StateNameValid) != 0)
                stringBuilder.Append(this.Name);
            else if (((int)this.state & (int)ZeroitColor.StateKnownColorValid) != 0)
                stringBuilder.Append(this.Name);
            else if (((int)this.state & (int)ZeroitColor.StateValueMask) != 0)
            {
                stringBuilder.Append("A=");
                stringBuilder.Append(this.A);
                stringBuilder.Append(", R=");
                stringBuilder.Append(this.R);
                stringBuilder.Append(", G=");
                stringBuilder.Append(this.G);
                stringBuilder.Append(", B=");
                stringBuilder.Append(this.B);
            }
            else
                stringBuilder.Append("Empty");
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        /// <summary>Tests whether the specified object is a <see cref="T:System.Drawing.ZeroitColor" /> structure and is equivalent to this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <param name="obj">The object to test. </param>
        /// <returns>true if <paramref name="obj" /> is a <see cref="T:System.Drawing.ZeroitColor" /> structure equivalent to this <see cref="T:System.Drawing.ZeroitColor" /> structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ZeroitColor)
            {
                ZeroitColor color = (ZeroitColor)obj;
                if (this.value == color.value && (int)this.state == (int)color.state && (int)this.knownColor == (int)color.knownColor)
                {
                    if (this.name == color.name)
                        return true;
                    if (this.name == null || color.name == null)
                        return false;
                    return this.name.Equals(this.name);
                }
            }
            return false;
        }

        /// <summary>Returns a hash code for this <see cref="T:System.Drawing.ZeroitColor" /> structure.</summary>
        /// <returns>An integer value that specifies the hash code for this <see cref="T:System.Drawing.ZeroitColor" />.</returns>
        public override int GetHashCode()
        {
            return this.value.GetHashCode() ^ this.state.GetHashCode() ^ this.knownColor.GetHashCode();
        }
    }



}
