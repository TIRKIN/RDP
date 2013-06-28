namespace SemanticAnalyzer.SyntaxTree
{
    /// <summary>
    /// Abstract representation of an Abstract Syntax Tree node.
    /// </summary>
    public abstract class ASTNode
    {
        private readonly string _value;
        private ASTNode _leftChild;
        private ASTNode _rightChild;

        protected ASTNode(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Evaluates the value of the node.
        /// </summary>
        /// <returns></returns>
        public abstract ASTNode Eval();

        public override bool Equals(object obj)
        {
            if (obj != null && GetType() == obj.GetType())
            {
                return Value.Equals(((ASTNode) obj).Value);
            }

            return false;
        }

        /// <summary>
        /// Returns the hashcode of the object
        /// </summary>
        /// <returns>Hash</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// The parent of the current node.
        /// </summary>
        public ASTNode Parent { get; set; }
        
        /// <summary>
        /// Left child
        /// </summary>
        public ASTNode LeftChild
        {
            get { return _leftChild; }
            set
            {
                value.Parent = this;
                _leftChild = value;
            }
        }

        /// <summary>
        /// Right child.
        /// </summary>
        public ASTNode RightChild
        {
            get { return _rightChild; }
            set
            {
                value.Parent = this;
                _rightChild = value;
            }
        }

        /// <summary>
        /// Value of the AST node.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
}