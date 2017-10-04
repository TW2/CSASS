using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS
{
    public class CA_Style
    {
        //Format: Name, Fontname, Fontsize, 
        //PrimaryColour, SecondaryColour, OutlineColour, BackColour,
        //Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, 
        //BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding

        private string _name = "Default";
        private string _fontname = "Arial";
        private string _fontsize = "20";
        private string _1stColor = "00FFFFFF";
        private string _2ndColor = "00FFFFFF";
        private string _3rdColor = "00000000";
        private string _4thColor = "00000000";
        private string _bold = "0";
        private string _italic = "0";
        private string _underline = "0";
        private string _strikeout = "0";
        private string _scaleX = "100";
        private string _scaleY = "100";
        private string _spacing = "0";
        private string _angle = "0";
        private string _borderstyle = "1";
        private string _outline = "2";
        private string _shadow = "2";
        private string _alignment = "2";
        private string _marginl = "0";
        private string _marginr = "0";
        private string _marginv = "0";
        private string _encoding = "0";

        private CA_Font _font = null;
        private CA_Color _1 = null;
        private CA_Color _2 = null;
        private CA_Color _3 = null;
        private CA_Color _4 = null;

        public CA_Style()
        {

        }

        public CA_Style(string rawline)
        {
            rawline = rawline.Substring("Style: ".Length);
            string[] table = rawline.Split(new char[] { ',' });
            _name = table[0];
            _fontname = table[1];
            _fontsize = table[2];
            _1stColor = table[3].Substring("&H".Length);
            _2ndColor = table[4].Substring("&H".Length);
            _3rdColor = table[5].Substring("&H".Length);
            _4thColor = table[6].Substring("&H".Length);
            _bold = table[7];
            _italic = table[8];
            _underline = table[9];
            _strikeout = table[10];
            _scaleX = table[11];
            _scaleY = table[12];
            _spacing = table[13];
            _angle = table[14];
            _borderstyle = table[15];
            _outline = table[16];
            _shadow = table[17];
            _alignment = table[18];
            _marginl = table[19];
            _marginr = table[20];
            _marginv = table[21];
            _encoding = table[22];

            _font = new CA_Font(_fontname, _fontsize, _bold, _italic, _underline, _strikeout);
            _1 = new CA_Color(_1stColor);
            _2 = new CA_Color(_2ndColor);
            _3 = new CA_Color(_3rdColor);
            _4 = new CA_Color(_4thColor);
        }

        public string GetRawLine()
        {
            string rawline =
                "Style: " +
                _name + "," +
                _font.FontName + "," +
                (int)_font.FontSize + "," +
                "&H" + _1.ABGR + "," +
                "&H" + _2.ABGR + "," +
                "&H" + _3.ABGR + "," +
                "&H" + _4.ABGR + "," +
                _font.BoldInt + "," +
                _font.ItalicInt + "," +
                _font.UnderlineInt + "," +
                _font.StrikeoutInt + "," +
                _scaleX + "," +
                _scaleY + "," +
                _spacing + "," +
                _angle + "," +
                _borderstyle + "," +
                _outline + "," +
                _shadow + "," +
                _alignment + "," +
                _marginl + "," +
                _marginr + "," +
                _marginv + "," +
                _encoding;

            return rawline;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public CA_Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public CA_Color PrimaryColour
        {
            get { return _1; }
            set { _1 = value; }
        }

        public CA_Color KaraokeColour
        {
            get { return _2; }
            set { _2 = value; }
        }

        public CA_Color OutlineColour
        {
            get { return _3; }
            set { _3 = value; }
        }

        public CA_Color BackColour
        {
            get { return _4; }
            set { _4 = value; }
        }

        public float ScaleX
        {
            get { return Convert.ToSingle(_scaleX); }
            set { _scaleX = Convert.ToString(value); }
        }

        public float ScaleY
        {
            get { return Convert.ToSingle(_scaleY); }
            set { _scaleY = Convert.ToString(value); }
        }

        public int Spacing
        {
            get { return Convert.ToInt32(_spacing); }
            set { _spacing = Convert.ToString(value); }
        }

        public float Angle
        {
            get { return Convert.ToSingle(_angle); }
            set { _angle = Convert.ToString(value); }
        }

        public int Borderline
        {
            get { return Convert.ToInt32(_borderstyle); }
            set { _borderstyle = Convert.ToString(value); }
        }

        public float Outline
        {
            get { return Convert.ToSingle(_outline); }
            set { _outline = Convert.ToString(value); }
        }

        public float Shadow
        {
            get { return Convert.ToSingle(_shadow); }
            set { _shadow = Convert.ToString(value); }
        }

        public int Alignment
        {
            get { return Convert.ToInt32(_alignment); }
            set { _alignment = Convert.ToString(value); }
        }

        public int MarginL
        {
            get { return Convert.ToInt32(_marginl); }
            set { _marginl = Convert.ToString(value); }
        }

        public int MarginR
        {
            get { return Convert.ToInt32(_marginr); }
            set { _marginr = Convert.ToString(value); }
        }

        public int MarginV
        {
            get { return Convert.ToInt32(_marginv); }
            set { _marginv = Convert.ToString(value); }
        }

        public int Encoding
        {
            get { return Convert.ToInt32(_encoding); }
            set { _encoding = Convert.ToString(value); }
        }
    }
}
