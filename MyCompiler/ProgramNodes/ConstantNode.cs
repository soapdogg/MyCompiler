using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class ConstantNode : IConstantNode
    {
        private readonly Translatable translatable;
        private string stringRepresentation;

        public ConstantNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            translatable.MarkAsTranslated();
            translatable.Address = stringRepresentation;
            return string.Empty;
        }

        public string PrettyPrint() => translatable.IsTranslated ? string.Empty : stringRepresentation;

        public IExpressionChild NewExpressionChildInstance() => new ConstantNode();
    }
}
