using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryOperatorNode : IUnaryOperatorNode
    {
        private const string PLUS = "+";
        private readonly Translatable translatable;
        private readonly IExpressionNode expression;
        private readonly string op;

        public UnaryOperatorNode(IExpressionChild child, string op)
        {
            translatable = new Translatable();
            expression = new ExpressionNode(child);
            this.op = op;
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
                    PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, op + expression.Address);
            return expressionString;
        }

        public void SetLabel(int i, string label){}

        public string GetLabel(int i) => string.Empty;
    }
}
