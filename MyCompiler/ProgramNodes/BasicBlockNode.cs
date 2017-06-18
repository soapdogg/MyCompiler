using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class BasicBlockNode : IBasicBlockNode
    {
        private readonly Translatable translatable;
        private IList<IStatementNode> statements;

        public BasicBlockNode()
        {
            translatable = new Translatable();
        }

        public string Address => translatable.Address;
        
        public string Translate()
        {
            foreach (var statementNode in statements)
                statementNode.Translate();
            return string.Empty;
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var statementNode in statements)
                sb.Append(statementNode.PrettyPrint());
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new BasicBlockNode();
    }
}
