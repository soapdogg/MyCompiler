namespace MyCompiler.Program.Interfaces
{
    public interface ITranslatable
    {
        string Type { get; }
        string Address { get; }
        string Translate();
    }
}
