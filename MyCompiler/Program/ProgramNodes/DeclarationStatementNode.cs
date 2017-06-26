using System.Text;
using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public void Parse(ITokenizer tokenizer)
        {
            SimpleCToken typeToken = tokenizer.Pop();
            SimpleCToken identifierToken = tokenizer.Pop();
            if (tokenizer.PeekTokenType() is LeftParenthesesTokenType)
                Child = new FunctionDeclarationNode(typeToken.Value, identifierToken.Value);
            else
                Child = new VariableDeclarationListNode(typeToken.Value, identifierToken.Value);
            Child.Parse(tokenizer);
        }

        public void Translate()
        {
            ITranslatable translatable = Child as ITranslatable;
            translatable?.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Child.PrettyPrint());
            sb.Append('\n');
            return sb.ToString();
        }

        public IDeclarationChild Child { get; private set; }

    }
}
