using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    internal interface IMyParser
    {
        bool IdentifyParser(string tag);
        /**
         * For basic usage, just replace a tag element with a data item from the 
         * dataSourceDict
         **/
        string Apply(string tag, IDictionary<string, object> dataSourceDict);

        /**
         * Truncate the body of the template
         **/
        string Truncate(string body, int closeBracketIndex);

        /**
         * We want a simple boolean variable for tracking the terminator of a wrapper
         **/
        bool IfFoundExitTagSplitterLoop();

        /**
         *  We needed something to parse the wrapper function
         **/
        bool IsWrapperParser();

        /**
         * The difference between the normal tag handlers vs the wrapper function is that
         * the wrapper should search for it's terminator, and then replace until the 
         * terminator
         **/
        string ApplyWrapper(string inBody, out string outBody, IDictionary<string, object> dataSourceDict);
    }
}
