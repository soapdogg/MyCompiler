
using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IProgramRootNode : IPrettyPrintable, ITranslatable, IParsable
    {
    }
}
