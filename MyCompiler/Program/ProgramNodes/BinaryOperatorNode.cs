using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryOperatorNode : Interfaces.IBinaryOperatorNode
    {
        private readonly Components.Translatable translatable;
        private Interfaces.IExpressionNode leftExpression, rightExpression;
        private string op;

        public BinaryOperatorNode()
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
                sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address,
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

        public Interfaces.IExpressionChild NewExpressionChildInstance() => new BinaryOperatorNode();
    }
}
