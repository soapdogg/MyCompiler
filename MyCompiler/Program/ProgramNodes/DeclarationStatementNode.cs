using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : Interfaces.IDeclarationStatementNode
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

        public Interfaces.IDeclarationChild Child { get; private set; }

    }
}
