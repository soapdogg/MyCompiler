using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAssignOperatorNode : IBinaryAssignOperatorNode
    {
        private readonly Translatable translatable;
        private string op;
        private IExpressionNode leftExpression, rightExpression;
        private bool isLeftArray;

        public string Address => translatable.Address;

        public BinaryAssignOperatorNode()
        {
            translatable = new Translatable();
        }

        public void Parse(ITokenizer tokenizer)
        {
            throw new System.NotImplementedException();
        }

        public string Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            return translatable.Translate();
        }

        public string PrettyPrint()
        {
            return translatable.IsTranslated
                ? PrettyPrintTranslated()
                : leftExpression.PrettyPrint() + op + rightExpression.PrettyPrint();
        }

        public IExpressionChild NewExpressionChildInstance() => new BinaryAssignOperatorNode();

        private string PrettyPrintTranslated()
        {
            return isLeftArray ? PrettyPrintLeftArray() : PrettyPrintLeftVariable();
        }

        private string PrettyPrintLeftArray()
        {
            IBinaryArrayOperatorNode leftChild = (IBinaryArrayOperatorNode) leftExpression.Child;
            string leftChildLValue = leftChild.LValueString; 
            StringBuilder sb = new StringBuilder();
            sb.Append(leftChild.TranslatedInnerExpression);
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                Address + op + rightExpression.Address));
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            return sb.ToString();
        }

        private string PrettyPrintLeftVariable()
        {
            IVariableExpressionNode leftChild = (IVariableExpressionNode) leftExpression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                leftChildLValue + op + rightExpression.Address));
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            return sb.ToString();
        }
    }
}
