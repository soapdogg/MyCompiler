using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class WhileTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bwhile\\b");

        public override bool Equals(object obj) => obj is WhileTokenType;

        public override int GetHashCode() => (int) TokenType.While;
    }
}
