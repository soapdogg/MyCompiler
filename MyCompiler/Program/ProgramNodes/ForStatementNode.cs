using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ForStatementNode : IForStatementNode
    {
        private readonly Labelable labelable;
        private IExpressionNode initExpressionNode, incrementExpressionNode;
        private IExpressionNode testExpressionNode;
        private IStatementNode body;

        public ForStatementNode()
        {
            labelable = new Labelable(3);
        }

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); // for token
            tokenizer.Pop(); //left parenthese token
            initExpressionNode = new ExpressionNode();
            initExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); // semicolon token
            testExpressionNode = new ExpressionNode();
            testExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); // semicolon token
            incrementExpressionNode = new ExpressionNode();
            incrementExpressionNode.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            body = new StatementNode();
            body.Parse(tokenizer);
        }

        public void Translate()
        {
            testExpressionNode.SetLabel(Labelable.SECOND, CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.START, CounterUtilities.GetNextLabelAvailable);
            testExpressionNode.SetLabel(Labelable.TRUE, CounterUtilities.GetNextLabelAvailable);
            initExpressionNode.Translate();
            testExpressionNode.Translate();
            incrementExpressionNode.Translate();
            body.Translate();
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
