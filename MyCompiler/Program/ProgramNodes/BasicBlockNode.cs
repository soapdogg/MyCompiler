using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

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
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LBrace);
            while (tokenizer.PeekTokenType().GetHashCode() != (int)TokenType.RBrace)
            {
                IStatementNode statement = new StatementNode();
                statement.Parse(tokenizer);
                statements.Add(statement);
            }
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RBrace); 
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
                sb.Append(statementNode.PrettyPrint());
            return sb.ToString();
        }

        public IStatementChild NewStatementChildInstance() => new BasicBlockNode();
    }
}
