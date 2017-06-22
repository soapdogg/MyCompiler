using System.Text;
using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAssignNode : IBinaryAssignNode
    {
        private readonly Translatable translatable;
        private readonly bool isLeftArray;
        private readonly IExpressionNode leftExpression;
        private readonly IExpressionNode rightExpression;

        public string Address => translatable.Address;

        public BinaryAssignNode(IExpressionChild left, IExpressionChild right)
        {
            translatable = new Translatable();
            leftExpression = new ExpressionNode(left);
            var value = leftExpression.Child as ILeftHandValue;
            value?.SetAsLValue();
            rightExpression = new ExpressionNode(right);
            isLeftArray = leftExpression.Child is BinaryArrayOperatorNode;
        }

        public string Translate()
        {
            leftExpression.Translate();
            string rightAddress = rightExpression.Translate();
            translatable.MarkAsTranslated();
            if (rightAddress.Equals(string.Empty))
            {
                translatable.Address = rightExpression.Child.Address;
                return string.Empty;
            }
            translatable.Address = rightAddress;
            return rightAddress;
        }

        public string PrettyPrint()
        {
            return translatable.IsTranslated
                ? PrettyPrintTranslated()
                : PrettyPrintingUtilities.GetVariableAssignment(leftExpression.PrettyPrint(),
                    rightExpression.PrettyPrint());
        }

        public void SetLabel(int i, string label) { }

        public string GetLabel(int i) => string.Empty;

        private string PrettyPrintTranslated()
        {
            string innerExpressionString = string.Empty;
            string lValueString;
            if (isLeftArray)
            {
                IBinaryArrayOperatorNode leftChild = (IBinaryArrayOperatorNode) leftExpression.Child;
                innerExpressionString = leftChild.TranslatedInnerExpression;
                lValueString = leftChild.LValueString;
            }
            else
            {
                IVariableExpressionNode leftChild = (IVariableExpressionNode) leftExpression.Child;
                lValueString = leftChild.LValueString;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(innerExpressionString);
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(lValueString,
                rightExpression.Address));
            return sb.ToString();
        }

        public string Type => "bool";
    }
}
