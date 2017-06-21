using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryArrayOperatorNode : IBinaryArrayOperatorNode
    {
        private readonly Translatable translatable;
        private IVariableExpressionNode outerExpression;
        private IExpressionNode innerExpression;
        private string variableType;

        public bool IsLValue { get; }
        public string LValueString => outerExpression.LValueString + "[" + innerExpression.Address + "]";
        public string TranslatedInnerExpression => innerExpression.PrettyPrint();
        public string Address => translatable.Address;

        public BinaryArrayOperatorNode()
        {
            translatable = new Translatable();
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
                sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
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

        public IExpressionChild NewExpressionChildInstance() => new BinaryArrayOperatorNode();

    }
}
