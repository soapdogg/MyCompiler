namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IStatementNode : ITranslatable, IPrettyPrintable
    {
        IStatementChild Child { get; }
    }
}
