using System;
using MyCompiler.Program;
using MyCompiler.Tokenizer;

namespace MyCompiler
{
    class Driver
    {
        static void Main()
        {
            ITokenizer t = new MyTokenizer(@"Data", @"test7.c");
            t.Tokenize();
            IProgram p = new MyProgram();
            p.Parse(t);
            p.Translate();
            Console.WriteLine(p.PrettyPrint());
            Console.ReadLine();
        }
    }
}