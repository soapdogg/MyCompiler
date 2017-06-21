using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class ExpressionChildGenerator
    {
        public static IExpressionChild ParseExpression(ITokenizer tokenizer)
        {
            return ParseAssignmentOperator(tokenizer);
        }

        private static IExpressionChild ParseAssignmentOperator(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseLogicalOr(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryAssignTokenType || tokenizer.PeekTokenType() is BinaryAssignOperatorTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseLogicalOr(tokenizer);
                left = token.TokenType is BinaryAssignTokenType
                    ? (IExpressionChild)new BinaryAssignNode()
                    : new BinaryAssignOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseLogicalOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseLogicalAnd(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOrOperatorTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseLogicalAnd(tokenizer);
                left = new BinaryOrOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseLogicalAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseOr(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryAndOperatorTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseBitwiseOr(tokenizer);
                left = new BinaryAndOperatorNode();
            }
            return left;
        }
        private static IExpressionChild ParseBitwiseOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseXor(tokenizer);
            while ((tokenizer.PeekTokenType() is BinaryOperatorTokenType) && tokenizer.PeekValue().Equals("|"))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseBitwiseXor(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseXor(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseAnd(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType && tokenizer.PeekValue().Equals("^"))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseBitwiseAnd(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseShift(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType && tokenizer.PeekValue().Equals("&"))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseShift(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseRelationalEquals(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseRelationalOperator(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryRelationalOperatorTokenType &&
                   (tokenizer.PeekValue().Equals("==") || tokenizer.PeekValue().Equals("!=")))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseRelationalOperator(tokenizer);
                left = new BinaryRelationalOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseRelationalOperator(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseShift(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryRelationalOperatorTokenType &&
                   (tokenizer.PeekValue().Contains(">") || tokenizer.PeekValue().Contains("<")))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseShift(tokenizer);
                left = new BinaryRelationalOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseShift(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseTerm(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType && (tokenizer.PeekValue().Equals("<<") || tokenizer.PeekValue().Equals(">>")))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseTerm(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseTerm(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseFactor(tokenizer);
            while (tokenizer.PeekTokenType() is PlusOrMinusTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseFactor(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseFactor(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseUnary(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType &&
                   (tokenizer.PeekValue().Equals("*") || tokenizer.PeekValue().Equals("/") ||
                    tokenizer.PeekValue().Equals("%")))
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseUnary(tokenizer);
                left = new BinaryOperatorNode();
            }
            return left;
        }

        private static IExpressionChild ParseUnary(ITokenizer tokenizer)
        {
            if (tokenizer.PeekTokenType() is PlusOrMinusTokenType ||
                   tokenizer.PeekTokenType() is PreOrPostOperatorTokenType
                   || tokenizer.PeekTokenType() is BitNegationOperatorTokenType
                   || tokenizer.PeekTokenType() is UnaryNotOperatorTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild right = ParseUnary(tokenizer);
                if (token.TokenType is PlusOrMinusTokenType || token.TokenType is BitNegationOperatorTokenType) return new UnaryOperatorNode();
                if (token.TokenType is UnaryNotOperatorTokenType) return new UnaryNotOperatorNode();
                return new UnaryPreOperatorNode();
            }
            return ParsePrimary(tokenizer);
        }

        private static IExpressionChild ParsePrimary(ITokenizer tokenizer)
        {
            if (tokenizer.PeekTokenType() is FloatingPointConstantTokenType ||
                tokenizer.PeekTokenType() is IntegerConstantTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                return new ConstantNode();
            }
            if (tokenizer.PeekTokenType() is IdentifierTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild varExpr = new VariableExpressionNode();
                if (tokenizer.PeekTokenType() is LeftBracketTokenType)
                {
                    tokenizer.Pop(); //left bracket
                    IExpressionChild inside = ParseExpression(tokenizer);
                    tokenizer.Pop(); //right bracket
                    varExpr = new BinaryArrayOperatorNode();
                }
                if (tokenizer.PeekTokenType() is PreOrPostOperatorTokenType)
                {
                    tokenizer.Pop(); //Post operator
                    varExpr = new UnaryPostOperatorNode();
                }
                return varExpr;
            }

            tokenizer.Pop();//left parentheses
            IExpressionChild result = ParseExpression(tokenizer);
            tokenizer.Pop(); //right parentheses
            return result;
        }
    }
}
