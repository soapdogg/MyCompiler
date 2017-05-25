using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ReturnTokenType : BaseTokenType
    {
        public ReturnTokenType()
        {
            Pattern = new Regex("^return");
        }
    }
}
