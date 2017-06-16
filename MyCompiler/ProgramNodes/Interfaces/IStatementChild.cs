namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IStatementChild : ITranslatable, IPrettyPrintable
    {
        IStatementChild NewStatementChildInstance();
    }
}
