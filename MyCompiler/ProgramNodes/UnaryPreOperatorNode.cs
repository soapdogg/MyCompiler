using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class UnaryPreOperatorNode : IUnaryPreOperatorNode
    {
        private readonly Translatable translatable;
        private string op;
        private IExpressionNode expression;
        private bool isLeftArray;

        public UnaryPreOperatorNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            expression.Translate();
            return translatable.Translate();
        }

        public string PrettyPrint()
        {
            throw new System.NotImplementedException();
        }

        public IExpressionChild NewExpressionChildInstance() => new UnaryPreOperatorNode();
    }
}
