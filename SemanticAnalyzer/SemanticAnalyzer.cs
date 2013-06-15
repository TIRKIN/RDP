using System.Collections;
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
            Queue<ParseNode> bfQueue = GetBreadthFirstQueue(node);



            return null;
        }

        /// <summary>
        /// Generates a Queue by walking breadth first through the tree.
        /// </summary>
        /// <param name="node">Starting node</param>
        /// <returns>Queue in breadth first order</returns>
        public Queue<ParseNode> GetBreadthFirstQueue(ParseNode node)
        {
            Queue<ParseNode> brQueue = new Queue<ParseNode>();
            Queue<ParseNode> queue = new Queue<ParseNode>();

            queue.Enqueue(node);
            brQueue.Enqueue(node);

            while (queue.Count > 0)
            {
                ParseNode tempNode = queue.Dequeue();

               foreach (ParseNode parseNode in tempNode.getChildren())
                {
                    queue.Enqueue(parseNode);
                    brQueue.Enqueue(parseNode);
                }

            }

            return brQueue;
        }
    }
}