using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IStatementChild : IPrettyPrintable, IParsable
    {
        IStatementChild NewStatementChildInstance();
    }
}
