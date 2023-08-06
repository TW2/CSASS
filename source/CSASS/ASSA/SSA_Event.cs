using CSASS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSA
{
    public class SSA_Event
    {
        private string _rawline = "";
        private C_Event _event = new C_Event();

        public SSA_Event()
        {

        }

        public SSA_Event(string rawline)
        {
            string forTable = string.Empty;

            if (rawline.StartsWith("Comment"))
            {
                _event.Type = C_Event.EventType.Comment;
                forTable = rawline.Substring("Comment: ".Length);
            }
            else if (rawline.StartsWith("Picture"))
            {
                _event.Type= C_Event.EventType.Picture;
                forTable = rawline.Substring("Picture: ".Length);
            }
            else if (rawline.StartsWith("Movie"))
            {
                _event.Type = C_Event.EventType.Movie;
                forTable = rawline.Substring("Movie: ".Length);
            }
            else if (rawline.StartsWith("Sound"))
            {
                _event.Type = C_Event.EventType.Sound;
                forTable = rawline.Substring("Sound: ".Length);
            }
            else if (rawline.StartsWith("Command"))
            {
                _event.Type = C_Event.EventType.Command;
                forTable = rawline.Substring("Command: ".Length);
            }
            else
            {
                _event.Type = C_Event.EventType.Dialogue;
                forTable = rawline.Substring("Dialogue: ".Length);
            }

            _rawline = rawline;

            string[] table = forTable.Split(new char[] { ',' }, 10);

            _event.Marked = table[0] == "Marked=1";
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
            string rawline =
                C_Event.fromEventTypeToString(_event.Type) + ": " +
                "Marked=" + (_event.Marked ? "1" : "0") + "," +
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
