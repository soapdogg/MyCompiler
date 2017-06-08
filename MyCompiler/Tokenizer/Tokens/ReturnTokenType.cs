using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ReturnTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\breturn\\b");
    }
}
