using System;
using System.Collections.Generic;
using System.Linq;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ExpressionNode : IExpressionNode
    {
        private readonly Components.Translatable translatable;
        private static readonly IDictionary<ITokenType, IExpressionChild> firstPrecedenceTokenType;

        static ExpressionNode()
        {
            
        }

        public ExpressionNode()
        {
            translatable = new Components.Translatable();
        }

        public IExpressionChild Child { get; private set; }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {

        }

        public string Translate()
        {
            string address = Child.Translate();
            translatable.Address = address;
            translatable.MarkAsTranslated();
            return address;
        }

        public string PrettyPrint() => Child.PrettyPrint();
    }
}
