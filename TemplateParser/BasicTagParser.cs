using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TemplateParser
{
    internal class BasicTagParser : AbstractTruncateFromCloseTagParser
    {
        private static BasicTagParser _instance;

        internal static BasicTagParser getInstance()
        {
            if (_instance == null)
            {
                _instance = new BasicTagParser();
            }
            return _instance;
        }

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
