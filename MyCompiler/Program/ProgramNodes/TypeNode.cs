using MyCompiler.Program.ProgramNodes.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class TypeNode : ITypeNode
    {
        private readonly string stringRepresentation;

        public TypeNode(string type)
        {
            stringRepresentation = type;
        }

        public string PrettyPrint() => stringRepresentation;
    }
}
