using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CSASS.ASSA;
using CSASS.Common;

namespace CSASS
{
    public class Csass : ICloneable
    {
        private ASS_IO ass = new ASS_IO();
        private SSA_IO ssa = new SSA_IO();

        private string videoPath = null;

        public string VideoPath { get => videoPath; set => videoPath = value; }

        public Csass()
        {
            
        }

        public void LoadASS(string path)
        {
            ass.LoadASS(path);
        }

        public void SaveASS(string path, string software = "CSASS library", string website = "unknown")
        {
            ass.SaveASS(path, software, website);
        }

        public void LoadSSA(string path)
        {
            ssa.LoadSSA(path);
        }

        public void SaveSSA(string path, string software = "CSASS library", string website = "unknown")
        {
            ssa.SaveSSA(path, software, website);
        }

        /// <summary>
        /// Add a dialogue event to Events
        /// </summary>
        /// <param name="evType">Event type (enum)</param>
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
        public void AddAssEvent(C_Event.EventType evType, int layer, string start, string end, string style, string name_or_actor,
            int marginL, int marginR, int marginV, string effect, string text, int index = -1)
        {
            ass.AddEvent(evType, layer, start, end, style, name_or_actor,
                marginL, marginR, marginV, effect, text, index);
        }

        /// <summary>
        /// Remove an event from Events
        /// </summary>
        /// <param name="index">Index of the event in Events</param>
        public void RemoveAssEvent(int index)
        {
            ass.RemoveEvent(index);
        }

        /// <summary>
        /// Add a dialogue event to Events
        /// </summary>
        /// <param name="evType">Event type (enum)</param>
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
        public void AddSsaEvent(C_Event.EventType evType, int marked, string start, string end, string style, string name_or_actor,
            int marginL, int marginR, int marginV, string effect, string text, int index = -1)
        {
            ssa.AddEvent(evType, marked, start, end, style, name_or_actor,
                marginL, marginR, marginV, effect, text, index);
        }

        /// <summary>
        /// Remove an event from Events
        /// </summary>
        /// <param name="index">Index of the event in Events</param>
        public void RemoveSsaEvent(int index)
        {
            ssa.RemoveEvent(index);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        
    }
}
