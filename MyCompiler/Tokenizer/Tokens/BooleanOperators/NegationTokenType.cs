﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class NegationTokenType : BaseTokenType
    {
        public NegationTokenType()
        {
            Pattern = new Regex("^!");
        }
    }
}