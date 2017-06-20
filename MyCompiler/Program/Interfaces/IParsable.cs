using MyCompiler.Tokenizer;

namespace MyCompiler.Program.Interfaces
{
    public interface IParsable
    {
        void Parse(ITokenizer tokenizer);
    }
}
