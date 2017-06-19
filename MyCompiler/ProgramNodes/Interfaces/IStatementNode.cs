namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IStatementNode : ITranslatable, IPrettyPrintable, IParsable
    {
        IStatementChild Child { get; }
    }
}
