using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class WhileStatementNode : IWhileStatementNode
    {
        private readonly Labelable labelable;
        private IExpressionNode expression;
        private IStatementNode body;

        public WhileStatementNode()
        {
            labelable = new Labelable(3);
        }

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.While);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LParent);
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RParent);
            body = new StatementNode();
            body.Parse(tokenizer);
        }

        public void Translate()
        {
            expression.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.START, CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.START)));
            sb.Append(expression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Labelable.START)));
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new WhileStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
