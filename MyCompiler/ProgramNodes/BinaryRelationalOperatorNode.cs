using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class BinaryRelationalOperatorNode : IBinaryRelationalOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IExpressionNode leftExpression, rightExpression;
        private string op;

        public BinaryRelationalOperatorNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append("if (");
            sb.Append(leftExpression.Address);
            sb.Append(op);
            sb.Append(rightExpression.Address);
            sb.Append(") ");
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Labelable.TRUE)));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }

        public IBooleanExpressionChild NewBooleanExpressionChildInstance => new BinaryRelationalOperatorNode();
    }
}
