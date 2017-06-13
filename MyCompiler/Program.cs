using System;

namespace MyCompiler
{
    class Program
    {
        static void Main()
        {
            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer (@"Data", @"test15.c");
            var result = t.Tokenize();
            foreach(var l in result) Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}