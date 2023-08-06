using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSA
{
    public class SSA_Infos
    {
        //[Script Info]
        private string Title { get; set; } = "";
        private string OriginalScript { get; set; } = "";
        private string OriginalTranslation { get; set; } = "";
        private string OriginalEditing { get; set; } = "";
        private string OriginalTiming { get; set; } = "";
        private string OriginalScriptChecking { get; set; } = "";
        private string ScriptType { get; } = "v4.00";
        private int PlayResX { get; set; } = 1280;
        private int PlayResY { get; set; } = 720;
        private int PlayDepth { get; set; } = 0;
        private string Wav { get; set; } = "";
        private string LastWav { get; set; } = "";
        private float Timer { get; set; } = 100f;

        public SSA_Infos()
        {

        }

        public void TryAdd(string rawline)
        {
            if (rawline.StartsWith("Title")) { Title = rawline.Substring("Title: ".Length); }
            if (rawline.StartsWith("Original Script")) { OriginalScript = rawline.Substring("Original Script: ".Length); }
            if (rawline.StartsWith("Original Translation")) { OriginalTranslation = rawline.Substring("Original Translation: ".Length); }
            if (rawline.StartsWith("Original Editing")) { OriginalEditing = rawline.Substring("Original Editing: ".Length); }
            if (rawline.StartsWith("Original Timing")) { OriginalTiming = rawline.Substring("Original Timing: ".Length); }
            if (rawline.StartsWith("Original Script Checking")) { OriginalScriptChecking = rawline.Substring("Original Script Checking: ".Length); }
            if (rawline.StartsWith("PlayResX")) { PlayResX = Convert.ToInt32(rawline.Substring("PlayResX: ".Length)); }
            if (rawline.StartsWith("PlayResY")) { PlayResY = Convert.ToInt32(rawline.Substring("PlayResY: ".Length)); }
            if (rawline.StartsWith("PlayDepth")) { PlayDepth = Convert.ToInt32(rawline.Substring("PlayDepth: ".Length)); }
            if (rawline.StartsWith("Wav")) { Wav = rawline.Substring("Wav: ".Length); }
            if (rawline.StartsWith("LastWav")) { LastWav = rawline.Substring("LastWav: ".Length); }
            if (rawline.StartsWith("Timer")) { Timer = Convert.ToSingle(rawline.Substring("Timer: ".Length)); }
        }

        public void WriteSSAInfos(StreamWriter sw, string software = "Sub Station Alpha",
            string website = "http://www.eswat.demon.co.uk/", string email = "kotus@eswat.demon.co.uk")
        {
            sw.WriteLine("[Script Info]");
            sw.WriteLine("; This is a Sub Station Alpha v4 script.");
            if(software != null && software != string.Empty)
            {
                sw.WriteLine("; For " + software + " info and downloads,");

                if (website != null && website != string.Empty)
                {
                    sw.WriteLine("; go to " + website);

                    if (email != null && email != string.Empty)
                    {
                        sw.WriteLine("; or email " + email);
                    }
                }

            }

            sw.WriteLine("Title: " + ((Title != null && Title != string.Empty) ?
                Title : "<untitled>"));
            sw.WriteLine("Original Script: " + ((OriginalScript != null && OriginalScript != string.Empty) ?
                OriginalScript : "<unknown>"));

            if (OriginalTranslation != null && OriginalTranslation != string.Empty)
            {
                sw.WriteLine("Original Translation: " + OriginalTranslation);
            }

            if (OriginalEditing != null && OriginalEditing != string.Empty)
            {
                sw.WriteLine("Original Editing: " + OriginalEditing);
            }

            if (OriginalTiming != null && OriginalTiming != string.Empty)
            {
                sw.WriteLine("Original Timing: " + OriginalTiming);
            }

            if (OriginalScriptChecking != null && OriginalScriptChecking != string.Empty)
            {
                sw.WriteLine("Original Script Checking: " + OriginalScriptChecking);
            }

            sw.WriteLine("ScriptType: " + ScriptType);
            sw.WriteLine("Collisions: Normal"); // TODO change and add variable

            if(PlayResX > 0)
            {
                sw.WriteLine("PlayResX: " + PlayResX);
            }

            if (PlayResY > 0)
            {
                sw.WriteLine("PlayResY: " + PlayResY);
            }

            if (PlayDepth > 0)
            {
                sw.WriteLine("PlayDepth: " + PlayDepth);
            }

            if (Wav != null && Wav != string.Empty)
            {
                sw.WriteLine("Wav: " + Wav);
            }

            if (LastWav != null && LastWav != string.Empty)
            {
                sw.WriteLine("LastWav: " + LastWav);
            }

            string strTimer = Convert.ToString(Timer);
            string strTimerFilled = "100,0000";
            if (strTimer != null && strTimer != string.Empty)
            {
                if (strTimer.Contains("."))
                {
                    string[] table = strTimer.Split('.');
                    string b, a = table[0];

                    if (table[1].Length > 4)
                    {
                        b = table[1].Substring(0, 4);
                    }
                    else if (table[1].Length == 4)
                    {
                        b = table[1];
                    }
                    else if (table[1].Length == 3)
                    {
                        b = table[1] + "0";
                    }
                    else if (table[1].Length == 2)
                    {
                        b = table[1] + "00";
                    }
                    else if (table[1].Length == 1)
                    {
                        b = table[1] + "000";
                    }
                    else
                    {
                        b = "0000";
                    }

                    strTimerFilled = a + "," + b;
                }
                else
                {
                    strTimerFilled = strTimer + ",0000";
                }                
            }

            sw.WriteLine("Timer: " + strTimerFilled);
            sw.WriteLine();
        }

    }
}
