using System;

namespace CSASS
{
    public class ASS_Infos
    {
        //[Script Info]
        private string _title = "";
        private string _original_script = "";
        private string _original_translation = "";
        private string _original_editing = "";
        private string _original_timing = "";
        private string _original_script_checking = "";
        private string _scripttype = "v4.00+";
        private int _playresX = 1280;
        private int _playresY = 720;
        private int _playdepth = 0;
        private string _wav = "";
        private string _lastwav = "";
        private float _timer = 100f;
        private int _wrapstyle = 0;
        private string _video_aspect_ratio = "";
        private string _video_zoom = "";
        private string _ycbcr_matrix = "";

        //[Aegisub Project Garbage]
        private string _last_style_storage = "";
        private string _audio_file = "";
        private string _video_file = "";
        private string _video_ar_mode = "";
        private string _video_ar_value = "";
        private string _video_zoom_percent = "";
        private string _active_line = "";
        private string _video_position = "";

        public ASS_Infos()
        {

        }

        public void TryAdd(string rawline)
        {
            if (rawline.StartsWith("Title")) { _title = rawline.Substring("Title: ".Length); }
            if (rawline.StartsWith("Original Script")) { _original_script = rawline.Substring("Original Script: ".Length); }
            if (rawline.StartsWith("Original Translation")) { _original_translation = rawline.Substring("Original Translation: ".Length); }
            if (rawline.StartsWith("Original Editing")) { _original_editing = rawline.Substring("Original Editing: ".Length); }
            if (rawline.StartsWith("Original Timing")) { _original_timing = rawline.Substring("Original Timing: ".Length); }
            if (rawline.StartsWith("Original Script Checking")) { _original_script_checking = rawline.Substring("Original Script Checking: ".Length); }
            if (rawline.StartsWith("ScriptType")) { _scripttype = rawline.Substring("ScriptType: ".Length); }
            if (rawline.StartsWith("PlayResX")) { _playresX = Convert.ToInt32(rawline.Substring("PlayResX: ".Length)); }
            if (rawline.StartsWith("PlayResY")) { _playresY = Convert.ToInt32(rawline.Substring("PlayResY: ".Length)); }
            if (rawline.StartsWith("PlayDepth")) { _playdepth = Convert.ToInt32(rawline.Substring("PlayDepth: ".Length)); }
            if (rawline.StartsWith("Wav")) { _wav = rawline.Substring("Wav: ".Length); }
            if (rawline.StartsWith("LastWav")) { _lastwav = rawline.Substring("LastWav: ".Length); }
            if (rawline.StartsWith("Timer")) { _timer = Convert.ToSingle(rawline.Substring("Timer: ".Length)); }
            if (rawline.StartsWith("WrapStyle")) { _wrapstyle = Convert.ToInt32(rawline.Substring("WrapStyle: ".Length)); }
            if (rawline.StartsWith("Video Aspect Ratio")) { _video_aspect_ratio = rawline.Substring("Video Aspect Ratio: ".Length); }
            if (rawline.StartsWith("Video Zoom")) { _video_zoom = rawline.Substring("Video Zoom: ".Length); }
            if (rawline.StartsWith("YCbCr Matrix")) { _ycbcr_matrix = rawline.Substring("YCbCr Matrix: ".Length); }
            if (rawline.StartsWith("Last Style Storage")) { _last_style_storage = rawline.Substring("Last Style Storage: ".Length); }
            if (rawline.StartsWith("Audio File")) { _audio_file = rawline.Substring("Audio File: ".Length); }
            if (rawline.StartsWith("Video File")) { _video_file = rawline.Substring("Video File: ".Length); }
            if (rawline.StartsWith("Video AR Mode")) { _video_ar_mode = rawline.Substring("Video AR Mode: ".Length); }
            if (rawline.StartsWith("Video AR Value")) { _video_ar_value = rawline.Substring("Video AR Value: ".Length); }
            if (rawline.StartsWith("Video Zoom Percent")) { _video_zoom_percent = rawline.Substring("Video Zoom Percent: ".Length); }
            if (rawline.StartsWith("Active Line")) { _active_line = rawline.Substring("Active Line: ".Length); }
            if (rawline.StartsWith("Video Position")) { _video_position = rawline.Substring("Video Position: ".Length); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string OriginalScript
        {
            get { return _original_script; }
            set { _original_script = value; }
        }

        public string OriginalTranslation
        {
            get { return _original_translation; }
            set { _original_translation = value; }
        }

        public string OriginalEditing
        {
            get { return _original_editing; }
            set { _original_editing = value; }
        }

        public string OriginalTiming
        {
            get { return _original_timing; }
            set { _original_timing = value; }
        }

        public string OriginalScriptChecking
        {
            get { return _original_script_checking; }
            set { _original_script_checking = value; }
        }

        public string ScriptType
        {
            get { return _scripttype; }
            set { _scripttype = value; }
        }

        public int PlayResX
        {
            get { return _playresX; }
            set { _playresX = value; }
        }

        public int PlayResY
        {
            get { return _playresY; }
            set { _playresY = value; }
        }

        public int PlayDepth
        {
            get { return _playdepth; }
            set { _playdepth = value; }
        }

        public string Wav
        {
            get { return _wav; }
            set { _wav = value; }
        }

        public string LastWav
        {
            get { return _lastwav; }
            set { _lastwav = value; }
        }

        public float Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }

        public int WrapStyle
        {
            get { return _wrapstyle; }
            set { _wrapstyle = value; }
        }

        public string VideoAspectRatio
        {
            get { return _video_aspect_ratio; }
            set { _video_aspect_ratio = value; }
        }

        public string VideoZoom
        {
            get { return _video_zoom; }
            set { _video_zoom = value; }
        }

        public string YCbCrMatrix
        {
            get { return _ycbcr_matrix; }
            set { _ycbcr_matrix = value; }
        }

        public string LastStyleStorage
        {
            get { return _last_style_storage; }
            set { _last_style_storage = value; }
        }

        public string AudioFile
        {
            get { return _audio_file; }
            set { _audio_file = value; }
        }

        public string VideoFile
        {
            get { return _video_file; }
            set { _video_file = value; }
        }

        public string VideoARMode
        {
            get { return _video_ar_mode; }
            set { _video_ar_mode = value; }
        }

        public string VideoARValue
        {
            get { return _video_ar_value; }
            set { _video_ar_value = value; }
        }

        public string VideoZoomPercent
        {
            get { return _video_zoom_percent; }
            set { _video_zoom_percent = value; }
        }

        public string ActiveLine
        {
            get { return _active_line; }
            set { _active_line = value; }
        }

        public string VideoPosition
        {
            get { return _video_position; }
            set { _video_position = value; }
        }
    }
}
