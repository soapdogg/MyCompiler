namespace MyCompiler.Program.ProgramNodes.Components.Interfaces
{
    public interface ILabelable
    {
        void SetLabel(int i, string label);

        string GetLabel(int i);
    }
}
