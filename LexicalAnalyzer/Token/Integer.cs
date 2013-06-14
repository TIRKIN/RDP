using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class Integer : Number
    {
        public Integer(String Value) : base(Value) { }

        public Integer(String Value, int Postion) : base(Value, Postion) { }
    }
}
