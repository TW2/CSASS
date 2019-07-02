using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public class CA_TaggedText
    {
        private List<ATag> tags = new List<ATag>();
        private string text = "";

        public CA_TaggedText()
        {
        }

        public List<ATag> Tags { get => tags; set => tags = value; }

        public string Text { get => text; set => text = value; }
    }
}
