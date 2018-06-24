using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TemplateParser {
    public class TemplateEngineImpl : ITemplateEngine {

        List<IMyParser> tag_parsers;

        public TemplateEngineImpl()
        {
            // Normally, I will use dependency injection to inject in the behaviour I want
            // But in this case, I am just gonna take a shortcut and just inject it in the
            // constructor
            tag_parsers = new List<IMyParser>();
        }

        /// <summary>
        /// Applies the specified datasource to a string template, and returns a result string
        /// with substituted values.
        /// </summary>
        public string Apply(string template, object dataSource)
        {
            StringBuilder result = new StringBuilder();

            string curr_string = template;
            // Search for all occurances of tokens
            // start from -1 instead of 0 since 0 can be a valid start of a tag
            for (int open_brkt_index = -1; (open_brkt_index = curr_string.IndexOf('[')) > -1;)
            {
                result.Append(curr_string.Substring(0, open_brkt_index - 1));
                // Determine the type of parser
                int close_brkt_index = curr_string.IndexOf(']', open_brkt_index);
                int tag_length = close_brkt_index - open_brkt_index - 1;
                string curr_tag = curr_string.Substring(open_brkt_index + 1, tag_length);
                // with parser
                foreach (IMyParser my_parser in tag_parsers)
                {
                    if (my_parser.IdentifyParser(curr_tag))
                    {
                        string tag_value = my_parser.Apply(curr_tag, dataSource);
                        result.Append(tag_value);
                        curr_string = my_parser.Truncate(curr_string, close_brkt_index);
                    }
                }
                if (curr_string.Length > 0)
                {
                    result.Append(curr_string);
                }
            }

            return result.ToString();
        }
    }
}
