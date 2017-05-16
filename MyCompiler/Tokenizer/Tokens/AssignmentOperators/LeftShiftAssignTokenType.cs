using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class LeftShiftAssignTokenType : BaseTokenType
    {
        public LeftShiftAssignTokenType()
        {
            Pattern = new Regex("^<<=");
        }
    }
}
