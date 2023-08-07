using CSASS.Common;
using System;

namespace CSASS.ASSA
{
    public class SSA_Event
    {
        public C_Event Event { get; set; } = new C_Event();

        public SSA_Event() { }

        public SSA_Event(string rawline)
        {
            string forTable;

            if (rawline.StartsWith("Comment"))
            {
                Event.Type = C_Event.EventType.Comment;
                forTable = rawline.Substring("Comment: ".Length);
            }
            else if (rawline.StartsWith("Picture"))
            {
                Event.Type= C_Event.EventType.Picture;
                forTable = rawline.Substring("Picture: ".Length);
            }
            else if (rawline.StartsWith("Movie"))
            {
                Event.Type = C_Event.EventType.Movie;
                forTable = rawline.Substring("Movie: ".Length);
            }
            else if (rawline.StartsWith("Sound"))
            {
                Event.Type = C_Event.EventType.Sound;
                forTable = rawline.Substring("Sound: ".Length);
            }
            else if (rawline.StartsWith("Command"))
            {
                Event.Type = C_Event.EventType.Command;
                forTable = rawline.Substring("Command: ".Length);
            }
            else
            {
                Event.Type = C_Event.EventType.Dialogue;
                forTable = rawline.Substring("Dialogue: ".Length);
            }

            string[] table = forTable.Split(new char[] { ',' }, 10);

            Event.Marked = table[0] == "Marked=1";
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
            string rawline =
                C_Event.FromEventTypeToString(Event.Type) + ": " +
                "Marked=" + (Event.Marked ? "1" : "0") + "," +
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
