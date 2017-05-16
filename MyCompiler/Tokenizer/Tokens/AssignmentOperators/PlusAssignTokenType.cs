using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class PlusAssignTokenType : BaseTokenType
    {
        public PlusAssignTokenType()
        {
            Pattern = new Regex("^+=");
        }
    }
}
