using System;
using System.Collections.Generic;
using LexicalAnalyzer.Token;

namespace LexicalAnalyzer
{
    public class ExpressionDictionary : Dictionary<Type, String>
    {
        public ExpressionDictionary()
        {
            Init();
        }

        private void Init()
        {
            Add(typeof(Float), "^\\s*([0-9][0-9]*)?(\\.[0-9]+)+([eE][+-]?[0-9]+)?");
            Add(typeof(Integer), "^\\s*(?<=\\s|^)\\d+(?=\\s|$|[^.e])");
            Add(typeof(AddSub), "^\\s*[+|-]");
            Add(typeof(Operator), "^\\s*[*|\\\\|^]");
            Add(typeof(OpenParenthesis), "^\\s*\\(");
            Add(typeof(CloseParenthesis), "^\\s*\\)");
            Add(typeof(Variable), "^\\s*[a-z]");
            Add(typeof(Equals), "^\\s*=");
        }
    }
}
