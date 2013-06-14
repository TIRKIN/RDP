using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LexicalAnalyzer.Token;
using NUnit.Framework;

namespace LexicalAnalyzer.Test.TokenTest
{
    [TestFixture]
    class OperatorTest
    {
        private ExpressionDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new ExpressionDictionary();
        }

        [Test]
        public void MultiplicationOperator()
        {
            Match match = Regex.Match("*", _dictionary[typeof(Operator)]);
            Assert.AreEqual("*", match.Value);
        }

        [Test]
        public void DivisionOperator()
        {
            Match match = Regex.Match("\\2", _dictionary[typeof(Operator)]);
            Assert.AreEqual("\\", match.Value);
        }
    }
}
