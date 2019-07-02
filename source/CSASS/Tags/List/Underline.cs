using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags.List
{
    public class Underline : ATag
    {
        public Underline()
        {
            _effectName = "Underline";
            _effectInLineName = "\\u";
            _effectHasParenthesis = false;

            _effectFormat.AddNotFormatted("\\u");
            _effectFormat.AddFormat(TagFormatEnum.Integer);
        }

        public bool IsUnderline()
        {
            return _effectInnerTagValues[0].Value != "0";
        }
    }
}
