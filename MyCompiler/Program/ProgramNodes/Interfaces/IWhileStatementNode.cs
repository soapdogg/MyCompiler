using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IWhileStatementNode : IStatementChild, ILabelable, ITranslatable
    {
    }
}
