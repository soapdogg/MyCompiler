using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class FloatingPointConstantTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\d*\\.\\d+)");

        public override bool Equals(object obj) => obj is FloatingPointConstantTokenType;

        public override int GetHashCode() => (int) TokenType.Float;
    }
}
