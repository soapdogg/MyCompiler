using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IfTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bif\\b");

        public override bool Equals(object obj) => obj is IfTokenType;

        public override int GetHashCode() => 15;
    }
}
