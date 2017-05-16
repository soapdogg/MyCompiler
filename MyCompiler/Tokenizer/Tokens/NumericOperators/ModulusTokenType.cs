using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens.NumericOperators
{
    public class ModulusTokenType : BaseTokenType
    {
        public ModulusTokenType()
        {
            Pattern = new Regex("^%");
        }
    }
}
