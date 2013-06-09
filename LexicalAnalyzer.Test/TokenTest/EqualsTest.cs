using System.Text.RegularExpressions;
using LexicalAnalyzer.Token;
using NUnit.Framework;

namespace LexicalAnalyzer.Test.TokenTest
{
    [TestFixture]
    class EqualsTest
    {
        private ExpressionDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new ExpressionDictionary();
        }

        [Test]
        public void SimpleTest()
        {
            Assert.AreEqual("=", Regex.Match("=", _dictionary[typeof(Equals)]).Value);    
        }
    }
}
