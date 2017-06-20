using System.Collections.Generic;
using System.Text;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BasicBlockNode : Interfaces.IBasicBlockNode
    {
        private readonly Components.Translatable translatable;
        private readonly IList<Interfaces.IStatementNode> statements;

        public BasicBlockNode()
        {
            translatable = new Components.Translatable();
            statements = new List<Interfaces.IStatementNode>();
        }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            tokenizer.Pop();// left brace
            while (!(tokenizer.PeekTokenType() is RightBraceTokenType))
            {
                Interfaces.IStatementNode statement = new StatementNode();
                statement.Parse(tokenizer);
                statements.Add(statement);
            }
            tokenizer.Pop(); //right brace
        }

        public string Translate()
        {
            foreach (var statementNode in statements)
                statementNode.Translate();
            return string.Empty;
        }

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var statementNode in statements)
                sb.Append(statementNode.PrettyPrint());
            return sb.ToString();
        }

        public Interfaces.IStatementChild NewStatementChildInstance() => new BasicBlockNode();
    }
}
