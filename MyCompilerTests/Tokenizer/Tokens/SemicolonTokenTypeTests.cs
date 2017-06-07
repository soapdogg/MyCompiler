using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class SemicolonTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new SemicolonTokenType();
        }

        [TestMethod]
        public void SemicolonMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(";"));
        }
    }
}
