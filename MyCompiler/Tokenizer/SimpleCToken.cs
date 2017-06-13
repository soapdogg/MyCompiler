﻿using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class SimpleCToken
    {
        public ITokenType TokenType { get; set; }
        public string Value { get; set; }

        public SimpleCToken(ITokenType tokenType)
        {
            TokenType = tokenType;   
        }

        public SimpleCToken(ITokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }

        public SimpleCToken Clone()
        {
            return new SimpleCToken(TokenType, Value);
        }

        public override string ToString()
        {
            return "TokenType: " + TokenType + "\tValue: " + Value;
        }
    }
}
