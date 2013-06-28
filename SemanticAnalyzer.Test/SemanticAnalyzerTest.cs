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
            _testTree.getChildren()[0].AddChild(new ParseNode(ParseEnum.Term));
            _testTree.getChildren()[0].AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            ParseNode node = _testTree.getChildren()[0].getChildren()[0];
            node.AddChild(new ParseNode(ParseEnum.Factor));
            node.AddChild(new ParseNode(ParseEnum.TermAccent));
            node.getChildren()[0].AddChild(new ParseNode(ParseEnum.Number, "3"));
            node.getChildren()[1].AddChild(new ParseNode(ParseEnum.Empty));

            node = _testTree.getChildren()[0].getChildren()[1];
            node.AddChild(new ParseNode(ParseEnum.Operator, "+"));
            node.AddChild(new ParseNode(ParseEnum.Term));
            node.AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            ParseNode termNode = node.getChildren()[1];
            
            termNode.AddChild(new ParseNode(ParseEnum.Factor));
            termNode.AddChild(new ParseNode(ParseEnum.TermAccent));
            termNode.getChildren()[0].AddChild(new ParseNode(ParseEnum.Number, "4"));
            termNode.getChildren()[1].AddChild(new ParseNode(ParseEnum.Empty));

            node.getChildren()[2].AddChild(new ParseNode(ParseEnum.Empty));
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
