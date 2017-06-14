using System;

namespace MyCompiler
{
    class Program
    {
        static void Main()
        {
            for (int i = 7; i <= 22; ++i)
            {
                Tokenizer.Tokenizer t = new Tokenizer.Tokenizer(@"Data", @"test" + i + ".c");
                t.Tokenize();
                Console.WriteLine(t.Size);
            }
            //foreach(var l in result) Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}