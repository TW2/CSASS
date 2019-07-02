using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags.List
{
    public class Strikeout : ATag
    {
        public Strikeout()
        {
            _effectName = "Strikeout";
            _effectInLineName = "\\s";
            _effectHasParenthesis = false;

            _effectFormat.AddNotFormatted("\\s");
            _effectFormat.AddFormat(TagFormatEnum.Integer);
        }

        public bool IsStrikeout()
        {
            return _effectInnerTagValues[0].Value != "0";
        }
    }
}
