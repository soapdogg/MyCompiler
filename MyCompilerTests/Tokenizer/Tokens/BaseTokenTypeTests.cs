using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BaseTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new InvalidTokenType();
        }

        [TestMethod]
        public void MatchSuccessTest()
        {
            TokenMatch tm = t.Match("tokenMatch123");
            Assert.IsTrue(tm.IsMatch);
            Assert.IsTrue(tm.RemainingText.Equals(string.Empty));
            Assert.IsInstanceOfType(tm.TokenType, typeof(InvalidTokenType));
            Assert.AreEqual("tokenMatch123", tm.Value);
        }

        [TestMethod]
        public void MatchSuccessHasRemainderTest()
        {
            t = new DoubleTokenType();
            TokenMatch tm = t.Match("double x = 30.0");
            Assert.IsTrue(tm.IsMatch);
            Assert.AreEqual(tm.RemainingText, " x = 30.0");
            Assert.IsInstanceOfType(tm.TokenType, typeof(DoubleTokenType));
            Assert.AreEqual("double", tm.Value);
        }

        [TestMethod]
        public void MatchUnsuccessfulTest()
        {
            t = new VoidTokenType();
            TokenMatch tm = t.Match("int");
            Assert.IsFalse(tm.IsMatch);
        }
    }
}


