using CSASS.Common;
using System.Collections.Generic;
using System.IO;

namespace CSASS.ASSA
{
    public class SSA_IO
    {
        private readonly List<SSA_Event> EventsList = new List<SSA_Event>();
        private readonly List<SSA_Style> StylesList = new List<SSA_Style>();
        private readonly SSA_Infos SsaInfos = new SSA_Infos();

        public SSA_IO() { }

        public void LoadSSA(string path)
        {
            string line;
            EventsList.Clear();
            StylesList.Clear();

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
                        SsaInfos.TryAdd(line);
                    }

                    if (line.StartsWith("Style"))
                    {
                        SSA_Style ssas = new SSA_Style(line);
                        StylesList.Add(ssas);
                    }

                    if (line.StartsWith("Dialogue") ||
                        line.StartsWith("Comment") ||
                        line.StartsWith("Command") ||
                        line.StartsWith("Picture") ||
                        line.StartsWith("Movie") ||
                        line.StartsWith("Sound"))
                    {
                        SSA_Event txt = new SSA_Event(line);
                        EventsList.Add(txt);
                    }
                }
            }
        }

        public void SaveSSA(string path, string software, string website, string email)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.AutoFlush = true;

                SsaInfos.WriteSSAInfos(sw, software, website, email);

                sw.WriteLine("[V4 Styles]");
                sw.WriteLine("Format: Name, Fontname, Fontsize," +
                    " PrimaryColour, SecondaryColour, TertiaryColour, BackColour," +
                    " Bold, Italic, BorderStyle, Outline, Shadow, Alignment," +
                    " MarginL, MarginR, MarginV, AlphaLevel, Encoding");
                foreach (SSA_Style sty in StylesList)
                {
                    sw.WriteLine(sty.GetRawLine());
                }
                sw.WriteLine("");

                sw.WriteLine("[Events]");
                sw.WriteLine("Format: Marked, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text");
                foreach (SSA_Event evt in EventsList)
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
            cae.Event.Start = C_Time.FromString(start);
            cae.Event.End = C_Time.FromString(end);
            cae.Event.Style = style;
            cae.Event.Name = name_or_actor;
            cae.Event.MarginL = marginL;
            cae.Event.MarginR = marginR;
            cae.Event.MarginV = marginV;
            cae.Event.Effect = effect;
            cae.Event.Text = text;

            if (index != -1)
            {
                EventsList.Insert(index, cae);
            }
            else
            {
                EventsList.Add(cae);
            }
        }

        /// <summary>
        /// Remove an event from Events
        /// </summary>
        /// <param name="index">Index of the event in Events</param>
        public void RemoveEvent(int index)
        {
            EventsList.RemoveAt(index);
        }

        public List<SSA_Event> Events
        {
            get { return EventsList; }
        }

        public List<SSA_Style> Styles
        {
            get { return StylesList; }
        }

        public SSA_Infos Infos
        {
            get { return SsaInfos; }
        }

    }
}
