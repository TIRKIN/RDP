using System;
using NUnit.Framework;

namespace Parser.Test
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void test()
        {
            String input = "(3+4)";
            RecursiveDescentParser.Parser p = new RecursiveDescentParser.Parser(input);
            p.Parse();
        }
    }
}
