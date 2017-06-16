using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class ExpressionStatementNode : IExpressionStatementNode
    {
        private readonly Translatable translatable;
        private IExpressionNode expression;

        public ExpressionStatementNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;

        public string Translate()
        {
            translatable.MarkAsTranslated();
            return expression.Translate();
        }

        public string PrettyPrint() => translatable.IsTranslated ? expression.PrettyPrint() : expression.PrettyPrint() + ";";

        public IStatementChild NewStatementChildInstance() => new ExpressionStatementNode();
    }
}
