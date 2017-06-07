using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class FloatTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new FloatTokenType();
        }

        [TestMethod]
        public void FloatMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("float"));
        }
    }
}


