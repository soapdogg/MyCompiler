using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IStatementChild : ITranslatable, IPrettyPrintable, IParsable
    {
        IStatementChild NewStatementChildInstance();
    }
}
