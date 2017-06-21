using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
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
