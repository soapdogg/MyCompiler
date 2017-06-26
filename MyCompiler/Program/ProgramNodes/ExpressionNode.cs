using MyCompiler.Program.Interfaces;
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
        public string Type
        {
            get
            {
                ITypable t = Child as ITypable;
                return t != null ? t.Type : string.Empty;
            }
        }

        public string Address
        {
            get
            {
                ITypable t = Child as ITypable;
                return t != null ? t.Address: string.Empty;
            }
        }

        public void Parse(ITokenizer tokenizer)
        {
            Child = ExpressionChildGenerator.ParseExpression(tokenizer);
        }

        public void Translate()
        {
            Child.Translate();
            translatable.Translate();
        }

        public string PrettyPrint() => Child.PrettyPrint();

        public void SetLabel(int i, string label)
        {
            ILabelable l = Child as ILabelable;
            l?.SetLabel(i, label);
        }

        public string GetLabel(int i)
        {
            ILabelable l = Child as ILabelable;
            return l != null ? l.GetLabel(i) : string.Empty;
        }
    }
}
