using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class LeftParenthesesTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new LeftParenthesesTokenType();
        }

        [TestMethod]
        public void LeftParentheseMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("("));
        }
    }
}

