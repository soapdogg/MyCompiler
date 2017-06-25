using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryNotOperatorNode : IUnaryNotOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private readonly IExpressionNode innerExpression;

        public UnaryNotOperatorNode(IExpressionChild inner)
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
            innerExpression = new ExpressionNode(inner);
        }

        public void Translate()
        {
            innerExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.SECOND));
            innerExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.TRUE));
            innerExpression.Translate();
            translatable.Translate();
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint() => innerExpression.PrettyPrint();
    }
}
