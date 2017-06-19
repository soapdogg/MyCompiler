using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.ProgramNodes
{
    public class ExpressionStatementNode : IExpressionStatementNode
    {
        private readonly Translatable translatable;
        private IExpressionNode expression;

        public ExpressionStatementNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); // semicolon
        }

        public string Translate()
        {
            translatable.MarkAsTranslated();
            return expression.Translate();
        }

        public string PrettyPrint() => translatable.IsTranslated ? expression.PrettyPrint() : expression.PrettyPrint() + ";";

        public IStatementChild NewStatementChildInstance() => new ExpressionStatementNode();
    }
}
