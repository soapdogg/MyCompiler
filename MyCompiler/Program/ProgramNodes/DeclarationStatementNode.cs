using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            SimpleCToken typeToken = tokenizer.Pop();
            SimpleCToken identifierToken = tokenizer.Pop();
            if (tokenizer.PeekTokenType() is LeftParenthesesTokenType)
                Child = new FunctionDeclarationNode(typeToken.Value, identifierToken.Value);
            else
            {
                Child = new VariableDeclarationListNode();
                tokenizer.Retreat();
                tokenizer.Retreat();
            }
            Child.Parse(tokenizer);
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public IDeclarationChild Child { get; private set; }

    }
}
