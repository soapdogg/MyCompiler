using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class FloatingPointConstantTokenType : BaseTokenType
    {
        public FloatingPointConstantTokenType()
        {
            Pattern = new Regex("^(\\d*\\.\\d+)");
        }
    }
}
