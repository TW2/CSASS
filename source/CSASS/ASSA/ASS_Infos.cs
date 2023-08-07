using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography;

namespace CSASS
{
    public class ASS_Infos
    {
        //[Script Info]
        public string Title { get; set; } = "";
        public string OriginalScript { get; set; } = "";
        public string OriginalTranslation { get; set; } = "";
        public string OriginalEditing { get; set; } = "";
        public string OriginalTiming { get; set; } = "";
        public string OriginalScriptChecking { get; set; } = "";
        public string ScriptType { get; } = "v4.00+";
        public int PlayResX { get; set; } = 1280;
        public int PlayResY { get; set; } = 720;
        public int PlayDepth { get; set; } = 0;
        public string Wav { get; set; } = "";
        public string LastWav { get; set; } = "";
        public float Timer { get; set; } = 100f;
        public int WrapStyle { get; set; } = 0;
        public string VideoAspectRatio { get; set; } = "";
        public string VideoZoom { get; set; } = "";
        public string YCbCrMatrix { get; set; } = "";

        //[Aegisub Project Garbage]
        public string LastStyleStorage { get; set; } = "";
        public string AudioFile { get; set; } = "";
        public string VideoFile { get; set; } = "";
        public string VideoArMode { get; set; } = "";
        public string VideoArValue { get; set; } = "";
        public string VideoZoomPercent { get; set; } = "";
        public string ActiveLine { get; set; } = "";
        public string VideoPosition { get; set; } = "";

        public ASS_Infos()
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
            if (rawline.StartsWith("WrapStyle")) { WrapStyle = Convert.ToInt32(rawline.Substring("WrapStyle: ".Length)); }
            if (rawline.StartsWith("Video Aspect Ratio")) { VideoAspectRatio = rawline.Substring("Video Aspect Ratio: ".Length); }
            if (rawline.StartsWith("Video Zoom")) { VideoZoom = rawline.Substring("Video Zoom: ".Length); }
            if (rawline.StartsWith("YCbCr Matrix")) { YCbCrMatrix = rawline.Substring("YCbCr Matrix: ".Length); }
            if (rawline.StartsWith("Last Style Storage")) { LastStyleStorage = rawline.Substring("Last Style Storage: ".Length); }
            if (rawline.StartsWith("Audio File")) { AudioFile = rawline.Substring("Audio File: ".Length); }
            if (rawline.StartsWith("Video File")) { VideoFile = rawline.Substring("Video File: ".Length); }
            if (rawline.StartsWith("Video AR Mode")) { VideoArMode = rawline.Substring("Video AR Mode: ".Length); }
            if (rawline.StartsWith("Video AR Value")) { VideoArValue = rawline.Substring("Video AR Value: ".Length); }
            if (rawline.StartsWith("Video Zoom Percent")) { VideoZoomPercent = rawline.Substring("Video Zoom Percent: ".Length); }
            if (rawline.StartsWith("Active Line")) { ActiveLine = rawline.Substring("Active Line: ".Length); }
            if (rawline.StartsWith("Video Position")) { VideoPosition = rawline.Substring("Video Position: ".Length); }
        }

        public void WriteASSInfos(StreamWriter sw, string software, string website, string email)
        {
            sw.WriteLine("[Script Info]");
            sw.WriteLine("; This is a Sub Station Alpha v4+ script.");
            if (software != null && software != string.Empty)
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

            if (Title != null && Title != string.Empty)
            {
                sw.WriteLine("Title: " + Title);
            }

            if (OriginalScript != null && OriginalScript != string.Empty)
            {
                sw.WriteLine("Original Script: " + OriginalScript);
            }

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

            if (PlayResX > 0)
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

            if (WrapStyle >= 0 && WrapStyle <= 3)
            {
                sw.WriteLine("WrapStyle: " + WrapStyle);
            }

            if (VideoAspectRatio != null && VideoAspectRatio != string.Empty)
            {
                sw.WriteLine("Video Aspect Ratio: " + VideoAspectRatio);
            }

            if (VideoZoom != null && VideoZoom != string.Empty)
            {
                sw.WriteLine("Video Zoom: " + VideoZoom);
            }

            if (YCbCrMatrix != null && YCbCrMatrix != string.Empty)
            {
                sw.WriteLine("YCbCr Matrix: " + YCbCrMatrix);
            }
            sw.WriteLine("");

            sw.WriteLine("[Aegisub Project Garbage]");
            if (LastStyleStorage != null && LastStyleStorage != string.Empty)
            {
                sw.WriteLine("Last Style Storage: " + LastStyleStorage);
            }

            if (AudioFile != null && AudioFile != string.Empty)
            {
                sw.WriteLine("Audio File: " + AudioFile);
            }

            if (VideoFile != null && VideoFile != string.Empty)
            {
                sw.WriteLine("Video File: " + VideoFile);
            }

            if (VideoArMode != null && VideoArMode != string.Empty)
            {
                sw.WriteLine("Video AR Mode: " + VideoArMode);
            }

            if (VideoArValue != null && VideoArValue != string.Empty)
            {
                sw.WriteLine("Video AR Value: " + VideoArValue);
            }

            if (VideoZoomPercent != null && VideoZoomPercent != string.Empty)
            {
                sw.WriteLine("Video Zoom Percent: " + VideoZoomPercent);
            }

            if (ActiveLine != null && ActiveLine != string.Empty)
            {
                sw.WriteLine("Active Line: " + ActiveLine);
            }

            if (VideoPosition != null && VideoPosition != string.Empty)
            {
                sw.WriteLine("Video Position: " + VideoPosition);
            }

            sw.WriteLine();
        }
    }
}
