﻿using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ReturnStatementNode : IReturnStatementNode
    {
        private readonly Translatable translatable;
        private bool shouldBeTranslated;
        private IExpressionNode expression;

        public ReturnStatementNode()
        {
            translatable = new Translatable();
        }

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Return);
            expression = new ExpressionNode();
            expression.Parse(tokenizer);
            shouldBeTranslated = !(expression.Child is IConstantNode || expression.Child is IVariableExpressionNode); //expression.Child
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Semi); 
        }

        public void Translate()
        {
            if (!shouldBeTranslated) return;
            translatable.Translate();
            expression.Translate();
        }

        public IStatementChild NewStatementChildInstance() => new ReturnStatementNode();

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if (translatable.IsTranslated)
            {
                sb.Append(expression.PrettyPrint());
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.Address);
                sb.Append(";");
            }
            else
            {
                sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append("return ");
                sb.Append(expression.PrettyPrint());
                sb.Append(";");
            }
            return sb.ToString();
        }
    }
}
