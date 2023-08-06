using CSASS.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSA
{
    public class SSA_Style
    {
        //Format: Name, Fontname, Fontsize, 
        //PrimaryColour, SecondaryColour, TertiaryColour, BackColour,
        //Bold, Italic, BorderStyle, Outline, Shadow, Alignment,
        //MarginL, MarginR, MarginV, AlphaLevel, Encoding

        private string Name { get; set; } = "Default";
        private string Fontname { get; set; } = "Arial";
        private int Fontsize { get; set; } = 20;
        private SSA_Color PrimaryColor { get; set; } = SSA_Color.Create(Color.White);
        private SSA_Color SecondaryColor { get; set; } = SSA_Color.Create(Color.Yellow);
        private SSA_Color TertiaryColor { get; set; } = SSA_Color.Create(Color.Cyan);
        private SSA_Color BackColor { get; set; } = SSA_Color.Create(Color.Black);
        private bool Bold { get; set; } = false;
        private bool Italic { get; set; } = false;
        private int Borderstyle { get; set; } = 1; // 1 = Normal, 3 or others = Box
        private int Outline { get; set; } = 2;
        private int Shadow { get; set; } = 2;
        private int Alignment { get; set; } = 2;
        private int MarginL { get; set; } = 0;
        private int MarginR { get; set; } = 0;
        private int MarginV { get; set; } = 0;
        private int AlphaLevel { get; set; } = 0;
        private int Encoding { get; set; } = 0;

        public SSA_Style()
        {

        }

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
            Borderstyle = Convert.ToInt32(table[9]);
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
                PrimaryColor.toStyleColor() + "," +
                SecondaryColor.toStyleColor() + "," +
                TertiaryColor.toStyleColor() + "," +
                BackColor.toStyleColor() + "," +
                (Bold ? "0" : "-1") + "," +
                (Italic ? "0" : "-1") + "," +
                Borderstyle + "," +
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
