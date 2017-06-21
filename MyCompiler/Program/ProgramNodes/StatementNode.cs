using System.Collections.Generic;
using MyCompiler.Program.ProgramNodes.Components;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class StatementNode : Interfaces.IStatementNode
    {
        private readonly Translatable translatable;
        private static readonly IDictionary<ITokenType, Interfaces.IStatementChild> statementChildDictionary;

        static StatementNode()
        {
            statementChildDictionary =
                new Dictionary<ITokenType, Interfaces.IStatementChild>
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

        public StatementNode()
        {
            translatable = new Translatable();
        }

        public Interfaces.IStatementChild Child { get; private set; }
        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            Child = statementChildDictionary.ContainsKey(tokenizer.PeekTokenType())
                ? statementChildDictionary[tokenizer.PeekTokenType()]
                : new ExpressionStatementNode();
            Child = Child.NewStatementChildInstance();
            Child.Parse(tokenizer);
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();
    }
}
