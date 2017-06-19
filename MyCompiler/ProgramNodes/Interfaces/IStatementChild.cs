namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IStatementChild : ITranslatable, IPrettyPrintable, IParsable
    {
        IStatementChild NewStatementChildInstance();
    }
}
