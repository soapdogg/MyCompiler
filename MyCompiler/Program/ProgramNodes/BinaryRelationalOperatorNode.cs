﻿using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class BinaryRelationalOperatorNode : IBinaryRelationalOperatorNode
    {
        private readonly Labelable labelable;
        private readonly IExpressionNode leftExpression, rightExpression;
        private readonly string op;

        public BinaryRelationalOperatorNode(IExpressionChild left, IExpressionChild right, string op)
        {
            labelable = new Labelable(2);
            leftExpression = new ExpressionNode(left);
            rightExpression = new ExpressionNode(right);
            this.op = op;
        }

        public void Translate()
        {
            leftExpression.Translate();
            rightExpression.Translate();
        }

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(leftExpression.PrettyPrint());
            sb.Append(rightExpression.PrettyPrint());
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append("if (");
            sb.Append(leftExpression.Address);
            sb.Append(' ');
            sb.Append(op);
            sb.Append(' ');
            sb.Append(rightExpression.Address);
            sb.Append(") ");
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Labelable.TRUE)));
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintedGoto(labelable.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }
    }
}
