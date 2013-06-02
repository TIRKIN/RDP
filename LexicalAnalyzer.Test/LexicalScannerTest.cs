using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
