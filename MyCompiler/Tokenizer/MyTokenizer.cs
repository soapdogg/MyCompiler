﻿using System.IO;
using System.Collections.Generic;
using System.Linq;
using MyCompiler.Tokenizer.Tokens;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Tokenizer
{
    public class MyTokenizer : ITokenizer
    {
        private string[] lines;
        private List<SimpleCToken> tokens;
        private int current;

        private static readonly IList<ITokenType> definitions;

        static MyTokenizer(){
            definitions = new List<ITokenType>
            {
                new BinaryAssignOperatorTokenType(),
                new BinaryAndOperatorTokenType(),
                new BinaryOrOperatorTokenType(),
                new BinaryOperatorTokenType(),
                new BinaryRelationalOperatorTokenType(),
                new UnaryNotOperatorTokenType(),
                new BinaryAssignTokenType(),
                new TypeTokenType(),
                new DoTokenType(),
                new ElseTokenType(),
                new IfTokenType(),
                new ReturnTokenType(),
                new WhileTokenType(),
                new ForTokenType(),
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

        public MyTokenizer()
        {
            Initialize();
        }

        public MyTokenizer(params string [] pathArray)
        {
            Initialize();
            string path = @"C:\Users\Eric\Documents\Github\MyCompiler\MyCompiler"; 
            foreach (string s in pathArray) path += Path.DirectorySeparatorChar + s;
            lines = File.ReadAllLines(path);
        }

        public MyTokenizer(List<SimpleCToken> t)
        {
            tokens = t;
        }

        public List<SimpleCToken> Tokenize()
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

        public List<SimpleCToken> Tokenize(params string [] inputText)
        {
            lines = inputText;
            return Tokenize();
        }

        public int Size => tokens.Count;

        public SimpleCToken Previous() => tokens[current - 1];

        public SimpleCToken Pop()
        {
            SimpleCToken result = Peek();
            ++current;
            return result;
        }

        public SimpleCToken Peek() => tokens[current];

        public ITokenType PeekTokenType() => Peek().TokenType;

        public string PeekValue() => Peek().Value;

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
            current = 0;
        }
    }
}
