namespace SemanticAnalyzer.SyntaxTree
{
    public abstract class ASTNode
    {
        public abstract ASTNode Eval();

        public ASTNode LeftChild { get; set; }
        public ASTNode RightChild { get; set; }
    }
}