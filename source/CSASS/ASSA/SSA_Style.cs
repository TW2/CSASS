using System;
using System.Drawing;

namespace CSASS.ASSA
{
    public class SSA_Style
    {
        //Format: Name, Fontname, Fontsize, 
        //PrimaryColour, SecondaryColour, TertiaryColour, BackColour,
        //Bold, Italic, BorderStyle, Outline, Shadow, Alignment,
        //MarginL, MarginR, MarginV, AlphaLevel, Encoding

        public string Name { get; set; } = "Default";
        public string Fontname { get; set; } = "Arial";
        public int Fontsize { get; set; } = 20;
        public SSA_Color PrimaryColor { get; set; } = SSA_Color.Create(Color.White);
        public SSA_Color SecondaryColor { get; set; } = SSA_Color.Create(Color.Yellow);
        public SSA_Color TertiaryColor { get; set; } = SSA_Color.Create(Color.Cyan);
        public SSA_Color BackColor { get; set; } = SSA_Color.Create(Color.Black);
        public bool Bold { get; set; } = false;
        public bool Italic { get; set; } = false;
        public int BorderStyle { get; set; } = 1; // 1 = Normal, 3 or others = Box
        public int Outline { get; set; } = 2;
        public int Shadow { get; set; } = 2;
        public int Alignment { get; set; } = 2;
        public int MarginL { get; set; } = 0;
        public int MarginR { get; set; } = 0;
        public int MarginV { get; set; } = 0;
        public int AlphaLevel { get; set; } = 0;
        public int Encoding { get; set; } = 0;

        public SSA_Style() { }

        public SSA_Style(string rawline)
        {
            rawline = rawline.Substring("Style: ".Length);
            string[] table = rawline.Split(new char[] { ',' });
            Name = table[0];
            Fontname = table[1];
            Fontsize = Convert.ToInt32(table[2]);
            PrimaryColor = SSA_Color.Create(table[3]);
            SecondaryColor = SSA_Color.Create(table[4]);
            TertiaryColor = SSA_Color.Create(table[5]);
            BackColor = SSA_Color.Create(table[6]);
            Bold = table[7] == "-1";
            Italic = table[8] == "-1";
            BorderStyle = Convert.ToInt32(table[9]);
            Outline = Convert.ToInt32(table[10]);
            Shadow = Convert.ToInt32(table[11]);
            Alignment = Convert.ToInt32(table[12]);
            MarginL = Convert.ToInt32(table[13]);
            MarginR = Convert.ToInt32(table[14]);
            MarginV = Convert.ToInt32(table[15]);
            AlphaLevel = Convert.ToInt32(table[16]);
            Encoding = Convert.ToInt32(table[17]);
        }

        public string GetRawLine()
        {
            string rawline =
                "Style: " +
                Name + "," +
                Fontname + "," +
                Fontsize + "," +
                PrimaryColor.ToStyleColor() + "," +
                SecondaryColor.ToStyleColor() + "," +
                TertiaryColor.ToStyleColor() + "," +
                BackColor.ToStyleColor() + "," +
                (Bold ? "-1" : "0") + "," +
                (Italic ? "-1" : "0") + "," +
                BorderStyle + "," +
                Outline + "," +
                Shadow + "," +
                Alignment + "," +
                MarginL + "," +
                MarginR + "," +
                MarginV + "," +
                AlphaLevel + "," +
                Encoding;

            return rawline;
        }
    }
}
