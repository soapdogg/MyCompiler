using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryOrOperatorTokenType : BaseTokenType
    {
        public BinaryOrOperatorTokenType()
        {
            Pattern = new Regex("^(\\|\\|)");
        }
    }
}
