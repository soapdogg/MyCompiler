using System;
using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Exceptions
{
    [Serializable]
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(SimpleCToken token, params ITokenType[] expected) : base(GetMessage(token,
            expected))
        {
        }

        private static string GetMessage(SimpleCToken token, params ITokenType [] expected)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Error! Expected token type(s): ");
            foreach (var tokenType in expected)
            {
                sb.Append(tokenType);
                sb.Append(' ');
            }
            sb.Append("\nActual Type: ");
            sb.Append(token.TokenType);
            sb.Append(" Value: ");
            sb.Append(token.Value);
            return sb.ToString();
        }
    }
}
