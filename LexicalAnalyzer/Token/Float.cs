using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class Float : Number
    {
        public Float(String Value) : base(Value) { } 

        public Float(String Value, int Postion) : base(Value, Postion) { }
    }
}
