using System.Collections.Generic;
using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class StatementNode : IStatementNode
    {
        private static readonly IDictionary<ITokenType, IStatementChild> statementChildDictionary;

        static StatementNode()
        {
            statementChildDictionary =
                new Dictionary<ITokenType, IStatementChild>
                {
                    [new ForTokenType()] = new ForStatementNode(),
                    [new WhileTokenType()] = new WhileStatementNode(),
                    [new DoTokenType()] = new DoWhileStatementNode(),
                    [new ReturnTokenType()] = new ReturnStatementNode(),
                    [new LeftBraceTokenType()] = new BasicBlockNode(),
                    [new IfTokenType()] = new IfStatementNode(),
                    [new TypeTokenType()] = new VariableDeclarationListNode()
                };
        }

        public IStatementChild Child { get; private set; }

        public void Parse(ITokenizer tokenizer)
        {
            Child = statementChildDictionary.ContainsKey(tokenizer.PeekTokenType())
                ? statementChildDictionary[tokenizer.PeekTokenType()]
                : new ExpressionStatementNode();
            Child = Child.NewStatementChildInstance();
            Child.Parse(tokenizer);
        }

        public void Translate()
        {
            ITranslatable translatable = Child as ITranslatable;
            translatable?.Translate();
        }

        public string PrettyPrint() => Child.PrettyPrint();
    }
}
