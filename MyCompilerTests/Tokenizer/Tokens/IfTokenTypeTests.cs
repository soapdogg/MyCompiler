using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class IfTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new IfTokenType();
        }

        [TestMethod]
        public void IfMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("if"));
        }

        [TestMethod]
        public void IfBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("gheif"));
        }

        [TestMethod]
        public void IfAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("ifdf"));
        }
    }
}
