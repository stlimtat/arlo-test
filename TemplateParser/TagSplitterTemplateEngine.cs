using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    class TagSplitterTemplateEngine : ITemplateEngine
    {
        private List<IMyParser> tagMyParsers;

        TagSplitterTemplateEngine(List<IMyParser> tagMyParsers)
        {
            this.tagMyParsers = tagMyParsers;
        }

        string ITemplateEngine.Apply(string template, object dataSource)
        {
            StringBuilder result = new StringBuilder();
            string currString = template;
            // Search for all occurances of tokens
            // start from -1 instead of 0 since 0 can be a valid start of a tag
            for (int openBracketIndex = -1; (openBracketIndex = currString.IndexOf('[')) > -1;)
            {
                result.Append(currString.Substring(0, openBracketIndex - 1));
                // Determine the type of parser
                int closeBrackerIndex = currString.IndexOf(']', openBracketIndex);
                int tagLength = closeBrackerIndex - openBracketIndex - 1;
                string currTag = currString.Substring(openBracketIndex + 1, tagLength);
                // with parser
                foreach (IMyParser myParser in tagMyParsers)
                {
                    if (myParser.IdentifyParser(currTag))
                    {
                        string tag_value = myParser.Apply(currTag, dataSource);
                        result.Append(tag_value);
                        currString = myParser.Truncate(currString, closeBrackerIndex);
                    }
                }
                if (currString.Length > 0)
                {
                    result.Append(currString);
                }
            }

            return result.ToString();
        }
    }
}
