using AVS;
using CSASS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Binary.CSASS
{
    public class RENDER
    {
        private static AviSynthScriptEnvironment asse = new AviSynthScriptEnvironment();
        private static string appPath = null;

        public RENDER()
        {
            string processCmdLine = GetModuleFileName(IntPtr.Zero);
            appPath = Path.GetDirectoryName(processCmdLine);
        }

        [DllImport("coredll", SetLastError = true)]
        extern static uint GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, [MarshalAs(UnmanagedType.U4)] int nSize);

        static string GetModuleFileName(IntPtr hModule)
        {

            StringBuilder fileName = new StringBuilder(short.MaxValue);
            uint retVal = GetModuleFileName(hModule, fileName, fileName.Capacity);

            if (retVal == 0)
            {
                throw new Win32Exception();
            }

            return fileName.ToString();
        }

        public static Bitmap GetImage(Csass main, string videoPath, long milliseconds, int offset = 0, double fps = 23.976d)
        {
            //Create a clip
            AviSynthClip clip = asse.ParseScript(GetScript(main, videoPath));

            //Return an image
            return AvisynthLoader.ReadFrameBitmap(clip, Convert.ToInt32((double)milliseconds / 1000d * fps) + offset);
        }

        public static Bitmap GetImage(Csass main, string videoPath, int framePosition)
        {
            //Create a clip
            AviSynthClip clip = asse.ParseScript(GetScript(main, videoPath));

            //Return an image
            return AvisynthLoader.ReadFrameBitmap(clip, framePosition);
        }

        private static string GetScript(Csass main, string videoPath)
        {
            string str = "";
            str += "# Load video\n";
            str += "LoadPlugin(\"" + appPath + "\\ffms2.dll\")\n";            
            str += "FFVideoSource(\"" + videoPath + "\")\n";

            if(main.Events.Count > 0)
            {
                string assPathTemp = appPath + @"\temp.ass";
                main.SaveASS(assPathTemp);
                str += "# Load ASS\n";
                str += "LoadPlugin(\"" + appPath + "\\xy-VSFilter.dll\")\n";
                str += "TextSub(\"" + assPathTemp + "\")\n";
            }

            str += "ConvertToYV12()\n";

            return str;
        }
    }
}
