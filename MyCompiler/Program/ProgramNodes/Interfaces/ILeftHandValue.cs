namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface ILeftHandValue
    {
        bool IsLValue { get; }
        string LValueString { get; }
    }
}
