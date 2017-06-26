using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ConstantNode : IConstantNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly string stringRepresentation;

        public ConstantNode(string value, bool isInt)
        {
            translatable = new Translatable();
            typable = new Typable();
            stringRepresentation = value;
            typable.Type = isInt ? "int" : "double";
        }

        public string Address => typable.Address;
        public string Type => typable.Type;

        public void Translate()
        {
            translatable.Translate();
            typable.Address = stringRepresentation;
        }

        public string PrettyPrint() => translatable.IsTranslated ? string.Empty : stringRepresentation;
    }
}
