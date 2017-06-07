using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAndOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^&&");
    }
}
