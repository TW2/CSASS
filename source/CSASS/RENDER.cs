using AVS;
using CSASS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary.CSASS
{
    public class RENDER
    {
        private static AviSynthScriptEnvironment asse = new AviSynthScriptEnvironment();
        private static string appPath = System.Windows.Forms.Application.StartupPath;

        public RENDER()
        {

        }

        public static Bitmap GetImage(Csass main, string videoPath, long milliseconds, double fps = 23.976d)
        {
            //Create a clip
            AviSynthClip clip = asse.ParseScript(GetScript(main, videoPath));

            //Return an image
            return AvisynthLoader.ReadFrameBitmap(clip, Convert.ToInt32(milliseconds / 1000 * fps));
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
            str += "# Load plugin\n";
            str += "LoadPlugin(\"" + appPath + "\\ffms2.dll\")\n";
            str += "# Load video\n";
            str += "FFVideoSource(\"" + videoPath + "\")\n";

            if(main.Events.Count > 0)
            {
                string assPathTemp = appPath + @"\temp.ass";
                main.SaveASS(assPathTemp);
                str += "# Load ASS\n";
                str += "TextSubMod(\"" + assPathTemp + "\")\n";
            }

            str += "ConvertToYV12()\n";

            return str;
        }
    }
}
