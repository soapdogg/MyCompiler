using System.Text;
using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Peek(), TokenType.Type);
            SimpleCToken typeToken = tokenizer.Pop();
            TokenConsumer.Consume(tokenizer.Peek(), TokenType.Identifier);
            SimpleCToken identifierToken = tokenizer.Pop();
            Child = tokenizer.PeekTokenType().GetHashCode() == (int) TokenType.LParent
                ? (IDeclarationChild) new FunctionDeclarationNode(typeToken.Value, identifierToken.Value)
                : new VariableDeclarationListNode(typeToken.Value, identifierToken.Value);
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
