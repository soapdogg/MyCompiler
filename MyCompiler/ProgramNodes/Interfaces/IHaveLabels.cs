namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IHaveLabels
    {
        string [] Labels { get; }

        void SetLabel(int i, string label);

        string GetLabel(int i);
    }
}
