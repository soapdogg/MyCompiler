using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class DoTokenType : BaseTokenType
    {
        public DoTokenType()
        {
            Pattern = new Regex("^do");
        }
    }
}
