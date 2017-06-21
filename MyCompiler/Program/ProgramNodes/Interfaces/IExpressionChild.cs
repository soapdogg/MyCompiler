using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IExpressionChild : ITranslatable, ILabelable, IPrettyPrintable
    {
    }
}
