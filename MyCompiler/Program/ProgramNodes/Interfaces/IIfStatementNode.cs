using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IIfStatementNode : IStatementChild, ILabelable, ITranslatable
    {
    }
}
