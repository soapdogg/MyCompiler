using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class IntegerConstantTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^([1-9]\\d*|0)");

        public override bool Equals(object obj) => obj is IntegerConstantTokenType;

        public override int GetHashCode() => (int) TokenType.Integer;
    }
}
