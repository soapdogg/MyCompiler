using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class ArrayTypeNode : IArrayTypeNode
    {
        private bool hasIndex;
        private IExpressionNode expression;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //left bracket token
            hasIndex = !(tokenizer.PeekTokenType() is RightBracketTokenType);
            if (hasIndex)
            {
                expression = new ExpressionNode();
                expression.Parse(tokenizer);
            }
            tokenizer.Pop(); //right bracket token
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
