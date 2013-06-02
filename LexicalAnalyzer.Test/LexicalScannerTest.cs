using System.Collections.Generic;
using LexicalAnalyzer.Token;
using NUnit.Framework;

namespace LexicalAnalyzer.Test
{
    [TestFixture]
    class LexicalScannerTest
    {
        [Test]
        public void TestInt()
        {
            LexicalScanner scanner = new LexicalScanner("1");

            AbstractToken token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("1"));
        }

        [Test]
        public void TestFloat()
        {
            LexicalScanner scanner = new LexicalScanner("1.0");

            AbstractToken token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Float), token);
            Assert.IsTrue(token.GetValue().Equals("1.0"));
        }

        [Test]
        public void TestSimpleOperatorExpression()
        {
            LexicalScanner scanner = new LexicalScanner("1*2");

            AbstractToken token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("1"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Operator), token);
            Assert.IsTrue(token.GetValue().Equals("*"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("2"));
        }

        [Test]
        public void TestSimpleAddSubExpression()
        {
            LexicalScanner scanner = new LexicalScanner("1+2");

            AbstractToken token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("1"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(AddSub), token);
            Assert.IsTrue(token.GetValue().Equals("+"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("2"));
        }

        [Test]
        public void TestGetAllTokens()
        {
            LexicalScanner scanner = new LexicalScanner("1+2");

            List<AbstractToken> tokens = scanner.GetAllTokens() as List<AbstractToken>;

            Assert.AreEqual(3, tokens.Count);
        }

        [Test]
        public void TestSimpleParenthesisExpression()
        {
            LexicalScanner scanner = new LexicalScanner("(1*2)");

            AbstractToken token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(OpenParenthesis), token);
            Assert.IsTrue(token.GetValue().Equals("("));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("1"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Operator), token);
            Assert.IsTrue(token.GetValue().Equals("*"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(Integer), token);
            Assert.IsTrue(token.GetValue().Equals("2"));

            token = scanner.GetNextToken();

            Assert.IsInstanceOf(typeof(CloseParenthesis), token);
            Assert.IsTrue(token.GetValue().Equals(")"));
        }

        [Test]
        public void TestPolynomialExpression()
        {
            LexicalScanner scanner = new LexicalScanner("a^2+b*x+c");

            List<AbstractToken> tokens = scanner.GetAllTokens() as List<AbstractToken>;

            Assert.AreEqual(9, tokens.Count);
        }


        [Test]
        public void TestPolynomialMixedExpression()
        {
            LexicalScanner scanner = new LexicalScanner("4.2^2+4*x+22.8");

            List<AbstractToken> tokens = scanner.GetAllTokens() as List<AbstractToken>;

            Assert.AreEqual(9, tokens.Count);
        }

        [Test]
        public void TestPolynomialMixedSpacesExpression()
        {
            LexicalScanner scanner = new LexicalScanner("4.2 ^2 + 4*x +22.8");

            List<AbstractToken> tokens = scanner.GetAllTokens() as List<AbstractToken>;

            Assert.AreEqual(9, tokens.Count);
        }
    }
}
