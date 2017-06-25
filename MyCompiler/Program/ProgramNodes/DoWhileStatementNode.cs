using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class DoWhileStatementNode : IDoWhileStatementNode
    {
        private readonly Labelable labelable;
        private IExpressionNode expression;
        private IStatementNode body;

        public DoWhileStatementNode()
        {
            labelable = new Labelable(2);
        }

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // do token
            body = new StatementNode();
            body.Parse(tokenizer);
            tokenizer.Pop(); //while token
            tokenizer.Pop(); //left parentheses
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); //right parentheses
            tokenizer.Pop(); //semicolon
        }

        public void Translate()
        {
            expression.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            body.Translate();
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
