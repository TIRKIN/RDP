using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexicalAnalyzer.Token;

namespace LexicalAnalyzer
{
    public class LexicalScanner
    {
        private string _input;

        public LexicalScanner(string Input)
        {
            _input = Input;
        }

        public AbstractToken GetNextToken()
        {

        }
    }
}
