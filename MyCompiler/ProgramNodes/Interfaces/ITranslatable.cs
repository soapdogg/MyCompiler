namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface ITranslatable
    {
        string Address { get; }
        //string VariableType { get; }
        //bool IsTranslated { get; }
        //void MarkAsTranslated();
        string Translate();
    }
}
