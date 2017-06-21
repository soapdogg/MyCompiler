using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableExpressionNode : IVariableExpressionNode
    {
        private readonly Translatable translatable;
        private readonly string stringRepresentation;

        public string VariableType { get; }
        public bool IsLValue { get; }
        public string LValueString => stringRepresentation;
        public string Address => translatable.Address;

        public VariableExpressionNode(string value)
        {
            translatable = new Translatable();
            stringRepresentation = value;
        }

        public string Translate()
        {
            if (!IsLValue) return translatable.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public string PrettyPrint() => translatable.IsTranslated 
            ? PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, stringRepresentation) 
            : stringRepresentation;

        public void SetLabel(int i, string label){}

        public string GetLabel(int i) => string.Empty;
    }
}
