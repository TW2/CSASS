using CSASS.Common;
using System;
using System.Drawing;

namespace CSASS.ASSA
{
    public class SSA_Color
    {
        public C_Color CColor { get; set; }

        private SSA_Color()
        {
            CColor = new C_Color(Color.Red);
        }

        public static SSA_Color Create()
        {
            return new SSA_Color();
        }

        public static SSA_Color Create(Color color)
        {
            SSA_Color ac = new SSA_Color();
            ac.CColor.Color = color;
            return ac;
        }

        public static SSA_Color Create(int color)
        {
            SSA_Color ac = new SSA_Color();
            ac.CColor.Color = Color.FromArgb(color);
            return ac;
        }

        public static SSA_Color Create(string color)
        {
            return Create(Convert.ToInt32(color));
        }

        public string ToStyleColor()
        {
            return Convert.ToString(CColor.Color.R * CColor.Color.G * CColor.Color.B);
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
