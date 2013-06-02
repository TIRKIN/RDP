using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class CloseParenthesis : AbstractToken
    {
        public CloseParenthesis(String Value) :base(Value) { }
    }
}
