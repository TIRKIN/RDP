namespace SemanticAnalyzer.SyntaxTree
{
    public abstract class ASTNode
    {
        private readonly string _value;
        private ASTNode _leftChild;
        private ASTNode _rightChild;

        protected ASTNode(string value)
        {
            _value = value;
        }

        public abstract ASTNode Eval();

        public ASTNode Parent { get; set; }
        
        public ASTNode LeftChild
        {
            get { return _leftChild; }
            set
            {
                value.Parent = this;
                _leftChild = value;
            }
        }

        public ASTNode RightChild
        {
            get { return _rightChild; }
            set
            {
                value.Parent = this;
                _rightChild = value;
            }
        }

        public string Value
        {
            get { return _value; }
        }
    }
}