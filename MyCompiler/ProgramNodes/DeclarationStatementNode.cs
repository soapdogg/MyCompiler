using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            SimpleCToken typeToken = tokenizer.Pop();
            SimpleCToken identifierToken = tokenizer.Pop();
            if(tokenizer.PeekTokenType() is LeftParenthesesTokenType) Child = new FunctionDeclarationNode();
            else Child = new VariableDeclarationListNode();
            tokenizer.Push(identifierToken);
            tokenizer.Push(typeToken);
            Child.Parse(tokenizer);
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public IDeclarationChild Child { get; private set; }

    }
}
