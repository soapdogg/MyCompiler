using System;
using System.Text;

namespace MyCompiler.Tokenizer.Exceptions
{
    [Serializable]
    public class InvalidTokenTypeException : Exception
    {
        public InvalidTokenTypeException(string remainingText) : base(GetMessage(remainingText))
        {

        }

        private static string GetMessage(string remainingText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Error! Invalid Token type. Value: ");
            sb.Append(remainingText);
            sb.Append(" doesn't match any token type!");
            return sb.ToString();
        }
    }
}
