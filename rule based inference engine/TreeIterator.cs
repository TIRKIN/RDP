using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticAnalyzer;

namespace rule_based_inference_engine
{
    public class TreeIterator
    {
        
        private void changeNode(SemanticAnalyzer.SyntaxTree.ASTNode OldNode, SemanticAnalyzer.SyntaxTree.ASTNode NewNode)
        {
            OldNode.Parent.LeftChild = NewNode;
            NewNode.Parent = OldNode.Parent;

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

        private SemanticAnalyzer.SyntaxTree.ASTNode combineChildren(SemanticAnalyzer.SyntaxTree.ASTNode parent)
        {
            String newString = parent.LeftChild.Value + parent.Value + parent.RightChild.Value;
            SemanticAnalyzer.SyntaxTree.Node.Variable newNode = new SemanticAnalyzer.SyntaxTree.Node.Variable(newString);
            return newNode;
        }
        
        
        private SemanticAnalyzer.SyntaxTree.ASTNode getBottomLeftParent(SemanticAnalyzer.SyntaxTree.ASTNode start) 
        { 
            while(!checkLeftChild(start))
            {
                start = start.LeftChild;
            }
            return start;
        }

        private SemanticAnalyzer.SyntaxTree.ASTNode getBottom(SemanticAnalyzer.SyntaxTree.ASTNode start)
        {
            SemanticAnalyzer.SyntaxTree.ASTNode newNode;
            while(!checkChildren(start)){
                newNode = getBottomLeftParent(start);
                if (checkRightChild(newNode))
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

        private Boolean checkLeftChild(SemanticAnalyzer.SyntaxTree.ASTNode parent)
        { 
            if(parent.LeftChild.LeftChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Number))
            {
                return true;
            }
            else if (parent.LeftChild.LeftChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Variable))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean checkRightChild(SemanticAnalyzer.SyntaxTree.ASTNode parent)
        {
            if (parent.RightChild.RightChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Number))
            {
                return true;
            }
            else if (parent.RightChild.RightChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Variable))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean checkChildren(SemanticAnalyzer.SyntaxTree.ASTNode parent)
        {
            if (parent.LeftChild.LeftChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Number))
            {
                if (parent.RightChild.RightChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Number))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (parent.LeftChild.LeftChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Variable))
            {
                if (parent.RightChild.RightChild.GetType() == typeof(SemanticAnalyzer.SyntaxTree.Node.Variable))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
