using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.VariablesAndConstants
{
    public class FloatingPointConstantTokenType : BaseTokenType
    {
        public FloatingPointConstantTokenType()
        {
            Pattern = new Regex("\\d*.\\d+ | \\d+.(e|E)(+|-)?\\d* | \\d+.(e|E)(+|-)?\\d+(f|F)? | (0x|0X)[\\da-fA-F]*.[\\da-fA-F]* | [\\da-fA-F]+ . (p|P) (+|-)? \\d+ (f|F)?");
        }
    }
}
