using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class DivideAssignTokenType : BaseTokenType
    {
        public DivideAssignTokenType()
        {
            Pattern = new Regex("^/=");
        }
    }
}
