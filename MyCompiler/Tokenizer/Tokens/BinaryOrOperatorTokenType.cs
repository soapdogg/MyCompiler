﻿using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryOrOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\|\\|)");

        public override bool Equals(object obj) => obj is BinaryOrOperatorTokenType;

        public override int GetHashCode() => (int) TokenType.Or;
    }
}
