using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryOrOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\|\\|)");
    }
}
