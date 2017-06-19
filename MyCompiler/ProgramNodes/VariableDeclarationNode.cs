using System.Text;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class VariableDeclarationNode : IVariableDeclarationNode
    {
        private ITypeNode type;
        private IAssignInitializerNode assignInitializer;
        private string variableName;
        private IArrayTypeNode arrayType;
        private bool hasArrayType, hasAssignInitializer;

        public string Address => string.Empty;

        public string Translate() => string.Empty;

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(type.PrettyPrint());
            sb.Append(variableName);
            if (hasArrayType) sb.Append(arrayType.PrettyPrint());
            if (hasAssignInitializer) sb.Append(assignInitializer.PrettyPrint());
            sb.Append(";");
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new VariableDeclarationNode();

        public IDeclarationChild NewDeclarationChildInstance => new VariableDeclarationNode();
    }
}
