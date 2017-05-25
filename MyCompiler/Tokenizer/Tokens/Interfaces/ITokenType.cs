using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.Interfaces
{
    public interface ITokenType
    {
        Regex Pattern { get;}

        TokenMatch Match(string inputString);
    }
}
