using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class IfStatementNode : IIfStatementNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IStatementNode trueBody, falseBody;
        private IExpressionNode booleanExpression;
        private bool hasFalse;

        public IfStatementNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(3);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //if token
            tokenizer.Pop(); //left parenthese token
            booleanExpression = new ExpressionNode();
            booleanExpression.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            trueBody = new StatementNode();
            trueBody.Parse(tokenizer);
            hasFalse = tokenizer.PeekTokenType() is ElseTokenType;
            if (!hasFalse) return;
            tokenizer.Pop(); //else token
            falseBody = new StatementNode();
            falseBody.Parse(tokenizer);
        }

        public string Translate()
        {
            SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            booleanExpression.SetLabel(Labelable.TRUE, GetLabel(Labelable.TRUE));
            SetLabel(Labelable.SECOND, hasFalse ? CounterUtilities.GetNextLabelAvailable : GetLabel(Labelable.FALSE));
            booleanExpression.SetLabel(Labelable.SECOND, GetLabel(Labelable.SECOND));
            booleanExpression.Translate();
            trueBody.Translate();
            if (hasFalse) falseBody.Translate();
            return string.Empty;
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
