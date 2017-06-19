
namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IDeclarationStatementNode : ITranslatable, IPrettyPrintable, IParsable
    {
        IDeclarationChild Child { get; }
    }
}
