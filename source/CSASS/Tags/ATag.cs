using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public class ATag : ITag
    {
        protected string _effectName = "";
        protected TagFormat _effectFormat = new TagFormat();
        protected string _effectInLineName = "";
        protected List<TagValue> _effectInnerTagValues = new List<TagValue>();
        protected bool _effectHasParenthesis = false;

        public ATag()
        {
        }

        public virtual string GetEffectName()
        {
            return _effectName;
        }

        public virtual TagFormat GetFormat()
        {
            return _effectFormat;
        }

        public virtual string GetInLineName()
        {
            return _effectInLineName;
        }

        public virtual List<TagValue> GetInnerTagValues()
        {
            return _effectInnerTagValues;
        }

        public virtual bool HasParenthesis()
        {
            return _effectHasParenthesis;
        }
    }
}
