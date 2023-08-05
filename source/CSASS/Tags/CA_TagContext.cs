using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public class CA_TagContext
    {
        // The main Csass and the time which is used now
        private Csass ca = null;
        private long milliseconds = 0L;

        public CA_TagContext()
        {

        }

        public static CA_TagContext Create(Csass main, long ms)
        {
            CA_TagContext tc = new CA_TagContext();

            tc.ca = main;
            tc.milliseconds = ms;

            return tc;
        }

        public Bitmap GetImage()
        {
            if(ca != null)
            {
                // Settings
                Bitmap bmp = new Bitmap(ca.Infos.PlayResX, ca.Infos.PlayResY);
                Graphics g = Graphics.FromImage(bmp);

                // Collect the events for time
                List<ASS_Event> evList = GetEventAtMilliseconds(milliseconds);

                // Draw
                foreach (ASS_Event ev in evList)
                {
                    // Event parameters
                    ASS_Style style = GetStyle(ev);
                    ASS_Font font = style.Font;

                    // Decompose #1 - \N
                    string[] lines = GetLines(ev);

                    // Iterate over lines
                    foreach(string line in lines)
                    {
                        // Decompose #2 - Inner tags

                    }

                }

                return bmp;
            }
            return null;
        }

        private List<ASS_Event> GetEventAtMilliseconds(long ms)
        {
            List<ASS_Event> list = new List<ASS_Event>();

            // Retrieve event (data) for this time
            foreach (ASS_Event ev in ca.Events)
            {
                if (ev.Start <= ms && ms < ev.End)
                {
                    list.Add(ev);
                }
            }

            return list;
        }

        private ASS_Style GetStyle(ASS_Event ev)
        {
            ASS_Style style = new ASS_Style();
            foreach (ASS_Style s in ca.Styles)
            {
                if (s.Name == ev.Style)
                {
                    style = s;
                    break;
                }
            }

            return style;
        }

        private string[] GetLines(ASS_Event ev)
        {
            return ev.Text.Split(new string[] { "\\N" }, StringSplitOptions.None);
        }

        private List<CA_TaggedText> FindTags(string text, out List<ATag> recursive)
        {
            recursive = new List<ATag>();

            List<CA_TaggedText> tts = new List<CA_TaggedText>();
            List<ATag> tagsInCourse = new List<ATag>();

            Regex regex = new Regex(@"\{(?<tags>[\}]*)\}(?<after>.*)");
            MatchCollection matches = regex.Matches(text);

            foreach (Match m in matches)
            {
                GroupCollection groups = m.Groups;
                Console.WriteLine(groups["tags"] + " ||| " + groups["after"]);
            }

            return tts;
        }
    }
}
