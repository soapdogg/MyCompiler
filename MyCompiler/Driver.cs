﻿using System;
using MyCompiler.Program;
using MyCompiler.Tokenizer;

namespace MyCompiler
{
    class Driver
    {
        static void Main()
        {
            try
            {
                ITokenizer t = new MyTokenizer(@"Data", @"test14.c");
                t.Tokenize();
                IProgram p = new MyProgram();
                p.Parse(t);
                p.Translate();
                Console.WriteLine(p.PrettyPrint());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}