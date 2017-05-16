using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.Punctuation
{
    public class SemicolonTokenType : BaseTokenType
    {
        public SemicolonTokenType()
        {
            Pattern = new Regex(";");
        }
    }
}
