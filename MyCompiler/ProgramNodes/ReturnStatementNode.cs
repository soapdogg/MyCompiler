using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class ReturnStatementNode : IReturnStatementNode
    {
        private Translatable translatable;

        public string Address { get; set; }
        public string VariableType { get; }
        public bool IsTranslated => translatable.IsTranslated;
        public void MarkAsTranslated() => translatable.MarkAsTranslated();

        public string Translate()
        {
            throw new NotImplementedException();
        }

        public IStatementChild NewStatementChildInstance()
        {
            return new ReturnStatementNode();
        }
    }
}
