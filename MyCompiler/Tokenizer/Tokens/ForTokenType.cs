using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ForTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bfor\\b");

        public override bool Equals(object obj) => obj is ForTokenType;

        public override int GetHashCode() => 13;
    }
}
