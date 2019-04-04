// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WebColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;

namespace Zeroit.Framework.Utilities.GraphicsExtension.Colors
{
    [ToolboxItem(false)]
    public partial class AllWebColor : CatColorPicker
    {
        private ColorGroup systemColors = null;

        /// <summary>
        ///     Generate color groups.
        /// </summary>
        /// <returns>Array of color groups.</returns>
		public override ColorGroup[] GenerateColorGroups()
        {
            systemColors = new ColorGroup("System Colors");

           

            //systemColors.Add(SystemColors.ActiveBorder);
            //systemColors.Add(SystemColors.ActiveCaption);
            //systemColors.Add(SystemColors.ActiveCaptionText);
            //systemColors.Add(SystemColors.AppWorkspace);
            //systemColors.Add(SystemColors.ButtonFace);
            //systemColors.Add(SystemColors.ButtonHighlight);
            //systemColors.Add(SystemColors.ButtonShadow);
            //systemColors.Add(SystemColors.Control);
            //systemColors.Add(SystemColors.ControlDark);
            //systemColors.Add(SystemColors.ControlDarkDark);
            //systemColors.Add(SystemColors.ControlLight);
            //systemColors.Add(SystemColors.ControlLightLight);
            //systemColors.Add(SystemColors.ControlText);
            //systemColors.Add(SystemColors.Desktop);
            //systemColors.Add(SystemColors.GradientActiveCaption);
            //systemColors.Add(SystemColors.GradientInactiveCaption);
            //systemColors.Add(SystemColors.GrayText);
            //systemColors.Add(SystemColors.Highlight);
            //systemColors.Add(SystemColors.HighlightText);
            //systemColors.Add(SystemColors.HotTrack);
            //systemColors.Add(SystemColors.InactiveBorder);
            //systemColors.Add(SystemColors.InactiveCaption);
            //systemColors.Add(SystemColors.InactiveCaptionText);
            //systemColors.Add(SystemColors.Info);
            //systemColors.Add(SystemColors.InfoText);
            //systemColors.Add(SystemColors.Menu);
            //systemColors.Add(SystemColors.MenuBar);
            //systemColors.Add(SystemColors.MenuHighlight);
            //systemColors.Add(SystemColors.MenuText);
            //systemColors.Add(SystemColors.ScrollBar);
            //systemColors.Add(SystemColors.Window);
            //systemColors.Add(SystemColors.WindowFrame);
            //systemColors.Add(SystemColors.WindowText);

            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zaffre);
            systemColors.Add(WebColor.ZinnwalditeBrown);
            systemColors.Add(WebColor.Zomp);
            systemColors.Add(WebColor.Zomp);

            return new ColorGroup[] { systemColors };
        }

        /// <summary>
        ///     Returns maximum number of columns (1).
        /// </summary>
        /// <returns>Maximum number of columns.</returns>
		public override int GetMaxColumnCount()
        {
            return 1;
        }

        /// <summary>
        ///     Organizes the color groups depending on the number of columns being displayed.
        /// </summary>
        /// <param name="groups">Array of array of color groups.</param>
		public override void SplitColorGroups(ColorGroup[][] groups)
        {
            groups[0] = new ColorGroup[1];

            AddColorGroup(systemColors);
        }
    }
}
