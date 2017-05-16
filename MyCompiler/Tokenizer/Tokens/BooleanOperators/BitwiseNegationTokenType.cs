using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class BitwiseNegationTokenType : BaseTokenType
    {
        public BitwiseNegationTokenType()
        {
            Pattern = new Regex("^~");
        }
    }
}
