using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class AssignInitializerNode : IAssignInitializerNode
    {
        private IExpressionNode expression;

        public string PrettyPrint() => " = " + expression.PrettyPrint();
    }
}
