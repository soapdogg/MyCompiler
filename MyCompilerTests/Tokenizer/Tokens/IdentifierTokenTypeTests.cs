using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class IdentifierTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new IdentifierTokenType();
        }

        [TestMethod]
        public void IdentifierMatchesTest1()
        {
            Assert.IsTrue(t.Pattern.IsMatch("a"));
        }

        [TestMethod]
        public void IdentifierMatchesTest2()
        {
            Assert.IsTrue(t.Pattern.IsMatch("_"));
        }

        [TestMethod]
        public void IdentifierMatchesTest3()
        {
            Assert.IsTrue(t.Pattern.IsMatch("__AppleBees"));
        }
    }
}


