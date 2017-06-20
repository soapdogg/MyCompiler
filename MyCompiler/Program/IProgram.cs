using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program
{
    interface IProgram : IParsable, ITranslatable, IPrettyPrintable
    {
    }
}
