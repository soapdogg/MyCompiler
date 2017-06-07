using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class RightBraceTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new RightBraceTokenType();
        }

        [TestMethod]
        public void RightBraceMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("}"));
        }
    }
}

