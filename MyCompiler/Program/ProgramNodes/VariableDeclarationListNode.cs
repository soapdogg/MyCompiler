using System.Collections.Generic;
using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class VariableDeclarationListNode : Interfaces.IVariableDeclarationListNode
    {
        private Interfaces.ITypeNode type;
        private IList<Interfaces.IVariableDeclarationNode> variableDeclarations;

        public string Address => string.Empty;

        public string Translate() => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            type = new TypeNode();
            variableDeclarations = new List<Interfaces.IVariableDeclarationNode>();
            type.Parse(tokenizer);
            Interfaces.IVariableDeclarationNode variableDeclaration = new VariableDeclarationNode();
            variableDeclaration.Parse(tokenizer);
            variableDeclarations.Add(variableDeclaration);
            while (tokenizer.PeekTokenType() is CommaTokenType)
            {
                tokenizer.Pop(); //comma token 
                Interfaces.IVariableDeclarationNode v = new VariableDeclarationNode();
                v.Parse(tokenizer);
                variableDeclarations.Add(v);
            }
            tokenizer.Pop(); // semicolon token
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Utilities.PrettyPrintingUtilities.GetTabbedNewLine());
            sb.Append(type.PrettyPrint());
            IEnumerator<Interfaces.IVariableDeclarationNode> enumerator = variableDeclarations.GetEnumerator();
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

        public Interfaces.IStatementChild NewStatementChildInstance() => new VariableDeclarationListNode();
    }
}
