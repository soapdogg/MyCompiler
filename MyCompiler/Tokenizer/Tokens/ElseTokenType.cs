using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ElseTokenType : BaseTokenType
    {
        public ElseTokenType()
        {
            Pattern = new Regex("^else");
        }
    }
}
