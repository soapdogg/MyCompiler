using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class MultiplyAssignTokenType : BaseTokenType
    {
        public MultiplyAssignTokenType()
        {
            Pattern = new Regex("^/*=");
        }
    }
}
