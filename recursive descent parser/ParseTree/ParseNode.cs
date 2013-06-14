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
        protected ParseEnum e;

        public ParseNode(ParseEnum e)       
        {
            this.e = e;
        }

        public ParseNode(ParseEnum e, String value) 
        {
            this.e = e;
            this.value = value;
        }

        public List<ParseNode> getChildren()
        {
            return children;
        }

        public void AddChild(ParseNode child)
        {
            child.SetParent(this);
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
            this.getChildren().ForEach(x => res += ":" + x.GetValue() + ":");
            return res;
        }

        public String printChildren() 
        {
            String res = "\n";
            this.getChildren().ForEach(x => res += ":" + x.GetValue() + ":");
            return res;
        }

        public String printTree()
        {
            String res = e.ToString();
            foreach (ParseNode x in this.getChildren())
            {
                res += x.printTree();
            }                     
            return res;
        }
    }
}
