using System.Collections.Generic;
using System.Text;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.ProgramNodes
{
    public class ProgramRootNode : IProgramRootNode
    {
        private IList<IDeclarationStatementNode> declarationStatements;

        public string Address => string.Empty;

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

        public void Parse(ITokenizer tokenizer)
        {
            while (!(tokenizer.PeekTokenType() is EndOfFileTokenType))
            {
                
            }
            throw new System.NotImplementedException();
        }
    }
}
