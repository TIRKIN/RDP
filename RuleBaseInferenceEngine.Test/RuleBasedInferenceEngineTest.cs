using NUnit.Framework;
using SemanticAnalyzer.SyntaxTree.Node;
using rule_based_inference_engine;

namespace RuleBaseInferenceEngine.Test
{
    [TestFixture]
    public class RuleBasedInferenceEngineTest
    {
        [Test]
        public void Test()
        {
            var node1 = new Operator("+");
            var node2 = new Operator("*");
            var node3 = new Operator("-");
            var node4 = new Number("1");
            var node5 = new Number("2");
            var node6 = new Number("3");
            var node7 = new Variable("X");
            var node8 = new Operator("*");
            var node9 = new Operator("/");
            var node10 = new Number("4");
            var node11 = new Number("5");
            var node12 = new Number("6");

            node1.LeftChild = node2;
            node2.Parent = node1;

            node1.RightChild = node3;
            node3.Parent = node1;

            node2.LeftChild = node6;
            node6.Parent = node2;

            node2.RightChild = node5;
            node5.Parent = node2;

            node3.LeftChild = node9;
            node9.Parent = node3;

            node3.RightChild = node10;
            node10.Parent = node3;

            node9.LeftChild = node11;
            node11.Parent = node9;

            node9.RightChild = node12;
            node12.Parent = node9;

            TreeIterator engine = new TreeIterator(node1);
        }
    }
}
