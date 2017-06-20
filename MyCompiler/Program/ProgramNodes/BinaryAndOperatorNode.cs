using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryAndOperatorNode : IBinaryAndOperatorNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private IBooleanExpressionNode leftExpression, rightExpression;

        public BinaryAndOperatorNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(2);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            LinkedList<SimpleCToken> temp = new LinkedList<SimpleCToken>();
            while (!(tokenizer.PeekTokenType() is BinaryAndOperatorTokenType)) temp.AddLast(tokenizer.Pop());
            tokenizer.Pop();// binary and operator token
            ITokenizer leftTokenizer = new MyTokenizer(temp);
            leftExpression = new BooleanExpressionNode();
            rightExpression = new BooleanExpressionNode();
            leftExpression.Parse(leftTokenizer);
            rightExpression.Parse(tokenizer);
        }

        public string Translate()
        {
            leftExpression.SetLabel(Components.Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            leftExpression.SetLabel(Components.Labelable.SECOND, labelable.GetLabel(Components.Labelable.SECOND));
            rightExpression.SetLabel(Components.Labelable.TRUE, labelable.GetLabel(Components.Labelable.TRUE));
            rightExpression.SetLabel(Components.Labelable.SECOND, labelable.GetLabel(Components.Labelable.SECOND));
            leftExpression.Translate();
            rightExpression.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(leftExpression.GetLabel(Components.Labelable.TRUE)));
            sb.Append(rightExpression.PrettyPrint());
            return sb.ToString();
        }

        public IBooleanExpressionChild NewBooleanExpressionChildInstance => new BinaryAndOperatorNode();
    }
}
