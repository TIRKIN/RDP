namespace SemanticAnalyzer.SyntaxTree.Node
{
    public class EqualSign : ASTNode
    {
        public EqualSign(string value) : base(value)
        {
        }

        public override ASTNode Eval()
        {
            throw new System.NotImplementedException();
        }
    }
}