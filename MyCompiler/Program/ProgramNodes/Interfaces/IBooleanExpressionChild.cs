using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Components.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IBooleanExpressionChild : ITranslatable, ILabelable, IPrettyPrintable, IParsable
    {
        IBooleanExpressionChild NewBooleanExpressionChildInstance { get; }
    }
}
