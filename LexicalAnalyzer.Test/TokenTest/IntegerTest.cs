using System.Text.RegularExpressions;
using LexicalAnalyzer.Token;
using NUnit.Framework;

namespace LexicalAnalyzer.Test.TokenTest
{
    [TestFixture]
    class IntegerTest
    {
        private ExpressionDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new ExpressionDictionary();
        }

        [Test]
        public void TestOneDigit()
        {
            Assert.IsTrue(Regex.Match("1", _dictionary[typeof(Integer)]).Success, "Should match number: 1");
            Assert.IsTrue(Regex.Match("2", _dictionary[typeof(Integer)]).Success, "Should match number: 2");
            Assert.IsTrue(Regex.Match("3", _dictionary[typeof(Integer)]).Success, "Should match number: 3");
            Assert.IsTrue(Regex.Match("4", _dictionary[typeof(Integer)]).Success, "Should match number: 4");
            Assert.IsTrue(Regex.Match("5", _dictionary[typeof(Integer)]).Success, "Should match number: 5");
            Assert.IsTrue(Regex.Match("6", _dictionary[typeof(Integer)]).Success, "Should match number: 6");
            Assert.IsTrue(Regex.Match("7", _dictionary[typeof(Integer)]).Success, "Should match number: 7");
            Assert.IsTrue(Regex.Match("8", _dictionary[typeof(Integer)]).Success, "Should match number: 8");
            Assert.IsTrue(Regex.Match("9", _dictionary[typeof(Integer)]).Success, "Should match number: 9");
            Assert.IsTrue(Regex.Match("0", _dictionary[typeof(Integer)]).Success, "Should match number: 0");
        }

        [Test]
        public void TestOneDigitSpace()
        {
            Assert.IsTrue(Regex.Match(" 1", _dictionary[typeof(Integer)]).Success, "Should match number: 1");
        }

        [Test]
        public void MultipleDigits()
        {
            Assert.IsTrue(Regex.Match("11", _dictionary[typeof (Integer)]).Success);
            Assert.IsTrue(Regex.Match("1234567890", _dictionary[typeof(Integer)]).Success);
        }

        [Test]
        public void TestScientific()
        {
            Assert.IsFalse(Regex.Match("1e-1", _dictionary[typeof(Integer)]).Success, "Should NOT match: 1e-1");
        }

        [Test]
        public void TestNegative()
        {
            Assert.IsFalse(Regex.Match("-1", _dictionary[typeof(Integer)]).Success, "Should NOT match number: -1");    
        }

        [Test]
        public void TestFloat()
        {
            Assert.IsFalse(Regex.Match("1.0", _dictionary[typeof(Integer)]).Success, "Should NOT match number: 1.0");    
        }

        [Test]
        public void TestString()
        {
            Assert.AreEqual("100", Regex.Match("100*2", _dictionary[typeof(Integer)]).Value);
            Assert.AreEqual("100", Regex.Match("100 * 2", _dictionary[typeof(Integer)]).Value);    
        }     
   }
}
