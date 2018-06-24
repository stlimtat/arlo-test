using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    interface IMyParser
    {
        bool IdentifyParser(string tag);
        string Apply(string tag, object dataSource);
        string Truncate(string body, int close_brkt_index);
    }
}
