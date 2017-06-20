using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class UnaryNotOperatorNode : Interfaces.IUnaryNotOperatorNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private Interfaces.IBooleanExpressionNode innerExpression;

        public UnaryNotOperatorNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(2);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            throw new System.NotImplementedException();
        }

        public string Translate()
        {
            innerExpression.SetLabel(Components.Labelable.TRUE, labelable.GetLabel(Components.Labelable.SECOND));
            innerExpression.SetLabel(Components.Labelable.SECOND, labelable.GetLabel(Components.Labelable.TRUE));
            innerExpression.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint() => innerExpression.PrettyPrint();

        public Interfaces.IBooleanExpressionChild NewBooleanExpressionChildInstance => new UnaryNotOperatorNode();
    }
}
