using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class DoTokenType : BaseTokenType
    {
        public DoTokenType()
        {
            Pattern = new Regex("do");
        }
    }
}
