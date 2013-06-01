using LexicalAnalyzer.Token;

namespace LexicalAnalyzer
{
    public class LexicalScanner
    {
        private readonly string _input;
        private ExpressionDictionary _dictionary;

        public LexicalScanner(string input)
        {
            _input = input;
            _dictionary = new ExpressionDictionary();
        }

        public string Input
        {
            get { return _input; }
        }

        public AbstractToken GetNextToken()
        {
            return new Number("1");
        }
    }
}
