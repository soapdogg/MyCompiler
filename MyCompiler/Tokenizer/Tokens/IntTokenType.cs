using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IntTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bint\\b");
    }
}
