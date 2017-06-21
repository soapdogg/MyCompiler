using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ForStatementNode : IForStatementNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private IExpressionNode initExpressionNode, incrementExpressionNode;
        private IBooleanExpressionNode testExpressionNode;
        private IStatementNode body;

        public ForStatementNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(3);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // for token
            tokenizer.Pop(); //left parenthese token
            initExpressionNode = new ExpressionNode();
            initExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); // semicolon token
            testExpressionNode = new BooleanExpressionNode();
            testExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); // semicolon token
            incrementExpressionNode = new ExpressionNode();
            incrementExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            body = new StatementNode();
            body.Parse(tokenizer);
        }

        public string Translate()
        {
            testExpressionNode.SetLabel(Components.Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            SetLabel(Components.Labelable.START, Utilities.CounterUtilities.GetNextLabelAvailable);
            testExpressionNode.SetLabel(Components.Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            initExpressionNode.Translate();
            testExpressionNode.Translate();
            incrementExpressionNode.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(initExpressionNode.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Components.Labelable.START)));
            sb.Append(testExpressionNode.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(testExpressionNode.GetLabel(Components.Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(incrementExpressionNode.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Components.Labelable.START)));
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(testExpressionNode.GetLabel(Components.Labelable.SECOND)));
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new ForStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
