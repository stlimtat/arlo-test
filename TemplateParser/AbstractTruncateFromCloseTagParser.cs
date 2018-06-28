using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal abstract class AbstractTruncateFromCloseTagParser : IMyParser
    {
        public abstract string Apply(string tag, IDictionary<string, object> dataSource);
        public virtual string ApplyWrapper(string tag, string inBody, IDictionary<string, object> dataSourceDict)
        {
            throw new NotImplementedException();
        }
        public abstract bool IdentifyParser(string tag);

        public virtual bool IfFoundExitTagSplitterLoop()
        {
            return false;
        }

        public virtual bool IsWrapperParser()
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
