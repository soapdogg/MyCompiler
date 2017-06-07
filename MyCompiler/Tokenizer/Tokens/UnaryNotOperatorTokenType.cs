using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class UnaryNotOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^!");
    }
}
