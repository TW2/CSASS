using System;
using System.Text.RegularExpressions;
using CSASS.Common;

namespace CSASS
{
    public class ASS_Event
    {
        private string _rawline = "";
        private C_Event _event = new C_Event();

        public ASS_Event()
        {

        }

        public ASS_Event(string rawline)
        {
            if (rawline.StartsWith("Comment")) {
                _event.Type = C_Event.EventType.Comment;
            }
            else
            {
                _event.Type = C_Event.EventType.Dialogue;
            }

            _rawline = rawline;

            string str = rawline.StartsWith("Comment") == true ?
                rawline.Substring("Comment: ".Length) : rawline.Substring("Dialogue: ".Length);
            string[] table = str.Split(new char[] { ',' }, 10);

            _event.Layer = Convert.ToInt32(table[0]);
            _event.Start = C_Time.fromString(table[1]);
            _event.End = C_Time.fromString(table[2]);
            _event.Style = table[3];
            _event.Name = table[4];
            _event.MarginL = Convert.ToInt32(table[5]);
            _event.MarginR = Convert.ToInt32(table[6]);
            _event.MarginV = Convert.ToInt32(table[7]);
            _event.Effect = table[8];
            _event.Text = table[9];
        }

        public string GetRawLine()
        {
            string comment = _event.Type == C_Event.EventType.Comment ? "Comment: " : "Dialogue: ";
            string rawline =
                comment + 
                _event.Layer + "," +
                C_Time.toASSA(_event.Start.Nanos) + "," +
                C_Time.toASSA(_event.End.Nanos) + "," +
                _event.Style + "," +
                _event.Name + "," +
                _event.MarginL + "," +
                _event.MarginR + "," +
                _event.MarginV + "," +
                _event.Effect + "," +
                _event.Text;

            return rawline;
        }

        public C_Event Event { get; set; }
    }
}
