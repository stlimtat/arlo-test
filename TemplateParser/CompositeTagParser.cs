using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace TemplateParser
{
    internal class CompositeTagParser : AbstractTruncateFromCloseTagParser
    {
        private const char DELIMITER = '.';

        public override string Apply(string tag, string template, IDictionary<string, object> dataSourceDict)
        {
            string result = string.Empty;
            string[] tagCompositeProperty = tag.Split(DELIMITER);

            IDictionary<string, object> myDict = dataSourceDict;
            
            for (int index = 0; 
                index < tagCompositeProperty.Length && myDict.ContainsKey(tagCompositeProperty[index]); 
                index++)
            {
                object tagValue = myDict[tagCompositeProperty[index]];
                if (index == tagCompositeProperty.Length - 1 &&
                    tagValue.GetType() == typeof(string))
                {
                    result = (string)tagValue;
                }
                else
                {
                    myDict = new RouteValueDictionary(tagValue);
                }
            }

            return result;
        }

        public override bool IdentifyParser(string tag)
        {
            return (tag.IndexOf(DELIMITER) > -1);
        }
    }
}
