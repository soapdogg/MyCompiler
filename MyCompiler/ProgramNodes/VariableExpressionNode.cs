using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class VariableExpressionNode : IVariableExpressionNode
    {
        private readonly Translatable translatable;
        private string stringRepresentation;

        public string VariableType { get; }
        public bool IsLValue { get; }
        public string LValueString => stringRepresentation;
        public string Address => translatable.Address;

        public string Translate()
        {
            if (!IsLValue) return translatable.Translate();
            translatable.MarkAsTranslated();
            return string.Empty;
        }

        public string PrettyPrint()
        {
            return translatable.IsTranslated 
                ? PrettyPrintingUtilities.GetTabbedNewLineAndVariableAssignment(Address, stringRepresentation) 
                : stringRepresentation;
        }

        public IExpressionChild NewExpressionChildInstance() => new VariableExpressionNode();
    }
}
