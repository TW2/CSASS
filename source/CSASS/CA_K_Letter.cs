using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS
{
    public class CA_K_Letter
    {
        private string _let = "";
        private long _duration = 0;
        private long _start = 0;
        private long _end = 0;
        private string _syl = "";
        private string _sentence = "";

        public CA_K_Letter()
        {

        }

        public CA_K_Letter(string letter, long start, long end, string syl, string text)
        {
            _let = letter;
            _duration = end - start;
            _start = start;
            _end = end;
            _syl = syl;            
            _sentence = text;
        }

        public string Letter
        {
            get { return _let; }
            set { _let = value; }
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

        public string FromSyllable
        {
            get { return _syl; }
            set { _syl = value; }
        }

        public string FromText
        {
            get { return _sentence; }
            set { _sentence = value; }
        }
    }
}
