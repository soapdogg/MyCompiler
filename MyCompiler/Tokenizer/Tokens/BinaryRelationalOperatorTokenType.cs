using System.Text.RegularExpressions;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer.Tokens
{
    public class BinaryRelationalOperatorTokenType : BaseTokenType
    {
        public override Regex Pattern => new Regex("^(={2}|>=|>|<=|<|!=)");

        public override bool Equals(object obj) => obj is BinaryRelationalOperatorTokenType;

        public override int GetHashCode() => (int) TokenType.Relational;
    }
}
