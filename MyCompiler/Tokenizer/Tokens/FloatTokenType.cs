﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class FloatTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bfloat\\b");
    }
}
