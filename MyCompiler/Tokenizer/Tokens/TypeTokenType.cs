﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class TypeTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\b(double|void|float|int|long)\\b");

        public override bool Equals(object obj) => obj is TypeTokenType;

        public override int GetHashCode() => 28;
    }
}