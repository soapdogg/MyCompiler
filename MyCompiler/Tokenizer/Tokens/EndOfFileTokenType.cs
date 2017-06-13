using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class EndOfFileTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex(".*");
    }
}
