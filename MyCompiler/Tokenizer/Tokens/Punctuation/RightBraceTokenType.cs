using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class RightBraceTokenType : BaseTokenType
    {
        public RightBraceTokenType()
        {
            Pattern = new Regex("\\}");
        }
    }
}
