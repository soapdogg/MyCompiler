using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class UnaryOperatorTokenType : BaseTokenType
    {
        public UnaryOperatorTokenType()
        {
            Pattern = new Regex("^\\+|-|~");
        }
    }
}
