using System.Collections.Generic;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public interface ITokenizer
    {
        IList<SimpleCToken> Tokenize();
        IList<SimpleCToken> Tokenize(params string[] inputText);
        int Size { get; }
        SimpleCToken Pop();
        SimpleCToken Peek();
        ITokenType PeekTokenType();
        string PeekValue();
    }
}
