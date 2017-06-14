
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCompilerTests.Tokenizer
{
    [TestClass]
    public class TokenizerTests
    {
        private MyCompiler.Tokenizer.Tokenizer t;

        [TestMethod]
        public void Test1()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test1.c");
            t.Tokenize();
            Assert.AreEqual(35, t.Size);
        }

        [TestMethod]
        public void Test2()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test2.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test3()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test3.c");
            t.Tokenize();
            Assert.AreEqual(35, t.Size);
        }

        [TestMethod]
        public void Test4()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test4.c");
            t.Tokenize();
            Assert.AreEqual(29, t.Size);
        }

        [TestMethod]
        public void Test5()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test5.c");
            t.Tokenize();
            Assert.AreEqual(37, t.Size);
        }

        [TestMethod]
        public void Test6()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test6.c");
            t.Tokenize();
            Assert.AreEqual(45, t.Size);
        }

        [TestMethod]
        public void Test7()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test7.c");
            t.Tokenize();
            Assert.AreEqual(70, t.Size);
        }

        [TestMethod]
        public void Test8()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test8.c");
            t.Tokenize();
            Assert.AreEqual(31, t.Size);
        }

        [TestMethod]
        public void Test9()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test9.c");
            t.Tokenize();
            Assert.AreEqual(104, t.Size);
        }

        [TestMethod]
        public void Test10()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test10.c");
            t.Tokenize();
            Assert.AreEqual(23, t.Size);
        }

        [TestMethod]
        public void Test11()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test11.c");
            t.Tokenize();
            Assert.AreEqual(23, t.Size);
        }

        [TestMethod]
        public void Test12()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test12.c");
            t.Tokenize();
            Assert.AreEqual(33, t.Size);
        }

        [TestMethod]
        public void Test13()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test13.c");
            t.Tokenize();
            Assert.AreEqual(31, t.Size);
        }

        [TestMethod]
        public void Test14()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test14.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test15()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test15.c");
            t.Tokenize();
            Assert.AreEqual(45, t.Size);
        }

        [TestMethod]
        public void Test16()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test16.c");
            t.Tokenize();
            Assert.AreEqual(43, t.Size);
        }

        [TestMethod]
        public void Test17()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test17.c");
            t.Tokenize();
            Assert.AreEqual(38, t.Size);
        }

        [TestMethod]
        public void Test18()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test18.c");
            t.Tokenize();
            Assert.AreEqual(43, t.Size);
        }

        [TestMethod]
        public void Test19()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test19.c");
            t.Tokenize();
            Assert.AreEqual(40, t.Size);
        }

        [TestMethod]
        public void Test20()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test20.c");
            t.Tokenize();
            Assert.AreEqual(40, t.Size);
        }

        [TestMethod]
        public void Test21()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test21.c");
            t.Tokenize();
            Assert.AreEqual(157, t.Size);
        }

        [TestMethod]
        public void Test22()
        {
            t = new MyCompiler.Tokenizer.Tokenizer(@"Data", "test22.c");
            t.Tokenize();
            Assert.AreEqual(368, t.Size);
        }
    }
}
