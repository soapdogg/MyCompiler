using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class PlusOrMinusTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\+|-)");
    }
}
