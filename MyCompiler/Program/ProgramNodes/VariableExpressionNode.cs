using System;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableExpressionNode : IVariableExpressionNode
    {
        private readonly Translatable translatable;
        private string stringRepresentation;

        public string VariableType { get; }
        public bool IsLValue { get; }
        public string LValueString => stringRepresentation;
        public string Address => translatable.Address;

        public VariableExpressionNode()
        {
            translatable = new Translatable();
        }

        public void Parse(ITokenizer tokenizer)
        {
            throw new NotImplementedException();
        }

        public string Translate()
        {
            if (!IsLValue) return translatable.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public string PrettyPrint() => translatable.IsTranslated 
            ? Utilities.PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, stringRepresentation) 
            : stringRepresentation;

        public IExpressionChild NewExpressionChildInstance() => new VariableExpressionNode();
    }
}
