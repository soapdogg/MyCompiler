using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ExpressionStatementNode : IExpressionStatementNode
    {
        private readonly Translatable translatable;
        private IExpressionNode expression;

        public ExpressionStatementNode()
        {
            translatable = new Translatable();
        }

        public void Parse(ITokenizer tokenizer)
        {
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); // semicolon
        }

        public void Translate()
        {
            translatable.Translate();
            expression.Translate();
        }

        public string PrettyPrint() => translatable.IsTranslated ? expression.PrettyPrint() : expression.PrettyPrint() + ";";

        public IStatementChild NewStatementChildInstance() => new ExpressionStatementNode();
    }
}
