using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAssignNode : IBinaryAssignNode
    {
        private readonly Components.Translatable translatable;
        private bool isLeftArray;
        private IExpressionNode leftExpression, rightExpression;

        public string Address => translatable.Address;

        public BinaryAssignNode()
        {
            translatable = new Components.Translatable();
        }

        public void Parse(ITokenizer tokenizer)
        {
            throw new System.NotImplementedException();
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
                : Utilities.PrettyPrintingUtilities.GetVariableAssignment(leftExpression.PrettyPrint(),
                    rightExpression.PrettyPrint());
        }

        public IExpressionChild NewExpressionChildInstance() => new BinaryAssignNode();

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
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(lValueString,
                rightExpression.Address));
            return sb.ToString();
        }
    }
}
