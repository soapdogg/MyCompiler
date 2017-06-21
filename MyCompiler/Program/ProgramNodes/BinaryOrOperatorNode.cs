using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryOrOperatorNode : IBinaryOrOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IExpressionNode leftExpression, rightExpression;

        public BinaryOrOperatorNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            leftExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.TRUE));
            leftExpression.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            rightExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.TRUE));
            rightExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.SECOND));
            leftExpression.Translate();
            rightExpression.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(leftExpression.GetLabel(Labelable.SECOND)));
            sb.Append(rightExpression.PrettyPrint());
            return sb.ToString();
        }

        public IExpressionChild NewExpressionChildInstance() => new BinaryOrOperatorNode();
    }
}
