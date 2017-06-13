﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class RightParenthesesTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\)");
    }
}