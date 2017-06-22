using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftBraceTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^{");

        public override bool Equals(object obj) => obj is LeftBraceTokenType;

        public override int GetHashCode() => 18;
    }
}
