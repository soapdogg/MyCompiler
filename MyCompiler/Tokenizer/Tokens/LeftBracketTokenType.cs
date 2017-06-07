﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftBracketTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\[");
    }
}
