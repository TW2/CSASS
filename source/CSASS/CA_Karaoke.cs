using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSASS
{
    public class CA_Karaoke
    {
        private string _text = "";
        private long _duration = 0;
        private long _start = 0;
        private long _end = 0;
        private List<CA_K_Syllable> _syllables = new List<CA_K_Syllable>();

        public CA_Karaoke()
        {

        }

        public static bool HasKaraoke(string text)
        {
            return text.Contains(@"\k") | text.Contains(@"\K");
        }

        public static CA_Karaoke Create(string text, long start, long end)
        {
            CA_Karaoke kara = new CA_Karaoke();

            if(HasKaraoke(text) == true)
            {
                kara._syllables.Clear();

                kara._text = text;
                kara._start = start;
                kara._end = end;
                kara._duration = end - start;

                string ns;
                ns = text.Replace("\\K", "\\k");
                ns = ns.Replace("\\ko", "\\k");
                ns = ns.Replace("\\kf", "\\k");

                long startsyl = 0;

                Regex r = new Regex(@"\{[\\k]{1}(\d+)\}(\w+)");
                Match m = r.Match(ns);

                while (m.Success)
                {
                    long dur_centi = Convert.ToInt32(m.Groups[1].Value);
                    long dur_milli = dur_centi * 10;

                    CA_K_Syllable syl = new CA_K_Syllable(
                        m.Groups[2].Value,
                        startsyl + start,
                        startsyl + start + dur_milli,
                        text);

                    kara._syllables.Add(syl);

                    startsyl += dur_milli;


                    m.NextMatch();
                }
            }

            return kara;
        }

        public List<CA_K_Syllable> Syllables
        {
            get { return _syllables; }
        }
    }
}
