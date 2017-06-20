using System.Collections.Generic;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public interface ITokenizer
    {
        LinkedList<SimpleCToken> Tokenize();
        LinkedList<SimpleCToken> Tokenize(params string[] inputText);
        int Size { get; }
        SimpleCToken Pop();
        SimpleCToken Peek();
        ITokenType PeekTokenType();
        string PeekValue();
    }
}
