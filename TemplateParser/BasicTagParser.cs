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
            string actualTag = tag;
            string formattingString = string.Empty;
            // Heck we could have solved this with regex - humbug
            int tagSpaceIndex = tag.IndexOf(' ');
            if (tagSpaceIndex > -1)
            {
                // there is a formatting provided for the data
                actualTag = tag.Substring(0, tagSpaceIndex).Trim();
                string remainingTag = tag.Substring(tagSpaceIndex + 1).Trim();
                int tagOpenQuoteIndex = remainingTag.IndexOf('"');
                formattingString = remainingTag.Substring(tagOpenQuoteIndex + 1, remainingTag.Length - 2);
            }
            if (dataSourceDict.ContainsKey(actualTag))
            {
                object tagValue = dataSourceDict[actualTag];
                if (tagValue.GetType() == typeof(string))
                {
                    result = (string)tagValue;
                } else if (tagValue.GetType() == typeof(DateTimeOffset))
                {
                    DateTimeOffset date = (DateTimeOffset)tagValue;
                    result = date.ToString(formattingString);
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
