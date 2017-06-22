using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryOperatorNode : IBinaryOperatorNode
    {
        private readonly Translatable translatable;
        private readonly IExpressionNode leftExpression, rightExpression;
        private readonly string op;

        public BinaryOperatorNode(IExpressionChild left, IExpressionChild right, string op)
        {
            translatable = new Translatable();
            leftExpression = new ExpressionNode(left);
            rightExpression = new ExpressionNode(right);
            this.op = op;
            translatable.Type = leftExpression.Type.Equals("double") || rightExpression.Type.Equals("double")
                ? "double"
                : "int";
        }

        public string Address => translatable.Address;
        public string Type => translatable.Type;

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
                    leftExpression.Address + " " + op + " " + rightExpression.Address));
            }
            else
            {
                sb.Append(leftExpression.PrettyPrint());
                sb.Append(op);
                sb.Append(rightExpression.PrettyPrint());
            }
            return sb.ToString();
        }

        public void SetLabel(int i, string label) { }

        public string GetLabel(int i) => string.Empty;
    }
}
