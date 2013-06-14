using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class OpenParenthesis : AbstractToken
    {
        public OpenParenthesis(String Value) :base(Value) { }

        public OpenParenthesis(String Value, int Postion) : base(Value, Postion) { }
    }
}
