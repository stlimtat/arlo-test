using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace TemplateParser
{
    internal class WithTagParser : AbstractTruncateFromCloseTagParser
    {
        private const string WITH = "with";

        private static TagSplitterTemplateEngine tagSplitterTemplateEngine;
        private static WithTagParser _instance;

        internal static WithTagParser getInstance()
        {
            if (_instance == null)
            {
                _instance = new WithTagParser();
                WithTagParser.tagSplitterTemplateEngine = new TagSplitterTemplateEngine();
                List<IMyParser> myTagParsers = new List<IMyParser>();
                // Usually I will use dependency injection to run this initialization
                // But in this case, I leave it to the constructor
                IMyParser parser = null;
                // the end with tag parser
                parser = EndWithTagParser.getInstance();
                myTagParsers.Add(parser);

                // the With tag parser
                parser = WithTagParser._instance;
                myTagParsers.Add(parser);

                // the composite tag parser
                parser = CompositeTagParser.getInstance();
                myTagParsers.Add(parser);

                // the dataSource simple tag parser
                parser = BasicTagParser.getInstance();
                myTagParsers.Add(parser);
                // the C# expression language tag parser

                WithTagParser.tagSplitterTemplateEngine.MyTagParsers = myTagParsers;
            }
            return _instance;
        }

        WithTagParser()
        {

        }

        public override string Apply(string tag, IDictionary<string, object> dataSourceDict)
        {
            throw new NotImplementedException();
        }

        public override string ApplyWrapper(string tag, string inBody, IDictionary<string, object> dataSourceDict)
        {
            string result = string.Empty;

            // The code here is only for a "with" expression.  
            // We can potentially support "for" expressions or other expressions later.
            // So at this point, we assume that the tag is split by the space
            // We are not looking to support composite tag element [with Contact.Address]
            string dataSourceKey = tag.Split(' ')[1];
            if (dataSourceDict.ContainsKey(dataSourceKey) )
            {
                IDictionary<string, object> subDataSourceDict = new RouteValueDictionary(dataSourceDict[dataSourceKey]);

                // This is where magic happens, and we should expect that the section of the data until the part where 
                // terminator is encountered is dealt with
                // TODO: Test
                result = WithTagParser.tagSplitterTemplateEngine.Apply(inBody, subDataSourceDict);
            }
            return result;
        }

        public override bool IdentifyParser(string tag)
        {
            return tag.StartsWith(WITH);
        }

        public override bool IsWrapperParser()
        {
            return true;
        }
    }
}
