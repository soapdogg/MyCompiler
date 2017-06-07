using System.Text.RegularExpressions;
namespace MyCompiler.Tokenizer.Tokens
{
    public class SemicolonTokenType : BaseTokenType
    {
        public override Regex Pattern =>  new Regex("^;");
    }
}
