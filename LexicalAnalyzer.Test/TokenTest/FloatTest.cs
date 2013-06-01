using System.Text.RegularExpressions;
using LexicalAnalyzer.Token;
using NUnit.Framework;

namespace LexicalAnalyzer.Test.TokenTest
{
    [TestFixture]
    class FloatTest
    {
        private ExpressionDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new ExpressionDictionary();
        }

        [Test]
        public void SingleDigit()
        {
            Assert.IsTrue(Regex.Match("1.0", _dictionary[typeof(Float)]).Success, "Should match number: 1");
        }

        [Test]
        public void MultipleDigit()
        {
            Assert.IsTrue(Regex.Match("1213.131230", _dictionary[typeof(Float)]).Success, "Should match number: 1");
        }

        [Test]
        public void ScientificNotation()
        {
            Assert.IsTrue(Regex.Match("1.0e1", _dictionary[typeof(Float)]).Success, "Should match number: 1");
            Assert.IsTrue(Regex.Match("1.0e-1", _dictionary[typeof(Float)]).Success, "Should match number: 1");
        }

        [Test]
        public void StartingDot()
        {
            Assert.IsTrue(Regex.Match(".1", _dictionary[typeof(Float)]).Success, "Should match number: 1");
        }

        [Test]
        public void NoIntegers()
        {
            Assert.IsFalse(Regex.Match("1", _dictionary[typeof(Float)]).Success, "Should NOT match number: 1");
        }

        [Test]
        public void MatchOnlyFloat()
        {
            Assert.AreEqual("1.1", Regex.Match("1.1*2", _dictionary[typeof(Float)]).Value);
        }

        [Test]
        public void MatchOnlyFloatScientific()
        {
            Assert.AreEqual("1.1e-2", Regex.Match("1.1e-2 *2", _dictionary[typeof(Float)]).Value);
        }
    }
}
