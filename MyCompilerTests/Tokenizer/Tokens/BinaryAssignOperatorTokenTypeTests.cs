using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BinaryAssignOperatorTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BinaryAssignOperatorTokenType();
        }

        [TestMethod]
        public void AndAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("&="));
        }

        [TestMethod]
        public void DivideAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("/="));
        }

        [TestMethod]
        public void LeftShiftAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("<<="));
        }

        [TestMethod]
        public void MinusAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("-="));
        }

        [TestMethod]
        public void ModulusAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("%="));
        }

        [TestMethod]
        public void MultiplyAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("*="));
        }

        [TestMethod]
        public void OrAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("|="));
        }

        [TestMethod]
        public void PlusAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("+="));
        }

        [TestMethod]
        public void RightAssignAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(">>="));
        }

        [TestMethod]
        public void XorAssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("^="));
        }
    }
}

