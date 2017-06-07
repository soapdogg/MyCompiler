using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IdentifierTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^([_a-zA-Z]\\w*)");
    }
}
