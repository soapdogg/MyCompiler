using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class DoubleTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^double");
    }
}
