using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ReturnTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\breturn\\b");

        public override bool Equals(object obj) => obj is ReturnTokenType;

        public override int GetHashCode() => 23;
    }
}
