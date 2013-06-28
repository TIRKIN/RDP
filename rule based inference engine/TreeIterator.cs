using System;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;

namespace rule_based_inference_engine
{
    public class TreeIterator
    {

        public TreeIterator(ASTNode parent)
        {
            while (!CheckChildren(parent))
            {
                ASTNode bottom = GetBottom(parent);
                Variable combination = CombineChildren(bottom);
                ChangeNode(bottom, combination);
            }
            ASTNode finalNode = CombineChildren(parent);
            Console.Write(finalNode.Value);
        }

        private void ChangeNode(ASTNode oldNode, ASTNode newNode)
        {
            if (oldNode.Parent.LeftChild.Value == oldNode.Value)
            {
                oldNode.Parent.LeftChild = newNode;
            }
            else
            {
                oldNode.Parent.RightChild = newNode;
            }
            newNode.Parent = oldNode.Parent;
        }

        /*private SemanticAnalyzer.SyntaxTree.ASTNode Operate(SemanticAnalyzer.SyntaxTree.ASTNode operateNode)
        {
            String Operator = operateNode.Value;
            float newValue;
            double doubleValue;
            String Value;
            switch (Operator) 
            { 
                case "*":
                    newValue = Single.Parse(operateNode.LeftChild.Value) * Single.Parse(operateNode.RightChild.Value);
                case "+":
                    newValue = Single.Parse(operateNode.LeftChild.Value) + Single.Parse(operateNode.RightChild.Value);
                case "-":
                    newValue = Single.Parse(operateNode.LeftChild.Value) - Single.Parse(operateNode.RightChild.Value);
                case "^":
                    doubleValue = Math.Pow(Single.Parse(operateNode.LeftChild.Value), Single.Parse(operateNode.RightChild.Value));
            }
            if(newValue != null)
            {
                Value = newValue.ToString();
            }
            else if (doubleValue != null)
            {
                Value = doubleValue.ToString();
            }
            else 
            {
                Value = "";
            }
            SemanticAnalyzer.SyntaxTree.Node.Number newNode = new SemanticAnalyzer.SyntaxTree.Node.Number(Value);
            changeNode(operateNode, newNode);
            return newNode;
        }*/

        private Variable CombineChildren(ASTNode parent)
        {
            String newString = parent.LeftChild.Value + parent.Value + parent.RightChild.Value;
            var newNode = new Variable(newString);
            return newNode;
        }


        private ASTNode GetBottomLeftParent(ASTNode start)
        {
            while (!CheckLeftChild(start))
            {
                start = start.LeftChild;
            }
            return start;
        }

        private ASTNode GetBottom(ASTNode start)
        {
            while (!CheckChildren(start))
            {
                ASTNode newNode = GetBottomLeftParent(start);
                if (CheckRightChild(newNode))
                {
                    start = newNode;
                }
                else
                {
                    start = newNode.RightChild;
                }
            }
            return start;
        }

        private Boolean CheckLeftChild(ASTNode parent)
        {
            if (parent.LeftChild.GetType() == typeof (Number))
            {
                return true;
            }
            if (parent.LeftChild.GetType() == typeof (Variable))
            {
                return true;
            }
            return false;
        }

        private static Boolean CheckRightChild(ASTNode parent)
        {
            if (parent.RightChild.GetType() == typeof (Number))
            {
                return true;
            }
            if (parent.RightChild.GetType() == typeof (Variable))
            {
                return true;
            }
            return false;
        }

        private Boolean CheckChildren(ASTNode parent)
        {
            if (parent.LeftChild.GetType() == typeof (Number))
            {
                if (CheckRightChild(parent))
                {
                    return true;
                }
                return false;
            }
            if (parent.LeftChild.GetType() == typeof (Variable))
            {
                if (CheckRightChild(parent))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
