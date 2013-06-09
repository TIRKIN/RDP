using System;

namespace LexicalAnalyzer.Token
{
    public class Number : AbstractToken
    {
        public Number(string value) : base(value)
        {
        }

        public Number(String Value, int Postion) : base(Value, Postion) { }
    }
}
