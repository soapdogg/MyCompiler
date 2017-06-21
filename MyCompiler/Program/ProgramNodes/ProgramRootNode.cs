using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class ProgramRootNode : IProgramRootNode
    {
        private IList<IDeclarationStatementNode> declarationStatements;

        public string Address => string.Empty;

        public void Parse(ITokenizer tokenizer)
        {
            declarationStatements = new List<IDeclarationStatementNode>();
            while (!(tokenizer.PeekTokenType() is EndOfFileTokenType))
            {
                IDeclarationStatementNode statement = new DeclarationStatementNode();
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
