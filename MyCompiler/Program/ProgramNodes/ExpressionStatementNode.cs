using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ExpressionStatementNode : Interfaces.IExpressionStatementNode
    {
        private readonly Components.Translatable translatable;
        private Interfaces.IExpressionNode expression;

        public ExpressionStatementNode()
        {
            translatable = new Components.Translatable();
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

        public Interfaces.IStatementChild NewStatementChildInstance() => new ExpressionStatementNode();
    }
}
