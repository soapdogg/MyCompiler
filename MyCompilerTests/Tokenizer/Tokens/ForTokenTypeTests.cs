using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class ForTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new ForTokenType();
        }

        [TestMethod]
        public void ForMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("for"));
        }

        [TestMethod]
        public void ForBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("wererefor"));
        }

        [TestMethod]
        public void ForAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("fordfjvh"));
        }
    }
}
