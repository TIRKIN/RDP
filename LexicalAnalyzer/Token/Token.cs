using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class AbstractToken
    {

        protected string _value;

        public String GetValue()
        {
            return _value;
        }
    }
}
