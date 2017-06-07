using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IntegerConstantTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^([1-9]\\d*|0)");
    }
}
