using System.Collections.Generic;
using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class ProgramRootNode : Interfaces.IProgramRootNode
    {
        private IList<Interfaces.IDeclarationStatementNode> declarationStatements;

        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            declarationStatements = new List<Interfaces.IDeclarationStatementNode>();
            while (!(tokenizer.PeekTokenType() is EndOfFileTokenType))
            {
                Interfaces.IDeclarationStatementNode statement = new DeclarationStatementNode();
                statement.Parse(tokenizer);
                declarationStatements.Add(statement);
            }
        }

        public string Translate()
        {
            foreach (var declarationStatementNode in declarationStatements)
                declarationStatementNode.Translate();
            return string.Empty;
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var declarationStatementNode in declarationStatements)
                sb.Append(declarationStatementNode.PrettyPrint());
            return sb.ToString();
        }
    }
}
