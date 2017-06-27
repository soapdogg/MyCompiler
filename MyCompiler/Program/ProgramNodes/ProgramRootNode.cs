using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class ProgramRootNode : IProgramRootNode
    {
        private IList<IDeclarationStatementNode> declarationStatements;

        public void Parse(ITokenizer tokenizer)
        {
            declarationStatements = new List<IDeclarationStatementNode>();
            while ((tokenizer.PeekTokenType().GetHashCode() != (int)TokenType.Eof))
            {
                IDeclarationStatementNode statement = new DeclarationStatementNode();
                statement.Parse(tokenizer);
                declarationStatements.Add(statement);
            }
        }

        public void Translate()
        {
            foreach (var declarationStatementNode in declarationStatements)
                declarationStatementNode.Translate();
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
