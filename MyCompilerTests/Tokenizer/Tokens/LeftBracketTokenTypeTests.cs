using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class LeftBracketTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new LeftBracketTokenType();
        }

        [TestMethod]
        public void LeftBracketMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("["));
        }
    }
}

