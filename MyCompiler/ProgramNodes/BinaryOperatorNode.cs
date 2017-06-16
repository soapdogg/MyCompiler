using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class BinaryOperatorNode : IBinaryOperatorNode
    {
        private readonly Translatable translatable;
        private IExpressionNode leftExpression, rightExpression;
        private string op;

        public BinaryOperatorNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            return translatable.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(leftExpression.PrettyPrint());
                sb.Append(rightExpression.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                    leftExpression.Address + op + rightExpression.Address));
            }
            else
            {
                sb.Append(leftExpression.PrettyPrint());
                sb.Append(op);
                sb.Append(rightExpression.PrettyPrint());
            }
            return sb.ToString();
        }

        public IExpressionChild NewExpressionChildInstance() => new BinaryOperatorNode();
    }
}
