using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAssignTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^=");
    }
}
