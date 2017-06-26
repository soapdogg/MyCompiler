using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class PreOrPostOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\+{2}|-{2})");

        public override bool Equals(object obj) => obj is PreOrPostOperatorTokenType;

        public override int GetHashCode() => (int) TokenType.PrePost;
    }
}
