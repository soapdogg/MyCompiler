using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ForTokenType : BaseTokenType
    {
        public ForTokenType()
        {
            Pattern = new Regex("^for");
        }
    }
}
