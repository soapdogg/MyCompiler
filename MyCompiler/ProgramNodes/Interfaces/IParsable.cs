using MyCompiler.Tokenizer;

namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IParsable
    {
        void Parse(ITokenizer tokenizer);
    }
}
