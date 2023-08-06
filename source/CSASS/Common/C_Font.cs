using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Common
{
    public class C_Font
    {
        private string _fontname;
        private float _fontsize;
        private FontStyle _style;

        public C_Font()
        {
            _fontname = "Arial";
            _fontsize = 12f;
            _style = FontStyle.Regular;
        }

        public C_Font(string fontname, float fontsize)
        {
            _fontname = fontname;
            _fontsize = fontsize;
            _style = FontStyle.Regular;
        }

        public C_Font(string fontname, float fontsize, FontStyle style)
        {
            _fontname = fontname;
            _fontsize = fontsize;
            _style = style;
        }

        public C_Font(string fontname, float fontsize, bool bold = false, bool italic = false,
            bool underline = false, bool strikeout = false)
        {
            _fontname = fontname;
            _fontsize = fontsize;
            _style = FontStyle.Regular;
            if (bold) { _style |= FontStyle.Bold; }
            if (italic) { _style |= FontStyle.Italic; }
            if (underline) { _style |= FontStyle.Underline; }
            if (strikeout) { _style |= FontStyle.Strikeout; }
        }

        public static float fromPixelToPoint(int pixels)
        {
            return pixels * 0.75f;
        }

        public static int fromPointToPixel(float points)
        {
            return Convert.ToInt32((points / 0.75f));
        }

        public static float fromPointToEm(float points)
        {
            return points * 0.083645834169792f;
        }

        public static float fromEmToPoint(float em)
        {
            return em / 0.083645834169792f;
        }

        public static float fromPixelToEm(int pixels)
        {
            return fromPointToEm(fromPixelToPoint(pixels));
        }

        public static int fromEmToPixel(float em)
        {
            return Convert.ToInt32(fromEmToPoint(fromPointToPixel(em)));
        }

        public Font toASSFont(bool bold = false, bool italic = false,
            bool underline = false, bool strikeout = false)
        {
            FontStyle style = FontStyle.Regular;
            if (bold) { style |= FontStyle.Bold; }
            if (italic) { style |= FontStyle.Italic; }
            if (underline) { style |= FontStyle.Underline; }
            if (strikeout) { style |= FontStyle.Strikeout; }

            return new Font(_fontname, _fontsize, style);
        }

        public Font toSSAFont(bool bold = false, bool italic = false)
        {
            FontStyle style = FontStyle.Regular;
            if (bold) { style |= FontStyle.Bold; }
            if (italic) { style |= FontStyle.Italic; }

            return new Font(_fontname, _fontsize, style);
        }
    }
}
