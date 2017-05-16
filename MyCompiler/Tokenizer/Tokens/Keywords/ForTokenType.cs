using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Keywords
{
    public class ForTokenType : BaseTokenType
    {
        public ForTokenType()
        {
            Pattern = new Regex("^for");
        }
    }
}
