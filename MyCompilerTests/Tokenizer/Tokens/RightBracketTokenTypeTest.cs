using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class RightBracketTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new RightBracketTokenType();
        }

        [TestMethod]
        public void RightBracketMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("]"));
        }
    }
}

