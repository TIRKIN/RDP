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
    class AddSubTest
    {

        private ExpressionDictionary _dictionary;

        [SetUp]
        public void Setup()
        {
            _dictionary = new ExpressionDictionary();
        }

        [Test]
        public void OneCharOnly()
        {
            Assert.AreEqual("+", Regex.Match("+", _dictionary[typeof(AddSub)]).Value);
            Assert.AreEqual("-", Regex.Match("-", _dictionary[typeof(AddSub)]).Value);
        }

        [Test]
        public void MultipleChars()
        {
            Assert.AreEqual("+", Regex.Match("+2", _dictionary[typeof(AddSub)]).Value);    
        }
    }
}
