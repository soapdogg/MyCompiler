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
        private readonly Typable typable;
        private readonly bool isLeftArray;
        private readonly IExpressionNode leftExpression;
        private readonly IExpressionNode rightExpression;

        public string Address => typable.Address;
        public string Type => typable.Type;

        public BinaryAssignNode(IExpressionChild left, IExpressionChild right)
        {
            translatable = new Translatable();
            typable = new Typable();
            leftExpression = new ExpressionNode(left);
            var value = leftExpression.Child as ILeftHandValue;
            value?.SetAsLValue();
            rightExpression = new ExpressionNode(right);
            isLeftArray = leftExpression.Child is BinaryArrayOperatorNode;
        }

        public void Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            string rightAddress = rightExpression.Address;
            translatable.Translate();
            ITypable t = rightExpression.Child as ITypable;
            typable.Address = rightAddress.Equals(string.Empty) && t != null ? t.Address : rightAddress;
        }

        public string PrettyPrint()
        {
            return translatable.IsTranslated
                ? PrettyPrintTranslated()
                : PrettyPrintingUtilities.GetVariableAssignment(leftExpression.PrettyPrint(),
                    rightExpression.PrettyPrint());
        }

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
    }
}
