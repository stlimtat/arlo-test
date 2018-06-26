using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal class WithTagParser : IMyParser
    {
        private const string WITH = "with";

        private TagSplitterTemplateEngine tagSplitterTemplateEngine;
        private List<IMyParser> myTagParsers;

        WithTagParser()
        {
            this.tagSplitterTemplateEngine = new TagSplitterTemplateEngine();
            this.myTagParsers = new List<IMyParser>();
            // Usually I will use dependency injection to run this initialization
            // But in this case, I leave it to the constructor
            this.myTagParsers = new List<IMyParser>();
            IMyParser parser = null;
            // the end with tag parser
            parser = new EndWithTagParser();
            this.myTagParsers.Add(parser);

            // the With tag parser
            parser = new WithTagParser();
            this.myTagParsers.Add(parser);

            // the composite tag parser
            parser = new CompositeTagParser();
            this.myTagParsers.Add(parser);

            // the dataSource simple tag parser
            parser = new BasicTagParser();
            this.myTagParsers.Add(parser);
            // the C# expression language tag parser
        }

        public string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            throw new NotImplementedException();
        }

        public string ApplyWrapper(string inBody, out string outBody, IDictionary<string, object> dataSourceDict)
        {
            string result = string.Empty;
            outBody = String.Copy(inBody);


            return result;
        }

        public bool IdentifyParser(string tag)
        {
            return tag.StartsWith(WITH);
        }

        public bool IfFoundExitTagSplitterLoop()
        {
            return false;
        }

        public bool IsWrapperParser()
        {
            return true;
        }

        public string Truncate(string body, int closeBracketIndex)
        {
            throw new NotImplementedException();
        }
    }
}
