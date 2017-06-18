using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class TypeNode : ITypeNode
    {
        private string stringRepresentation;

        public string PrettyPrint() => stringRepresentation;
    }
}
