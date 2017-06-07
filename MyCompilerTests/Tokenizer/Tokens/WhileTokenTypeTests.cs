using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class WhileTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new WhileTokenType();
        }

        [TestMethod]
        public void WhileMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("while"));
        }
    }
}
