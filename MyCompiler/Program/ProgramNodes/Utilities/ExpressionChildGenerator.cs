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
                    ? (IExpressionChild)new BinaryAssignNode(left, right)
                    : new BinaryAssignOperatorNode(left, right, token.Value.Replace("=",""));
            }
            return left;
        }

        private static IExpressionChild ParseLogicalOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseLogicalAnd(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOrOperatorTokenType)
            {
                tokenizer.Pop();
                IExpressionChild right = ParseLogicalAnd(tokenizer);
                left = new BinaryOrOperatorNode(left, right);
            }
            return left;
        }

        private static IExpressionChild ParseLogicalAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseOr(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryAndOperatorTokenType)
            {
                tokenizer.Pop();
                IExpressionChild right = ParseBitwiseOr(tokenizer);
                left = new BinaryAndOperatorNode(left, right);
            }
            return left;
        }
        private static IExpressionChild ParseBitwiseOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseXor(tokenizer);
            while ((tokenizer.PeekTokenType() is BinaryOperatorTokenType) && tokenizer.PeekValue().Equals("|"))
            {
                tokenizer.Pop();
                IExpressionChild right = ParseBitwiseXor(tokenizer);
                left = new BinaryOperatorNode(left, right, "|");
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseXor(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseAnd(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType && tokenizer.PeekValue().Equals("^"))
            {
                tokenizer.Pop();
                IExpressionChild right = ParseBitwiseAnd(tokenizer);
                left = new BinaryOperatorNode(left, right, "^");
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseRelationalEquals(tokenizer);
            while (tokenizer.PeekTokenType() is BinaryOperatorTokenType && tokenizer.PeekValue().Equals("&"))
            {
                tokenizer.Pop();
                IExpressionChild right = ParseRelationalEquals(tokenizer);
                left = new BinaryOperatorNode(left, right, "&");
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
                left = new BinaryRelationalOperatorNode(left, right, token.Value);
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
                left = new BinaryRelationalOperatorNode(left, right, token.Value);
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
                left = new BinaryOperatorNode(left, right, token.Value);
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
                left = new BinaryOperatorNode(left, right, token.Value);
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
                left = new BinaryOperatorNode(left, right, token.Value);
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
                if (token.TokenType is PlusOrMinusTokenType || token.TokenType is BitNegationOperatorTokenType) return new UnaryOperatorNode(right, token.Value);
                if (token.TokenType is UnaryNotOperatorTokenType) return new UnaryNotOperatorNode(right);
                return new UnaryPreOperatorNode(right, token.Value[0].ToString());
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
                return new ConstantNode(token.Value, token.TokenType is IntegerConstantTokenType);
            }
            if (tokenizer.PeekTokenType() is IdentifierTokenType)
            {
                tokenizer.Pop();
                SimpleCToken token = tokenizer.Previous();
                IExpressionChild varExpr = new VariableExpressionNode(token.Value);
                if (tokenizer.PeekTokenType() is LeftBracketTokenType)
                {
                    tokenizer.Pop(); //left bracket
                    IExpressionChild inside = ParseExpression(tokenizer);
                    tokenizer.Pop(); //right bracket
                    varExpr = new BinaryArrayOperatorNode((IVariableExpressionNode)varExpr, inside);
                }
                if (tokenizer.PeekTokenType() is PreOrPostOperatorTokenType)
                {
                    tokenizer.Pop(); //Post operator
                    token = tokenizer.Previous();
                    varExpr = new UnaryPostOperatorNode(varExpr, token.Value[0].ToString());
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
