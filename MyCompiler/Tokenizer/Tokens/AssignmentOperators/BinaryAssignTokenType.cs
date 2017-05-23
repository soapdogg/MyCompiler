using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class BinaryAssignTokenType : BaseTokenType
    {
        public BinaryAssignTokenType()
        {
            Pattern = new Regex("^=");
        }
    }
}
