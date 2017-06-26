using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ReturnTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\breturn\\b");

        public override bool Equals(object obj) => obj is ReturnTokenType;

        public override int GetHashCode() => (int) TokenType.Return;
    }
}
