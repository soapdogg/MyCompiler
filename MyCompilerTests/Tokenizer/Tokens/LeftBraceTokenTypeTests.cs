using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class LeftBraceTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new LeftBraceTokenType();
        }

        [TestMethod]
        public void LeftBraceMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("{"));
        }
    }
}

