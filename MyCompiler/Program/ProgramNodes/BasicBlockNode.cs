using System.Collections.Generic;
using System.Text;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes
{
    public class BasicBlockNode : IBasicBlockNode
    {
        private readonly Translatable translatable;
        private readonly IList<IStatementNode> statements;

        public BasicBlockNode()
        {
            translatable = new Translatable();
            statements = new List<IStatementNode>();
        }

        public string Address => translatable.Address;
        public string Type => translatable.Type;

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

        public IStatementChild NewStatementChildInstance() => new BasicBlockNode();
    }
}
