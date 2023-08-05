using System.Collections.Generic;

namespace CSASS
{
    public class ASS_K_Syllable
    {
        private string _syl = "";
        private long _duration = 0;
        private long _start = 0;
        private long _end = 0;
        private string _sentence = "";
        private List<ASS_K_Letter> _letters = new List<ASS_K_Letter>();

        public ASS_K_Syllable()
        {

        }

        public ASS_K_Syllable(string syl, long start, long end, string text)
        {
            _syl = syl;
            _duration = end - start;
            _start = start;
            _end = end;
            _sentence = text;

            _letters.Clear();

            if(syl.Length > 0)
            {
                long startlet = start; int index = 1;
                long max_letter_duration = _duration / syl.Length;
                long min_letter_duration = _duration - (max_letter_duration * (syl.Length - 1));
                foreach (char c in syl)
                {
                    if (index < syl.Length)
                    {
                        ASS_K_Letter letter = new ASS_K_Letter(
                            c.ToString(),
                            startlet,
                            startlet + max_letter_duration,
                            syl,
                            text);

                        _letters.Add(letter);

                        startlet += max_letter_duration;
                    }
                    else
                    {
                        ASS_K_Letter letter = new ASS_K_Letter(
                            c.ToString(),
                            startlet,
                            startlet + min_letter_duration,
                            syl,
                            text);

                        _letters.Add(letter);
                    }

                    index++;
                }
            }
        }

        public string Syllable
        {
            get { return _syl; }
            set { _syl = value; }
        }

        public long Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public long Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public long End
        {
            get { return _end; }
            set { _end = value; }
        }

        public string FromText
        {
            get { return _sentence; }
            set { _sentence = value; }
        }

        public List<ASS_K_Letter> Letters
        {
            get { return _letters; }
        }
    }
}
