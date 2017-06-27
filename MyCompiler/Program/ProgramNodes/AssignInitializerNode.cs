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
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Assign); // Binary Assign Token
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
        }

        public string PrettyPrint() => " = " + expression.PrettyPrint();
    }
}
