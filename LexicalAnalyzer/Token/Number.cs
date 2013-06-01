using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class Number : AbstractToken
    {
        public Number(string Value)
        {
            this._value = Value;
        }
    }
}
