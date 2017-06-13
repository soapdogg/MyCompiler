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

        [TestMethod]
        public void IntBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("565int"));
        }

        [TestMethod]
        public void IntAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("int34cdf"));
        }
    }
}

