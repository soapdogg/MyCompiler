using System.Collections.Generic;
using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryRelationalOperatorNode : Interfaces.IBinaryRelationalOperatorNode
    {
        private readonly Components.Translatable translatable;
        private readonly Components.Labelable labelable;
        private Interfaces.IExpressionNode leftExpression, rightExpression;
        private string op;

        public BinaryRelationalOperatorNode()
        {
            translatable = new Components.Translatable();
            labelable = new Components.Labelable(2);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            LinkedList<SimpleCToken> temp = new LinkedList<SimpleCToken>();
            while(!(tokenizer.PeekTokenType() is BinaryOrOperatorTokenType)) temp.AddLast(tokenizer.Pop());
            op = tokenizer.Pop().Value;// binary relational operator token
            ITokenizer leftTokenizer = new MyTokenizer(temp);
            leftExpression = new ExpressionNode();
            rightExpression = new ExpressionNode();
            leftExpression.Parse(leftTokenizer);
            rightExpression.Parse(tokenizer);
        }

        public string Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
            return string.Empty;
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append("if (");
            sb.Append(leftExpression.Address);
            sb.Append(op);
            sb.Append(rightExpression.Address);
            sb.Append(") ");
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Components.Labelable.TRUE)));
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Components.Labelable.SECOND)));
            return sb.ToString();
        }

        public Interfaces.IBooleanExpressionChild NewBooleanExpressionChildInstance => new BinaryRelationalOperatorNode();

    }
}
