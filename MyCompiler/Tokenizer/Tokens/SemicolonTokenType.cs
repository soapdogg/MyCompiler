using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class SemicolonTokenType : BaseTokenType
    {
        public SemicolonTokenType()
        {
            Pattern = new Regex("^;");
        }
    }
}
