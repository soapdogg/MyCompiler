﻿using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftBraceTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\{");
    }
}
