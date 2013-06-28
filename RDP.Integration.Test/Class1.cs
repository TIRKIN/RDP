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
