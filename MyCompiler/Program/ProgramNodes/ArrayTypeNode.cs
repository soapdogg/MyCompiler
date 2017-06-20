using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class ArrayTypeNode : Interfaces.IArrayTypeNode
    {
        private bool hasIndex;
        private Interfaces.IExpressionNode expression;

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
