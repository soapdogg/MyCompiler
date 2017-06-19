
namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IDeclarationStatementNode : ITranslatable, IPrettyPrintable
    {
        IDeclarationChild Child { get; }
    }
}
