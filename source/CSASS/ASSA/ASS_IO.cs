using CSASS.Common;
using System.Collections.Generic;
using System.IO;

namespace CSASS.ASSA
{
    public class ASS_IO
    {
        private readonly List<ASS_Event> EventsList = new List<ASS_Event>();
        private readonly List<ASS_Style> StylesList = new List<ASS_Style>();
        private readonly ASS_Infos AssInfos = new ASS_Infos();

        public ASS_IO() { }

        public void LoadASS(string path)
        {
            string line;
            EventsList.Clear();
            StylesList.Clear();

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("Style") && !line.StartsWith("Dialogue") && !line.StartsWith("Comment"))
                    {
                        AssInfos.TryAdd(line);
                    }

                    if (line.StartsWith("Style"))
                    {
                        ASS_Style asss = new ASS_Style(line);
                        StylesList.Add(asss);
                    }

                    if (line.StartsWith("Dialogue") || line.StartsWith("Comment"))
                    {
                        ASS_Event txt = new ASS_Event(line);
                        EventsList.Add(txt);
                    }
                }
            }
        }

        public void SaveASS(string path, string software, string website, string email)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.AutoFlush = true;

                AssInfos.WriteASSInfos(sw, software, website, email);

                sw.WriteLine("[V4+ Styles]");
                sw.WriteLine("Format: Name, Fontname, Fontsize," +
                    " PrimaryColour, SecondaryColour, OutlineColour, BackColour," +
                    " Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle," +
                    " BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding");
                foreach (ASS_Style sty in StylesList)
                {
                    sw.WriteLine(sty.GetRawLine());
                }
                sw.WriteLine("");

                sw.WriteLine("[Events]");
                sw.WriteLine("Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text");
                foreach (ASS_Event evt in EventsList)
                {
                    sw.WriteLine(evt.GetRawLine());
                }
            }
        }

        /// <summary>
        /// Add a dialogue event to Events
        /// </summary>
        /// <param name="layer">Layer in integer</param>
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
        public void AddEvent(C_Event.EventType evType, int layer, string start, string end, string style, string name_or_actor,
            int marginL, int marginR, int marginV, string effect, string text, int index = -1)
        {
            ASS_Event cae = new ASS_Event();
            cae.Event.Type = evType;
            cae.Event.Layer = layer;
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

        public List<ASS_Event> Events
        {
            get { return EventsList; }
        }

        public List<ASS_Style> Styles
        {
            get { return StylesList; }
        }

        public ASS_Infos Infos
        {
            get { return AssInfos; }
        }

    }
}
