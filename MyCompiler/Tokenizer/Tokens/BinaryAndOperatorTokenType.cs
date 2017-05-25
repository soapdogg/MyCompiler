using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAndOperatorTokenType : BaseTokenType
    {
        public BinaryAndOperatorTokenType()
        {
            Pattern = new Regex("^&&");
        }
    }
}
