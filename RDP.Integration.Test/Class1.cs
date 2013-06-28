using NUnit.Framework;
using RecursiveDescentParser;
using RecursiveDescentParser.ParseTree;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;
using SemanticAnalyzer;


namespace RDP.Integration.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        private ParseNode _testTree;

        [SetUp]
        public void Setup()
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
        public void SimpleExpressionTest()
        {
            string test = "(3+4)*6+1";
            
            Parser parsers = new Parser(test);
            ParseNode parseTree = parsers.Parse();

            var analyzer = new SemanticAnalyzer.SemanticAnalyzer();
            ASTNode AST = analyzer.GenerateAST(parseTree);

            
        }
    }
}
