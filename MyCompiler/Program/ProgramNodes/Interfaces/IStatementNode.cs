using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IStatementNode : ITranslatable, IPrettyPrintable, IParsable
    {
        IStatementChild Child { get; }
    }
}
