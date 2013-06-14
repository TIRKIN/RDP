using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursive_descent_parser.ParseTree
{
    public enum ParseEnum 
    {
        Start,
        Expression, 
        ExpressionAccent,
        Term,
        TermAccent,
        Factor,
        Operator,
        Number,
        OpenParenthesis,
        CloseParenthesis,
        Equals,
        Variable,
        Empty
    }
}
