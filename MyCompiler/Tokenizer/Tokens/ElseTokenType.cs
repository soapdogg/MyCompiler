using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class ElseTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\belse\\b");
    }
}
