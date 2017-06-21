using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryPreOperatorNode : IUnaryPreOperatorNode
    {
        private readonly Translatable translatable;
        private string op;
        private IExpressionNode expression;
        private bool isLeftArray;

        public UnaryPreOperatorNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            expression.Translate();
            return translatable.Translate();
        }

        public string PrettyPrint() => translatable.IsTranslated ? PrettyPrintTranslated() : expression.PrettyPrint() + op;

        public IExpressionChild NewExpressionChildInstance() => new UnaryPreOperatorNode();

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
                leftChildLValue + op + " 1"));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            return sb.ToString();
        }
    }
}
