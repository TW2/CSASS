using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSASS.Tags
{
    public interface ITag
    {
        /// <summary>
        /// Effect name in english (ex: Bold)
        /// </summary>
        /// <returns>Name of the effect</returns>
        string GetEffectName();

        /// <summary>
        /// In line name (ex: \b)
        /// </summary>
        /// <returns>In line tag without value(s)</returns>
        string GetInLineName();

        /// <summary>
        /// Values with parenthesis or not
        /// </summary>
        /// <returns>True if values are in parenthesis</returns>
        bool HasParenthesis();

        /// <summary>
        /// Parameters included in the effect
        /// </summary>
        /// <returns>List of tags and them values</returns>
        List<TagValue> GetInnerTagValues();

        /// <summary>
        /// In line format for this effect
        /// </summary>
        /// <returns>Format to deal with GetInnerTagValues()</returns>
        TagFormat GetFormat();
    }
}
