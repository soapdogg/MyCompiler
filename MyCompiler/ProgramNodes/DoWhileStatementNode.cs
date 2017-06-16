using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class DoWhileStatementNode : IDoWhileStatementNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IBooleanExpressionNode expression;
        private IStatementNode body;

        public DoWhileStatementNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            expression.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(expression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new DoWhileStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
