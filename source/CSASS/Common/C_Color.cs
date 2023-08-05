using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Common
{
    public class C_Color
    {
        private Color _c_color;

        public enum ColorMethod
        {
            BGR = 0, RGB = 1, BGRA = 2, RGBA = 3, ABGR = 4, ARGB = 5
        }

        public C_Color(Color color)
        {
            _c_color = color;
        }

        public static string toString(Color c, ColorMethod m = ColorMethod.BGR)
        {
            int red = c.R;
            int green = c.G;
            int blue = c.B;
            int alpha = c.A;

            string r = Convert.ToString(red, 16);
            string g = Convert.ToString(green, 16);
            string b = Convert.ToString(blue, 16);
            string a = Convert.ToString(alpha, 16);

            if(r.Length == 1) r = "0" + r;
            if(g.Length == 1) g = "0" + g;
            if(b.Length == 1) b = "0" + b;
            if(a.Length == 1) a = "0" + a;

            string v = string.Empty;

            switch (m)
            {
                case ColorMethod.BGR: v = b + g + r; break;
                case ColorMethod.RGB: v = r + g + b; break;
                case ColorMethod.BGRA: v = b + g + r + a; break;
                case ColorMethod.RGBA: v = r + g + b + a; break;
                case ColorMethod.ABGR: v = a + b + g + r; break;
                case ColorMethod.ARGB: v = a + r + g + b; break;
                default: v = b + g + r; break;
            }

            return v;
        }

        public static Color toColor(string s, ColorMethod m = ColorMethod.BGR)
        {
            string r = string.Empty;
            string g = string.Empty;
            string b = string.Empty;
            string a = string.Empty;

            switch (m)
            {
                case ColorMethod.BGR:
                    b = s.Substring(0, 2);
                    g = s.Substring(2, 2);
                    r = s.Substring(4, 2);
                    break;
                case ColorMethod.RGB:
                    r = s.Substring(0, 2);
                    g = s.Substring(2, 2);
                    b = s.Substring(4, 2);
                    break;
                case ColorMethod.BGRA:
                    b = s.Substring(0, 2);
                    g = s.Substring(2, 2);
                    r = s.Substring(4, 2);
                    a = s.Substring(6, 2);
                    break;
                case ColorMethod.RGBA:
                    r = s.Substring(0, 2);
                    g = s.Substring(2, 2);
                    b = s.Substring(4, 2);
                    a = s.Substring(6, 2);
                    break;
                case ColorMethod.ABGR:
                    a = s.Substring(0, 2);
                    b = s.Substring(2, 2);
                    g = s.Substring(4, 2);
                    r = s.Substring(6, 2);
                    break;
                case ColorMethod.ARGB:
                    a = s.Substring(0, 2);
                    r = s.Substring(2, 2);
                    g = s.Substring(4, 2);
                    b = s.Substring(6, 2);
                    break;
            }

            int alpha = a == string.Empty ? 0 : int.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int red = int.Parse(r, System.Globalization.NumberStyles.HexNumber);
            int green = int.Parse(g, System.Globalization.NumberStyles.HexNumber);
            int blue = int.Parse(b, System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public Color Color
        {
            get { return _c_color; }
            set { _c_color = value; }
        }

        public string BGR
        {
            get { return toString(_c_color); }
            set { toColor(value); }
        }

        public string RGB
        {
            get { return toString(_c_color, ColorMethod.RGB); }
            set { toColor(value, ColorMethod.RGB); }
        }

        public string BGRA
        {
            get { return toString(_c_color, ColorMethod.BGRA); }
            set { toColor(value, ColorMethod.BGRA); }
        }

        public string RGBA
        {
            get { return toString(_c_color, ColorMethod.RGBA); }
            set { toColor(value, ColorMethod.RGBA); }
        }

        public string ABGR
        {
            get { return toString(_c_color, ColorMethod.ABGR); }
            set { toColor(value, ColorMethod.ABGR); }
        }

        public string ARGB
        {
            get { return toString(_c_color, ColorMethod.ARGB); }
            set { toColor(value, ColorMethod.ARGB); }
        }
    }
}
