using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class LeftBraceTokenType : BaseTokenType
    {
        public LeftBraceTokenType()
        {
            Pattern = new Regex("^\\{");
        }
    }
}
