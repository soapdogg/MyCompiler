using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class UnaryNotOperatorTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new UnaryNotOperatorTokenType();
        }

        [TestMethod]
        public void UnaryNotOperatorMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("!"));
        }
    }
}
