using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class Tokenizer
    {
        private string[] lines;
        private IList<SimpleCToken> tokens;

        private static readonly IList<ITokenType> definitions;

        static Tokenizer(){
            definitions = new List<ITokenType>
            {
                new BinaryAssignOperatorTokenType(),
                new BinaryAssignTokenType(),
                new BinaryAndOperatorTokenType(),
                new BinaryOrOperatorTokenType(),
                new BinaryOperatorTokenType(),
                new BinaryRelationalOperatorTokenType(),
                new UnaryNotOperatorTokenType(),
                new DoubleTokenType(),
                new DoTokenType(),
                new ElseTokenType(),
                new FloatTokenType(),
                new IfTokenType(),
                new IntTokenType(),
                new LongTokenType(),
                new ReturnTokenType(),
                new VoidTokenType(),
                new WhileTokenType(),
                new PreOrPostOperatorTokenType(),
                new PlusOrMinusTokenType(),
                new BitNegationOperatorTokenType(),
                new LeftBraceTokenType(),
                new LeftBracketTokenType(),
                new LeftParenthesesTokenType(),
                new RightBraceTokenType(),
                new RightBracketTokenType(),
                new RightParenthesesTokenType(),
                new SemicolonTokenType(),
                new CommaTokenType(),
                new FloatingPointConstantTokenType(),
                new IdentifierTokenType(),
                new IntegerConstantTokenType()
            };

        }

        public Tokenizer()
        {
            Initialize();
        }

        public Tokenizer(params string [] pathArray)
        {
            Initialize();
			string path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (string s in pathArray) path += Path.DirectorySeparatorChar + s;
            lines = File.ReadAllLines(path);
        }

        public IList<SimpleCToken> Tokenize()
        {
            bool continueScanning = true;
            for (int i = 0; i < lines.Length && continueScanning; ++i)
            {
                string line = lines[i];
                continueScanning = TokenizeLine(line);
            }
            if(!(tokens.Last().TokenType is InvalidTokenType)) tokens.Add(new SimpleCToken(new EndOfFileTokenType(), "END_OF_FILE"));
			return tokens;
        }

        public IList<SimpleCToken> Tokenize(params string [] inputText)
        {
            lines = inputText;
            return Tokenize();
        }

        public int Size => tokens.Count;

        private bool TokenizeLine(string inputText)
        {
			string remainingText = inputText.TrimStart();
			while (!string.IsNullOrWhiteSpace(remainingText))
			{
				var match = FindMatch(remainingText);

				if (match.IsMatch)
				{
					tokens.Add(new SimpleCToken(match.TokenType, match.Value));
					remainingText = match.RemainingText.TrimStart();
				}
				else
				{
					var invalidTokenMatch = CreateInvalidTokenMatch(remainingText);
					tokens.Add(new SimpleCToken(invalidTokenMatch.TokenType, invalidTokenMatch.Value));
					return false;
				}
			}
            return true;
        }
        
        private static TokenMatch FindMatch(string inputText)
        {
            foreach (var tokenType in definitions)
            {
                var match = tokenType.Match(inputText);
                if (match.IsMatch) return match;
            }
            return new TokenMatch { IsMatch = false }; 
        }

        private static TokenMatch CreateInvalidTokenMatch(string inputText)
        {
            return new TokenMatch
            {
                IsMatch = true,
                RemainingText = inputText.Substring(inputText.Length),
                TokenType = new InvalidTokenType(),
                Value = inputText
            };   
        }

        private void Initialize()
        {
            lines = new string[0];
            tokens = new List<SimpleCToken>();
        }
    }
}
