using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens
{
    public class TypeTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("\\b(double|void|float|int|long)\\b");
    }
}
