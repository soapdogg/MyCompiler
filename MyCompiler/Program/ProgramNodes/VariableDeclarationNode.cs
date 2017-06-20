using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableDeclarationNode : Interfaces.IVariableDeclarationNode
    {
        private Interfaces.IAssignInitializerNode assignInitializer;
        private string variableName;
        private Interfaces.IArrayTypeNode arrayType;
        private bool hasArrayType, hasAssignInitializer;

        public void Parse(ITokenizer tokenizer)
        {
            variableName = tokenizer.Pop().Value;
            hasArrayType = tokenizer.PeekTokenType() is LeftBracketTokenType;
            if (hasArrayType)
            {
                arrayType = new ArrayTypeNode();
                arrayType.Parse(tokenizer);
            }
            hasAssignInitializer = tokenizer.PeekTokenType() is BinaryAssignTokenType;
            if (hasAssignInitializer)
            {
                assignInitializer = new AssignInitializerNode();
                assignInitializer.Parse(tokenizer);
            }
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(variableName);
            if (hasArrayType) sb.Append(arrayType.PrettyPrint());
            if (hasAssignInitializer) sb.Append(assignInitializer.PrettyPrint());
            return sb.ToString();
        }
    }
}
