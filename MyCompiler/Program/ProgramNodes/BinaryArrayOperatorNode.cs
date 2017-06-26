using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryArrayOperatorNode : IBinaryArrayOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly IVariableExpressionNode outerExpression;
        private readonly IExpressionNode innerExpression;

        public bool IsLValue { get; private set; }
        public string Type => typable.Type;
        public string LValueString => outerExpression.LValueString + "[" + innerExpression.Address + "]";
        public void SetAsLValue() => IsLValue = true;

        public string TranslatedInnerExpression => innerExpression.PrettyPrint();
        public string Address => typable.Address;

        public BinaryArrayOperatorNode(IVariableExpressionNode outer, IExpressionChild inner)
        {
            translatable = new Translatable();
            typable = new Typable();
            outerExpression = outer;
            typable.Type = outer.Type;
            innerExpression = new ExpressionNode(inner);
        }

        public void Translate()
        {
            innerExpression.Translate();
            translatable.Translate();
            if (!IsLValue) typable.Address = typable.GenerateNewAddress();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(innerExpression.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append(Address);
                sb.Append(" = ");
                sb.Append(LValueString);
                sb.Append(";");
            }
            else
            {
                sb.Append(outerExpression.PrettyPrint());
                sb.Append("[");
                sb.Append(innerExpression.PrettyPrint());
                sb.Append("]");
            }
            return sb.ToString();
        }
    }
}
