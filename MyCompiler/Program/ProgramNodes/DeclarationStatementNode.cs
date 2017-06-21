using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public IDeclarationChild Child { get; private set; }

    }
}
