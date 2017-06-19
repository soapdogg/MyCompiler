namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IDeclarationChild : ITranslatable, IPrettyPrintable, IParsable
    {
        IDeclarationChild NewDeclarationChildInstance { get; }
    }
}
