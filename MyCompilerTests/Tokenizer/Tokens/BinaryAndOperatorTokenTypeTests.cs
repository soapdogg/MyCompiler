using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BinaryAndOperatorTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BinaryAndOperatorTokenType();
        }

        [TestMethod]
        public void AndMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("&&"));
        }
    }
}

