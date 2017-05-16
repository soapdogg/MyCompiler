using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class MinusAssignTokenType : BaseTokenType
    {
        public MinusAssignTokenType()
        {
            Pattern = new Regex("^-=");
        }
    }
}
