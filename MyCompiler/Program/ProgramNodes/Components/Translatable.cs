using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Components
{
    public class Translatable : ITranslatable
    {
        public bool IsTranslated { get; private set; }

        public void Translate()
        {
            IsTranslated = true;
        }
    }
}
