using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class DeclarationStatementNode : IDeclarationStatementNode
    {
        public string Address => string.Empty;

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public IDeclarationChild Child { get; }
    }
}
