using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ConstantNode : IConstantNode
    {
        private readonly Translatable translatable;
        private readonly string stringRepresentation;

        public ConstantNode(string value, bool isInt)
        {
            translatable = new Translatable();
            stringRepresentation = value;
            Type = isInt ? "int" : "double";
        }

        public string Address => translatable.Address;
        public string Type { get; }

        public string Translate()
        {
            translatable.MarkAsTranslated();
            translatable.Address = stringRepresentation;
            return string.Empty;
        }

        public string PrettyPrint() => translatable.IsTranslated ? string.Empty : stringRepresentation;

        public void SetLabel(int i, string label){}

        public string GetLabel(int i) => string.Empty;
    }
}
