namespace SemanticAnalyzer.SyntaxTree.Node
{
    public class Variable:ASTNode
    {
         public Variable(string value) : base(value)
        {
        }

        public override ASTNode Eval()
        {
            throw new System.NotImplementedException();
        }
    }
}