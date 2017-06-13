using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class BitNegationOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^~");
    }
}
