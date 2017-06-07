using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class RightBraceTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^\\}");
    }
}
