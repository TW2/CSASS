using System.Drawing;
using CSASS.Common;

namespace CSASS
{
    public class ASS_Color
    {
        private C_Color _color;

        private ASS_Color()
        {
            _color = new C_Color(Color.Red);
        }

        public static ASS_Color create()
        {
            return new ASS_Color();
        }

        public static ASS_Color create(Color color)
        {
            ASS_Color ac = new ASS_Color();
            ac._color.Color = color;
            return ac;
        }

        public static ASS_Color create(string abgr)
        {
            ASS_Color ac = new ASS_Color();

            abgr = abgr.Replace("&", "");
            abgr = abgr.Replace("H", "");

            if (abgr.Length == 8)
            {
                ac._color.ABGR = abgr;
            }
            else if (abgr.Length == 6)
            {
                ac._color.BGR = abgr;
            }

            return ac;
        }

        public string toStyleColor()
        {
            return "&H" + C_Color.toString(_color.Color, C_Color.ColorMethod.ABGR);
        }

        public string toInLineColor()
        {
            return "&H" + C_Color.toString(_color.Color, C_Color.ColorMethod.BGR) + "&";
        }

        public string toInLineAlpha(bool reverse = false)
        {
            Color c = _color.Color;

            if (reverse)
            {
                c = Color.FromArgb(255 - c.A, c.R, c.G, c.B);
            }
            string alpha = C_Color.toString(c, C_Color.ColorMethod.ABGR).Substring(0, 2);

            return "&H" + alpha + "&";
        }
    }
}
