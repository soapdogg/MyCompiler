using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryOperatorNode : IUnaryOperatorNode
    {
        private const string PLUS = "+";
        private readonly Translatable translatable;
        private IExpressionNode expression;
        private string op;

        public UnaryOperatorNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

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
