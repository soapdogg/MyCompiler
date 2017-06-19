using System.Collections.Generic;
using System.Text;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.ProgramNodes
{
    public class VariableDeclarationListNode : IVariableDeclarationListNode
    {
        private ITypeNode type;
        private IList<IVariableDeclarationNode> variableDeclarations;

        public string Address => string.Empty;

        public string Translate() => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            type = new TypeNode();
            type.Parse(tokenizer);
            IVariableDeclarationNode variableDeclaration = new VariableDeclarationNode();
            variableDeclaration.Parse(tokenizer);
            variableDeclarations.Add(variableDeclaration);
            while (tokenizer.PeekTokenType() is CommaTokenType)
            {
                tokenizer.Pop(); //comma token 
                IVariableDeclarationNode v = new VariableDeclarationNode();
                v.Parse(tokenizer);
                variableDeclarations.Add(v);
            }
            tokenizer.Pop(); // semicolon token
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(type.PrettyPrint());
            IEnumerator<IVariableDeclarationNode> enumerator = variableDeclarations.GetEnumerator();
            bool hasNext = true;
            while (hasNext)
            {
                sb.Append(enumerator.Current.PrettyPrint());
                hasNext = enumerator.MoveNext();
                if (hasNext) sb.Append(",");
            }
            enumerator.Dispose();
            sb.Append(";");
            return sb.ToString();
        }

        public IDeclarationChild NewDeclarationChildInstance => new VariableDeclarationListNode();

        public IStatementChild NewStatementChildInstance() => new VariableDeclarationListNode();
    }
}
