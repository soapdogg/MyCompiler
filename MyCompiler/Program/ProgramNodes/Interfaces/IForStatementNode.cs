using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IForStatementNode : IStatementChild, ILabelable, ITranslatable
    {
    }
}
