namespace MyCompiler.Program.Interfaces
{
    public interface ILeftHandValue
    {
        bool IsLValue { get; }
        string LValueString { get; }
        void SetAsLValue();
    }
}
