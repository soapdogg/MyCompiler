using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class AndAssignTokenType : BaseTokenType
    {
        public AndAssignTokenType()
        {
            Pattern = new Regex("^&=");
        }
    }
}
