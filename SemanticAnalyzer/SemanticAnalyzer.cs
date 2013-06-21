using System;
using System.Collections.Generic;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;
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
        /// <param name="node">Start node</param>
        /// <returns>Abstract syntax tree </returns>
        public ASTNode GenerateAST(ParseNode node)
        {
            ASTNode root;
            // Skip start node
            if (node.GetEnum() == ParseEnum.Start)
            {
                node = node.getChildren()[0];
            }

            List<ParseNode> bfQueue = GetBreadthFirstQueue(node).FindAll(x => x.GetEnum() == ParseEnum.Operator || x.GetEnum() == ParseEnum.Number 
                || x.GetEnum() == ParseEnum.Variable || x.GetEnum() == ParseEnum.Equals);

            if (bfQueue.Count == 1)
            {
                root = ConvertPNtoASTNode(bfQueue[0]);
            }
            else
            {
                ParseNode tree = node.getChildren().Find(x => ContainsNode(x, bfQueue[0]));

                root = ConvertPNtoASTNode(bfQueue[0]);

                if (node.getChildren()[0].Equals(tree))
                {
                    tree.getChildren().Remove(bfQueue[0]);
                    root.LeftChild = GenerateAST(tree);
                    root.RightChild = GenerateAST(node.getChildren()[1]);
                }
                else
                {
                    tree.getChildren().Remove(bfQueue[0]);
                    root.RightChild = GenerateAST(tree);
                    root.LeftChild = GenerateAST(node.getChildren()[0]);
                }
            }

            return root;
        }

        private ASTNode ConvertPNtoASTNode(ParseNode parseNode)
        {
            ASTNode ret;

            switch (parseNode.GetEnum())
            {
                case ParseEnum.Number:
                    ret = new Number(parseNode.GetValue());
                    break;
                case ParseEnum.Operator:
                    ret = new Operator(parseNode.GetValue());
                    break;
                case ParseEnum.Variable:
                    ret = new Variable(parseNode.GetValue());
                    break;
                case ParseEnum.Equals:
                    ret = new EqualSign(parseNode.GetValue());
                    break;
                default:
                    throw new Exception("Could not convert Parsenode");
            }

            return ret;
        }

        /// <summary>
        /// Generates a Queue by walking breadth first through the tree.
        /// </summary>
        /// <param name="node">Starting node</param>
        /// <returns>Queue in breadth first order</returns>
        public List<ParseNode> GetBreadthFirstQueue(ParseNode node)
        {
            List<ParseNode> brQueue = new List<ParseNode>();
            Queue<ParseNode> queue = new Queue<ParseNode>();

            queue.Enqueue(node);
            brQueue.Add(node);

            while (queue.Count > 0)
            {
                ParseNode tempNode = queue.Dequeue();

               foreach (ParseNode parseNode in tempNode.getChildren())
                {
                    queue.Enqueue(parseNode);
                    brQueue.Add(parseNode);
                }

            }

            return brQueue;
        }

        private bool ContainsNode(ParseNode startNode, ParseNode nodeToFind)
        {
            if (startNode.Equals(nodeToFind))
            {
                return true;
            }

            return startNode.getChildren().Exists(x => ContainsNode(x, nodeToFind));
        }


    }
}