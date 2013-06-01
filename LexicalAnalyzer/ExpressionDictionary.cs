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
            Add(typeof(Float), "");
            Add(typeof(Integer), "^(?<=\\s|^)\\d+(?=\\s|$|[^.e])");
        }
    }
}
