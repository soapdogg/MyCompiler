using System;

namespace MyCompiler
{
    class Program
    {
        static void Main()
        {
            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer (@"Data", @"test10.c");
            var result = t.Tokenize();
            Console.ReadLine();
        }
    }
}