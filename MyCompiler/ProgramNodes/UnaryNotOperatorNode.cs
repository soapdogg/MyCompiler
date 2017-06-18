using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class UnaryNotOperatorNode : IUnaryNotOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IBooleanExpressionNode innerExpression;

        public UnaryNotOperatorNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            innerExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.SECOND));
            innerExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.TRUE));
            innerExpression.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint() => innerExpression.PrettyPrint();

        public IBooleanExpressionChild NewBooleanExpressionChildInstance => new UnaryNotOperatorNode();
    }
}
