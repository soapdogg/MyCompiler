
using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class BinaryAndOperatorNode : IBinaryAndOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IBooleanExpressionNode leftExpression, rightExpression;

        public BinaryAndOperatorNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            leftExpression.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            leftExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.SECOND));
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
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(leftExpression.GetLabel(Labelable.TRUE)));
            sb.Append(rightExpression.PrettyPrint());
            return sb.ToString();
        }

        public IBooleanExpressionChild NewBooleanExpressionChildInstance => new BinaryAndOperatorNode();
    }
}
