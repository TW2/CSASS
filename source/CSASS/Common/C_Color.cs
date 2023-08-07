using System;
using System.Drawing;

namespace CSASS.Common
{
    public class C_Color
    {
        private Color MyColor;

        public enum ColorMethod
        {
            BGR = 0, RGB = 1, BGRA = 2, RGBA = 3, ABGR = 4, ARGB = 5
        }

        public C_Color(Color color)
        {
            MyColor = color;
        }

        public static string ToString(Color c, ColorMethod m = ColorMethod.BGR)
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

            string v;

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

        public static Color ToColor(string s, ColorMethod m = ColorMethod.BGR)
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
            get { return MyColor; }
            set { MyColor = value; }
        }

        public string BGR
        {
            get { return ToString(MyColor); }
            set { ToColor(value); }
        }

        public string RGB
        {
            get { return ToString(MyColor, ColorMethod.RGB); }
            set { ToColor(value, ColorMethod.RGB); }
        }

        public string BGRA
        {
            get { return ToString(MyColor, ColorMethod.BGRA); }
            set { ToColor(value, ColorMethod.BGRA); }
        }

        public string RGBA
        {
            get { return ToString(MyColor, ColorMethod.RGBA); }
            set { ToColor(value, ColorMethod.RGBA); }
        }

        public string ABGR
        {
            get { return ToString(MyColor, ColorMethod.ABGR); }
            set { ToColor(value, ColorMethod.ABGR); }
        }

        public string ARGB
        {
            get { return ToString(MyColor, ColorMethod.ARGB); }
            set { ToColor(value, ColorMethod.ARGB); }
        }
    }
}
