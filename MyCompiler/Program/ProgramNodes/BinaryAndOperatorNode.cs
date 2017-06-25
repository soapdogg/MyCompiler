using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAndOperatorNode : IBinaryAndOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private readonly IExpressionNode leftExpression, rightExpression;

        public BinaryAndOperatorNode(IExpressionChild left, IExpressionChild right)
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
            leftExpression = new ExpressionNode(left);
            rightExpression = new ExpressionNode(right);
        }
        
        public void Translate()
        {
            leftExpression.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            leftExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.SECOND));
            rightExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.TRUE));
            rightExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.SECOND));
            leftExpression.Translate();
            rightExpression.Translate();
            translatable.Translate();
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(leftExpression.GetLabel(Labelable.TRUE)));
            sb.Append(rightExpression.PrettyPrint());
            return sb.ToString();
        }
    }
}
