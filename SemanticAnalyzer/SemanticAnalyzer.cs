using System.Collections.Generic;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;
using recursive_descent_parser;
using recursive_descent_parser.ParseTree;

namespace SemanticAnalyzer
{
    public class SemanticAnalyzer
    {

        public SemanticAnalyzer()
        {
                  
        }

        /// <summary>
        /// Generates a abstract syntrax tree from the given ParseTree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public ASTNode GenerateAST(ParseNode node)
        {
            Queue<ParseNode> allNodes = new Queue<ParseNode>();
            Queue<ParseNode> tempQueue= new Queue<ParseNode>();

            if (node != null)
            {
                tempQueue.Enqueue(node);
                allNodes.Enqueue(node);

                while (tempQueue.Count != 0)
                {
                    ParseNode tempNode = tempQueue.Dequeue();

                    tempNode.getChildren().ForEach(x => tempQueue.Enqueue(x));
                }
            }

            return null;
        }
    }
}