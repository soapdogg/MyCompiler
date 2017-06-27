using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableDeclarationListNode : IVariableDeclarationListNode
    {
        private ITypeNode type;
        private readonly bool isInMethod;
        private IList<IVariableDeclarationNode> variableDeclarations;
        private IVariableDeclarationNode first;

        public VariableDeclarationListNode()
        {
            isInMethod = true;
        }

        public VariableDeclarationListNode(string typeString, string identifierString)
        {
            isInMethod = false;
            type = new TypeNode(typeString);
            variableDeclarations = new List<IVariableDeclarationNode>();
            first = new VariableDeclarationNode(identifierString);
            TypeTracker.AddType(identifierString, typeString);
        }

        public void Parse(ITokenizer tokenizer)
        {
            if(isInMethod) ParseTypeAndIdentifier(tokenizer);
            first.Parse(tokenizer);
            variableDeclarations.Add(first);
            while (tokenizer.PeekTokenType().GetHashCode() ==  (int) TokenType.Comma)
            {
                TokenConsumer.Consume(tokenizer.Pop(), TokenType.Comma);
                IVariableDeclarationNode v = new VariableDeclarationNode(tokenizer.Pop().Value);
                v.Parse(tokenizer);
                variableDeclarations.Add(v);
                TypeTracker.AddType(v.Id, type.PrettyPrint());
            }
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.Semi);
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            if(isInMethod) sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(type.PrettyPrint());
            sb.Append(' ');
            for (var index = 0; index < variableDeclarations.Count; ++index)
            {
                var variableDeclarationNode = variableDeclarations[index];
                sb.Append(variableDeclarationNode.PrettyPrint());
                if (index != variableDeclarations.Count - 1) sb.Append(", ");
            }

            sb.Append(";");
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new VariableDeclarationListNode();

        private void ParseTypeAndIdentifier(ITokenizer tokenizer)
        {
            type = new TypeNode(tokenizer.Pop().Value);
            variableDeclarations = new List<IVariableDeclarationNode>();
            first = new VariableDeclarationNode(tokenizer.Pop().Value);
            TypeTracker.AddType(first.Id, type.PrettyPrint());
        }
    }
}
