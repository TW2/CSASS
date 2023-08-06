using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSASS.Common
{
    public class C_Time
    {
        private long _nanos;

        public C_Time()
        {
            _nanos = 0;
        }

        public C_Time(long nanos)
        {
            _nanos = nanos;
        }

        public long Nanos { get; set; }

        public static C_Time fromString(string str)
        {
            C_Time time = new C_Time();

            Regex r = new Regex("(\\d+)[^\\d]+(\\d+)[^\\d]+(\\d+)[^\\d]+(\\d+)", RegexOptions.Compiled);
            Match m = r.Match(str);

            if (m.Success)
            {
                string hour = m.Groups[1].Value;
                string min = m.Groups[2].Value;
                string sec = m.Groups[3].Value;

                string last = m.Groups[4].Value;

                string millis;
                if(last.Length == 3)
                {
                    millis = last;
                }
                else
                {
                    millis = last + "0";
                }

                int h = Convert.ToInt32(hour);
                int mn = Convert.ToInt32(min);
                int s = Convert.ToInt32(sec);
                int ms = Convert.ToInt32(millis);

                time._nanos = Convert.ToInt64(
                    Math.Pow(ms, 6) +
                    Math.Pow(s * 1000, 6) +
                    Math.Pow(mn * 60000, 6) +
                    Math.Pow(h * 3600000, 6)
                );
            }

            return time;
        }

        public static string toASSA(long nanos)
        {
            double mst = (double)nanos / 1_000_000d;

            int hour = (int)(mst / 3600000);
            int min = (int)((mst - 3600000 * hour) / 60000);
            int sec = (int)((mst - 3600000 * hour - 60000 * min) / 1000);
            int mSec = (int)(mst - 3600000 * hour - 60000 * min - 1000 * sec);

            string h = Convert.ToString(hour);
            string m = Convert.ToString(min);
            if (m.Length == 1) m = "0" + m;
            string s = Convert.ToString(sec);
            if (s.Length == 1) s = "0" + s;
            string ms = Convert.ToString(mSec);

            if (ms.Length == 2)
            {
                ms = "0" + ms;
            }
            else if (ms.Length == 1)
            {
                m = "00" + ms;
            }
            
            return string.Format("%d:%d:%d.%d", h, m, s, ms.Substring(0, 2));
        }
    }
}
