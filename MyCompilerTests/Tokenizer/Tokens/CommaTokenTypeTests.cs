﻿using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class CommaTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new CommaTokenType();
        }

        [TestMethod]
        public void SemicolonMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch(","));
        }
    }
}
