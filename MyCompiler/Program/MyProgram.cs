using MyCompiler.Program.ProgramNodes;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program
{
    public class MyProgram : IProgram
    {
        private readonly IProgramRootNode root;

        public MyProgram()
        {
            root = new ProgramRootNode();
        }

        public void Parse(ITokenizer tokenizer) => root.Parse(tokenizer);

        public string Address => string.Empty;

        public string Translate() => root.Translate();

        public string PrettyPrint() => root.PrettyPrint();
    }
}
