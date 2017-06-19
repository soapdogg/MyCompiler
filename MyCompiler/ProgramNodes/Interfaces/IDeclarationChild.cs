namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IDeclarationChild : ITranslatable, IPrettyPrintable
    {
        IDeclarationChild NewDeclarationChildInstance { get; }
    }
}
