using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class XorAssignTokenType : BaseTokenType
    {
        public XorAssignTokenType()
        {
            Pattern = new Regex("^/^=");
        }
    }
}
