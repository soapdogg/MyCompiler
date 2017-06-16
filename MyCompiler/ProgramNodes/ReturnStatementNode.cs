using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class ReturnStatementNode : IReturnStatementNode
    {
        private readonly Translatable translatable;
        private bool shouldBeTranslated;
        private IExpressionNode expression;

        public ReturnStatementNode()
        {
            translatable = new Translatable();
        }

        public string Address
        {
            get => translatable.Address;
            set => translatable.Address = value;
        }

        public string Translate()
        {
            if (!shouldBeTranslated) return string.Empty;
            translatable.MarkAsTranslated();
            return expression.Translate();
        }

        public IStatementChild NewStatementChildInstance() => new ReturnStatementNode();

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(expression.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.Address);
                sb.Append(";");
            }
            else
            {
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.PrettyPrint());
                sb.Append(";");
            }
            return sb.ToString();
        }
    }
}
