using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class ForStatementNode : IForStatementNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IExpressionNode initExpressionNode, incrementExpressionNode;
        private IBooleanExpressionNode testExpressionNode;
        private IStatementNode body;

        public ForStatementNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(3);
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            testExpressionNode.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.START, CounterUtilities.GetNextLabelAvailable);
            testExpressionNode.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            initExpressionNode.Translate();
            testExpressionNode.Translate();
            incrementExpressionNode.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(initExpressionNode.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.START)));
            sb.Append(testExpressionNode.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(testExpressionNode.GetLabel(Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(incrementExpressionNode.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Labelable.START)));
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(testExpressionNode.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new ForStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
