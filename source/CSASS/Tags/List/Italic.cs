using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags.List
{
    public class Italic : ATag
    {
        public Italic()
        {
            _effectName = "Italic";
            _effectInLineName = "\\i";
            _effectHasParenthesis = false;

            _effectFormat.AddNotFormatted("\\i");
            _effectFormat.AddFormat(TagFormatEnum.Integer);
        }

        public bool IsItalic()
        {
            return _effectInnerTagValues[0].Value != "0";
        }
    }
}
