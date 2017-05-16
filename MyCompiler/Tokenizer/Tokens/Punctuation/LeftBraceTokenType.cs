using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class LeftBraceTokenType : BaseTokenType
    {
        public LeftBraceTokenType()
        {
            Pattern = new Regex("\\{");
        }
    }
}
