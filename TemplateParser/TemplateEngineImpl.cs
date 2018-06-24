using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TemplateParser {
    public class TemplateEngineImpl : ITemplateEngine {
        List<IMyParser> myTagParsers;

        TemplateEngineImpl()
        {
            // Usually I will use dependency injection to run this initialization
            // But in this case, I leave it to the constructor
            this.myTagParsers = new List<IMyParser>();
            // the With tag parser
            // the composite tag parser
            // the dataSource simple tag parser
            // the C# expression language tag parser
        }

        /// <summary>
        /// Applies the specified datasource to a string template, and returns a result string
        /// with substituted values.
        /// </summary>
        public string Apply(string template, object dataSource)
        {
            string result = null;


            TagSplitterTemplateEngine tagSplitterTemplateEngine = new TagSplitterTemplateEngine(this.myTagParsers);

            return result;
        }
    }
}
