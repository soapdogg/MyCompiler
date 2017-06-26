using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class DoTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bdo\\b");

        public override bool Equals(object obj) => obj is DoTokenType;

        public override int GetHashCode() => (int) TokenType.Do;
    }
}
