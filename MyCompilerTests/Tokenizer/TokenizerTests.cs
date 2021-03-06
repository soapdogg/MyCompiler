﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Tokenizer;

namespace MyCompilerTests.Tokenizer
{
    [TestClass]
    public class TokenizerTests
    {
        private MyTokenizer t;

        [TestMethod]
        public void Test1()
        {
            t = new MyTokenizer(@"Data", "test1.c");
            t.Tokenize();
            Assert.AreEqual(35, t.Size);
        }

        [TestMethod]
        public void Test2()
        {
            t = new MyTokenizer(@"Data", "test2.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test3()
        {
            t = new MyTokenizer(@"Data", "test3.c");
            t.Tokenize();
            Assert.AreEqual(35, t.Size);
        }

        [TestMethod]
        public void Test4()
        {
            t = new MyTokenizer(@"Data", "test4.c");
            t.Tokenize();
            Assert.AreEqual(29, t.Size);
        }

        [TestMethod]
        public void Test5()
        {
            t = new MyTokenizer(@"Data", "test5.c");
            t.Tokenize();
            Assert.AreEqual(37, t.Size);
        }

        [TestMethod]
        public void Test6()
        {
            t = new MyTokenizer(@"Data", "test6.c");
            t.Tokenize();
            Assert.AreEqual(45, t.Size);
        }

        [TestMethod]
        public void Test7()
        {
            t = new MyTokenizer(@"Data", "test7.c");
            t.Tokenize();
            Assert.AreEqual(72, t.Size);
        }

        [TestMethod]
        public void Test8()
        {
            t = new MyTokenizer(@"Data", "test8.c");
            t.Tokenize();
            Assert.AreEqual(31, t.Size);
        }

        [TestMethod]
        public void Test9()
        {
            t = new MyTokenizer(@"Data", "test9.c");
            t.Tokenize();
            Assert.AreEqual(101, t.Size);
        }

        [TestMethod]
        public void Test10()
        {
            t = new MyTokenizer(@"Data", "test10.c");
            t.Tokenize();
            Assert.AreEqual(23, t.Size);
        }

        [TestMethod]
        public void Test11()
        {
            t = new MyTokenizer(@"Data", "test11.c");
            t.Tokenize();
            Assert.AreEqual(23, t.Size);
        }

        [TestMethod]
        public void Test12()
        {
            t = new MyTokenizer(@"Data", "test12.c");
            t.Tokenize();
            Assert.AreEqual(33, t.Size);
        }

        [TestMethod]
        public void Test13()
        {
            t = new MyTokenizer(@"Data", "test13.c");
            t.Tokenize();
            Assert.AreEqual(31, t.Size);
        }

        [TestMethod]
        public void Test14()
        {
            t = new MyTokenizer(@"Data", "test14.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test15()
        {
            t = new MyTokenizer(@"Data", "test15.c");
            t.Tokenize();
            Assert.AreEqual(45, t.Size);
        }

        [TestMethod]
        public void Test16()
        {
            t = new MyTokenizer(@"Data", "test16.c");
            t.Tokenize();
            Assert.AreEqual(43, t.Size);
        }

        [TestMethod]
        public void Test17()
        {
            t = new MyTokenizer(@"Data", "test17.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test18()
        {
            t = new MyTokenizer(@"Data", "test18.c");
            t.Tokenize();
            Assert.AreEqual(43, t.Size);
        }

        [TestMethod]
        public void Test19()
        {
            t = new MyTokenizer(@"Data", "test19.c");
            t.Tokenize();
            Assert.AreEqual(40, t.Size);
        }

        [TestMethod]
        public void Test20()
        {
            t = new MyTokenizer(@"Data", "test20.c");
            t.Tokenize();
            Assert.AreEqual(40, t.Size);
        }

        [TestMethod]
        public void Test21()
        {
            t = new MyTokenizer(@"Data", "test21.c");
            t.Tokenize();
            Assert.AreEqual(153, t.Size);
        }

        [TestMethod]
        public void Test22()
        {
            t = new MyTokenizer(@"Data", "test22.c");
            t.Tokenize();
            Assert.AreEqual(368, t.Size);
        }
    }
}
