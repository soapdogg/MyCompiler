using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryAssignTokenType : BaseTokenType
    {
        public BinaryAssignTokenType()
        {
            Pattern = new Regex("^=");
        }
    }
}
