using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ArrayTypeNode : IArrayTypeNode
    {
        private bool hasIndex;
        private IExpressionNode expression;

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LBracket);
            hasIndex = tokenizer.Peek().GetHashCode() != (int)TokenType.RBracket;
            if (hasIndex)
            {
                expression = new ExpressionNode();
                expression.Parse(tokenizer);
            }
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RBracket);
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (hasIndex) sb.Append(expression.PrettyPrint());
            sb.Append("]");
            return sb.ToString();
        }
    }
}
