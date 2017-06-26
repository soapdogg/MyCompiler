using System.Collections.Generic;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public interface ITokenizer
    {
        List<SimpleCToken> Tokenize();
        List<SimpleCToken> Tokenize(params string[] inputText);
        int Size { get; }
        SimpleCToken Previous();
        SimpleCToken Pop();
        SimpleCToken Peek();
        ITokenType PeekTokenType();
        string PeekValue();
    }
}
