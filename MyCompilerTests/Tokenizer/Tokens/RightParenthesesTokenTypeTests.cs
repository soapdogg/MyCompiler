using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class RightParenthesesTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new RightParenthesesTokenType();
        }

        [TestMethod]
        public void RightParentheseMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(")"));
        }
    }
}

