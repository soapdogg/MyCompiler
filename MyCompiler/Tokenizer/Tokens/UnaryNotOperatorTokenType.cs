using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class UnaryNotOperatorTokenType : BaseTokenType
    {
        public UnaryNotOperatorTokenType()
        {
            Pattern = new Regex("^!");
        }
    }
}
