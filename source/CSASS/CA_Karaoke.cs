using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            kara._syllables.Clear();

            kara._text = text;
            kara._start = start;
            kara._end = end;
            kara._duration = end - start;

            string[] table = text.Split(new char[] { '{' });
            long startsyl = 0;

            foreach (string s in table)
            {
                if (s.Length > 0)
                {
                    string ns = s.Replace("\\K", "\\k"); ns = ns.Replace("\\ko", "\\k"); ns = ns.Replace("\\kf", "\\k");
                    string asss = ns.StartsWith("\\k") == true ? ns.Replace("\\k", "") : ns;
                    string[] table2 = asss.Split(new char[] { '}' });
                    long dur_centi = Convert.ToInt32(table2[0]);
                    long dur_milli = dur_centi * 10;

                    CA_K_Syllable syl = new CA_K_Syllable(
                        table2[1],
                        startsyl + start,
                        startsyl + start + dur_milli,
                        text);

                    kara._syllables.Add(syl);

                    startsyl += dur_milli;
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
