using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class IfStatementNode : Interfaces.IIfStatementNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private Interfaces.IStatementNode trueBody, falseBody;
        private Interfaces.IBooleanExpressionNode booleanExpression;
        private bool hasFalse;

        public IfStatementNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(3);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //if token
            tokenizer.Pop(); //left parenthese token
            booleanExpression = new BooleanExpressionNode();
            booleanExpression.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            trueBody = new StatementNode();
            trueBody.Parse(tokenizer);
            hasFalse = tokenizer.PeekTokenType() is ElseTokenType;
            if (!hasFalse) return;
            falseBody = new StatementNode();
            falseBody.Parse(tokenizer);
        }

        public string Translate()
        {
            SetLabel(Components.Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            SetLabel(Components.Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            booleanExpression.SetLabel(Components.Labelable.TRUE, GetLabel(Components.Labelable.TRUE));
            SetLabel(Components.Labelable.SECOND, hasFalse ? Utilities.CounterUtilities.GetNextLabelAvailable : GetLabel(Components.Labelable.FALSE));
            booleanExpression.SetLabel(Components.Labelable.SECOND, GetLabel(Components.Labelable.SECOND));
            booleanExpression.Translate();
            trueBody.Translate();
            if (hasFalse) falseBody.Translate();
            return string.Empty;
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(booleanExpression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.TRUE)));
            sb.Append(trueBody.PrettyPrint());
            if (hasFalse)
            {
                sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Components.Labelable.FALSE)));
                sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.SECOND)));
                sb.Append(falseBody.PrettyPrint());
                sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.FALSE)));
            }
            else
            {
                sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.SECOND)));
            }
            return sb.ToString();
        }

        public Interfaces.IStatementChild NewStatementChildInstance() => new IfStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
