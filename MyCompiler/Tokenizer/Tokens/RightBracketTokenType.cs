﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class RightBracketTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\]");
    }
}
