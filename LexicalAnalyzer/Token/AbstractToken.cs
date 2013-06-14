using System;

namespace LexicalAnalyzer.Token
{
    public class AbstractToken
    {

        protected string Value;
        private int _position;

        public AbstractToken(String value)
        {
            Value = value;
        }

        public AbstractToken(String value, int Position)
        {
            Value = value;
            _position = Position;
        }

        public String GetValue()
        {
            return Value;
        }

        public int Position
        {
            get { return _position; }
        }
    }
}
