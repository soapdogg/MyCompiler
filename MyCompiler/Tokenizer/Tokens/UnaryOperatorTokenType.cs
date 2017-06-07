using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class UnaryOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\+|-|~)");
    }
}
