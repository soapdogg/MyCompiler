using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class TypeTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\b(double|int)\\b");

        public override bool Equals(object obj) => obj is TypeTokenType;

        public override int GetHashCode() => (int) TokenType.Type;
    }
}
