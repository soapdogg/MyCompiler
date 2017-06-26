using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ElseTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\belse\\b");

        public override bool Equals(object obj) => obj is ElseTokenType;

        public override int GetHashCode() => (int) TokenType.Else;
    }
}
