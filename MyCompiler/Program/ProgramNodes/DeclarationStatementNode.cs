using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : Interfaces.IDeclarationStatementNode
    {
        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public Interfaces.IDeclarationChild Child { get; private set; }

    }
}
