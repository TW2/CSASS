using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags.List
{
    public class Bold : ATag
    {
        public Bold()
        {
            _effectName = "Bold";
            _effectInLineName = "\\b";
            _effectHasParenthesis = false;

            _effectFormat.AddNotFormatted("\\b");
            _effectFormat.AddFormat(TagFormatEnum.Integer);
        }

        public bool IsBold()
        {
            return _effectInnerTagValues[0].Value != "0";
        }
    }
}
