namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IStatementChild : ITranslatable
    {
        IStatementChild NewStatementChildInstance();
    }
}
