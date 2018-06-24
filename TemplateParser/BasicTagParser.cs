using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TemplateParser
{
    internal class BasicTagParser : AbstractTruncateFromCloseTagParser
    {
        public override string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            string result = string.Empty;
            if (dataSourceDict.ContainsKey(tag))
            {
                object tagValue = dataSourceDict[tag];
                if (tagValue.GetType() == typeof(string))
                {
                    result = (string)tagValue;
                }
            }
            return result;
        }

        public override bool IdentifyParser(string tag)
        {
            return true;
        }
    }
}
