using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryOperatorNode : IUnaryOperatorNode
    {
        private const string PLUS = "+";
        private readonly Components.Translatable translatable;
        private IExpressionNode expression;
        private string op;

        public UnaryOperatorNode()
        {
            translatable = new Components.Translatable();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            SimpleCToken temp = tokenizer.Pop();
            op = temp.TokenType is BitNegationOperatorTokenType
                ? "~"
                : temp.Value.Contains(PLUS)
                    ? PLUS
                    : "-";
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
        }

        public string Translate()
        {
            if (!op.Equals(PLUS)) return translatable.Translate();
            string a = expression.Translate();
            translatable.MarkAsTranslated();
            translatable.Address = a;
            return a;
        }

        public string PrettyPrint()
        {
            if (!translatable.IsTranslated) return op + expression.PrettyPrint();
            string expressionString = expression.PrettyPrint();
            if (!op.Equals(PLUS))
                expressionString +=
                    Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, op + expression.Address);
            return expressionString;
        }

        public IExpressionChild NewExpressionChildInstance() => new UnaryOperatorNode();
    }
}
