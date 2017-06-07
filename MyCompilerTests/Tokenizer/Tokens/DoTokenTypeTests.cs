using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class DoTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new DoTokenType();
        }

        [TestMethod]
        public void DoMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("do"));
        }
    }
}

