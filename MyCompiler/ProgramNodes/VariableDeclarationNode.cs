using System.Text;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.ProgramNodes
{
    public class VariableDeclarationNode : IVariableDeclarationNode
    {
        private IAssignInitializerNode assignInitializer;
        private string variableName;
        private IArrayTypeNode arrayType;
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
