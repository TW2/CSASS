using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSASS
{
    public class CA_Event
    {
        private string _rawline = "";
        private int _layer = 0;
        private long _start = 0;
        private long _end = 0;
        private string _style = "";
        private string _name_or_actor = "";
        private int _marginL = 0;
        private int _marginR = 0;
        private int _marginV = 0;
        private string _effect = "";
        private string _text = "";
        private bool _comment = false;

        public CA_Event()
        {

        }

        public CA_Event(string rawline)
        {
            _comment = rawline.StartsWith("Comment");
            _rawline = rawline;

            string str = rawline.StartsWith("Comment") == true ?
                rawline.Substring("Comment: ".Length) : rawline.Substring("Dialogue: ".Length);
            string[] table = str.Split(new char[] { ',' }, 10);

            _layer = Convert.ToInt32(table[0]);
            _start = GetTime(table[1]);
            _end = GetTime(table[2]);
            _style = table[3];
            _name_or_actor = table[4];
            _marginL = Convert.ToInt32(table[5]);
            _marginR = Convert.ToInt32(table[6]);
            _marginV = Convert.ToInt32(table[7]);
            _effect = table[8];
            _text = table[9];
        }

        private long GetTime(string rawTime)
        {
            string pat = @"(\d+):(\d+):(\d+).(\d+)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            int hour = 0, min = 0, sec = 0, ms = 0;

            Match m = r.Match(rawTime);
            if (m.Success)
            {
                hour = Convert.ToInt32(m.Groups[1].Value);
                min = Convert.ToInt32(m.Groups[2].Value);
                sec = Convert.ToInt32(m.Groups[3].Value);
                ms = Convert.ToInt32(m.Groups[4].Value) * 10;
            }

            long time = hour * 3600000 + min * 60000 + sec * 1000 + ms;

            return time;
        }

        private string SetTime(long time)
        {
            int hour = (int)(time / 3600000);
            int min = (int)((time - 3600000 * hour) / 60000);
            int sec = (int)((time - 3600000 * hour - 60000 * min) / 1000);
            int mSec = (int)(time - 3600000 * hour - 60000 * min - 1000 * sec);

            int centi = mSec / 10;

            string h = Convert.ToString(hour);
            string m = min > 9 ? Convert.ToString(min) : "0" + Convert.ToString(min);
            string s = sec > 9 ? Convert.ToString(sec) : "0" + Convert.ToString(sec);
            string n = centi > 9 ? Convert.ToString(centi) : "0" + Convert.ToString(centi);

            return h + ":" + m + ":" + s + "." + n;
        }

        public int Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public long Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public string StartString
        {
            get { return SetTime(_start); }
        }

        public long End
        {
            get { return _end; }
            set { _end = value; }
        }

        public string EndString
        {
            get { return SetTime(_end); }
        }

        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public string NameOrActor
        {
            get { return _name_or_actor; }
            set { _name_or_actor = value; }
        }

        public int MarginL
        {
            get { return _marginL; }
            set { _marginL = value; }
        }

        public int MarginR
        {
            get { return _marginR; }
            set { _marginR = value; }
        }

        public int MarginV
        {
            get { return _marginV; }
            set { _marginV = value; }
        }

        public string Effect
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public bool Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
    }
}
