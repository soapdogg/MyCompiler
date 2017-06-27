using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class DoWhileStatementNode : IDoWhileStatementNode
    {
        private IExpressionNode expression;
        private IStatementNode body;

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Do); 
            body = new StatementNode();
            body.Parse(tokenizer);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.While);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LParent);
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RParent); 
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Semi);
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
    }
}
