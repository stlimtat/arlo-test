using System.Collections.Generic;

namespace TemplateParser
{
    internal class EndWithTagParser : AbstractTruncateFromCloseTagParser
    {
        private const string END_WITH = "/with";

        public override string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            return string.Empty;
        }

        public override bool IdentifyParser(string tag)
        {
            return tag.StartsWith(END_WITH);
        }

        public new bool IfFoundExitTagSplitterLoop()
        {
            return true;
        }
    }
}