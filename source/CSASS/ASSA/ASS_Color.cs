using System.Drawing;
using CSASS.Common;

namespace CSASS
{
    public class ASS_Color
    {
        public C_Color CColor { get; set; }

        private ASS_Color()
        {
            CColor = new C_Color(Color.Red);
        }

        public static ASS_Color Create()
        {
            return new ASS_Color();
        }

        public static ASS_Color Create(Color color)
        {
            ASS_Color ac = new ASS_Color();
            ac.CColor.Color = color;
            return ac;
        }

        public static ASS_Color Create(string abgr)
        {
            ASS_Color ac = new ASS_Color();

            abgr = abgr.Replace("&", "");
            abgr = abgr.Replace("H", "");

            if (abgr.Length == 8)
            {
                ac.CColor.ABGR = abgr;
            }
            else if (abgr.Length == 6)
            {
                ac.CColor.BGR = abgr;
            }

            return ac;
        }

        public string ToStyleColor()
        {
            return "&H" + C_Color.ToString(CColor.Color, C_Color.ColorMethod.ABGR);
        }

        public string ToInLineColor()
        {
            return "&H" + C_Color.ToString(CColor.Color, C_Color.ColorMethod.BGR) + "&";
        }

        public string ToInLineAlpha(bool reverse = false)
        {
            Color c = CColor.Color;

            if (reverse)
            {
                c = Color.FromArgb(255 - c.A, c.R, c.G, c.B);
            }
            string alpha = C_Color.ToString(c, C_Color.ColorMethod.ABGR).Substring(0, 2);

            return "&H" + alpha + "&";
        }
    }
}
