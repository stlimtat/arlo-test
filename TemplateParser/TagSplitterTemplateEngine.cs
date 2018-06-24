using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    public class TagSplitterTemplateEngine : ITemplateEngine
    {
        internal List<IMyParser> MyTagParsers { get; set; }

        public string Apply(string template, object dataSource)
        {
            StringBuilder result = new StringBuilder();

            // I only have one caller
            IDictionary<string, object> dataSourceDict = (IDictionary<string, object>) dataSource;

            string currString = template;
            // Search for all occurances of tokens
            // start from -1 instead of 0 since 0 can be a valid start of a tag
            for (int openBracketIndex = -1; (openBracketIndex = currString.IndexOf('[')) > -1;)
            {
                result.Append(currString.Substring(0, openBracketIndex));
                // Determine the type of parser
                int closeBrackerIndex = currString.IndexOf(']', openBracketIndex);
                int tagLength = closeBrackerIndex - openBracketIndex - 1;
                string currTag = currString.Substring(openBracketIndex + 1, tagLength);
                // with parser
                bool found = false;
                foreach (IMyParser myParser in this.MyTagParsers)
                {
                    if (!found && (found = myParser.IdentifyParser(currTag)))
                    {
                        string tag_value = myParser.Apply(currTag, dataSourceDict);
                        result.Append(tag_value);
                        currString = myParser.Truncate(currString, closeBrackerIndex);
                    }
                }
            }
            if (currString.Length > 0)
            {
                result.Append(currString);
            }

            return result.ToString();
        }
    }
}
