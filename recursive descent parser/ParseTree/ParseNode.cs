using System;
using System.Collections.Generic;

namespace RecursiveDescentParser.ParseTree
{
    public class ParseNode
    {
        protected List<ParseNode> Children = new List<ParseNode>();
        protected ParseEnum E;
        protected ParseNode Parent;
        protected String Value;

        public ParseNode(ParseEnum e)
        {
            this.E = e;
        }

        public ParseNode(ParseEnum e, String value)
        {
            this.E = e;
            this.Value = value;
        }

        public List<ParseNode> GetChildren()
        {
            return Children;
        }

        public void AddChild(ParseNode child)
        {
            child.SetParent(this);
            Children.Add(child);
        }

        public ParseNode GetParent()
        {
            return Parent;
        }

        public void SetParent(ParseNode parent)
        {
            this.Parent = parent;
        }

        public String GetValue()
        {
            return Value;
        }

        public ParseEnum GetEnum()
        {
            return E;
        }

        public String PrintChildren()
        {
            String res = "\n";
            GetChildren().ForEach(x => res += ":" + x.GetEnum() + ":");
            return res;
        }

        public void PrintTree()
        {
            foreach (ParseNode x in GetChildren())
            {
                Console.WriteLine(x.PrintChildren());
                x.PrintTree();
            }
        }
    }
}