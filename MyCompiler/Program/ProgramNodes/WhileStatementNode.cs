﻿using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class WhileStatementNode : IWhileStatementNode
    {
        private readonly Translatable translatable;
        private readonly Labelable labelable;
        private IBooleanExpressionNode expression;
        private IStatementNode body;

        public WhileStatementNode()
        {
            translatable = new Translatable();
            labelable = new Labelable(3);
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop(); //while token
            tokenizer.Pop(); //left parenthese token
            expression = new BooleanExpressionNode();
            expression.Parse(tokenizer);
            tokenizer.Pop(); //right parenthese token
            body = new StatementNode();
            body.Parse(tokenizer);
        }

        public string Translate()
        {
            expression.SetLabel(Labelable.SECOND, Utilities.CounterUtilities.GetNextLabelAvailable);
            SetLabel(Labelable.START, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.SetLabel(Labelable.TRUE, Utilities.CounterUtilities.GetNextLabelAvailable);
            expression.Translate();
            return body.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(GetLabel(Labelable.START)));
            sb.Append(expression.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.TRUE)));
            sb.Append(body.PrettyPrint());
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedGoto(GetLabel(Labelable.START)));
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintedLabel(expression.GetLabel(Labelable.SECOND)));
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new WhileStatementNode();

        public void SetLabel(int i, string label) => labelable.SetLabel(i, label);

        public string GetLabel(int i) => labelable.GetLabel(i);
    }
}
