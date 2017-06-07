using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class FloatingPointConstantTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\d*\\.\\d+)");
    }
}
