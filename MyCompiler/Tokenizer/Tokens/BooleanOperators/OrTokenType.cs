using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.BooleanOperators
{
    public class OrTokenType : BaseTokenType
    {
        public OrTokenType()
        {
            Pattern = new Regex("^||");
        }
    }
}
