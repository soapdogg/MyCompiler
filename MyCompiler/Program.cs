using System;

namespace MyCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer(new string[] { @"Data", @"test10.c" });
            var result = t.Tokenize();
            Console.ReadLine();
        }
    }
}