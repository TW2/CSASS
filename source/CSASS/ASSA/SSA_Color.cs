using CSASS.Common;
using System;
using System.Drawing;

namespace CSASS.ASSA
{
    public class SSA_Color
    {
        private C_Color _color;

        private SSA_Color()
        {
            _color = new C_Color(Color.Red);
        }

        public static SSA_Color create()
        {
            return new SSA_Color();
        }

        public static SSA_Color create(Color color)
        {
            SSA_Color ac = new SSA_Color();
            ac._color.Color = color;
            return ac;
        }

        public static SSA_Color create(int color)
        {
            SSA_Color ac = new SSA_Color();
            ac._color.Color = Color.FromArgb(color);
            return ac;
        }

        public static SSA_Color create(string color)
        {
            return create(Convert.ToInt32(color));
        }

        public string toStyleColor()
        {
            return Convert.ToString(_color.Color.R * _color.Color.G * _color.Color.B);
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
