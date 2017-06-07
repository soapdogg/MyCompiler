using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class DoTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^do");
    }
}
