using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.AssignmentOperators
{
    public class ModulusAssignTokenType : BaseTokenType
    {
        public ModulusAssignTokenType()
        {
            Pattern = new Regex("^%=");
        }
    }
}
