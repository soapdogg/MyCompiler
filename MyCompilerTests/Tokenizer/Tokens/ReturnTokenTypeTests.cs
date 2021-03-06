﻿using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class ReturnTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new ReturnTokenType();
        }

        [TestMethod]
        public void ReturnMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("return"));
        }

        [TestMethod]
        public void ReturnBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("idkreturn"));
        }

        [TestMethod]
        public void ForAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("returnplx"));
        }
    }
}

