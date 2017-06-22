namespace MyCompiler.Program.Interfaces
{
    public interface ILabelable
    {
        void SetLabel(int i, string label);

        string GetLabel(int i);
    }
}
