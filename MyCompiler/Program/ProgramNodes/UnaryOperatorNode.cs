using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryOperatorNode : IUnaryOperatorNode
    {
        private const string PLUS = "+";
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly IExpressionNode expression;
        private readonly string op;

        public UnaryOperatorNode(IExpressionChild child, string op)
        {
            translatable = new Translatable();
            typable = new Typable();
            expression = new ExpressionNode(child);
            this.op = op;
            typable.Type = expression.Type;
        }

        public string Address => typable.Address;
        public string Type => typable.Type;

        public void Translate()
        {
            expression.Translate();
            string a = expression.Address;
            translatable.Translate();
            if (!op.Equals(PLUS)) typable.GenerateNewAddress();
            else typable.Address = a;
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
