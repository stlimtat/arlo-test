using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal interface IMyParser
    {
        bool IdentifyParser(string tag);
        string Apply(string tag, string body, IDictionary<string, object> dataSourceDict);
        string Truncate(string body, int closeBracketIndex);
        bool IfFoundExitTagSplitterLoop();
    }
}
