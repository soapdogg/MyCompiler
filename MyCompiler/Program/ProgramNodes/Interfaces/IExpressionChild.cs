using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IExpressionChild : ITranslatable, IPrettyPrintable, IParsable
    {
        IExpressionChild NewExpressionChildInstance();
    }
}
