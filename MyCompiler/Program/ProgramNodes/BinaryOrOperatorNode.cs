using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryOrOperatorNode : IBinaryOrOperatorNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IBooleanExpressionNode leftExpression, rightExpression;

        public BinaryOrOperatorNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(2);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            LinkedList<SimpleCToken> temp = new LinkedList<SimpleCToken>();
            while(!(tokenizer.PeekTokenType() is BinaryOrOperatorTokenType)) temp.AddLast(tokenizer.Pop());
            tokenizer.Pop();// binary or operator token
            ITokenizer leftTokenizer = new MyTokenizer(temp);
            leftExpression = new BooleanExpressionNode();
            rightExpression = new BooleanExpressionNode();
            leftExpression.Parse(leftTokenizer);
            rightExpression.Parse(tokenizer);
        }

        public string Translate()
        {
            leftExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.TRUE));
            leftExpression.SetLabel(Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            rightExpression.SetLabel(Labelable.TRUE, labelable.GetLabel(Labelable.TRUE));
            rightExpression.SetLabel(Labelable.SECOND, labelable.GetLabel(Labelable.SECOND));
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
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(leftExpression.GetLabel(Labelable.SECOND)));
            sb.Append(rightExpression.PrettyPrint());
            return sb.ToString();
        }

        public IBooleanExpressionChild NewBooleanExpressionChildInstance => new BinaryOrOperatorNode();
    }
}
