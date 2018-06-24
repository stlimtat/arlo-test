using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal class WithTagParser : IMyParser
    {
        private const string WITH = "with";

        internal TagSplitterTemplateEngine TagSplitterTemplateEngine { get; set; }

        public string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            throw new NotImplementedException();
        }

        public bool IdentifyParser(string tag)
        {
            return tag.StartsWith(WITH);
        }

        public string Truncate(string body, int closeBracketIndex)
        {
            throw new NotImplementedException();
        }
    }
}
