using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class ElseTokenType : BaseTokenType
    {
        public ElseTokenType()
        {
            Pattern = new Regex("^else");
        }
    }
}
