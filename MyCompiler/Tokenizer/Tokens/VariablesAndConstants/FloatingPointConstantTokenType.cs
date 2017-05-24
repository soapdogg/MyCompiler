using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.VariablesAndConstants
{
    public class FloatingPointConstantTokenType : BaseTokenType
    {
        public FloatingPointConstantTokenType()
        {
            Pattern = new Regex("^(\\d*\\.\\d+)");
        }
    }
}
