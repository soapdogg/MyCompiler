using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class TypeTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new TypeTokenType();
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
