using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.ASSNeo
{
    /// <summary>
    /// New ASS Rendering method far than libass or other VsFilter
    /// </summary>
    public class Core
    {

        public Core()
        {

        }

        public static Bitmap RenderNeoASS(Csass main, long ms)
        {
            // Settings
            Bitmap bmp = new Bitmap(main.Infos.PlayResX, main.Infos.PlayResY);
            Graphics g = Graphics.FromImage(bmp);

            // Collect the events for time
            List<ASS_Event> list = new List<ASS_Event>();

            // Retrieve event (data) for this time
            foreach (ASS_Event ev in main.Events)
            {
                if(ev.Start <= ms && ms < ev.End)
                {
                    list.Add(ev);
                }
            }

            // Draw
            foreach (ASS_Event ev in list)
            {
                // Retrieve style (font)
                ASS_Style style = new ASS_Style();
                foreach (ASS_Style s in main.Styles)
                {
                    if(s.Name == ev.Style)
                    {
                        style = s;
                        break;
                    }
                }

                // Prepare font
                ASS_Font fnt = style.Font;
                Font font = fnt.Font;

                // Prepare path                
                GraphicsPath path = new GraphicsPath();

                // Convert font size into appropriate coordinates
                //float emSize = g.DpiY * fnt.FontSize / 72;

                // Try to split in \N (crlf)
                string[] texts = ev.Text.Split(new string[] { "\\N" }, StringSplitOptions.None);
                

                // Configure lines
                path.AddString(ev.Text, font.FontFamily, (int)font.Style, fnt.FontSize, new Point(100, 100), new StringFormat());

                g.FillPath(Brushes.White, path);
                g.DrawPath(Pens.Black, path);
            }

            return bmp;
        }

        private static void DrawPathes(Graphics g, List<ASS_Event> evts, List<ASS_Style> styles)
        {
            
        }

    }
}
