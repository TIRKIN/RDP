using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class AddSub : AbstractToken
    {
        public AddSub(String Value) : base(Value) {}

        public AddSub(String Value, int Postion) : base(Value, Postion) { }
    }
}
