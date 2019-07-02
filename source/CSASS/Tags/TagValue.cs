using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public class TagValue
    {
        private string _name = null;
        private Type _type = null;
        private string _value = null;

        public TagValue()
        {

        }

        public string Name { get => _name; set => _name = value; }
        public Type Type { get => _type; set => _type = value; }
        public string Value { get => _value; set => _value = value; }

    }
}
