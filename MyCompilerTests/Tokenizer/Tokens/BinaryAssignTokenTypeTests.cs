using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class BinaryAssignTokenTypeTests
    {
        private ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new BinaryAssignTokenType();
        }

        [TestMethod]
        public void AssignMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("="));
        }
    }
}


