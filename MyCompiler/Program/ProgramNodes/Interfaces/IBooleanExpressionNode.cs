using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Components.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IBooleanExpressionNode :  ITranslatable, IPrettyPrintable, ILabelable, IParsable
    {
    }
}
