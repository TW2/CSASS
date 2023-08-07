using System;
using System.Drawing;

namespace CSASS
{
    public class ASS_Style
    {
        //Format: Name, Fontname, Fontsize, 
        //PrimaryColour, SecondaryColour, OutlineColour, BackColour,
        //Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, 
        //BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding

        public string Name { get; set; } = "Default";
        public string Fontname { get; set; } = "Arial";
        public int Fontsize { get; set; } = 20;
        public ASS_Color TextColor { get; set; } = ASS_Color.Create(Color.White);
        public ASS_Color KaraokeColor { get; set; } = ASS_Color.Create(Color.Yellow);
        public ASS_Color OutlineColor { get; set; } = ASS_Color.Create(Color.Black);
        public ASS_Color ShadowColor { get; set; } = ASS_Color.Create(Color.Black);
        public bool Bold { get; set; } = false;
        public bool Italic { get; set; } = false;
        public bool Underline { get; set; } = false;
        public bool StrikeOut { get; set; } = false;
        public int ScaleX { get; set; } = 100;
        public int ScaleY { get; set; } = 100;
        public int Spacing { get; set; } = 0;
        public int Angle { get; set; } = 0;
        public int BorderStyle { get; set; } = 1; // 1 = Normal, 3 or others = Box
        public int Outline { get; set; } = 2;
        public int Shadow { get; set; } = 2;
        public int Alignment { get; set; } = 2;
        public int MarginL { get; set; } = 0;
        public int MarginR { get; set; } = 0;
        public int MarginV { get; set; } = 0;
        public int Encoding { get; set; } = 0;

        public ASS_Style()
        {

        }

        public ASS_Style(string rawline)
        {
            rawline = rawline.Substring("Style: ".Length);
            string[] table = rawline.Split(new char[] { ',' });
            Name = table[0];
            Fontname = table[1];
            Fontsize = Convert.ToInt32(table[2]);
            TextColor = ASS_Color.Create(table[3]);
            KaraokeColor = ASS_Color.Create(table[4]);
            OutlineColor = ASS_Color.Create(table[5]);
            ShadowColor = ASS_Color.Create(table[6]);
            Bold = table[7] == "-1";
            Italic = table[8] == "-1";
            Underline = table[9] == "-1";
            StrikeOut = table[10] == "-1";
            ScaleX = Convert.ToInt32(table[11]);
            ScaleY = Convert.ToInt32(table[12]);
            Spacing = Convert.ToInt32(table[13]);
            Angle = Convert.ToInt32(table[14]);
            BorderStyle = Convert.ToInt32(table[15]);
            Outline = Convert.ToInt32(table[16]);
            Shadow = Convert.ToInt32(table[17]);
            Alignment = Convert.ToInt32(table[18]);
            MarginL = Convert.ToInt32(table[19]);
            MarginR = Convert.ToInt32(table[20]);
            MarginV = Convert.ToInt32(table[21]);
            Encoding = Convert.ToInt32(table[22]);
        }

        public string GetRawLine()
        {
            string rawline =
                "Style: " +
                Name + "," +
                Fontname + "," +
                Fontsize + "," +
                TextColor.ToStyleColor() + "," +
                KaraokeColor.ToStyleColor() + "," +
                OutlineColor.ToStyleColor() + "," +
                ShadowColor.ToStyleColor() + "," +
                (Bold ? "-1" : "0") + "," +
                (Italic ? "-1" : "0") + "," +
                (Underline ? "-1" : "0") + "," +
                (StrikeOut ? "-1" : "0") + "," +
                ScaleX + "," +
                ScaleY + "," +
                Spacing + "," +
                Angle + "," +
                BorderStyle + "," +
                Outline + "," +
                Shadow + "," +
                Alignment + "," +
                MarginL + "," +
                MarginR + "," +
                MarginV + "," +
                Encoding;

            return rawline;
        }
    }
}
