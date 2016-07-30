using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS
{
    public class Csass
    {
        private List<CA_Event> events = new List<CA_Event>();
        private List<CA_Style> styles = new List<CA_Style>();
        private CA_Infos assinfos = new CA_Infos();

        public Csass()
        {

        }

        public void LoadASS(string path)
        {
            string line;
            events.Clear();
            styles.Clear();

            using(StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("Style") & !line.StartsWith("Dialogue") & !line.StartsWith("Comment"))
                    {
                        assinfos.TryAdd(line);
                    }

                    if (line.StartsWith("Style"))
                    {
                        CA_Style asss = new CA_Style(line);
                        styles.Add(asss);
                    }

                    if (line.StartsWith("Dialogue") | line.StartsWith("Comment"))
                    {
                        CA_Event txt = new CA_Event(line);
                        events.Add(txt);
                    }
                }
            }
        }

        public void SaveASS(string path, string software = "CSASS library", string website = "unknown")
        {

        }

        public List<CA_Event> Events
        {
            get { return events; }
        }

        public List<CA_Style> Styles
        {
            get { return styles; }
        }

        public CA_Infos Infos
        {
            get { return assinfos; }
        }
    }
}
