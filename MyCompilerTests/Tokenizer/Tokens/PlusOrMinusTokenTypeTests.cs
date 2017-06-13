using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class PlusOrMinusTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new PlusOrMinusTokenType();
        }

        [TestMethod]
        public void MinusMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("-"));
        }

        [TestMethod]
        public void PlusMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("+"));
        }
    }
}
