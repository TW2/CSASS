using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS
{
    public class CA_Font
    {
        private Font _font = new Font("Arial", 12f, FontStyle.Regular);

        public CA_Font(string fontname = "Arial", string fontsize = "12",
            string bold = "0", string italic = "0", string underline = "0", string strikeout = "0")
        {
            float fs = Convert.ToSingle(fontsize);
            int b = Convert.ToInt32(bold);
            int i = Convert.ToInt32(italic);
            int u = Convert.ToInt32(underline);
            int s = Convert.ToInt32(strikeout);

            Configure(fontname, fs, b, i, u, s);
        }

        public CA_Font(string fontname = "Arial", float fontsize = 12f,
            int bold = 0, int italic = 0, int underline = 0, int strikeout = 0)
        {
            Configure(fontname, fontsize, bold, italic, underline, strikeout);
        }

        public CA_Font(Font font)
        {
            Configure(
                font.Name, 
                font.Size, 
                ConvertBoolean(font.Bold),
                ConvertBoolean(font.Italic),
                ConvertBoolean(font.Underline),
                ConvertBoolean(font.Strikeout));
        }

        private void Configure(string fontname = "Arial", float fontsize = 12f,
            int bold = 0, int italic = 0, int underline = 0, int strikeout = 0)
        {
            bool b = ConvertInteger(bold);
            bool i = ConvertInteger(italic);
            bool u = ConvertInteger(underline);
            bool s = ConvertInteger(strikeout);

            FontStyle defFS = FontStyle.Regular;
            defFS = b == true ? defFS | FontStyle.Bold : defFS;
            defFS = i == true ? defFS | FontStyle.Italic : defFS;
            defFS = u == true ? defFS | FontStyle.Underline : defFS;
            defFS = s == true ? defFS | FontStyle.Strikeout : defFS;

            _font = new Font(fontname, fontsize, defFS);
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public string FontName
        {
            get { return _font.FontFamily.Name; }
        }

        public float FontSize
        {
            get { return _font.Size; }
        }

        public bool Bold
        {
            get { return _font.Bold; }
        }

        public bool Italic
        {
            get { return _font.Italic; }
        }

        public bool Underline
        {
            get { return _font.Underline; }
        }

        public bool Strikeout
        {
            get { return _font.Strikeout; }
        }

        public int BoldInt
        {
            get { return ConvertBoolean(_font.Bold); }
        }

        public int ItalicInt
        {
            get { return ConvertBoolean(_font.Italic); }
        }

        public int UnderlineInt
        {
            get { return ConvertBoolean(_font.Underline); }
        }

        public int StrikeoutInt
        {
            get { return ConvertBoolean(_font.Strikeout); }
        }

        public int ConvertBoolean(bool b)
        {
            return b == true ? -1 : 0;
        }

        public bool ConvertInteger(int i)
        {
            return i == -1 ? true : false;
        }
    }
}
