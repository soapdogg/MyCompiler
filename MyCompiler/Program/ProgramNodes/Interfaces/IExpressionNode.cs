using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IExpressionNode : ITranslatable, IPrettyPrintable, IParsable, ILabelable, ITypable
    {
        IExpressionChild Child { get; }
    }
}
