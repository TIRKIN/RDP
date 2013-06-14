namespace SemanticAnalyzer.SyntaxTree.Node
{
    public class Number : ASTNode
    {
        public Number(string value) : base(value)
        {
        }

        public override ASTNode Eval()
        {
            throw new System.NotImplementedException();
        }
    }
}