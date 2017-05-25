using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class RightBraceTokenType : BaseTokenType
    {
        public RightBraceTokenType()
        {
            Pattern = new Regex("^\\}");
        }
    }
}
