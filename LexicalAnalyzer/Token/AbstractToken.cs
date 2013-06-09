using System;

namespace LexicalAnalyzer.Token
{
    public class AbstractToken
    {

        public AbstractToken(String value)
        {
            Value = value;
        }

        protected string Value;

        public String GetValue()
        {
            return Value;
        }
    }
}
