using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class AssignInitializerNode : IAssignInitializerNode
    {
        private IExpressionNode expression;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // Binary Assign Token
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
        }

        public string PrettyPrint() => " = " + expression.PrettyPrint();
    }
}
