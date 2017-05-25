using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class TokenMatch
    {
        public bool IsMatch { get; set; }
        public ITokenType TokenType { get; set; }
        public string Value { get; set; }
        public string RemainingText { get; set; }
    }
}
