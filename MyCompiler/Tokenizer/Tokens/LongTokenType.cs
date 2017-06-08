using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class LongTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\blong\\b");
    }
}
