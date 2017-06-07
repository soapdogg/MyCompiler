using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class FloatingPointConstantTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new FloatingPointConstantTokenType();
        }

        [TestMethod]
        public void FloatingPointMatchesTest1()
        {
            Assert.IsTrue(t.Pattern.IsMatch(".003"));
        }

        [TestMethod]
        public void FloatingPointMatchesTest2()
        {
            Assert.IsTrue(t.Pattern.IsMatch("103.4"));
        }

        [TestMethod]
        public void FloatingPointMatchesTest3()
        {
            Assert.IsTrue(t.Pattern.IsMatch("0.0"));
        }
    }
}

