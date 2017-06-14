using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class SimpleCToken
    {
        public ITokenType TokenType { get; }
        public string Value { get; }

        public SimpleCToken(ITokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }

        public SimpleCToken Clone()
        {
            return new SimpleCToken(TokenType, Value);
        }

        public override string ToString()
        {
            return "TokenType: " + TokenType + "\tValue: " + Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is SimpleCToken)) return false;
            SimpleCToken that = (SimpleCToken) obj;
            return TokenType.Equals(that.TokenType) && Value.Equals(that.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((TokenType != null ? TokenType.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}
