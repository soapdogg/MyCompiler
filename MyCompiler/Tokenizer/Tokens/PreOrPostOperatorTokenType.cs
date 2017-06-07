using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class PreOrPostOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(\\+\\+|--)");
    }
}
