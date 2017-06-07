using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class LongTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new LongTokenType();
        }

        [TestMethod]
        public void LongMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("long"));
        }
    }
}

