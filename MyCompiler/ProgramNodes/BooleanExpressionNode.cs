using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.ProgramNodes
{
    public class BooleanExpressionNode : IBooleanExpressionNode
    {
        private readonly Translatable translatable;

        public BooleanExpressionNode()
        {
            translatable = new Translatable();
        }

        public IBooleanExpressionChild Child { get; }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            throw new System.NotImplementedException();
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public IExpressionChild NewExpressionChildInstance() => new BooleanExpressionNode();

        public void SetLabel(int i, string label) => Child.SetLabel(i, label);

        public string GetLabel(int i) => Child.GetLabel(i);

    }
}
