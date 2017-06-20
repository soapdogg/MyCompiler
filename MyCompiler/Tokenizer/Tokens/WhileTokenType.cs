using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class WhileTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bwhile\\b");

        public override bool Equals(object obj) => obj is WhileTokenType;

        public override int GetHashCode() => 30;
    }
}
