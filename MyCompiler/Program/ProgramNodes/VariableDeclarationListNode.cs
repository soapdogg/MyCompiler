using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableDeclarationListNode : IVariableDeclarationListNode
    {
        private ITypeNode type;
        private readonly bool isInMethod;
        private IList<IVariableDeclarationNode> variableDeclarations;

        public VariableDeclarationListNode(bool inMethod)
        {
            isInMethod = inMethod;
        }

        public void Parse(ITokenizer tokenizer)
        {
            type = new TypeNode(tokenizer.Pop().Value);
            variableDeclarations = new List<IVariableDeclarationNode>();
            IVariableDeclarationNode variableDeclaration = new VariableDeclarationNode();
            variableDeclaration.Parse(tokenizer);
            variableDeclarations.Add(variableDeclaration);
            TypeTracker.AddType(variableDeclaration.Id, type.PrettyPrint());
            while (tokenizer.PeekTokenType() is CommaTokenType)
            {
                tokenizer.Pop(); //comma token 
                IVariableDeclarationNode v = new VariableDeclarationNode();
                v.Parse(tokenizer);
                variableDeclarations.Add(v);
                TypeTracker.AddType(v.Id, type.PrettyPrint());
            }
            tokenizer.Pop(); // semicolon token
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if(isInMethod) sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(type.PrettyPrint());
            sb.Append(' ');
            for (var index = 0; index < variableDeclarations.Count; index++)
            {
                var variableDeclarationNode = variableDeclarations[index];
                sb.Append(variableDeclarationNode.PrettyPrint());
                if (index != variableDeclarations.Count - 1) sb.Append(", ");
            }

            sb.Append(";");
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new VariableDeclarationListNode(true);
    }
}
