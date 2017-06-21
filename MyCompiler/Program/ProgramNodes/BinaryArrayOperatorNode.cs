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
        private string variableType;

        public bool IsLValue { get; }
        public string LValueString => outerExpression.LValueString + "[" + innerExpression.Address + "]";
        public string TranslatedInnerExpression => innerExpression.PrettyPrint();
        public string Address => translatable.Address;

        public BinaryArrayOperatorNode(IVariableExpressionNode outer, IExpressionChild inner)
        {
            translatable = new Translatable();
            outerExpression = outer;
            innerExpression = new ExpressionNode(inner);
        }

        public string Translate()
        {
            innerExpression.Translate();
            variableType = outerExpression.VariableType;
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
