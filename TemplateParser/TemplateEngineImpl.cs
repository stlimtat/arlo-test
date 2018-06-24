﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Routing;

namespace TemplateParser {
    public class TemplateEngineImpl : ITemplateEngine {
        List<IMyParser> myTagParsers;

        public TemplateEngineImpl()
        {
            // Usually I will use dependency injection to run this initialization
            // But in this case, I leave it to the constructor
            this.myTagParsers = new List<IMyParser>();
            // the With tag parser
            IMyParser parser = null;

            // the composite tag parser
            parser = new CompositeTagParser();
            this.myTagParsers.Add(parser);

            // the dataSource simple tag parser
            parser = new BasicTagParser();
            this.myTagParsers.Add(parser);
            // the C# expression language tag parser
        }

        /// <summary>
        /// Applies the specified datasource to a string template, and returns a result string
        /// with substituted values.
        /// </summary>
        public string Apply(string template, object dataSource)
        {
            string result = null;

            TagSplitterTemplateEngine tagSplitterTemplateEngine = new TagSplitterTemplateEngine();
            tagSplitterTemplateEngine.MyTagParsers = this.myTagParsers;

            IDictionary<string, object> dataSourceDict = new RouteValueDictionary(dataSource);

            result = tagSplitterTemplateEngine.Apply(template, dataSourceDict);

            return result;
        }
    }
}
