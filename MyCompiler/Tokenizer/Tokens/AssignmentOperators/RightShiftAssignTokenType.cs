using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class RightShiftAssignTokenType : BaseTokenType
    {
        public RightShiftAssignTokenType()
        {
            Pattern = new Regex("^>>=");
        }
    }
}
