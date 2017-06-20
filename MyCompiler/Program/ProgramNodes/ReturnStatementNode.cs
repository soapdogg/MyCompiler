using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ReturnStatementNode : Interfaces.IReturnStatementNode
    {
        private readonly Components.Translatable translatable;
        private bool shouldBeTranslated;
        private Interfaces.IExpressionNode expression;

        public ReturnStatementNode()
        {
            translatable = new Components.Translatable();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //return token
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            shouldBeTranslated = false; //expression.Child
            tokenizer.Pop(); //semicolon token
        }

        public string Translate()
        {
            if (!shouldBeTranslated) return string.Empty;
            translatable.MarkAsTranslated();
            return expression.Translate();
        }

        public Interfaces.IStatementChild NewStatementChildInstance() => new ReturnStatementNode();

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(expression.PrettyPrint());
                sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.Address);
                sb.Append(";");
            }
            else
            {
                sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.PrettyPrint());
                sb.Append(";");
            }
            return sb.ToString();
        }
    }
}
