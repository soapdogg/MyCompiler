using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class AssignTokenType : BaseTokenType
    {
        public AssignTokenType()
        {
            Pattern = new Regex("^=");
        }
    }
}
