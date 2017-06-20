using System.Collections.Generic;
using System.Linq;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class BooleanExpressionNode : IBooleanExpressionNode
    {
        private readonly Components.Translatable translatable;
        private static readonly IDictionary<ITokenType, IBooleanExpressionChild> booleanChildDictionary;

        static BooleanExpressionNode()
        {
            booleanChildDictionary =
                new Dictionary<ITokenType, IBooleanExpressionChild>
                {
                    [new BinaryAndOperatorTokenType()] = new BinaryAndOperatorNode(),
                    [new BinaryOrOperatorTokenType()] = new BinaryOrOperatorNode(),
                    [new BinaryRelationalOperatorTokenType()] = new BinaryRelationalOperatorNode()
                };
        }

        public BooleanExpressionNode()
        {
            translatable = new Components.Translatable();
        }

        public IBooleanExpressionChild Child { get; private set; }

        public string Address => translatable.Address;

        public void Parse(ITokenizer tokenizer)
        {
            if (tokenizer.PeekTokenType() is UnaryNotOperatorTokenType)
            {
                Child = new UnaryNotOperatorNode();
                Child.Parse(tokenizer);
                return;
            }
            IList<SimpleCToken> temp = new List<SimpleCToken>();
            while(booleanChildDictionary.ContainsKey(tokenizer.PeekTokenType())) temp.Add(tokenizer.Pop());
            Child = booleanChildDictionary[tokenizer.PeekTokenType()];
            Child = Child.NewBooleanExpressionChildInstance;
            temp = (IList<SimpleCToken>) temp.Reverse();
            foreach (var simpleCToken in temp) tokenizer.Push(simpleCToken);
            Child.Parse(tokenizer);
        }

        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();

        public void SetLabel(int i, string label) => Child.SetLabel(i, label);

        public string GetLabel(int i) => Child.GetLabel(i);

    }
}
