using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ExpressionNode : IExpressionNode
    {
        private readonly Translatable translatable;

        public ExpressionNode()
        {
            translatable = new Translatable();
        }

        public ExpressionNode(IExpressionChild child)
        {
            translatable = new Translatable();
            Child = child;
        }

        public IExpressionChild Child { get; private set; }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            Child = ExpressionChildGenerator.ParseExpression(tokenizer);
        }

        public string Translate()
        {
            string address = Child.Translate();
            translatable.Address = address;
            translatable.MarkAsTranslated();
            return address;
        }

        public string PrettyPrint() => Child.PrettyPrint();

        public void SetLabel(int i, string label) => Child.SetLabel(i, label);

        public string GetLabel(int i) => Child.GetLabel(i);
    }
}
