using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class IntegerConstantTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new IntegerConstantTokenType();
        }

        [TestMethod]
        public void IntegerMatchesTest1()
        {
            Assert.IsTrue(t.Pattern.IsMatch("0"));
        }

        [TestMethod]
        public void IntegerMatchesTest2()
        {
            Assert.IsTrue(t.Pattern.IsMatch("4"));
        }

        [TestMethod]
        public void IntegerMatchesTest3()
        {
            Assert.IsTrue(t.Pattern.IsMatch("34234"));
        }
    }
}

