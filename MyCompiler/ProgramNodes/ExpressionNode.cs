using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.ProgramNodes
{
    public class ExpressionNode : IExpressionNode
    {
        private readonly Translatable translatable;

        public ExpressionNode()
        {
            translatable = new Translatable();
        }

        public IExpressionChild Child { get; }

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
