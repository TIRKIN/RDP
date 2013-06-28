using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticAnalyzer.SyntaxTree.Node
{
    public class Operator : ASTNode
    {
        private string p;

        public Operator(string value) : base(value)
        {
        }

        public override ASTNode Eval()
        {
            throw new NotImplementedException();
        }
    }
}
