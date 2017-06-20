using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompiler.Program;
using MyCompiler.Tokenizer;

namespace MyCompilerTests.Program
{
    [TestClass]
    public class ParsingTests
    {
        private MyTokenizer t;
        private MyProgram p;

        [TestMethod]
        public void Test1()
        {
            t = new MyTokenizer(@"Data", "test1.c");
            t.Tokenize();
            p = new MyProgram();
            p.Parse(t);
        }
    }
}
