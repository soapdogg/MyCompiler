using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class DoubleTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new DoubleTokenType();
        }

        [TestMethod]
        public void DoubleMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("double"));
        }

        [TestMethod]
        public void DoubleBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("ddouble"));
        }

        [TestMethod]
        public void DoubleAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("doublewfvf"));
        }
    }
}

