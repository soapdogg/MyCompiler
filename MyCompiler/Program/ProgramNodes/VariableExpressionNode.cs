using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableExpressionNode : IVariableExpressionNode
    {
        private readonly Translatable translatable;
        private readonly Typable typable;
        private readonly string stringRepresentation;

        public string Type => typable.Type;
        public bool IsLValue { get; private set; }
        public string LValueString => stringRepresentation;
        public void SetAsLValue() => IsLValue = true;

        public string Address => typable.Address;

        public VariableExpressionNode(string value)
        {
            translatable = new Translatable();
            typable = new Typable();
            stringRepresentation = value;
            typable.Type = TypeTracker.GetType(value);
        }

        public void Translate()
        {
            translatable.Translate();
            if (!IsLValue) typable.GenerateNewAddress();
        }

        public string PrettyPrint() => translatable.IsTranslated 
            ? PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, stringRepresentation) 
            : stringRepresentation;

        public void SetLabel(int i, string label){}

        public string GetLabel(int i) => string.Empty;
    }
}
