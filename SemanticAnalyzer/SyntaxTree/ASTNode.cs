namespace SemanticAnalyzer.SyntaxTree
{
    public abstract class ASTNode
    {
        private readonly string _value;

        protected ASTNode(string value)
        {
            _value = value;
        }

        public abstract ASTNode Eval();

        public ASTNode LeftChild { get; set; }
        public ASTNode RightChild { get; set; }

        public string Value
        {
            get { return _value; }
        }
    }
}