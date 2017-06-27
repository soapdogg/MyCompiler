using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class IfStatementNode : IIfStatementNode
    {
        private readonly Labelable labelable;
        private IStatementNode trueBody, falseBody;
        private IExpressionNode booleanExpression;
        private bool hasFalse;

        public IfStatementNode()
        {
            labelable = new Labelable(3);
        }

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.If);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LParent);
            booleanExpression = new ExpressionNode();
            booleanExpression.Parse(tokenizer);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RParent);
            trueBody = new StatementNode();
            trueBody.Parse(tokenizer);
            hasFalse = tokenizer.PeekTokenType().GetHashCode() == (int)TokenType.Else;
            if (!hasFalse) return;
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Else); //else token
            falseBody = new StatementNode();
            falseBody.Parse(tokenizer);
        }

        public void Translate()
        {
            SetLabel(Labelable.FALSE, CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            booleanExpression.SetLabel(Labelable.TRUE, GetLabel(Labelable.TRUE));
            SetLabel(Labelable.SECOND, hasFalse ? CounterUtilities.GetNextLabelAvailable : GetLabel(Labelable.FALSE));
            booleanExpression.SetLabel(Labelable.SECOND, GetLabel(Labelable.SECOND));
            booleanExpression.Translate();
            trueBody.Translate();
            if (hasFalse) falseBody.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(booleanExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.TRUE)));
            sb.Append(trueBody.PrettyPrint());
            if (hasFalse)
            {
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Labelable.FALSE)));
                sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.SECOND)));
                sb.Append(falseBody.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.FALSE)));
            }
            else
            {
                sb.Append(PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.SECOND)));
            }
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new IfStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
