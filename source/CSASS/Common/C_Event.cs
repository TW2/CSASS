using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Common
{
    public class C_Event
    {
        public enum EventType
        {
            Comment = 0, Dialogue = 1, Picture = 2, Sound = 3, Movie = 4, Command = 5, Vectors = 6, _3D = 7
        }

        public EventType Type { get; set; } = EventType.Dialogue;
        public bool Marked { get; set; } = false;
        public int Layer { get; set; } = 0;
        public C_Time Start { get; set; } = new C_Time();
        public C_Time End { get; set; } = new C_Time();
        public string Style { get; set; } = "Default";
        public string Name { get; set; } = string.Empty;
        public long MarginL { get; set; } = 0L;
        public long MarginR { get; set; } = 0L;
        public long MarginV { get; set; } = 0L;
        public long MarginT { get; set; } = 0L;
        public long MarginB { get; set; } = 0L;
        public string Effect { get; set;} = string.Empty;
        public string Text { get; set; } = string.Empty;


        public C_Event() { }
    }
}
