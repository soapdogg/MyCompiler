using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class AssignInitializerNode : IAssignInitializerNode
    {
        private IExpressionNode expression;

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Assign); 
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" = ");
            sb.Append(expression.PrettyPrint());
            return sb.ToString();
        }
    }
}
