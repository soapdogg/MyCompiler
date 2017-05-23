using System.IO;
using System;


namespace MyCompiler
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines(AppContext.BaseDirectory +Path.DirectorySeparatorChar+ @"Data" + Path.DirectorySeparatorChar + @"test3.c");
            Tokenizer.Tokenizer t = new Tokenizer.Tokenizer();
            var result = t.Tokenize(lines[4]);

        }
    }
}
