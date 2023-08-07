using System;
using System.Text.RegularExpressions;

namespace CSASS
{
    public class ASS_Karaoke
    {
        //private string KaraText = "";
        //private long KaraDuration = 0;
        //private long KaraStart = 0;
        //private long KaraEnd = 0;

        public ASS_Karaoke()
        {

        }

        public static bool HasKaraoke(string text)
        {
            return text.Contains(@"\k") | text.Contains(@"\K");
        }

        public static ASS_Karaoke Create(string text, long start, long end)
        {
            ASS_Karaoke kara = new ASS_Karaoke();

            if(HasKaraoke(text) == true)
            {
                //kara._syllables.Clear();

                //kara.KaraText = text;
                //kara.KaraStart = start;
                //kara.KaraEnd = end;
                //kara.KaraDuration = end - start;

                //string ns;
                //ns = text.Replace("\\K", "\\k");
                //ns = ns.Replace("\\ko", "\\k");
                //ns = ns.Replace("\\kf", "\\k");

                //long startsyl = 0;

                //Regex r = new Regex(@"\{[\\k]{1}(\d+)\}(\w+)");
                //Match m = r.Match(ns);

                //while (m.Success)
                //{
                //    long dur_centi = Convert.ToInt32(m.Groups[1].Value);
                //    long dur_milli = dur_centi * 10;

                //    //ASS_K_Syllable syl = new ASS_K_Syllable(
                //    //    m.Groups[2].Value,
                //    //    startsyl + start,
                //    //    startsyl + start + dur_milli,
                //    //    text);

                //    //kara._syllables.Add(syl);

                //    startsyl += dur_milli;


                //    m.NextMatch();
                //}
            }

            return kara;
        }

        //public List<ASS_K_Syllable> Syllables
        //{
        //    get { return _syllables; }
        //}
    }
}
