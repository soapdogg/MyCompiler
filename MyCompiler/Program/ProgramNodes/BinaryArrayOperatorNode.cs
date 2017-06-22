using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryArrayOperatorNode : IBinaryArrayOperatorNode
    {
        private readonly Translatable translatable;
        private readonly IVariableExpressionNode outerExpression;
        private readonly IExpressionNode innerExpression;

        public bool IsLValue { get; private set; }
        public string Type => translatable.Type;
        public string LValueString => outerExpression.LValueString + "[" + innerExpression.Address + "]";
        public void SetAsLValue() => IsLValue = true;

        public string TranslatedInnerExpression => innerExpression.PrettyPrint();
        public string Address => translatable.Address;

        public BinaryArrayOperatorNode(IVariableExpressionNode outer, IExpressionChild inner)
        {
            translatable = new Translatable();
            outerExpression = outer;
            translatable.Type = outer.Type;
            innerExpression = new ExpressionNode(inner);
        }

        public string Translate()
        {
            innerExpression.Translate();
            if (IsLValue)
            {
                translatable.MarkAsTranslated();
                return string.Empty;
            }
            return translatable.Translate();
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

        public void SetLabel(int i, string label){}

        public string GetLabel(int i) => string.Empty;
    }
}
