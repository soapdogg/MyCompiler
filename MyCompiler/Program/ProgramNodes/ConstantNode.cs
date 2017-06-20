using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class ConstantNode : Interfaces.IConstantNode
    {
        private readonly Components.Translatable translatable;
        private string stringRepresentation, variableType;

        public ConstantNode()
        {
            translatable = new Components.Translatable();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            stringRepresentation = tokenizer.Pop().Value; //floating point or integer constant
        }

        public string Translate()
        {
            translatable.MarkAsTranslated();
            translatable.Address = stringRepresentation;
            return string.Empty;
        }

        public string PrettyPrint() => translatable.IsTranslated ? string.Empty : stringRepresentation;

        public Interfaces.IExpressionChild NewExpressionChildInstance() => new ConstantNode();
    }
}
