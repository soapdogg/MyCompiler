using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class TypeNode : Interfaces.ITypeNode
    {
        private string stringRepresentation;

        public void Parse(ITokenizer tokenizer) => stringRepresentation = tokenizer.Pop().Value;

        public string PrettyPrint() => stringRepresentation;
    }
}
