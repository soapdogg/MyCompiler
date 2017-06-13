using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BitNegationOperatorTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BitNegationOperatorTokenType();
        }

        [TestMethod]
        public void UnaryNegationMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("~"));
        }
    }
}

