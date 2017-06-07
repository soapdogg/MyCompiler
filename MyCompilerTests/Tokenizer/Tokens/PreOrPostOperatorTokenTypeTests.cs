using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class PreOrPostOperatorTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new PreOrPostOperatorTokenType();
        }

        [TestMethod]
        public void PlusPlusMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("++"));
        }

        [TestMethod]
        public void MinusMinusMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("--"));
        }
    }
}

