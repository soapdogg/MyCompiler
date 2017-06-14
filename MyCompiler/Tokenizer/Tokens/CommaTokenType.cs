using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class CommaTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^,");
    }
}
