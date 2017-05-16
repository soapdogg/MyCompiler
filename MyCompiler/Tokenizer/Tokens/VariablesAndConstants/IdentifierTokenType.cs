using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.VariablesAndConstants
{
    public class IdentifierTokenType : BaseTokenType
    {
        public IdentifierTokenType()
        {
            Pattern = new Regex("[_a-zA-Z][_a-zA-Z0-9]*");
        }
    }
}
