using System.Collections.Generic;

namespace TemplateParser
{
    internal class EndWithTagParser : AbstractTruncateFromCloseTagParser
    {
        private const string END_WITH = "/with";
        private static EndWithTagParser _instance;

        internal static EndWithTagParser getInstance()
        {
            if (_instance == null)
            {
                _instance = new EndWithTagParser();
            }
            return _instance;
        }

        public override string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            return string.Empty;
        }

        public override bool IdentifyParser(string tag)
        {
            return tag.StartsWith(END_WITH);
        }

        public override bool IfFoundExitTagSplitterLoop()
        {
            return true;
        }
    }
}