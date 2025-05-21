using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BachelorProject
{
    public class ThumbnailConfig
    {
        public string BackgroundImage { get; set; }
        public string OverlayImage { get; set; }
        public int BlurAmount { get; set; }
        public Point OverlayPosition { get; set; }
        public float OverlayScale { get; set; }
        public string Text { get; set; }
        public string TextFont { get; set; }
        public float TextFontSize { get; set; }
        public string TextColor { get; set; }
        public bool IsBold { get; set; }
        public string TextHorizontalAlignment { get; set; }
        public int TextVerticalPosition { get; set; }
        public bool WrapText { get; set; }
        public float WrapWidthRatio { get; set; }
        public float TextPositionX { get; set; }
        public float TextPositionY { get; set; }

    }
}
