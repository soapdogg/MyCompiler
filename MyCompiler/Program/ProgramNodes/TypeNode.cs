using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class TypeNode : ITypeNode
    {
        private string stringRepresentation;

        public void Parse(ITokenizer tokenizer) => stringRepresentation = tokenizer.Pop().Value;

        public string PrettyPrint() => stringRepresentation;
    }
}
