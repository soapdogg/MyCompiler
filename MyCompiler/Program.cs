using System;

namespace MyCompiler
{
    class Program
    {
        static void Main()
        {
            Tokenizer.MyTokenizer t = new Tokenizer.MyTokenizer(@"Data", @"test7.c");
            var result = t.Tokenize();
            foreach(var l in result) Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}