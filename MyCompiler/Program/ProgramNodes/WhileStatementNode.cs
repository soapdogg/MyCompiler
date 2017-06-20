using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class WhileStatementNode : Interfaces.IWhileStatementNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private Interfaces.IBooleanExpressionNode expression;
        private Interfaces.IStatementNode body;

        public WhileStatementNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(3);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //while token
            tokenizer.Pop(); //left parenthese token
            expression = new BooleanExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            body = new StatementNode();
            body.Parse(tokenizer);
        }

        public string Translate()
        {
            expression.SetLabel(Components.Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            SetLabel(Components.Labelable.START, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Components.Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.START)));
            sb.Append(expression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Components.Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Components.Labelable.START)));
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Components.Labelable.SECOND)));
            return sb.ToString();
        }

        public Interfaces.IStatementChild NewStatementChildInstance() => new WhileStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
