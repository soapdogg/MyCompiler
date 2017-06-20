
using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IDeclarationStatementNode : ITranslatable, IPrettyPrintable, IParsable
    {
        IDeclarationChild Child { get; }
    }
}
