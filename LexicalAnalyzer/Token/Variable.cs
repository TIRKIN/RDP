using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class Variable : AbstractToken
    {
        public Variable(String Value) :base(Value) { }

        public Variable(String Value, int Postion) : base(Value, Postion) { }
    }
}
