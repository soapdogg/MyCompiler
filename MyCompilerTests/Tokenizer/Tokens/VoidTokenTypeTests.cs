using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class VoidTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new VoidTokenType();
        }

        [TestMethod]
        public void VoidMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("void"));
        }
    }
}
