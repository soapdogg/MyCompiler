using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IdentifierTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^([_a-zA-Z]\\w*)");

        public override bool Equals(object obj) => obj is IdentifierTokenType;

        public override int GetHashCode() => (int) TokenType.Identifier;
    }
}
