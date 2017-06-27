using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryOperatorNode : IBinaryOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly IExpressionNode leftExpression, rightExpression;
        private readonly string op;

        public BinaryOperatorNode(IExpressionChild left, IExpressionChild right, string op)
        {
            translatable = new Translatable();
            typable = new Typable();
            leftExpression = new ExpressionNode(left);
            rightExpression = new ExpressionNode(right);
            this.op = op;
            typable.Type = leftExpression.Type.Equals("double") || rightExpression.Type.Equals("double")
                ? "double"
                : "int";
        }

        public string Address => typable.Address;
        public string Type => typable.Type;

        public void Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            translatable.Translate();
            typable.GenerateNewAddress();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(leftExpression.PrettyPrint());
                sb.Append(rightExpression.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
                    $"{leftExpression.Address} {op} {rightExpression.Address}"));
            }
            else
            {
                sb.Append(leftExpression.PrettyPrint());
                sb.Append(op);
                sb.Append(rightExpression.PrettyPrint());
            }
            return sb.ToString();
        }
    }
}
