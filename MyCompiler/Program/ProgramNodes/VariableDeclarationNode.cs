using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableDeclarationNode : IVariableDeclarationNode
    {
        private IAssignInitializerNode assignInitializer;
        private IArrayTypeNode arrayType;
        private bool hasArrayType, hasAssignInitializer;

        public string Id { get; }

        public VariableDeclarationNode(string id)
        {
            Id = id;
        }

        public void Parse(ITokenizer tokenizer)
        {
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
            sb.Append(Id);
            if (hasArrayType) sb.Append(arrayType.PrettyPrint());
            if (hasAssignInitializer) sb.Append(assignInitializer.PrettyPrint());
            return sb.ToString();
        }
    }
}
