using System.Linq;
using MyCompiler.Program.ProgramNodes.Exceptions;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class TokenConsumer
    {
        public static void Consume(SimpleCToken actual, params TokenType[] accepted)
        {
            if (accepted.Any(tokenType => (int) tokenType == actual.TokenType.GetHashCode())) return;
            throw new UnexpectedTokenException(actual);
        }
    }
}
