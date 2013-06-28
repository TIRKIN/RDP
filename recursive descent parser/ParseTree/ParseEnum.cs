namespace RecursiveDescentParser.ParseTree
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
