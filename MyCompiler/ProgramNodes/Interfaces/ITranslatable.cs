using System;

namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface ITranslatable
    {
        bool IsTranslated { get; }
        void MarkAsTranslated();
        string Translate();
        string Address { get; set; }
        string VariableType { get; }
    }
}
