using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal abstract class AbstractTruncateFromCloseTagParser : IMyParser
    {
        public abstract string Apply(string tag, IDictionary<string, object> dataSource);
        public abstract bool IdentifyParser(string tag);

        public bool IfFoundExitTagSplitterLoop()
        {
            return false;
        }

        public string Truncate(string body, int closeBracketIndex)
        {
            string result = string.Empty;
            if (closeBracketIndex < body.Length)
            {
                result = body.Substring(closeBracketIndex + 1);
            }
            return result;
        }
    }
}
