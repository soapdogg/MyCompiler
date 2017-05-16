using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class OrAssignTokenType : BaseTokenType
    {
        public OrAssignTokenType()
        {
            Pattern = new Regex("^|=");
        }
    }
}
