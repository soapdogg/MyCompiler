using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class UnaryOperatorTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new UnaryOperatorTokenType();
        }

        [TestMethod]
        public void UnaryPositiveMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("+"));
        }

        [TestMethod]
        public void UnaryNegativeMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("-"));
        }

        [TestMethod]
        public void UnaryNegationMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("~"));
        }
    }
}

