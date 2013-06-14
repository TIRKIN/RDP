using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursive_descent_parser.ParseTree
{
    class ParseNode
    {
        protected List<ParseNode> children = new List<ParseNode>();
        protected ParseNode parent;
        protected String value;

        public ParseNode(String value) 
        {
            this.value = value;
        }

        public List<ParseNode> getChildren()
        {
            return children;
        }

        public void AddChild(ParseNode child)
        {
            children.Add(child);
        }

        public ParseNode GetParent()
        {
            return parent;
        }

        public void SetParent(ParseNode parent) 
        {
            this.parent = parent;
        }

        public String GetValue()
        {
            return value;
        }

        public String toString()
        {
            String res = "Parent: " + parent.GetValue();
            res += "\nChildren: ";
            this.getChildren().ForEach(x => res += x.GetValue() + ", ");
            return res;
        }
    }
}
