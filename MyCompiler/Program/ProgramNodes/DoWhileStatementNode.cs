using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class DoWhileStatementNode : Interfaces.IDoWhileStatementNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private Interfaces.IBooleanExpressionNode expression;
        private Interfaces.IStatementNode body;

        public DoWhileStatementNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(2);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // do token
            body = new StatementNode();
            body.Parse(tokenizer);
            tokenizer.Pop(); //while token
            tokenizer.Pop(); //left parentheses
            expression = new BooleanExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); //right parentheses
            tokenizer.Pop(); //semicolon
        }

        public string Translate()
        {
            expression.SetLabel(Components.Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Components.Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Components.Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(expression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Components.Labelable.SECOND)));
            return sb.ToString();
        }

        public Interfaces.IStatementChild NewStatementChildInstance() => new DoWhileStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
