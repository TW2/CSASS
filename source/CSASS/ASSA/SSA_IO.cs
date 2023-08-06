using CSASS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSA
{
    public class SSA_IO
    {
        private List<SSA_Event> events = new List<SSA_Event>();
        private List<SSA_Style> styles = new List<SSA_Style>();
        private SSA_Infos ssainfos = new SSA_Infos();

        public SSA_IO() { }

        public void LoadSSA(string path)
        {
            string line;
            events.Clear();
            styles.Clear();

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("Style") &&
                        !line.StartsWith("Dialogue") &&
                        !line.StartsWith("Comment") &&
                        !line.StartsWith("Command") &&
                        !line.StartsWith("Picture") &&
                        !line.StartsWith("Movie") &&
                        !line.StartsWith("Sound"))
                    {
                        ssainfos.TryAdd(line);
                    }

                    if (line.StartsWith("Style"))
                    {
                        SSA_Style ssas = new SSA_Style(line);
                        styles.Add(ssas);
                    }

                    if (line.StartsWith("Dialogue") ||
                        line.StartsWith("Comment") ||
                        line.StartsWith("Command") ||
                        line.StartsWith("Picture") ||
                        line.StartsWith("Movie") ||
                        line.StartsWith("Sound"))
                    {
                        SSA_Event txt = new SSA_Event(line);
                        events.Add(txt);
                    }
                }
            }
        }

        public void SaveSSA(string path, string software = "CSASS library", string website = "unknown")
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.AutoFlush = true;

                ssainfos.WriteSSAInfos(sw);

                sw.WriteLine("[V4 Styles]");
                sw.WriteLine("Format: Name, Fontname, Fontsize," +
                    " PrimaryColour, SecondaryColour, TertiaryColour, BackColour," +
                    " Bold, Italic, BorderStyle, Outline, Shadow, Alignment," +
                    " MarginL, MarginR, MarginV, AlphaLevel, Encoding");
                foreach (SSA_Style sty in styles)
                {
                    sw.WriteLine(sty.GetRawLine());
                }
                sw.WriteLine("");

                sw.WriteLine("[Events]");
                sw.WriteLine("Format: Marked, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text");
                foreach (SSA_Event evt in events)
                {
                    sw.WriteLine(evt.GetRawLine());
                }
            }
        }

        /// <summary>
        /// Add an event to Events
        /// </summary>
        /// <param name="marked">Marked in integer</param>
        /// <param name="start">Start in hh:mm:ss:cc format</param>
        /// <param name="end">End in hh:mm:ss:cc format</param>
        /// <param name="style">Name of the Style</param>
        /// <param name="name_or_actor">A string</param>
        /// <param name="marginL">An integer</param>
        /// <param name="marginR">An integer</param>
        /// <param name="marginV">An integer</param>
        /// <param name="effect">A string</param>
        /// <param name="text">Your text or karaoke</param>
        /// <param name="index">Index of the event in Events or not if -1</param>
        public void AddEvent(C_Event.EventType evType, int marked, string start, string end, string style, string name_or_actor,
            int marginL, int marginR, int marginV, string effect, string text, int index = -1)
        {
            SSA_Event cae = new SSA_Event();
            cae.Event.Type = evType;
            cae.Event.Marked = marked == 1;
            cae.Event.Start = C_Time.fromString(start);
            cae.Event.End = C_Time.fromString(end);
            cae.Event.Style = style;
            cae.Event.Name = name_or_actor;
            cae.Event.MarginL = marginL;
            cae.Event.MarginR = marginR;
            cae.Event.MarginV = marginV;
            cae.Event.Effect = effect;
            cae.Event.Text = text;

            if (index != -1)
            {
                events.Insert(index, cae);
            }
            else
            {
                events.Add(cae);
            }
        }

        /// <summary>
        /// Remove an event from Events
        /// </summary>
        /// <param name="index">Index of the event in Events</param>
        public void RemoveEvent(int index)
        {
            events.RemoveAt(index);
        }
    }
}
