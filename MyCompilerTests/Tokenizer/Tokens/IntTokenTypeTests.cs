using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class IntTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new IntTokenType();
        }

        [TestMethod]
        public void IntMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("int"));
        }
    }
}

