﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Token
{
    public class Operator : AbstractToken
    {
        public Operator(String Value) :base(Value) { }

        public Operator(String Value, int Postion) : base(Value, Postion) { }
    }
}
