using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public class TagFormat
    {
        private static string _forInteger = "¤";
        private static string _forFloat = "%";
        private static string _forDouble = "µ";
        private static string _forString = "@";
        private static int _digitsAfterDot = 3;
        private static string _forVariable = "$";
        private static string _forCalculation = "!";

        private string _tag = "";

        public TagFormat()
        {

        }

        public void AddNotFormatted(string s)
        {
            _tag += s;
        }

        public void AddFormat(TagFormatEnum kind)
        {
            switch (kind)
            {
                case TagFormatEnum.Integer: _tag += _forInteger; break;
                case TagFormatEnum.Float: _tag += _forFloat; break;
                case TagFormatEnum.Double: _tag += _forDouble; break;
                case TagFormatEnum.String: _tag += _forString;  break;
                case TagFormatEnum.Variable: _tag += _forVariable; break;
                case TagFormatEnum.Calculation: _tag += _forCalculation; break;
            }            
        }

        public string Tag { get => _tag; set => _tag = value; }

        public static string GetFormattedTag(List<TagValue> values, TagFormat format)
        {
            int countTags = 0;
            string formatted = "";

            foreach (char c in format.Tag.ToCharArray())
            {
                string character = Convert.ToString(c);

                if(character == _forInteger | character == _forFloat | character == _forDouble |
                    character == _forString | character == _forVariable | character == _forCalculation)
                {
                    formatted += Convert.ToString(values[countTags]);
                    countTags++;
                }
                else
                {
                    formatted += character;
                }

            }

            return formatted;
        }
    }
}
