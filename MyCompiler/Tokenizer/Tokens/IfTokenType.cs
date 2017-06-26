using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IfTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bif\\b");

        public override bool Equals(object obj) => obj is IfTokenType;

        public override int GetHashCode() => (int) TokenType.If;
    }
}
