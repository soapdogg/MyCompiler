using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class VoidTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\bvoid\\b");
    }
}
