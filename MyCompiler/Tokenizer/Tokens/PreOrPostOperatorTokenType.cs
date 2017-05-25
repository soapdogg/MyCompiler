using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class PreOrPostOperatorTokenType : BaseTokenType
    {
        public PreOrPostOperatorTokenType()
        {
            Pattern = new Regex("^\\+\\+|--");
        }
    }
}
