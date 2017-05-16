using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class DoToken : BaseTokenType
    {
        public DoToken()
        {
            Pattern = new Regex("^do");
        }
    }
}
