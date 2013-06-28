using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SemanticAnalyzer.SyntaxTree;

namespace GUI
{
    class DrawingNode:ASTNode
    {
        private ASTNode _rightChild1;

        public DrawingNode(string value) : base(value)
        {
        }

        public new string Value { get; set; }

        public Point Location { get; set; }

        public int Identifier { get; set; }

        public new ASTNode LeftChild { get; set; }

        public new ASTNode RightChild { get; set; }

        public override ASTNode Eval()
        {
            return null;
        }

        public new ASTNode Parent { get; set; }
    }
}
