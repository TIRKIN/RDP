using NUnit.Framework;
using RecursiveDescentParser.ParseTree;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;

namespace SemanticAnalyzer.Test
{
    [TestFixture]
    public class SemanticAnalyzerTest
    {
        private ParseNode _testTree;

        [SetUp]
        public void Init()
        {
            _testTree = new ParseNode(ParseEnum.Start);
            _testTree.AddChild(new ParseNode(ParseEnum.Expression));
            _testTree.GetChildren()[0].AddChild(new ParseNode(ParseEnum.Term));
            _testTree.GetChildren()[0].AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            ParseNode node = _testTree.GetChildren()[0].GetChildren()[0];
            node.AddChild(new ParseNode(ParseEnum.Factor));
            node.AddChild(new ParseNode(ParseEnum.TermAccent));
            node.GetChildren()[0].AddChild(new ParseNode(ParseEnum.Number, "3"));
            node.GetChildren()[1].AddChild(new ParseNode(ParseEnum.Empty));

            node = _testTree.GetChildren()[0].GetChildren()[1];
            node.AddChild(new ParseNode(ParseEnum.Operator, "+"));
            node.AddChild(new ParseNode(ParseEnum.Term));
            node.AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            ParseNode termNode = node.GetChildren()[1];
            
            termNode.AddChild(new ParseNode(ParseEnum.Factor));
            termNode.AddChild(new ParseNode(ParseEnum.TermAccent));
            termNode.GetChildren()[0].AddChild(new ParseNode(ParseEnum.Number, "4"));
            termNode.GetChildren()[1].AddChild(new ParseNode(ParseEnum.Empty));

            node.GetChildren()[2].AddChild(new ParseNode(ParseEnum.Empty));
        }

        [Test]
        public void TestQueueGeneration()
        {
            SemanticAnalyzer analyzer = new SemanticAnalyzer();
            var elements = analyzer.GetBreadthFirstQueue(_testTree);

            Assert.AreEqual(16, elements.Count);
            Assert.IsTrue(elements[0].GetEnum() == ParseEnum.Start);
        }

        [Test]
        public void TestASTGeneration()
        {
            SemanticAnalyzer analyzer = new SemanticAnalyzer();
            ASTNode start = analyzer.GenerateAST(_testTree);

            Assert.IsTrue(start.GetType() == typeof (Operator));
        }
    }
}
