using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryPostOperatorNode : Interfaces.IUnaryPostOperatorNode
    {
        private readonly Components.Translatable translatable;
        private string op;
        private bool isLeftArray;
        private Interfaces.IExpressionNode expression;

        public UnaryPostOperatorNode()
        {
            translatable = new Components.Translatable();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            throw new System.NotImplementedException();
        }

        public string Translate()
        {
            expression.Translate();
            return translatable.Translate();
        }

        public string PrettyPrint() => translatable.IsTranslated ? PrettyPrintTranslated() : expression.PrettyPrint() + op;

        public Interfaces.IExpressionChild NewExpressionChildInstance() => new UnaryPostOperatorNode();

        private string PrettyPrintTranslated() => isLeftArray ? PrettyPrintLeftArray() : PrettyPrintLeftVariable();

        private string PrettyPrintLeftArray()
        {
            Interfaces.IBinaryArrayOperatorNode leftChild = (Interfaces.IBinaryArrayOperatorNode) expression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(leftChild.TranslatedInnerExpression);
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            sb.Append(Utilities.PrettyPrintingUtilities
                .GetTabbedNewLineAndVariableAssignment(Address, Address + " " + op + " 1"));
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue, Address));
            string xop = op.Contains("+") ? "-" : "+";
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, Address + xop + " 1"));
            return sb.ToString();
        }

        private string PrettyPrintLeftVariable()
        {
            Interfaces.IVariableExpressionNode leftChild = (Interfaces.IVariableExpressionNode) expression.Child;
            string leftChildLValue = leftChild.LValueString;
            StringBuilder sb = new StringBuilder();
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, leftChildLValue));
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(leftChildLValue,
                leftChildLValue + op + " 1"));
            return sb.ToString();
        }
    }
}
