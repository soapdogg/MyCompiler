using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompilerTests.Tokenizer
{
    [TestClass]
    public class SimpleCTokenTests
    {
        private SimpleCToken simpleCToken;

        [TestInitialize]
        public void TestInitialize()
        {
            simpleCToken = new SimpleCToken(new EndOfFileTokenType(), "END_OF_FILE");
        }

        [TestMethod]
        public void EqualsTestThis()
        {
            Assert.IsTrue(simpleCToken.Equals(simpleCToken));
        }

        [TestMethod]
        public void EqualsTestNull()
        {
            Assert.AreNotEqual(null, simpleCToken);
        }

        [TestMethod]
        public void CloneTest()
        {
            SimpleCToken other = simpleCToken.Clone();
            Assert.AreEqual(simpleCToken, other);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("TokenType: MyCompiler.Tokenizer.Tokens.EndOfFileTokenType\tValue: END_OF_FILE", simpleCToken.ToString());
        }

    }
}
