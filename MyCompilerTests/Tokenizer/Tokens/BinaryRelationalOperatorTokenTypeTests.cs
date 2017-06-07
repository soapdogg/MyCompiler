
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BinaryRelationalOperatorTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BinaryRelationalOperatorTokenType();
        }

        [TestMethod]
        public void EqualsMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("=="));
        }

        [TestMethod]
        public void NotEqualsMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("!="));
        }

        [TestMethod]
        public void GreaterThanMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(">"));
        }

        [TestMethod]
        public void GreaterThanOrEqualToMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(">="));
        }

        [TestMethod]
        public void LessThanMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(">"));
        }

        [TestMethod]
        public void LessThanOrEqualToMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(">="));
        }
    }
}
