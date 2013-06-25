using NUnit.Framework;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;
using recursive_descent_parser;
using recursive_descent_parser.ParseTree;
using SemanticAnalyzer;


namespace RDP.Integration.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        public void SimpleExpressionTest()
        {
            string test = "3+4";
            
            Parser parser = new Parser(test);
            ParseNode parseTree = parser.parse();

            var analyzer = new SemanticAnalyzer.SemanticAnalyzer();
            ASTNode AST = analyzer.GenerateAST(parseTree);

            
        }
    }
}
