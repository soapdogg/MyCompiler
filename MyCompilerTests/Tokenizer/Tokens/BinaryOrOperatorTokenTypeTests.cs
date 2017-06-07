using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BinaryOrOperatorTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BinaryOrOperatorTokenType();
        }

        [TestMethod]
        public void AndMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("||"));
        }
    }
}