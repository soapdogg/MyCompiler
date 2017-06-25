using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryPreOperatorNode : IUnaryPreOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly string op;
        private readonly IExpressionNode expression;
        private readonly bool isLeftArray;

        public UnaryPreOperatorNode(IExpressionChild child, string op)
        {
            translatable = new Translatable();
            typable = new Typable();
            expression = new ExpressionNode(child);
            this.op = op;
            isLeftArray = expression.Child is BinaryArrayOperatorNode;
            typable.Type = expression.Type;
        }

        public string Type => typable.Type;
        public string Address => typable.Address;

        public void Translate()
        {
            expression.Translate();
            translatable.Translate();
            typable.GenerateNewAddress();
        }

        public string PrettyPrint() => translatable.IsTranslated ? PrettyPrintTranslated() : expression.PrettyPrint() + op;

        public void SetLabel(int i, string label) { }

        public string GetLabel(int i) => string.Empty;

        private string PrettyPrintTranslated() => isLeftArray ? PrettyPrintLeftArray() : PrettyPrintLeftVariable();

        private string PrettyPrintLeftArray()
        {
            IBinaryArrayOperatorNode leftChild = (IBinaryArrayOperatorNode) expression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(leftChild.TranslatedInnerExpression);
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            sb.Append(PrettyPrintingUtilities
                .GetTabbedNewLineAndVariableAssignment(Address, Address + " " + op + " 1"));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            return sb.ToString();
        }

        private string PrettyPrintLeftVariable()
        {
            IVariableExpressionNode leftChild = (IVariableExpressionNode)expression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue,
                leftChildLValue + " " + op + " 1"));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            return sb.ToString();
        }
    }
}
