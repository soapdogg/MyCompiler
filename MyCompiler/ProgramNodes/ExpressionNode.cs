using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

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
