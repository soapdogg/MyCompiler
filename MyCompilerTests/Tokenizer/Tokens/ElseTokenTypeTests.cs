﻿using MyCompiler.Tokenizer.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompilerTests.Tokenizer.Tokens
{
    [TestClass]
    public class ElseTokenTypeTests
    {
        ITokenType t;

        [TestInitialize]
        public void TestInitialize()
        {
            t = new ElseTokenType();
        }

        [TestMethod]
        public void ElseMatchesTest()
        {
            Assert.IsTrue(t.Pattern.IsMatch("else"));
        }

        [TestMethod]
        public void ElseBeforeDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("45else"));
        }

        [TestMethod]
        public void ElseAfterDoesntMatchTest()
        {
            Assert.IsFalse(t.Pattern.IsMatch("elsethg"));
        }
    }
}

