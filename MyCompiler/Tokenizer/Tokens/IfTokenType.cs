﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IfTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bif\\b");
    }
}