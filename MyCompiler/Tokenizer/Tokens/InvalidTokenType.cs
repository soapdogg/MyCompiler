
using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class InvalidTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex(".*");
    }
}
