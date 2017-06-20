using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class AssignInitializerNode : Interfaces.IAssignInitializerNode
    {
        private Interfaces.IExpressionNode expression;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // Binary Assign Token
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
        }

        public string PrettyPrint() => " = " + expression.PrettyPrint();
    }
}
