using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Components
{
    public class Labelable : ILabelable
    {
        private readonly string[] labels;
        public const int TRUE = 0, SECOND = 1, FALSE = 2, START = 2;

        public Labelable(int length)
        {
            labels = new string[length];
        }
       
        public void SetLabel(int i, string label) => labels[i] = label;

        public string GetLabel(int i) => labels[i];
    }
}
