using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BasicBlockNode : IBasicBlockNode
    {
        private readonly IList<IStatementNode> statements;

        public BasicBlockNode()
        {
            statements = new List<IStatementNode>();
        }

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop();// left brace
            while (!(tokenizer.PeekTokenType() is RightBraceTokenType))
            {
                IStatementNode statement = new StatementNode();
                statement.Parse(tokenizer);
                statements.Add(statement);
            }
            tokenizer.Pop(); //right brace
        }

        public void Translate()
        {
            foreach (var statementNode in statements)
                statementNode.Translate();
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var statementNode in statements)
            {
                //sb.Append(PrettyPrintingUtilities.GetTabbedNewLine());
                sb.Append(statementNode.PrettyPrint());
            }
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new BasicBlockNode();
    }
}
