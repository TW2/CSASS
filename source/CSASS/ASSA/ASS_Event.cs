using System;
using CSASS.Common;

namespace CSASS
{
    public class ASS_Event
    {
        public C_Event Event { get; set; } = new C_Event();

        public ASS_Event()
        {

        }

        public ASS_Event(string rawline)
        {
            if (rawline.StartsWith("Comment")) {
                Event.Type = C_Event.EventType.Comment;
            }
            else
            {
                Event.Type = C_Event.EventType.Dialogue;
            }

            string str = rawline.StartsWith("Comment") == true ?
                rawline.Substring("Comment: ".Length) : rawline.Substring("Dialogue: ".Length);
            string[] table = str.Split(new char[] { ',' }, 10);

            Event.Layer = Convert.ToInt32(table[0]);
            Event.Start = C_Time.FromString(table[1]);
            Event.End = C_Time.FromString(table[2]);
            Event.Style = table[3];
            Event.Name = table[4];
            Event.MarginL = Convert.ToInt32(table[5]);
            Event.MarginR = Convert.ToInt32(table[6]);
            Event.MarginV = Convert.ToInt32(table[7]);
            Event.Effect = table[8];
            Event.Text = table[9];
        }

        public string GetRawLine()
        {
            string comment = Event.Type == C_Event.EventType.Comment ? "Comment: " : "Dialogue: ";
            string rawline =
                comment + 
                Event.Layer + "," +
                C_Time.ToASSA(Event.Start.Nanos) + "," +
                C_Time.ToASSA(Event.End.Nanos) + "," +
                Event.Style + "," +
                Event.Name + "," +
                Event.MarginL + "," +
                Event.MarginR + "," +
                Event.MarginV + "," +
                Event.Effect + "," +
                Event.Text;

            return rawline;
        }

    }
}
